using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GODInventory;
using GODInventory.MyLinq;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using GODInventory.ViewModel.EDI;
using System.IO;
using System.Diagnostics;

namespace GODInventory.ViewModel
{
    public class OrderSqlHelper
    {

        //sqlStr = "SELECT t_orderdata.`出荷日`,t_orderdata.`納品日`,t_orderdata.`受注日`,t_orderdata.`キャンセル`,t_orderdata.`一旦保留`," _
        //& " t_orderdata.`伝票番号`,t_orderdata.`社内伝番`,t_orderdata.`行数`,t_orderdata.`最大行数`,t_orderdata.`口数`,t_orderdata.`発注数量`," _
        //& " t_orderdata.`実際配送担当`,t_orderdata.`備考`,t_orderdata.`店舗コード`,t_orderdata.`店舗名漢字`,t_orderdata.`id受注データ`,`発注形態名称漢字`," _
        //& " t_orderdata.`原単価(税抜)`,t_orderdata.`重量`,'' " _
        //& " FROM t_orderdata" _
        //& " WHERE t_orderdata.`店舗コード` = " & Cells(2, 3).Value & " AND t_orderdata.`受注日` BETWEEN DATE_SUB(NOW(),INTERVAL 60 DAY) AND now()" _
        //& " ORDER BY t_orderdata.`受注日` DESC,t_orderdata.`社内伝番` ASC,t_orderdata.`行数` ASC,t_orderdata.`伝票番号` ASC"
        //出荷日納品日受注日, 店舗コード,店名, 社内伝番, 伝票番号,品名漢字， 規格名漢字， 発注数量，実際配送担当， 県別，
        //原単価(税抜)，， 原価金額(税抜)， 発注形態名称漢字， キャンセル， 一旦保留， 受領， ダブリ
        //public static IQueryable<t_orderdata> NewOrderQuery(EntityDataSource entityDataSource1)
        //{
        //    var a = entityDataSource1.EntitySets["t_orderdatas"];
        //    var q = from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
        //            where o.Status == OrderStatus.New
        //            orderby o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号

        //            select o;
        //    return q;
        //}
        
        // file 受注管理★受注作業用/m4
        // SELECT t_orderdata.`出荷日`,t_orderdata.`納品日`,t_orderdata.`受注日`,t_orderdata.`店舗コード`," _
        //&" t_shoplist.`店名`,t_orderdata.`伝票番号`,t_orderdata.`口数`,t_orderdata.`ジャンル`,t_orderdata.`品名漢字`,t_orderdata.`規格名漢字`," _
        //& " t_orderdata.`発注数量`,t_orderdata.`実際配送担当`,t_shoplist.`県別`," _
        //& " t_orderdata.`発注形態名称漢字`,t_orderdata.`キャンセル`,t_orderdata.`ダブリ`,t_orderdata.`一旦保留`" _
        //& " FROM t_orderdata" _
        //& " INNER JOIN t_shoplist ON t_orderdata.`店舗コード` = t_shoplist.`店番`" _
        //& " WHERE t_orderdata.`キャンセル` = 'no' AND t_orderdata.`納品日` IS NULL" _
        //& " ORDER BY t_orderdata.`実際配送担当` ASC,t_shoplist.`県別` ASC,t_orderdata.`店舗コード` ASC," _
        //& " t_orderdata.`ＪＡＮコード` ASC,t_orderdata.`受注日` ASC,t_orderdata.`伝票番号` ASC"

        public static IQueryable PendingOrderSql(EntityDataSource entityDataSource1)
        {
            var q = from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                    join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
                    where o.配送担当受信時刻 == null
                    orderby o.実際配送担当, s.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                    select new
                    {
                        o.出荷日,
                        o.納品日,
                        o.受注日,
                        o.店舗コード,
                        s.店名,
                        o.伝票番号,
                        o.口数,
                        o.品名漢字,
                        o.規格名漢字,
                        o.発注数量,
                        o.実際配送担当,
                        s.県別,
                        o.キャンセル,
                        o.ダブリ,
                        o.一旦保留
                    };
            return q;
        }

        public static IQueryable<t_orderdata> PendingOrderQuery(EntityDataSource entityDataSource1)
        {
            var a = entityDataSource1.EntitySets["t_orderdatas"];
            var q = from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                    where o.Status == OrderStatus.Pending
                    select o;
            return q;
        }

