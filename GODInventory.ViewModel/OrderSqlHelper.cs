﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GODInventory;
using GODInventory.MyLinq;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using GODInventory.ViewModel.EDI;
using System.IO;

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

        public static IQueryable<t_orderdata> ECWithoutCodeOrderQuery(EntityDataSource entityDataSource1, int genreId)
        {
            var a = entityDataSource1.EntitySets["t_orderdatas"];
            var q = from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                    where o.Status == OrderStatus.NotifyShipper && o.ジャンル == genreId && o.社内伝番 == null
                    select o;
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
                         店名 = o.店舗名漢字,
                         店舗コード = o.店舗コード,
                         納品場所名漢字 = o.納品場所名漢字,
                         伝票番号 = o.伝票番号,
                         自社コード = o.自社コード,
                         口数 = o.口数,
                         重量 = o.重量,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
                         実際配送担当 = o.実際配送担当,
                         県別 = o.県別,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
                         一旦保留 = o.一旦保留,
                         在庫状態 = o.在庫状態,
                         納品指示 = o.納品指示,
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
                         口数 = o.口数,
                         重量 = o.重量,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
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
                         GenreName = g.ジャンル名

                     });
            return q;

        }
        public static IQueryable<v_pendingorder> ShippingOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
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
                         店名 = s.店名,
                         伝票番号 = o.伝票番号,
                         口数 = o.口数,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         発注数量 = o.発注数量,
                         ＪＡＮコード = o.ＪＡＮコード,
                         商品コード = o.商品コード,
                         実際出荷数量 = o.実際出荷数量,
                         原単価_税抜_ = o.原単価_税抜_,
                         実際配送担当 = o.実際配送担当,
                         県別 = s.県別,
                         受領 = o.受領,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
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
        public static int SendOrderToShipper(List<int> orderIds)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {

                MySqlParameter[] parameters = { new MySqlParameter("@p1", true), new MySqlParameter("@p2", DateTime.Now), new MySqlParameter("@p3", ((int)OrderStatus.NotifyShipper)) };
                string sql = String.Format("UPDATE t_orderdata SET `配送担当受信`=@p1, `配送担当受信時刻`=@p2 ,`Status`=@p3 WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);
                ctx.SaveChanges();
            }
            return count;
        }

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

        public static int FinishOrders(List<int> orderIds)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                MySqlParameter[] parameters = { new MySqlParameter("@p3", ((int)OrderStatus.Completed)) };
                string sql = String.Format("UPDATE t_orderdata SET `Status`=@p3  WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);
                ctx.SaveChanges();
            }
            return count;

        }


        public static int GenerateASN(List<string> shipNOs) {
            var now = DateTime.Now;
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EDITxtHandler.ASNFolder, "NYOTEI_" + now.ToString("yyyyMMddHHmmss") + ".txt");

            using (var ctx = new GODDbContext())
            {
                var orders = (from t_orderdata o in ctx.t_orderdata
                              where shipNOs.Contains(o.ShipNO)
                              orderby o.法人コード, o.店舗コード
                              select o).ToList();
                // generate ASN管理連番, 出荷No
                var mid = EDITxtHandler.GenerateMID(ctx);
                var grouped_orders = orders.GroupBy(o => new { o.法人コード, o.店舗コード }, o => o);
                foreach (var gos in grouped_orders)
                {
                    long ship_no = EDITxtHandler.GenerateShipNo(ctx, gos.First());
                    foreach (var o in gos)
                    {
                        o.出荷No = ship_no;
                        o.ASN管理連番 = mid;
                    }
                }


                ASNHeadModel asnhead = EDITxtHandler.GenerateASNTxt(path, orders);

                string sql = asnhead.ToRawSql();

                ctx.Database.ExecuteSqlCommand(sql);

                foreach (var gos in grouped_orders)
                {
                    var oids = gos.Select(order => order.id受注データ);
                    var o = gos.First();
                    sql = String.Format("UPDATE t_orderdata SET `出荷No`={1}, `ASN管理連番`={2}, `Status`={3} WHERE `id受注データ` in ({0})", String.Join(",", oids.ToArray()), o.出荷No, o.ASN管理連番, ((int)OrderStatus.ASN));
                    ctx.Database.ExecuteSqlCommand(sql);                  
                }
                //ctx.SaveChanges();
            }
            return 0;
        }

        public  string[]  StrockReback()
        {

            //string[] names = new string[5,4];
            string[] names = { "GOD", "MKL", "マツモト産業" };

            return names;
        
        }
        public string[] Strock_out()
        {
            //事由
            //string[] names = new string[5,4];
            string[] names = { "零售"  };

            return names;

        }
        public string[] Strock_QuFenout()
        {
            //事由
            string[] names = { "出庫", "入庫" };

            return names;

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
                              where s.自社コード == pid && s.状態 == "完了" && (s.先==warehouse.FullName || s.元 == warehouse.FullName)
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
        public static int NotifyShipper(GODDbContext ctx, string shipperName)
        {
            int count = 0;

            string sql = @"UPDATE t_orderdata SET `Status`={2}, `配送担当受信`=TRUE, `配送担当受信時刻`= NOW() WHERE `Status`={0} AND `実際配送担当`={1}";

            count = ctx.Database.ExecuteSqlCommand(sql, OrderStatus.NotifyShipper, shipperName, OrderStatus.WaitToShip);

            return count;

        }

        public static List<t_orderdata> OrderListByShipNO(EntityDataSource entityDataSource1, string shipNO)
        {

            var orders = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                          where o.ShipNO == shipNO
                          select o ).ToList();
            return orders;
        }
    }
}