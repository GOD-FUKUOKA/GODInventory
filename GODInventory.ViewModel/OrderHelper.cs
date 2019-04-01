using GODInventory.MyLinq;
using GODInventory.ViewModel.EDI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.ViewModel
{
    public class OrderHelper
    {
        /// <summary>
        /// 初始化一个订单，根据订单的基本属性，设置订单的其它相关值， 为创建订单做准备。
        /// 如 订单的运费
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool InitializeOrderByXlsxOrder(t_orderdata order, v_shop shop, v_itemprice price) {
            // order 的必填值如下
            //県別	店舗コード	店舗名漢字	自社コード	品名漢字	最小発注単位数量	口数	発注数量	原単価(税抜)	原価金額(税抜)
            //order.商品コード = 0;
            //order.発注数量 = 0;
            //order.品名漢字 = "";
            //order.規格名漢字 = "";
            //order.ＪＡＮコード = 0;
            //order.最小発注単位数量 = 0;
            //order.納品口数 = 0;
            //order.発注数量 = 0;
            //order.原単価_税抜_ = 0;
            //order.売単価_税抜_ = 0;

            // 根据 商品コード 初始化商品信息
            order.商品コード = price.商品コード;
            order.規格名漢字 = price.規格;
            order.ＪＡＮコード = price.JANコード;

            // 设置产品分类
            order.ジャンル = price.ジャンル;

            // 生成订单编号

            // 设置基本值
            //order.税区分 = 1;
            var now = DateTime.Now ;
            order.発注日 = now.Date;
            order.受注日 = now.Date;
            /// TODO customer表
            order.法人コード = 4;
            order.法人名漢字 = "ナフコ";

            order.部門コード = 9;
            order.納品予定日 = now.AddDays(2).Date;
            order.税率 = 0.08;
            if ( shop.納品場所コード>=0)
            {
               
                order.納品場所コード = (short)shop.納品場所コード;
                order.納品場所名漢字 = shop.納品場所名漢字;
                order.納品場所名カナ = shop.納品場所名カナ;
                
            }
            else
            {
                order.納品場所コード = -1;
                order.納品場所名漢字 = "";
                order.納品場所名カナ = "";
            }
            order.発注形態区分 = 10;
            order.発注形態名称漢字 = "補充";
            order.一旦保留 = true;

            // 设置 一些常量
            order.納品先店舗コード = (short)order.店舗コード;
            order.納品先店舗名漢字 = order.店舗名漢字;
            order.税率 = 0.08;
            order.特価区分 = 0;
            order.PB区分 = 0;
            order.原価区分 = 0;
            order.納期回答区分 = 0;
            order.回答納期 = "00000000";
            order.入力区分 = 1;
            order.実際出荷数量 = order.発注数量;
            order.納品口数 = order.口数;


            order.重量 = (int)(Convert.ToDecimal(price.単品重量) * order.発注数量);
            order.単位 = price.単位;
            order.県別 = price.県別;
            
            //order.原単価_税抜_ = (int)selectedItem.原単価;
            order.原単価_税込_ = ((int)(order.原単価_税抜_ * (1 + order.税率) * 100)) * 1.0 / 100;

            order.原価金額_税抜_ = order.実際出荷数量 * order.原単価_税抜_;
            order.原価金額_税込_ = (int)(order.実際出荷数量 * order.原単価_税込_);

            order.納品原価金額 = order.原価金額_税抜_;

            //order.売単価_税抜_ = (int)selectedItem.売単価;
            order.売単価_税込_ = (int)(order.売単価_税抜_ * (1 + order.税率));
            order.税額 = (int)(order.原価金額_税抜_ * order.税率);

            order.仕入原価 = price.仕入原価;
            order.仕入金額 = order.実際出荷数量 * order.仕入原価;
            order.粗利金額 = order.納品原価金額 - order.仕入金額;

            order.発注品名漢字 = order.品名漢字;
            order.発注規格名漢字 = order.規格名漢字;
            order.用度品区分 = 0;
            order.id = String.Format("{0}a{1}", order.店舗コード, order.伝票番号);

            //判断全角半角
            bool isValidName = isValidOrderName(order.発注品名漢字);

            isValidName = isValidOrderName(order.発注規格名漢字);

 
            order.実際配送担当 = price.配送担当;
            order.warehousename = price.warehousename;

            // 社内伝番処理使用缺省配置
            order.社内伝番処理 = price.社内伝番処理;

            
            order.週目 = GetOrderWeekOfYear(order.受注日.Value);

            order.運賃 = ComputeFreight(order, price.fee, price.columnname);

            return true;
        }

        // 
        public static int ChangeOrderCost(int productCode, decimal cost, DateTime startAt, DateTime endAt, string county)
        {
            int count = 0;
            string sql = "";
            using (var ctx = new GODDbContext())
            {
                // UPDATE `god_om2`.`t_orderdata` SET `仕入原価`='12' WHERE `id受注データ`='1';
                // add AND `id受注データ`>0
                // Error Code: 1175. You are using safe update mode and you tried to update a table without a WHERE that uses a KEY column To disable safe mode, toggle the option in Preferences -> SQL Editor and reconnect.
                if (county.Length > 0)
                {
                    string sqlFormat = "UPDATE t_orderdata SET `仕入原価`={4}, `仕入金額`= `実際出荷数量` * `仕入原価`, `粗利金額`=`納品原価金額` - `仕入金額` WHERE `自社コード`={0} AND `発注日`>='{1:yyyy-MM-dd}' AND `発注日`<='{2:yyyy-MM-dd}' AND `県別`='{3}' AND `id受注データ`>0;";

                    sql = String.Format(sqlFormat, productCode, startAt, endAt, county, cost);
                }
                else
                {
                    string sqlFormat = "UPDATE t_orderdata SET `仕入原価`={3}, `仕入金額`= `実際出荷数量` * `仕入原価`, `粗利金額`=`納品原価金額` - `仕入金額` WHERE `自社コード`={0} AND `発注日`>='{1:yyyy-MM-dd}' AND `発注日`<='{2:yyyy-MM-dd}' AND `id受注データ`>0;";

                    sql = String.Format(sqlFormat, productCode, startAt, endAt, cost);
                }
                count = ctx.Database.ExecuteSqlCommand(sql);
            }

            return count;
        }


        public static int UpdateProductCost(int productCode, string county = "", int storeId = 0, decimal cost = -1, decimal price = -1, decimal promotePrice = -1, decimal adPrice = -1, decimal salePrice = -1)
        {
            int count = 0;
            string sql = "";
            using (var ctx = new GODDbContext())
            {
                String[] cols = { "仕入原価", "通常原単価", "特売原単価", "広告原単価", "売単価" };
                Decimal[] prices = { cost, price, promotePrice, adPrice, salePrice };

                //if (warehouse.Length > 0)
                //{
                //    sql = String.Format("UPDATE t_pricelist SET `配送担当`={0} WHERE `自社コード`={1}", warehouse, productCode);
                //    count = ctx.Database.ExecuteSqlCommand(sql);
                //}

                for (int i = 0; i < cols.Length; i++)
                {
                    if (prices.Length < i && prices[i] < 0)
                    {
                        continue;
                    }
                    sql = String.Format("UPDATE t_pricelist SET `{0}`={1} WHERE `自社コード`={2}", cols[i], prices[i], productCode);

                    if (county.Length > 0)
                    {
                        sql += string.Format(" AND `県別`='{0}'", county);
                    }
                    if (storeId > 0)
                    {
                        sql += string.Format(" AND `店番`={0}", storeId);
                    }
                    count = ctx.Database.ExecuteSqlCommand(sql);
                }
            }

            return count;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse_id"></param>
        /// <param name="transport_id"></param>
        /// <param name="shop_id"></param>
        /// <param name="unitname"></param>
        /// <param name="newFee"> -1 表示不更新</param>
        /// <param name="newUnitname"></param>
        /// <param name="newColumnname"></param>
        /// <returns></returns>
        public static int Updatetransportfee(int warehouse_id, int transport_id, int shop_id = 0, int genre_id = 0, int product_id = 0, string unitname = "", decimal newFee = -1, string newUnitname = "", string newColumnname = "")
        {
            int count = 0;
            string sql = "UPDATE t_freights SET ";
            using (var ctx = new GODDbContext())
            {
                List<string> sets = new List<string>();
                List<string> conditions = new List<string>();
                if (newFee >= 0)
                {
                    sets.Add(string.Format(" `fee`={0} ", newFee));
                }
                if (newUnitname.Length > 0)
                {
                    sets.Add(string.Format(" `unitname`='{0}' ", newUnitname));
                }
                if (newColumnname.Length > 0)
                {
                    sets.Add(string.Format(" `columnname`='{0}' ", newColumnname));
                }

                if (warehouse_id > 0) {
                    conditions.Add(string.Format(" `warehouse_id`={0} ", warehouse_id));
                }
                if (transport_id > 0)
                {
                    conditions.Add(string.Format(" `transport_id`={0} ", transport_id));
                }
                if (shop_id > 0)
                {
                    conditions.Add(string.Format(" `shop_id`={0} ", shop_id));
                }
                //if (unitname.Length > 0)
                //{
                //    conditions.Add(string.Format(" `unitname`='{0}' ", unitname));
                //}
                if (genre_id > 0) 
                {
                    var pids = ctx.t_itemlist.Where(o => o.ジャンル == genre_id).Select(o => o.自社コード).ToList();
                    if (pids.Count > 0) {
                        conditions.Add(string.Format(" `自社コード` in ({0}) ", string.Join(",", pids)));
                    }
                }
                if (product_id > 0)
                {
                    conditions.Add(string.Format(" `自社コード`={0} ", product_id));
                }

                if (sets.Count > 0 && conditions.Count> 0)
                {

                    sql = String.Format("UPDATE t_freights SET  {0} WHERE {1}",  string.Join(",", sets ), string.Join(" AND ", conditions));
                    count = ctx.Database.ExecuteSqlCommand(sql);
                }
            }
            return count;
        }




        /// <summary>
        /// 设置类中的属性值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SetModelValue(string FieldName, string Value, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object v = Convert.ChangeType(Value, Ts.GetProperty(FieldName).PropertyType);
                Ts.GetProperty(FieldName).SetValue(obj, v, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 全角半角检查
        /// </summary>
        /// <param name="str"> 発注品名漢字/発注規格名漢字 必须为全角字符</param>
        /// <returns></returns>
        private static bool isValidOrderName(string str)
        {
            // 
            return !String.IsNullOrEmpty(str) && EDITxtHandler.IsAllQuanjiaoJapan(str);
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="itemprice"> 如果提供itemprice，使用 itemprice中的 fee 计算</param>
        /// <returns></returns>
        public static decimal ComputeFreight(t_orderdata order, decimal unitfee = 0, string columnname = null)
        {
            decimal fee = 0;           

            if (columnname != null)
            {
                string val = GetModelValue(columnname, order);
                if (!string.IsNullOrEmpty(val))
                {
                    fee = unitfee * Convert.ToInt32(val);
                }
            }

            return fee;
        }
         
        public static decimal ComputeFreight(v_pendingorder order, decimal unitfee = 0, string columnname = null)
        {
            decimal fee = 0;

            if (columnname != null)
            {
                string val = GetModelValue(columnname, order);
                if (!string.IsNullOrEmpty(val))
                {
                    fee = unitfee * Convert.ToInt32(val);
                }
            }

            return fee;
        }

        public static int GetOrderWeekOfYear(DateTime time)
        {
            var newTime = time.AddDays(6 - CustomPropertyHelper.GetOrderWeekEndDay());
            //CultureInfo ci = new CultureInfo("zh-CN");
            System.Globalization.Calendar cal = CultureInfo.CurrentCulture.Calendar;
            CalendarWeekRule cwr = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
            DayOfWeek dow = DayOfWeek.Sunday;
            int week = cal.GetWeekOfYear(newTime, cwr, dow);
            return Convert.ToInt32(string.Format("{0:D4}{1:D2}", newTime.Year, week));
        }

        /// <summary>
        /// 获取类中的属性值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetModelValue(string FieldName, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(FieldName).GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 基于店铺id生成传真订单编号
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public static int GenerateOrderNumber(int storeId)
        {
            int max = 1000000; //传真订单 6位，小于 1000000
            int lastOrderNumber = 0;
            using (var ctx = new GODDbContext())
            {
                var lastOrder = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)storeId) && s.伝票番号 < max
                                  orderby s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (lastOrder != null)
                {
                    lastOrderNumber = lastOrder.伝票番号;
                }
            }

            return  GetNextOrderNumberByLastOrderNumber( lastOrderNumber);

        }

        public static int GetNextOrderNumberByLastOrderNumber(int lastOrderNumber)
        {
            int position = lastOrderNumber / 10;  // remove last check number
            position %= 99999;              // max position is 99999,

            position += 1;

            return (position * 10) + (position % 7);

        }

    }
}