        public static IQueryable<v_pendingorder> ECWithoutCodeOrderQuery(EntityDataSource entityDataSource1, int genreId)
        {
            var a = entityDataSource1.EntitySets["t_orderdatas"];
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.NotifyShipper && o.ジャンル == genreId && o.社内伝番 == 0 && o.実際配送担当 == "丸健"
                     orderby o.店舗コード
                     select new v_pendingorder
                      {
                          id受注データ = o.id受注データ,
                          出荷日 = o.出荷日,
                          納品日 = o.納品日,
                          受注日 = o.受注日,
                          店舗名漢字 = o.店舗名漢字,
                          店舗コード = o.店舗コード,
                          納品場所名漢字 = o.納品場所名漢字,
                          伝票番号 = o.伝票番号,
                          自社コード = o.自社コード,
                          口数 = o.口数,
                          納品口数 = o.納品口数,
                          重量 = o.重量,
                          ジャンル = o.ジャンル,
                          品名漢字 = o.品名漢字,
                          規格名漢字 = o.規格名漢字,
                          発注数量 = o.発注数量,
                          最小発注単位数量 = o.最小発注単位数量,
                          実際出荷数量 = o.実際出荷数量,
                          実際配送担当 = o.実際配送担当,
                          県別 = o.県別,
                          発注形態名称漢字 = o.発注形態名称漢字,
                          キャンセル = o.キャンセル,
                          ダブリ = o.ダブリ,
                          一旦保留 = o.一旦保留,
                          法人名漢字 = o.法人名漢字,
                          備考 = o.備考,
                          納品指示 = o.納品指示,
                          社内伝番UnSaved = 0
                      });
            return q;
        }

