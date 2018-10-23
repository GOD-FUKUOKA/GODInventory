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


        public static int UpdateProductCost(int productCode, string county = "", int storeId = 0, decimal cost = -1, decimal price = -1, decimal promotePrice = -1, decimal adPrice = -1, decimal salePrice = -1, string warehouse = "")
        {
            int count = 0;
            string sql = "";
            using (var ctx = new GODDbContext())
            {
                String[] cols = { "仕入原価", "通常原単価", "特売原単価", "広告原単価", "売単価" };
                Decimal[] prices = { cost, price, promotePrice, adPrice, salePrice };
                
                if (warehouse.Length > 0)
                {
                    sql = String.Format("UPDATE t_pricelist SET `配送担当`={0} WHERE `自社コード`={1}", warehouse, productCode);
                    count = ctx.Database.ExecuteSqlCommand(sql);
                }

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
    }
}
