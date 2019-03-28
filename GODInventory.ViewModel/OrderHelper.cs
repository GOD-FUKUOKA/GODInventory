using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.ViewModel
{
    public class OrderHelper
    {
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
        public static int Updatetransportfee(int warehouse_id, int transport_id, int shop_id = 0, string unitname="", decimal newFee = -1, string newUnitname = "", string newColumnname = "")
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
                if (unitname.Length > 0)
                {
                    conditions.Add(string.Format(" `unitname`='{0}' ", unitname));
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
    }
}