        public static IQueryable<v_pendingorder> PendingOrderQueryEx(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     //join t_itemlist i in entityDataSource1.EntitySets["t_itemlist"] on new { jid = o.ＪＡＮコード, sid = o.実際配送担当 } equals new { jid = i.JANコード, sid = i.配送担当 }
                     //join t_itemlist i in entityDataSource1.EntitySets["t_itemlist"] on o.自社コード equals  i.自社コード
                     join t_stockstate k in entityDataSource1.EntitySets["t_stockstate"] on new { pid = o.自社コード, sid = o.実際配送担当 } equals new { pid = k.自社コード, sid = k.ShipperName } into t_join
                     from x in t_join.DefaultIfEmpty()
                     join t_genre g in entityDataSource1.EntitySets["t_genre"] on o.ジャンル equals g.idジャンル
                     where o.Status == OrderStatus.Pending
                     orderby o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select new v_pendingorder
                     {
                         id受注データ = o.id受注データ,
                         出荷日 = o.出荷日,
                         納品日 = o.納品日,
                         受注日 = o.受注日,
                         店舗名漢字 = o.店舗名漢字,
                         店舗コード = o.店舗コード,
                         納品場所名漢字 = o.納品場所名漢字,
                         伝票番号 = o.伝票番号,
                         自社コード = o.自社コード,
                         口数 = o.口数,
                         納品口数 = o.納品口数,
                         重量 = o.重量,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
                         最小発注単位数量 = o.最小発注単位数量,
                         実際出荷数量 = o.実際出荷数量,
                         実際配送担当 = o.実際配送担当,
                         県別 = o.県別,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
                         一旦保留 = o.一旦保留,
                         在庫状態 = "unkown",
                         法人名漢字 = o.法人名漢字,
                         備考 = o.備考,
                         納品指示 = o.納品指示,
                         訂正理由区分 = o.訂正理由区分,
                         在庫数 = x.在庫数,
                         GenreName = g.ジャンル名
                     });
            return q;

        }

        //sqlStr = "SELECT t_orderdata.`出荷日`,t_orderdata.`納品日`,t_orderdata.`受注日`,t_orderdata.`キャンセル`,t_orderdata.`一旦保留`," _
        //& " t_orderdata.`伝票番号`,t_orderdata.`社内伝番`,t_orderdata.`行数`,t_orderdata.`最大行数`,t_orderdata.`口数`,t_orderdata.`発注数量`," _
        //& " t_orderdata.`実際配送担当`,t_orderdata.`備考`,t_orderdata.`店舗コード`,t_orderdata.`店舗名漢字`,t_orderdata.`id受注データ`,`発注形態名称漢字`," _
        //& " t_orderdata.`原単価(税抜)`,t_orderdata.`重量`,'' " _
        //& " FROM t_orderdata" _
        //& " WHERE t_orderdata.`店舗コード` = " & Cells(2, 3).Value & " AND t_orderdata.`受注日` BETWEEN DATE_SUB(NOW(),INTERVAL 60 DAY) AND now()" _
        //& " ORDER BY t_orderdata.`受注日` DESC,t_orderdata.`社内伝番` ASC,t_orderdata.`行数` ASC,t_orderdata.`伝票番号` ASC"


        public static IQueryable<v_pendingorder> WaitToShipOrderSql(EntityDataSource entityDataSource1)
        {
            //sqlStr = "SELECT t_orderdata.`出荷日`,t_orderdata.`納品日`,t_orderdata.`受注日`,t_orderdata.`店舗コード`," _
            //& " t_shoplist.`店名`,t_orderdata.`伝票番号`,t_orderdata.`口数`,t_orderdata.`ジャンル`,t_orderdata.`品名漢字`,t_orderdata.`規格名漢字`," _
            //& " t_orderdata.`発注数量`,t_orderdata.`実際配送担当`,t_shoplist.`県別`," _
            //& " t_orderdata.`発注形態名称漢字`,t_orderdata.`キャンセル`,t_orderdata.`ダブリ`,t_orderdata.`一旦保留`" _
            //& " FROM t_orderdata" _
            //& " INNER JOIN t_shoplist ON t_orderdata.`店舗コード` = t_shoplist.`店番`" _
            //& " WHERE t_orderdata.`キャンセル` = 'no' AND t_orderdata.`納品日` IS NULL" _
            //& " ORDER BY t_orderdata.`実際配送担当` ASC,t_shoplist.`県別` ASC,t_orderdata.`店舗コード` ASC," _
            //& " t_orderdata.`ＪＡＮコード` ASC,t_orderdata.`受注日` ASC,t_orderdata.`伝票番号` ASC"

            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     //join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
                     join t_genre g in entityDataSource1.EntitySets["t_genre"] on o.ジャンル equals g.idジャンル
                     //where o.配送担当受信  && o.出荷日 == null
                     where o.Status == OrderStatus.WaitToShip
                     orderby o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select new v_pendingorder
                     {
                         id受注データ = o.id受注データ,
                         出荷日 = o.出荷日,
                         納品日 = o.納品日,
                         受注日 = o.受注日,
                         店舗コード = o.店舗コード,
                         店名 = o.店舗名漢字,
                         納品場所名漢字 = o.納品場所名漢字,
                         伝票番号 = o.伝票番号,
                         社内伝番 = o.社内伝番,
                         納品口数 = o.納品口数,
                         口数 = o.口数,
                         重量 = o.重量,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
                         実際出荷数量 = o.実際出荷数量,
                         実際配送担当 = o.実際配送担当,
                         県別 = o.県別,
                         原単価_税抜_ = o.原単価_税抜_,
                         原価金額_税抜_ = o.原価金額_税抜_,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
                         行数 = o.行数,
                         最大行数 = o.最大行数,
                         一旦保留 = o.一旦保留,
                         納品指示 = o.納品指示,
                         ShipNO = o.ShipNO,
                         GenreName = g.ジャンル名

                     });
            return q;

        }
        public static IQueryable<v_pendingorder> ShippingOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     join t_genre g in entityDataSource1.EntitySets["t_genre"] on o.ジャンル equals g.idジャンル
                     where o.Status == OrderStatus.PendingShipment
                     //where o.出荷日 != null && o.ASN管理連番==0 && !o.受領確認 
                     orderby o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select new v_pendingorder
                     {
                         id受注データ = o.id受注データ,
                         出荷日 = o.出荷日,
                         納品日 = o.納品日,
                         受注日 = o.受注日,
                         店舗コード = o.店舗コード,
                         店名 = o.店舗名漢字,
                         納品場所名漢字 = o.納品場所名漢字,
                         伝票番号 = o.伝票番号,
                         社内伝番 = o.社内伝番,
                         口数 = o.口数,
                         納品口数 = o.納品口数,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
                         ＪＡＮコード = o.ＪＡＮコード,
                         商品コード = o.商品コード,
                         実際出荷数量 = o.実際出荷数量,
                         原単価_税抜_ = o.原単価_税抜_,
                         実際配送担当 = o.実際配送担当,
                         県別 = o.県別,
                         受領 = o.受領,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
                         ShipNO = o.ShipNO,
                         GenreName = g.ジャンル名,
                         一旦保留 = o.一旦保留
                     });
            return q;
        }

        public static IQueryable<t_orderdata> ASNOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.ASN 
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                     );
            return q;
        }
        public static IQueryable<t_orderdata> ShippedOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.Shipped
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                     );
            return q;
        }

        public static List<t_orderdata> CanceledOrderSql(EntityDataSource entityDataSource1)
        {
            //由于entityDataSource1 缓存问题，所以使用新连接
            List<t_orderdata> list = null;
            using (GODDbContext ctx = new GODDbContext())
            {

                list = (from t_orderdata o in ctx.t_orderdata
                     where o.Status == OrderStatus.Cancelled
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                         ).ToList();
            }
            return list;
        }

        public static IQueryable<t_orderdata> ReceivedOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.Received
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                     );
            return q;
        }

        public static List<v_pendingorder> ASNOrderDataListByMid(EntityDataSource entityDataSource1, long mid)
        {

            var orders = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                          join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
                          where o.ASN管理連番 == mid
                          select new v_pendingorder {
                              ASN管理連番 = o.ASN管理連番,
                              出荷No = o.出荷No,
                              店舗コード = o.店舗コード,
                              伝票番号 = o.伝票番号,
                              納品場所名カナ = o.納品場所名カナ,
                              納品場所名漢字 = o.納品場所名漢字,
                              出荷業務仕入先コード = o.出荷業務仕入先コード,
                              発注形態区分 = o.発注形態区分,
                              納品日 = o.納品日,
                              ＪＡＮコード = o.ＪＡＮコード,
                              商品コード = o.商品コード,
                              品名漢字 = o.品名漢字,
                              規格名漢字 = o.規格名漢字,
                              実際出荷数量 = o.実際出荷数量,
                              原単価_税抜_ = o.原単価_税抜_,
                              口数 = o.口数,
                              オプション使用欄 = o.オプション使用欄,
                              店舗名漢字 = o.店舗名漢字,
                              直送区分 = "通常",
                              店名 = s.店名,
                              住所 = s.住所,
                              電話番号 = s.電話番号
                          }).ToList();
            return orders;
        }

        public static List<v_pendingorder> ASNOrderDataListByShipNo(EntityDataSource entityDataSource1, string shipNo)
        {

            var orders = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                          join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
                          where o.ShipNO == shipNo
                          select new v_pendingorder
                          {
                              id受注データ = o.id受注データ,
                              ASN管理連番 = o.ASN管理連番,
                              出荷No = o.出荷No,
                              店舗コード = o.店舗コード,
                              伝票番号 = o.伝票番号,
                              納品場所名カナ = o.納品場所名カナ,
                              納品場所名漢字 = o.納品場所名漢字,
                              出荷業務仕入先コード = o.出荷業務仕入先コード,
                              発注形態区分 = o.発注形態区分,
                              納品日 = o.納品日,
                              ＪＡＮコード = o.ＪＡＮコード,
                              商品コード = o.商品コード,
                              品名漢字 = o.発注品名漢字,
                              規格名漢字 = o.発注規格名漢字,
                              実際出荷数量 = o.実際出荷数量,
                              原単価_税抜_ = o.原単価_税抜_,
                              口数 = o.口数,
                              オプション使用欄 = o.オプション使用欄,
                              店舗名漢字 = o.店舗名漢字,
                              直送区分 = "通常",
                              店名 = s.店名,
                              住所 = s.住所,
                              電話番号 = s.電話番号
                          }).ToList();
            return orders;
        }

        public static IBindingList ASNEdiDataList(EntityDataSource entityDataSource1)
        {
            var q = (from t_edidata o in entityDataSource1.EntitySets["t_edidata"]
                     where !o.is_sent
                     orderby o.Id descending
                     select o);
            return entityDataSource1.CreateView(q); ;
        }
 
        public static int ShippedOrderCount(EntityDataSource entityDataSource1) {
            int  count = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.出荷日 != null && !o.受領確認
                     select o
                     ).Count();
            return count;

        }

        public static int ASNCountByStore(short company_code, int store_code) {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                var date = DateTime.Now.AddMonths(-6);
                count = (from t_orderdata o in ctx.t_orderdata
                             where o.ASN管理連番 > 0 && o.店舗コード == store_code && o.法人コード == company_code && o.発注日 > date
                             group o by o.ASN管理連番 into g
                             select g
                     ).Count();
            }

            return count;
        }

        public static int ASNCountByDate(EntityDataSource entityDataSource1, DateTime date)
        {
            //int count = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
            //             where o.出荷日 != null && o.受領確認
            //             select o
            //         ).Count();
            return 0;

        }
        public static int CancelOrders(List<v_pendingorder> orders)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                //order.キャンセル = "yes";
                //order.キャンセル時刻 = DateTime.Now;
                //order.Status = OrderStatus.Cancelled;
                //order.備考 = "キャンセル";
                var orderIds = orders.Select(o => o.id受注データ).ToList();
                MySqlParameter[] parameters = { new MySqlParameter("@p1", "yes"), new MySqlParameter("@p2", DateTime.Now), new MySqlParameter("@p3", ((int)OrderStatus.Cancelled)) };
                string sql = String.Format("UPDATE t_orderdata SET `備考`='キャンセル',`キャンセル`=@p1, `キャンセル時刻`=@p2 ,`Status`=@p3 WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);

            }
            return count;
        }
        public static int SendOrderToShipper(List<v_pendingorder> orders)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                var customer = ctx.t_customers.First();
                var orderIds = orders.Select(o => o.id受注データ).ToList();
                var warehouseList = ctx.t_warehouses.ToList();
                MySqlParameter[] parameters = { new MySqlParameter("@p1", true), new MySqlParameter("@p2", DateTime.Now), new MySqlParameter("@p3", ((int)OrderStatus.NotifyShipper)) };
                string sql = String.Format("UPDATE t_orderdata SET `一旦保留`=0,`配送担当受信`=@p1, `配送担当受信時刻`=@p2 ,`Status`=@p3 WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);

                List<t_stockrec> changes = new List<t_stockrec>();
                foreach (var order in orders)
                {
                    var warehouse = warehouseList.Find(o => o.ShipperName == order.実際配送担当);
                    // add stockrec
                    var genreId = order.ジャンル;
                    var date = DateTime.Now;
                    string stockNum = BuildStockNum(ctx, genreId, warehouse.ShortName, date);
                    var s = new t_stockrec();
                    s.元 = warehouse.FullName;
                    s.先 = customer.FullName;
                    s.数量 = -order.実際出荷数量;
                    s.自社コード = order.自社コード;
                    s.日付 = date;
                    s.区分 = StockIoEnum.出庫.ToString();
                    s.状態 = StockIoProgressEnum.完了.ToString();
                    s.事由 = StockIoClueEnum.EDI出荷.ToString();
                    s.納品書番号 = stockNum;
                    s.客 = customer.FullName;
                    s.OrderId = order.id受注データ;
                    changes.Add(s);                      
                }
                ctx.t_stockrec.AddRange(changes);
                ctx.SaveChanges();
                UpdateStockState(ctx, changes);
            }
            return count;
        }

        // 配车及日期确认
        public static int ShippingInfoConfirm(List<int> orderIds, DateTime ShippedAtDate, DateTime ReceivedAtDate, string shipNO)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                MySqlParameter[] parameters = { new MySqlParameter("@p1", ShippedAtDate), new MySqlParameter("@p2", ReceivedAtDate), new MySqlParameter("@p3", ((int)OrderStatus.PendingShipment)), new MySqlParameter("@p4",  shipNO) };
                string sql = String.Format("UPDATE t_orderdata SET `出荷日`=@p1, `納品日`=@p2,`Status`=@p3, `ShipNO`=@p4  WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);                
                ctx.SaveChanges();
            }
            return count;
        
        }

        // 取消配车及日期确认
        public static int UnShippingInfoConfirm(List<int> orderIds)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                MySqlParameter[] parameters = { };
                string sql = String.Format("UPDATE t_orderdata SET `出荷日`=NULL, `納品日`=NULL,`Status`={1}, `ShipNO`=NULL  WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()), (int)OrderStatus.WaitToShip);
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);
                ctx.SaveChanges();
            }
            return count;

        }

        public static int UpdateOrderStatusShipped(List<string> shipNOs)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                //var orderList = (from t_orderdata o in ctx.t_orderdata
                //                 where orderIds.Contains(o.id受注データ)
                //                 select o).ToList();

                string sql = string.Format("UPDATE t_orderdata SET `Status`={1}  WHERE `shipNO` in ({0})", String.Join(",", shipNOs.Select(s => "'" + s + "'").ToArray()), (int)OrderStatus.Shipped);
                count = ctx.Database.ExecuteSqlCommand(sql);
                //Debug.Assert(count == orderList.Count);
                //var order = orderList.First();
                //if (order != null) {
                //    var edidata = (from o in ctx.t_edidata
                //                   where o.管理連番 == order.ASN管理連番
                //                   select o).First();
                //    edidata.is_printed = true;
                //    edidata.printed_at = DateTime.Now;
                //    ctx.SaveChanges();
                //}
            }
            return count;
        }

        public static int FinishOrders(List<int> orderIds)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                MySqlParameter[] parameters = { new MySqlParameter("@p3", ((int)OrderStatus.Completed)) };
                string sql = String.Format("UPDATE t_orderdata SET `受領確認`=1, `Status`=@p3  WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);
                ctx.SaveChanges();
            }
            return count;

        }

        public static int LockOrdersByShipNO(string shipNO)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                string sql = "UPDATE t_orderdata SET `Status`={2}  WHERE `ShipNO` = ({0}) && `Status`={1}";
                count = ctx.Database.ExecuteSqlCommand(sql, shipNO, OrderStatus.PendingShipment, OrderStatus.Locked);
                ctx.SaveChanges();
            }
            return count;
        }
        public static int UnlockOrdersByShipNO(string shipNO)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                string sql = "UPDATE t_orderdata SET `Status`={2}  WHERE `ShipNO` = ({0}) && `Status`={1}";
                count = ctx.Database.ExecuteSqlCommand(sql, shipNO, OrderStatus.Locked, OrderStatus.PendingShipment);
                ctx.SaveChanges();
            }
            return count;
        }

        public static int GenerateASN(List<string> shipNOs) {
            
            using (var ctx = new GODDbContext())
            {
                // get 受注管理連番 by shipNos

                var orders = (from t_orderdata o in ctx.t_orderdata
                              where shipNOs.Contains(o.ShipNO)                             
                              select o).ToList();

                // generate ASN管理連番, 出荷No
                UpdateOrderChuHeNO(ctx, orders);
            }
            return 0;
        }

        public static void UpdateOrderChuHeNO(GODDbContext ctx, List<t_orderdata> orders)
        {
            var grouped_orders = orders.GroupBy(o => new { o.法人コード, o.店舗コード, o.ShipNO, o.納品場所コード }, o => o);
            foreach (var gos in grouped_orders)
            {
                var oids = gos.Select(o => o.id受注データ);
                long chuhe_no = EDITxtHandler.GenerateEDIShipNO(ctx, gos.First());
                // 不能加入状态条件， 取消的订单也需要生成 出荷NO
                var sql1 = String.Format("UPDATE t_orderdata SET  `出荷No`={1}, `Status`={2}  WHERE  `id受注データ` in ({0}) ", String.Join(",", oids.ToArray()), chuhe_no, (int)OrderStatus.ASN);
                ctx.Database.ExecuteSqlCommand(sql1);
            }

        }

        // 返回 管理连番
        public static long GenerateASN2(GODDbContext ctx, List<string> shipNOs)
        {

            var now = DateTime.Now;

            // generate ASN管理連番
            long mid = EDITxtHandler.GenerateMID(ctx);
            // 无需 条件OrderStatus.ASN, 取消的订单也要生成ASN
            var sql1 = String.Format("UPDATE t_orderdata SET `ASN管理連番`={1}  WHERE `ShipNO` in ({0}) ", String.Join(",", shipNOs.Select(s => "'" + s + "'").ToArray()), mid);
            var path = EDITxtHandler.BuildASNFilePath(mid);

            ctx.Database.ExecuteSqlCommand(sql1);

            var orders = (from t_orderdata o in ctx.t_orderdata
                            where shipNOs.Contains(o.ShipNO)
                            orderby o.出荷No
                            select o
                            ).ToList(); 

            ASNHeadModel asnhead = EDITxtHandler.GenerateASNTxt(path, orders);
            

            string sql = asnhead.ToRawSql();

            ctx.Database.ExecuteSqlCommand(sql);
            return mid;

        }


        private static string BuildStockNum(GODDbContext ctx, int genre_id, string warehouseName, DateTime selectedDate)
        {

            var startAt = selectedDate.Date;
            var endAt = startAt.AddDays(1).Date;

            var results = from s in ctx.t_stockrec
                          where s.日付 >= startAt && s.日付 < endAt
                          group s by s.納品書番号 into g
                          select g;
            int count = results.Count();

            string stock_no = String.Format(warehouseName + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

            return stock_no;
        }


        public static IQueryable<t_stockrec> stockQuery(EntityDataSource entityDataSource1)
        {
            var a = entityDataSource1.EntitySets["t_stockrec"];
            var q = from t_stockrec o in entityDataSource1.EntitySets["t_stockrec"]
                    where o.id >0
                    select o;
            return q;
        }

        public static List<t_itemlist> ASNstockrecDataListByMid(EntityDataSource entityDataSource1, short? mid)
        {

            //var orders = (from t_itemlist o in entityDataSource1.EntitySets["t_orderdata"]
            //              join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
            //              where o.ASN管理連番 == mid
            //              select new v_pendingorder
            //              {
            //                  ASN管理連番 = o.ASN管理連番,
            //                  出荷No = o.出荷No,  
            //                  店舗コード = o.店舗コード,
            //                  伝票番号 = o.伝票番号,
            //                  納品場所名カナ = o.納品場所名カナ,
            //                  納品場所名漢字 = o.納品場所名漢字,
            //                  出荷業務仕入先コード = o.出荷業務仕入先コード,
            //                  発注形態区分 = o.発注形態区分,
            //                  納品日 = o.納品日,
            //                  ＪＡＮコード = o.ＪＡＮコード,
            //                  商品コード = o.商品コード,
            //                  品名漢字 = o.品名漢字,
            //                  規格名漢字 = o.規格名漢字,
            //                  実際出荷数量 = o.実際出荷数量,
            //                  原単価_税抜_ = o.原単価_税抜_,
            //                  口数 = o.口数,
            //                  店舗名漢字 = o.店舗名漢字,
            //                  直送区分 = "通常",
            //                  店名 = s.店名,
            //                  住所 = s.住所,
            //                  電話番号 = s.電話番号
            //              }).ToList();
           return null;
        }


        public static int UpdateStockState(GODDbContext ctx, List<t_stockrec> stockrecs)
        {
            int count = 0;

            var warehouseList = ctx.t_warehouses.ToList();
            t_warehouses warehouse;

            foreach (var rec in stockrecs)
            {
                var pid = rec.自社コード;
                if (rec.区分 == StockIoEnum.出庫.ToString())
                {
                    warehouse = warehouseList.First(o => o.FullName == rec.元);
                }
                else {
                    warehouse = warehouseList.First(o => o.FullName == rec.先);                                
                }
                

                    //SELECT sum() FROM god_inventory.t_stockrec where `区分`='入庫' and `自社コード`=100234 and `状態`="完了";
                    //SELECT * FROM god_inventory.t_stockrec where `区分`='出庫' and `自社コード`=100234 and `状態`="完了";
                   //var income = (from s in ctx.t_stockrec
                   //  where s.区分 == "入庫" && s.自社コード == pid && s.状態 == "完了"
                   //  select s.数量).Sum();
                   //var outcome = (from s in ctx.t_stockrec
                   //               where s.区分 == "出庫" && s.自社コード == pid && s.状態 == "完了"
                   //               select s.数量).Sum();
                   // income/outcome may be null
                   //income = Convert.ToInt32(income);
                   //outcome = Convert.ToInt32(outcome);
                   var nullableQty = (from s in ctx.t_stockrec
                              where s.自社コード == pid && s.状態 == "完了" &&  ((s.先 ==warehouse.FullName && s.区分 == "入庫") || (s.元 ==warehouse.FullName && s.区分 == "出庫") )
                                  select s.数量).Sum();
                   var qty = Convert.ToInt32(nullableQty);

                  

                   var stockstate = ctx.t_stockstate.Find(pid, warehouse.Id);

                   if (stockstate != null)
                   {
                       stockstate.在庫数 = qty;
                       stockstate.ShipperName = warehouse.ShipperName;
                   }
                   else {
                       stockstate = new t_stockstate();
                       stockstate.自社コード = pid;
                       stockstate.WarehouseID = warehouse.Id;
                       stockstate.ShipperName = warehouse.ShipperName;
                       stockstate.在庫数 = qty;

                       ctx.t_stockstate.Add(stockstate);
                   }
                   if (qty > 0)
                   {
                       stockstate.在庫状態 = "あり";
                   }
                   else
                   {

                       stockstate.在庫状態 = "なし";
                   } 
                ctx.SaveChanges();
                   
            }
            
            
            return count;

        }
        public static int NotifyShipper(GODDbContext ctx, List<v_pendingorder> pendingOrders, string shipperName)
        {
            var orderIds = pendingOrders.Select(order => order.id受注データ).ToList();
            List<t_maruken_trans> trans = new List<t_maruken_trans>();

            string sql = "SELECT MAX(t_orderdata.`社内伝番`) FROM t_orderdata";
            int max = Convert.ToInt32(ctx.Database.SqlQuery<int?>(sql).FirstOrDefault());
            //max = Convert.ToInt32(max);
            //社内传番应该为8位，我们现在排到了10009837
            if (max < 10002000)
            {
                max += 10002000;
            }

            int count = 0;

            var orders = (from t_orderdata o in ctx.t_orderdata
                where orderIds.Contains( o.id受注データ )
                              select o).ToList();
            //二次制品订单
            //where o.Status == OrderStatus.NotifyShipper && o.ジャンル == genreId && o.社内伝番 == 0 && o.実際配送担当 == "丸健"

            var groupedOrders = orders.Where(o => (o.実際配送担当 == "丸健" && o.ジャンル == 1003)).GroupBy(o => new { o.店舗コード, o.納品場所コード });

            int i = 0;
            foreach (var gos in groupedOrders)
            {
                i++;
                int j = 0;
                foreach (var o in gos)
                {
                    j++;
                    o.社内伝番 = max + i;
                    o.行数 = Convert.ToInt16(j);
                    o.最大行数 = Convert.ToInt16(gos.Count());
                }
                //SELECT  min(`id受注データ`), min(`受注日`), min(`店舗コード`), min(`店舗名漢字`),`社内伝番` as `伝票番号`,`社内伝番`,`ジャンル`, '二次製品' as `品名漢字` , '' as `規格名漢字`, min(`最大行数`) as `納品口数`, sum(`重量`) as `実際出荷数量`, sum(`重量`) as `重量`, min(`実際配送担当`),min(`県別`), min(`納品指示`), min(`備考`)
                //FROM t_orderdata
                //WHERE `Status`={0} AND `ジャンル`= 1003 AND `社内伝番` >0 AND `実際配送担当` = '丸健'
                //GROUP BY `社内伝番`
                t_maruken_trans temp = new t_maruken_trans();
                var order = gos.First();
                temp.OrderId = order.id受注データ;
                temp.受注日 = order.受注日;
                temp.店舗コード = order.店舗コード;
                temp.店舗名漢字 = order.店舗名漢字;
                temp.伝票番号 = order.社内伝番;
                temp.ジャンル = Convert.ToInt16(order.ジャンル);
                temp.品名漢字 = "二次製品";
                temp.規格名漢字 = "";
                temp.口数 = gos.Count();
                temp.発注数量 = gos.Sum(o => o.重量);
                temp.重量 = gos.Sum(o => o.重量);
                temp.実際配送担当 = order.実際配送担当;
                temp.県別 = order.県別;
                temp.納品指示 = order.納品指示;
                temp.備考 = order.備考;
                trans.Add(temp);
            }

            var normalOrders = orders.Where(o => !(o.実際配送担当 == "丸健" && o.ジャンル == 1003));

            foreach (var o in normalOrders)
            {

                t_maruken_trans temp = new t_maruken_trans();

                temp.OrderId = o.id受注データ;
                temp.受注日 = o.受注日;
                temp.店舗コード = o.店舗コード;
                temp.店舗名漢字 = o.店舗名漢字;
                temp.伝票番号 = o.伝票番号;
                temp.ジャンル = Convert.ToInt16(o.ジャンル);
                temp.品名漢字 = o.品名漢字;
                temp.規格名漢字 = o.規格名漢字;
                temp.口数 = o.納品口数;
                temp.発注数量 = o.実際出荷数量;
                temp.重量 = o.重量;
                temp.実際配送担当 = o.実際配送担当;
                temp.県別 = o.県別;
                temp.納品指示 = o.納品指示;
                temp.備考 = o.備考;
                trans.Add(temp);
            }

            ctx.t_maruken_trans.AddRange(trans);

            sql = String.Format("UPDATE t_orderdata SET `Status`={3}, `配送担当受信`=TRUE, `配送担当受信時刻`= NOW() WHERE `Status`={0} AND `実際配送担当`='{1}' AND `id受注データ` in ({2});", (int)OrderStatus.NotifyShipper, shipperName, String.Join(",", orderIds.ToArray()), (int)OrderStatus.WaitToShip);

            count = ctx.Database.ExecuteSqlCommand(sql); 
            
            ctx.SaveChanges();

            return count;

        }

        public static List<t_orderdata> OrderListByShipNO(EntityDataSource entityDataSource1, string shipNO)
        {

            var orders = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                          where o.ShipNO == shipNO
                          select o ).ToList();
            return orders;
        }

        public static void ChangeOrderQuantity(int orderId, int quantity)
        {
            using (var ctx = new GODDbContext())
            {
            }
        }

        public static void CancelOrder(List<v_pendingorder> pendingOrders)
        {
            using (var ctx = new GODDbContext())
            {
                var orderIds = pendingOrders.Select(o => o.id受注データ);

                var orderList = (from t_orderdata o in ctx.t_orderdata
                                 where orderIds.Contains(o.id受注データ)
                                 select o).ToList();
                var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();
                var marukenTransList = (from t_maruken_trans s in ctx.t_maruken_trans
                                        where orderIds.Contains(s.OrderId)
                                        select s).ToList();

                foreach (var order in orderList)
                {
                    //二次制品订单？
                    order.キャンセル = "yes";
                    order.キャンセル時刻 = DateTime.Now;
                    order.Status = OrderStatus.Cancelled;
                }

                ctx.t_stockrec.RemoveRange(stockrecList);
                ctx.t_maruken_trans.RemoveRange(marukenTransList);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);
            }
        }

        public static void RollbackOrder(List<v_pendingorder> pendingOrders) 
        {
            using (var ctx = new GODDbContext())
            {
                var orderIds = pendingOrders.Select(o => o.id受注データ);

                var orderList = (from t_orderdata o in ctx.t_orderdata
                                 where orderIds.Contains(o.id受注データ)
                                 select o).ToList();
                var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();
                var marukenTransList = (from t_maruken_trans s in ctx.t_maruken_trans
                                        where orderIds.Contains(s.OrderId)
                                        select s).ToList();

                foreach (var order in orderList)
                {
                    //二次制品订单？
                    order.社内伝番 = 0;
                    order.一旦保留 = true;
                    order.配送担当受信 = false;
                    order.配送担当受信時刻 = null;
                    order.Status = OrderStatus.Pending;
                }

                ctx.t_stockrec.RemoveRange(stockrecList);
                ctx.t_maruken_trans.RemoveRange(marukenTransList);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);
            }
        }



    }
}