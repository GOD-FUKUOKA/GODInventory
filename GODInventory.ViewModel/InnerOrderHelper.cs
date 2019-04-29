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
    public class InnerOrderHelper
    {

        // 
        public static int ChangeOrderCost(int productCode, decimal cost, DateTime startAt, DateTime endAt, string county)
        {
            int count = 0;
            string sql = "";
            using (var ctx = new GODDbContext())
            {
                // UPDATE `god_om2`.`t_innerorders` SET `仕入原価`='12' WHERE `id受注データ`='1';
                // add AND `id受注データ`>0
                // Error Code: 1175. You are using safe update mode and you tried to update a table without a WHERE that uses a KEY column To disable safe mode, toggle the option in Preferences -> SQL Editor and reconnect.
                if (county.Length > 0)
                {
                    string sqlFormat = "UPDATE t_innerorders SET `仕入原価`={4}, `仕入金額`= `実際出荷数量` * `仕入原価`, `粗利金額`=`納品原価金額` - `仕入金額` WHERE `自社コード`={0} AND `発注日`>='{1:yyyy-MM-dd}' AND `発注日`<='{2:yyyy-MM-dd}' AND `県別`='{3}' AND `id受注データ`>0;";

                    sql = String.Format(sqlFormat, productCode, startAt, endAt, county, cost);
                }
                else
                {
                    string sqlFormat = "UPDATE t_innerorders SET `仕入原価`={3}, `仕入金額`= `実際出荷数量` * `仕入原価`, `粗利金額`=`納品原価金額` - `仕入金額` WHERE `自社コード`={0} AND `発注日`>='{1:yyyy-MM-dd}' AND `発注日`<='{2:yyyy-MM-dd}' AND `id受注データ`>0;";

                    sql = String.Format(sqlFormat, productCode, startAt, endAt, cost);
                }
                count = ctx.Database.ExecuteSqlCommand(sql);
            }

            return count;
        }


        public static int UpdateProductCost(int productCode, string area = "", string county = "", int storeId = 0, decimal cost = -1, decimal price = -1, decimal promotePrice = -1, decimal adPrice = -1, decimal salePrice = -1)
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


                    if (storeId > 0)
                    {
                        sql += string.Format(" AND `店番`={0}", storeId);
                    }else if (county.Length > 0)
                    {
                        sql += string.Format(" AND `県別`='{0}'", county);
                    }
                    else if (area.Length > 0)
                    {
                        var pids = ctx.t_shoplist.Where(o => o.地域 == area).Select(o => o.店番).ToList();
                        sql += string.Format(" AND  `店番` in ({0}) ", string.Join(",", pids));
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
        public static int Updatetransportfee(int warehouse_id, int transport_id, int shop_id = 0, int genre_id = 0, int product_id = 0, string area = "", string county="", decimal newFee = -1, string newUnitname = "", string newColumnname = "")
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
                else if (county.Length > 0)
                {
                    var pids = ctx.t_shoplist.Where(o => o.県別 == county).Select(o => o.店番).ToList();
                    conditions.Add(string.Format(" `shop_id` in ({0}) ", string.Join(",",pids)));
                }
                else if (area.Length > 0)
                {
                    var pids = ctx.t_shoplist.Where(o => o.地域 == area).Select(o => o.店番).ToList();
                    conditions.Add(string.Format(" `shop_id` in ({0}) ", string.Join(",", pids)));
                }

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
                    sql = String.Format("UPDATE t_freights SET {0} WHERE {1}",  string.Join(",", sets ), string.Join(" AND ", conditions));
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
        public static int ComputeFreight(t_innerorders order, decimal unitfee = 0, string columnname = null)
        {
            int fee = 0;           

            if (columnname != null)
            {
                string val = GetModelValue(columnname, order);
                if (!string.IsNullOrEmpty(val))
                {
                    fee = Convert.ToInt32( unitfee * Convert.ToInt32(val) );
                }
            }

            return fee;
        }

        public static int ComputeFreight(v_pendingorder order, decimal unitfee = 0, string columnname = null)
        {
            int fee = 0;

            if (columnname != null)
            {
                string val = GetModelValue(columnname, order);
                if (!string.IsNullOrEmpty(val))
                {
                    fee = Convert.ToInt32( unitfee * Convert.ToInt32(val) );
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
                var lastOrder = (from s in ctx.t_innerorders
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
