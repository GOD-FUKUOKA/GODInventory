﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GODInventory;
using GODInventory.MyLinq;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using GODInventory.NAFCO.EDI;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace GODInventory
{
    public class OrderSqlHelper
    {
        public static List<t_genre> genreList = null;

        /// <summary>
        /// 取得当前登录用户的店铺ids
        /// </summary>
        /// <returns> List<int> | null</returns>
        public static List<int> GetLoginUserStoreIds() {
            return LoginUser.GetInstance().GetStoreIds();            
        }

        /// <summary>
        /// 取得当前登录用户的店铺ids
        /// </summary>
        /// <returns> List<int> | null</returns>
        public static List<int> GetLoginUserWarehouseIds()
        {
            return LoginUser.GetInstance().GetWarehouseIds();
        }

        public static string GetWarehouseIdsConditions()
        {
            string conditions = String.Empty;
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if(storeids != null){
                conditions = string.Join(",", storeids);
            }
            return conditions;
        }
        public static int IsInnerCodeRequired(int genre_id)
        {
            int 社内伝番処理 = 0;
            if (genreList == null)
            {
                using (var ctx = new GODDbContext())
                {
                    genreList = ctx.t_genre.ToList();
                }            
            }
            var genre = genreList.Where(o => o.idジャンル == genre_id).First();
            社内伝番処理 = genre.社内伝番処理;
            return 社内伝番処理;
        }

        /// <summary>
        /// 取得订单状态为 “Duplicated” 重复订单列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static IQueryable<v_duplicatedorder> GetDuplicateOrderQuery(GODDbContext ctx)
        {

            //            string sql = @"SELECT o1.id受注データ as duplicatedId, o2.id受注データ, o2.`発注日`,o2.`出荷日`,o2.`納品日`,o2.`受注日`,o2.`店舗コード`, o2.`店舗名漢字`,
            //          o2.`納品場所名漢字`,o2.`伝票番号`,o2.`納品口数`,o2.`ジャンル`,o2.`品名漢字`,o2.`規格名漢字`, 
            //          o2.`実際出荷数量`,o2.`実際配送担当`,o2.`県別`, 
            //          o2.`発注形態名称漢字`,o2.`キャンセル`,o2.`ダブリ`, o2.Status, o3.ジャンル名 as GenreName
            //            FROM t_orderdata o1 
            //            INNER JOIN t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
            //            INNER JOIN t_genre  o3 on o1.ジャンル = o3.idジャンル 
            //    where o1.`Status`=22 AND (o1.id受注データ = o2.id受注データ OR  o2.`Status`=0 OR o2.`Status`=2 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品予定日`>NOW()) )
            //    order by o2.店舗コード, o2.自社コード , o2.受注日, o1.id受注データ";



            var q = from t_orderdata o1 in ctx.t_orderdata
                    join t_orderdata o2 in ctx.t_orderdata on new { 自社コード = o1.自社コード, 店舗コード = o1.店舗コード } equals new { 自社コード = o2.自社コード, 店舗コード = o2.店舗コード }
                    join t_genre g in ctx.t_genre on o1.ジャンル equals g.idジャンル
                    where o1.Status == OrderStatus.Duplicated && (o1.id受注データ == o2.id受注データ || o2.Status == OrderStatus.Pending || o2.Status == OrderStatus.NotifyShipper || o2.Status == OrderStatus.WaitToShip || o2.Status == OrderStatus.PendingShipment)
                    orderby o2.店舗コード, o2.自社コード, o2.受注日, o1.id受注データ
                    select new v_duplicatedorder
                    {
                        duplicatedId = o1.id受注データ,
                        id受注データ = o2.id受注データ,
                        発注日 = o2.発注日,
                        出荷日 = o2.出荷日,
                        納品日 = o2.納品日,
                        店舗コード = o2.店舗コード,
                        店舗名漢字 = o2.店舗名漢字,
                        納品場所名漢字 = o2.納品場所名漢字,
                        伝票番号 = o2.伝票番号,
                        納品口数 = o2.納品口数,
                        ジャンル = o2.ジャンル,
                        品名漢字 = o2.品名漢字,
                        規格名漢字 = o2.規格名漢字,
                        実際出荷数量 = o2.実際出荷数量,
                        実際配送担当 = o2.実際配送担当,
                        県別 = o2.県別,
                        発注形態名称漢字 = o2.発注形態名称漢字,
                        キャンセル = o2.キャンセル,
                        ダブリ = o2.ダブリ,
                        Status = o2.Status,
                        GenreName = g.ジャンル名
                    };
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if ( storeids != null) 
            {             

                q = from t_orderdata o1 in ctx.t_orderdata
                    join t_orderdata o2 in ctx.t_orderdata on new { 自社コード = o1.自社コード, 店舗コード = o1.店舗コード } equals new { 自社コード = o2.自社コード, 店舗コード = o2.店舗コード }
                    join t_genre g in ctx.t_genre on o1.ジャンル equals g.idジャンル
                    where storeids.Contains(o1.warehouse_id) && o1.Status == OrderStatus.Duplicated && (o1.id受注データ == o2.id受注データ || o2.Status == OrderStatus.Pending || o2.Status == OrderStatus.NotifyShipper || o2.Status == OrderStatus.WaitToShip || o2.Status == OrderStatus.PendingShipment)
                    orderby o2.店舗コード, o2.自社コード, o2.受注日, o1.id受注データ
                    select new v_duplicatedorder
                    {
                        duplicatedId = o1.id受注データ,
                        id受注データ = o2.id受注データ,
                        発注日 = o2.発注日,
                        出荷日 = o2.出荷日,
                        納品日 = o2.納品日,
                        店舗コード = o2.店舗コード,
                        店舗名漢字 = o2.店舗名漢字,
                        納品場所名漢字 = o2.納品場所名漢字,
                        伝票番号 = o2.伝票番号,
                        納品口数 = o2.納品口数,
                        ジャンル = o2.ジャンル,
                        品名漢字 = o2.品名漢字,
                        規格名漢字 = o2.規格名漢字,
                        実際出荷数量 = o2.実際出荷数量,
                        実際配送担当 = o2.実際配送担当,
                        県別 = o2.県別,
                        発注形態名称漢字 = o2.発注形態名称漢字,
                        キャンセル = o2.キャンセル,
                        ダブリ = o2.ダブリ,
                        Status = o2.Status,
                        GenreName = g.ジャンル名
                    };

            }
            return q;

        }
        
        //sqlStr = "SELECT t_orderdata.`出荷日`,t_orderdata.`納品日`,t_orderdata.`受注日`,t_orderdata.`キャンセル`,t_orderdata.`一旦保留`," _
        //& " t_orderdata.`伝票番号`,t_orderdata.`社内伝番`,t_orderdata.`行数`,t_orderdata.`最大行数`,t_orderdata.`口数`,t_orderdata.`発注数量`," _
        //& " t_orderdata.`実際配送担当`,t_orderdata.`備考`,t_orderdata.`店舗コード`,t_orderdata.`店舗名漢字`,t_orderdata.`id受注データ`,`発注形態名称漢字`," _
        //& " t_orderdata.`原単価(税抜)`,t_orderdata.`重量`,'' " _
        //& " FROM t_orderdata" _
        //& " WHERE t_orderdata.`店舗コード` = " & Cells(2, 3).Value & " AND t_orderdata.`受注日` BETWEEN DATE_SUB(NOW(),INTERVAL 60 DAY) AND now()" _
        //& " ORDER BY t_orderdata.`受注日` DESC,t_orderdata.`社内伝番` ASC,t_orderdata.`行数` ASC,t_orderdata.`伝票番号` ASC"
        //出荷日納品日受注日, 店舗コード,店名, 社内伝番, 伝票番号,品名漢字， 規格名漢字， 発注数量，実際配送担当， 県別，
        //原単価(税抜)，， 原価金額(税抜)， 発注形態名称漢字， キャンセル， 一旦保留， 受領， ダブリ

        
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

        /// <summary>
        /// 取得订单状态为 “Pending” 订单列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static List<v_pendingorder> GetPendingOrderList(EntityDataSource dataSource, int pageSize, int offset)
        {


            string format = @" SELECT o.*, o.`原単価(税抜)` as `原単価_税抜_`, o.`原単価(税込)` as `原単価_税込_`, o.`売単価（税抜）` as `売単価_税抜_`, o.`売単価（税込）` as `売単価_税込_`,
g.`ジャンル名` as `GenreName`, k.`在庫数` as `在庫数`, s.`売上ランク`, p.`厳しさ`, p.`欠品カウンター`
FROM t_orderdata o
INNER JOIN t_genre g  on o.ジャンル = g.idジャンル
INNER JOIN t_shoplist s  on o.法人コード = s.customerId AND  o.店舗コード = s.店番 
INNER JOIN t_pricelist p on  o.自社コード = p.自社コード AND  o.店舗コード = p.店番 
LEFT JOIN t_stockstate k on  o.自社コード = k.自社コード AND  o.warehouse_id = k.WarehouseId 
WHERE o.Status ={0} {3}
ORDER BY o.受注日 desc, o.Status, o.transport_id,o.warehouse_id, o.県別, o.店舗コード, o.ＪＡＮコード,  o.伝票番号 LIMIT {1} OFFSET {2};";

            string storeIdsCondition = OrderSqlHelper.GetWarehouseIdsConditions();
            string conditions = string.Empty;

            if (storeIdsCondition.Length > 0)
            {
                conditions = string.Format("and o.warehouse_id in ({0})", storeIdsCondition);
            }

            string sql = string.Format(format, (int)OrderStatus.Pending, pageSize, offset, conditions);
            var list = dataSource.DbContext.Database.SqlQuery<v_pendingorder>(sql).ToList();
            return list;
        }

        /// <summary>
        /// 查找订单状态为 “待处理” 的数量
        /// </summary>
        /// <param name="storeIds"></param>
        /// <param name="entityDataSource1"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static IQueryable<t_orderdata> PendingOrderQuery(EntityDataSource entityDataSource1)
        {
            var a = entityDataSource1.EntitySets["t_orderdatas"];
            var q = from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                    where o.Status == OrderStatus.Pending
                    select o;
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            }
            return q;
        }

        //public static IQueryable<v_pendingorder> ECWithoutCodeOrderQuery(EntityDataSource entityDataSource1, int genreId)
        //{

        //    var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
        //             where o.Status == OrderStatus.NotifyShipper && o.ジャンル == genreId && o.社内伝番 == 0 && o.実際配送担当 == "丸健"
        //             orderby o.店舗コード
        //             select new v_pendingorder
        //              {
        //                  id受注データ = o.id受注データ,
        //                  出荷日 = o.出荷日,
        //                  納品日 = o.納品日,
        //                  受注日 = o.受注日,
        //                  店舗名漢字 = o.店舗名漢字,
        //                  店舗コード = o.店舗コード,
        //                  納品場所名漢字 = o.納品場所名漢字,
        //                  伝票番号 = o.伝票番号,
        //                  自社コード = o.自社コード,
        //                  口数 = o.口数,
        //                  納品口数 = o.納品口数,
        //                  重量 = o.重量,
        //                  ジャンル = o.ジャンル,
        //                  品名漢字 = o.品名漢字,
        //                  規格名漢字 = o.規格名漢字,
        //                  発注数量 = o.発注数量,
        //                  最小発注単位数量 = o.最小発注単位数量,
        //                  実際出荷数量 = o.実際出荷数量,
        //                  実際配送担当 = o.実際配送担当,
        //                  県別 = o.県別,
        //                  発注形態名称漢字 = o.発注形態名称漢字,
        //                  キャンセル = o.キャンセル,
        //                  ダブリ = o.ダブリ,
        //                  法人名漢字 = o.法人名漢字,
        //                  備考 = o.備考,
        //                  納品指示 = o.納品指示,
        //                  社内伝番UnSaved = 0
        //              });
        //    return q;
        //}

        //public static IQueryable<v_pendingorder> PendingOrderQueryEx(EntityDataSource entityDataSource1)
        //{
        //    // https://www.cnblogs.com/weixing/p/4447927.html
        //    // o.`原単価(税抜)` as `原単価_税抜_`, o.`原単価(税込)` as `原単価_税込_`, o.`売単価（税抜）` as `売単価_税抜_`, o.`売単価（税込）` as `売単価_税込_`, 
        //    // g.`ジャンル名` as `GenreName`, k.`在庫数` as `在庫数`, s.`売上ランク`, p.`厳しさ`, p.`欠品カウンター`

        //    var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
        //             join t_genre g in entityDataSource1.EntitySets["t_genre"] on o.ジャンル equals g.idジャンル
        //             join t_pricelist i in entityDataSource1.EntitySets["t_pricelist"] on new { pid = o.自社コード, sid = o.店舗コード } equals new { pid = i.自社コード, sid = i.店番 }
        //             join t_stockstate k in entityDataSource1.EntitySets["t_stockstate"] on new { pid = o.自社コード, wid = o.warehouse_id } equals new { pid = k.自社コード, wid = k.WarehouseID } into t_join
        //             from x in t_join.DefaultIfEmpty()
        //             where o.Status == OrderStatus.Pending
        //             orderby o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
        //             select new v_pendingorder
        //             {
        //                 id受注データ = o.id受注データ,
        //                 出荷日 = o.出荷日,
        //                 納品日 = o.納品日,
        //                 受注日 = o.受注日,
        //                 店舗名漢字 = o.店舗名漢字,
        //                 店舗コード = o.店舗コード,
        //                 納品場所名漢字 = o.納品場所名漢字,
        //                 伝票番号 = o.伝票番号,
        //                 自社コード = o.自社コード,
        //                 口数 = o.口数,
        //                 納品口数 = o.納品口数,
        //                 重量 = o.重量,
        //                 ジャンル = o.ジャンル,
        //                 品名漢字 = o.品名漢字,
        //                 規格名漢字 = o.規格名漢字,
        //                 発注数量 = o.発注数量,
        //                 最小発注単位数量 = o.最小発注単位数量,
        //                 実際出荷数量 = o.実際出荷数量,
        //                 実際配送担当 = o.実際配送担当,
        //                 県別 = o.県別,
        //                 発注形態名称漢字 = o.発注形態名称漢字,
        //                 キャンセル = o.キャンセル,
        //                 ダブリ = o.ダブリ,
        //                 在庫状態 = "unkown",
        //                 法人名漢字 = o.法人名漢字,
        //                 備考 = o.備考,
        //                 納品指示 = o.納品指示,
        //                 訂正理由区分 = o.訂正理由区分,
        //                 在庫数 = x.在庫数,
        //                 GenreName = g.ジャンル名
        //             });
        //    return q;
        //}

        /// <summary>
        ///  查找订单状态为 “NotifyShipper” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static List<v_pendingorder> GetNotifiedOrderList(EntityDataSource entityDataSource)
        {

            var q = (from t_orderdata o in entityDataSource.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.NotifyShipper
                     orderby o.実際配送担当, o.県別, o.店舗コード, o.受注日, o.伝票番号
                     select new v_pendingorder
                     {
                         id受注データ = o.id受注データ,
                         受注日 = o.受注日,
                         店舗コード = o.店舗コード,
                         warehouse_id = o.warehouse_id,
                         warehousename = o.warehousename,
                         店舗名漢字 = o.店舗名漢字,
                         伝票番号 = o.伝票番号,
                         社内伝番 = o.社内伝番,
                         ジャンル = o.ジャンル,
                         品名漢字 = o.品名漢字,
                         規格名漢字 = o.規格名漢字,
                         納品口数 = o.納品口数,
                         実際出荷数量 = o.実際出荷数量,
                         重量 = o.重量,
                         transport_id = o.transport_id,
                         実際配送担当 = o.実際配送担当,
                         県別 = o.県別,
                         納品指示 = o.納品指示,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         備考 = o.備考,
                         社内伝番処理 = o.社内伝番処理
                     });
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            }

          var list = q.ToList();
          return list;
        }

        /// <summary>
        ///  查找订单状态为 “WaitToShip” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
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
                         納品指示 = o.納品指示,
                         ShipNO = o.ShipNO,
                         GenreName = g.ジャンル名,
                         備考 = o.備考

                     });
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            }
            return q;

        }


        /// <summary>
        ///  查找订单状态为 “PendingShipment” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
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
                         重量 = o.重量,
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
                         //受領 = o.受領,
                         発注形態名称漢字 = o.発注形態名称漢字,
                         キャンセル = o.キャンセル,
                         ダブリ = o.ダブリ,
                         ShipNO = o.ShipNO,
                         GenreName = g.ジャンル名,
                         備考 = o.備考

                     });
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            }
            return q;
        }

        //public static IQueryable<t_orderdata> ASNOrderSql(EntityDataSource entityDataSource1)
        //{
        //    var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
        //             where o.Status == OrderStatus.ASN 
        //             orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
        //             select o
        //             );
        //    return q;
        //}

        /// <summary>
        ///  查找订单状态为 “ASN” 的订单， 以 "実際配送担当","ShipNO", "出荷日", "納品日" 分组
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static List<v_groupedorder> GroupedASNOrderList(EntityDataSource dataSource)
        {
            string format = @"SELECT o.`ShipNO`, o.`出荷日`, o.`納品日`,
 min(o.`県別`) as `県別`, o.`実際配送担当`, o.`reportState`,  
sum(`納品原価金額`) as TotalPrice, sum(`重量`) as TotalWeight  
FROM  t_orderdata o WHERE o.`受注管理連番`=0 AND o.Status ={0} {1} GROUP BY  o.`実際配送担当`, o.`ShipNO`, o.`出荷日`, o.`納品日`ORDER BY o.出荷日 desc";

            string storeIdsCondition = OrderSqlHelper.GetWarehouseIdsConditions();
            string conditions = string.Empty;

            if (storeIdsCondition.Length > 0)
            {
                conditions = string.Format("and o.warehouse_id in ({0})", storeIdsCondition);
            }

            string sql = string.Format(format, (int)OrderStatus.ASN, conditions);
            
            var list = dataSource.DbContext.Database.SqlQuery<v_groupedorder>(sql ).ToList();

            return list;

        }

        /// <summary>
        ///  查找订单状态为 “Shipped” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static IQueryable<t_orderdata> ShippedOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.Shipped
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                     ) as IQueryable<t_orderdata>;
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            }
            return q;
        }

        /// <summary>
        ///  查找订单状态为 “Cancelled” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static List<t_orderdata> CanceledOrderSql(EntityDataSource entityDataSource1)
        {
            //由于entityDataSource1 缓存问题，所以使用新连接
            List<t_orderdata> list = null;
            using (GODDbContext ctx = new GODDbContext())
            {

                var q = (from t_orderdata o in ctx.t_orderdata
                         where o.Status == OrderStatus.Cancelled
                         orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                         select o
                         ) as IQueryable<t_orderdata>;
                var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
                if (storeids != null)
                {
                    q = q.Where(o => storeids.Contains(o.warehouse_id));
                }         
                list = q.ToList();
            }
            return list;
        }

        /// <summary>
        ///  查找订单状态为 “Received” 的订单列表
        /// </summary>
        /// <param name="entityDataSource"></param>
        /// <param name="loginUser.storeIds"></param>
        /// <returns></returns>
        public static IQueryable<t_orderdata> ReceivedOrderSql(EntityDataSource entityDataSource1)
        {
            var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                     where o.Status == OrderStatus.Received
                     orderby o.実際配送担当, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号
                     select o
                     ) as IQueryable<t_orderdata>;
            var storeids = OrderSqlHelper.GetLoginUserWarehouseIds();
            if (storeids != null)
            {
                q = q.Where(o => storeids.Contains(o.warehouse_id));
            } 
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
                          join NafcoOrder norder in entityDataSource1.EntitySets["t_nafco_orders"] on o.origin_order_id equals norder.id受注データ
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
                              品名漢字 = norder.発注品名漢字,
                              規格名漢字 = norder.発注規格名漢字,
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

        public static List<v_pendingorder> ASNOrderDataListByChuHeNo(EntityDataSource entityDataSource1, long chuHeNo)
        {

            var orders = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                          join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on o.店舗コード equals s.店番
                          where o.出荷No == chuHeNo
                          select new v_pendingorder
                          {
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

        /// <summary>
        ///  
        /// </summary>
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


        // 取消 pending 订单
        public static int CancelOrders(List<int> orderIds)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                //order.キャンセル = "yes";
                //order.キャンセル時刻 = DateTime.Now;
                //order.Status = OrderStatus.Cancelled;
                //order.備考 = "キャンセル";
                //MySqlParameter[] parameters = { new MySqlParameter("@p1", "yes"), new MySqlParameter("@p2", DateTime.Now), new MySqlParameter("@p3", ((int)OrderStatus.Cancelled)) };
                //string sqlFormat = "UPDATE t_orderdata SET `実際出荷数量`=0, `最終出荷数`=0, `納品原価金額`=0, `税額`=0, `備考`='キャンセル',`キャンセル`=@p1, `キャンセル時刻`=@p2 ,`Status`=@p3 WHERE `id受注データ` in ({0})";
                //string sql = String.Format(sqlFormat, String.Join(",", orderIds.ToArray()));
                //count = ctx.Database.ExecuteSqlCommand(sql, parameters);

                List<t_orderdata> orders = (from t_orderdata o in ctx.t_orderdata
                                            where orderIds.Contains(o.id受注データ)
                                            select o).ToList();
                foreach (var order in orders)
                {
                    OrderSqlHelper.CancelOrder(ctx, order);
                }
               
            }
            return count;
        }

        // 取消任意状态订单
        public static void CancelOrder(GODDbContext ctx, t_orderdata order)
        {

            var orderIds = new List<int> {  order.id受注データ };

            var orderList = new List<t_orderdata> { order };

            var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                where orderIds.Contains(s.OrderId)
                                select s).ToList();
            var marukenTransList = (from t_maruken_trans s in ctx.t_maruken_trans
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();

            order.実際出荷数量 = 0;
            order.納品口数 = 0;

            var product = ctx.t_itemlist.Find( order.自社コード);
            OrderSqlHelper.AfterOrderQtyChanged(order, product);
            //当订单被取消掉的时候，重量=t_orderdata.`発注数量`* t_itemlist.`単品重量`。

            order.重量 = Convert.ToInt32( ((double)order.発注数量) * product.単品重量 );
            order.キャンセル = "yes";
            order.キャンセル時刻 = DateTime.Now;
            order.Status = OrderStatus.Cancelled;
            order.備考 = "キャンセル";

            ctx.t_stockrec.RemoveRange(stockrecList);
            ctx.t_maruken_trans.RemoveRange(marukenTransList);

            var priceItem = ctx.t_pricelist.Where(p => p.自社コード == order.自社コード && p.店番 == order.店舗コード).FirstOrDefault();
            priceItem.欠品カウンター += 1;    

            ctx.SaveChanges();

            if (stockrecList.Count > 0)
            {
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);
            }
            
        }

        // 撤销取消掉订单
        public static void UncancelOrder(GODDbContext ctx, t_orderdata order)
        {

            order.Status = OrderStatus.Pending;
            order.キャンセル時刻 = null;
            order.実際出荷数量 = order.発注数量;
            order.納品口数 = order.口数;

            var product = ctx.t_itemlist.Find(order.自社コード);
    

            var priceItem = ctx.t_pricelist.Where(p => p.自社コード == order.自社コード && p.店番 == order.店舗コード).FirstOrDefault();

            if (priceItem.欠品カウンター > 0)
            {
                priceItem.欠品カウンター -= 1;
            }

            OrderSqlHelper.AfterOrderQtyChanged(order, product);

            ctx.SaveChanges();

        }

        // 订单发送给运输公司
        public static int SendOrderToShipper(List<v_pendingorder> orders)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                var customer = ctx.t_customers.First();
                var orderIds = orders.Select(o => o.id受注データ).ToList();
                var warehouseList = ctx.t_warehouses.ToList();
                MySqlParameter[] parameters = { new MySqlParameter("@p1", true), new MySqlParameter("@p2", DateTime.Now), new MySqlParameter("@p3", ((int)OrderStatus.NotifyShipper)) };
                string sql = String.Format("UPDATE t_orderdata SET `配送担当受信`=@p1, `配送担当受信時刻`=@p2 ,`Status`=@p3 WHERE `id受注データ` in ({0})", String.Join(",", orderIds.ToArray()));
                count = ctx.Database.ExecuteSqlCommand(sql, parameters);

                List<t_stockrec> changes = new List<t_stockrec>();
                foreach (var order in orders)
                {
                    var warehouse = warehouseList.Find(o => o.FullName == order.warehousename);
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
        
        public static int UpdateOrderreportState(List<string> shipNOs,int status)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {

                //string sql = String.Format("UPDATE t_orderdata SET `reportState`={0} WHERE `ShipNO`={1}", status, shipNOs);

                string sql = string.Format("UPDATE t_orderdata SET `reportState`={1}  WHERE `shipNO` in ({0})", String.Join(",", shipNOs.Select(s => "'" + s + "'").ToArray()), status);
                count = ctx.Database.ExecuteSqlCommand(sql);
     
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

        // 生成出荷NO，为生成ASN做准备。
        // 对于上传后，再修正的订单，需要保留原来的 “出荷NO”。
        public static int GenerateOrderChuHeNO(List<string> shipNOs) {
            
            using (var ctx = new GODDbContext())
            {
                // get 受注管理連番 by shipNos
                var orders = (from t_orderdata o in ctx.t_orderdata
                              where shipNOs.Contains(o.ShipNO)                             
                              select o).ToList();
                // generate ASN管理連番, 出荷No

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
            return 0;
        }

        // 生成管理连番， 更新订单的管理连番，生成ASN文件
        // 返回 管理连番
        public static long GenerateASNByShipNOs(GODDbContext ctx, List<string> shipNOs)
        {
            var shipnos = String.Join(",", shipNOs.Select(s => "'" + s + "'").ToArray());
            var now = DateTime.Now;

            // generate ASN管理連番
            long mid = EDITxtHandler.GenerateMID(ctx);
            // 无需 条件OrderStatus.ASN, 取消的订单也要生成ASN
            string sql1 = String.Format("UPDATE t_orderdata SET `ASN管理連番`={1}  WHERE `ShipNO` in ({0}) ", shipnos, mid);
            var path = EDITxtHandler.BuildASNFilePath(mid);

            ctx.Database.ExecuteSqlCommand(sql1);


            //var orders = (from t_orderdata o in ctx.t_orderdata
            //              join NafcoOrder norder in ctx.t_nafco_orders on o.origin_order_id equals norder.id受注データ
            //              where shipnos.contains(o.shipno)
            //              orderby o.出荷no
            //              select o
            //                ).tolist(); 
            string query = string.Format(@"select norder.発注品名漢字, norder.発注規格名漢字, norder.品名カナ, norder.規格名カナ, o.*, o.`売単価（税込）` as 売単価_税込_, o.`売単価（税抜）` as 売単価_税抜_ from t_orderdata o
             inner join t_nafco_orders norder on o.origin_order_id = norder.id受注データ
             where o.shipno in ({0})", shipnos);

            var orders = ctx.Database.SqlQuery< WholeOrder>(query).ToList();
            ASNHeadModel asnhead = EDITxtHandler.GenerateASNTxt(path, orders);

            List<t_pricelist> canceledPriceItems = (from t_pricelist p in ctx.t_pricelist
                                                    where p.欠品カウンター > 0
                                                    select p).ToList();

            foreach (var order in orders)
            {
                if (order.実際出荷数量 > 0)
                {
                    var priceItem = canceledPriceItems.Where(p => p.自社コード == order.自社コード && p.店番 == order.店舗コード).FirstOrDefault();
                    if (priceItem != null)
                    {
                        priceItem.欠品カウンター = 0;
                    }
                }
            }
            ctx.SaveChanges();

            string sql = asnhead.ToRawSql();

            ctx.Database.ExecuteSqlCommand(sql);
            return mid;

        }

        // 生成管理连番， 更新订单的管理连番，生成ASN文件
        // 返回 管理连番
        public static long GenerateASNByOrderIds(GODDbContext ctx, List<int> orderIds)
        {

            var orderids = String.Join(",", orderIds.ToArray());
            var now = DateTime.Now;

            // generate ASN管理連番
            long mid = EDITxtHandler.GenerateMID(ctx);
            // 无需 条件OrderStatus.ASN, 取消的订单也要生成ASN
            var sql1 = String.Format("UPDATE t_orderdata SET `ASN管理連番`={1}  WHERE `id受注データ` in ({0}) ", orderids, mid);
            var path = EDITxtHandler.BuildASNFilePath(mid);

            ctx.Database.ExecuteSqlCommand(sql1);

            //var orders = (from t_orderdata o in ctx.t_orderdata
            //              where orderIds.Contains(o.id受注データ)
            //              orderby o.出荷No
            //              select o
            //                ).ToList();
            string query = string.Format(@"select norder.発注品名漢字, norder.発注規格名漢字, norder.品名カナ, norder.規格名カナ, o.*, o.`売単価（税込）` as 売単価_税込_, o.`売単価（税抜）` as 売単価_税抜_ from 
             inner join t_nafco_orders norder on o.origin_order_id = norder.id受注データ
             where o.id受注データ in ({0}) order by o.出荷No", orderids);
            var orders = ctx.Database.SqlQuery<WholeOrder>(query).ToList();

            ASNHeadModel asnhead = EDITxtHandler.GenerateASNTxt(path, orders);

            List<t_pricelist> canceledPriceItems = (from t_pricelist p in ctx.t_pricelist
                                                    where p.欠品カウンター > 0
                                                    select p).ToList();
            foreach (var order in orders)
            {
                if (order.実際出荷数量 > 0)
                {
                    var priceItem = canceledPriceItems.Where(p => p.自社コード == order.自社コード && p.店番 == order.店舗コード).FirstOrDefault();
                    if (priceItem != null)
                    {
                        priceItem.欠品カウンター = 0;
                    }
                }
            }
            ctx.SaveChanges();

            string sql = asnhead.ToRawSql();

            ctx.Database.ExecuteSqlCommand(sql);
            return mid;

        }

        private static string BuildStockNum(GODDbContext ctx, int genre_id, string warehousename, DateTime selectedDate)
        {

            var startAt = selectedDate.Date;
            var endAt = startAt.AddDays(1).Date;

            var results = from s in ctx.t_stockrec
                          where s.日付 >= startAt && s.日付 < endAt
                          group s by s.納品書番号 into g
                          select g;
            int count = results.Count();

            string stock_no = String.Format(warehousename + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

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

        /// <summary>
        /// 根据商品出入库信息，更新商品库存状态
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="stockrecs"></param>
        /// <returns></returns>
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
                       stockstate.ShipperName = warehouse.FullName;
                   }
                   else {
                       stockstate = new t_stockstate();
                       stockstate.自社コード = pid;
                       stockstate.WarehouseID = warehouse.Id;
                       stockstate.ShipperName = warehouse.FullName;
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


        public static int NotifyShipper(GODDbContext ctx, List<v_pendingorder> pendingOrders, string transportName)
        {
            var orderIds = pendingOrders.Select(order => order.id受注データ).ToList();
            // 确保没有 OrderId 冲突
            string delete_sql = String.Format("DELETE FROM t_maruken_trans WHERE  `OrderId` in ({0});",   String.Join(",", orderIds.ToArray()) );

            ctx.Database.ExecuteSqlCommand(delete_sql); 

            List<t_maruken_trans> trans = new List<t_maruken_trans>();

            string sql = "SELECT MAX(t_orderdata.`社内伝番`) FROM t_orderdata";
            int max = Convert.ToInt32(ctx.Database.SqlQuery<int?>(sql).FirstOrDefault());
            //max = Convert.ToInt32(max);
            //社内传番应该为8位，我们现在排到了10009837
            if (max < 10000000)
            {
                max += 10000000;
            }

            int count = 0;

            var orders = (from t_orderdata o in ctx.t_orderdata
                where orderIds.Contains( o.id受注データ )
                              select o).ToList();
            var genres = ctx.t_genre.ToList();
            //二次制品订单
            //where o.Status == OrderStatus.NotifyShipper && o.ジャンル == genreId && o.社内伝番 == 0 && o.実際配送担当 == "丸健"

            //var groupedOrders = orders.Where(o => (o.実際配送担当 == "丸健" && o.ジャンル == 1003)).GroupBy(o => new { o.店舗コード, o.納品場所コード });
            var groupedOrders = orders.Where(o => (o.社内伝番処理 == 1)).GroupBy(o => new { o.店舗コード, o.納品場所コード });

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
                var genre = genres.FirstOrDefault(o => (o.idジャンル == order.ジャンル));
                temp.OrderId = order.id受注データ;
                temp.受注日 = order.受注日;
                temp.店舗コード = order.店舗コード;
                temp.店舗名漢字 = order.店舗名漢字;
                temp.伝票番号 = order.社内伝番;
                temp.ジャンル = Convert.ToInt16(order.ジャンル);
                temp.品名漢字 = genre.ジャンル名; //使用分类的名称代替 "二次製品"
                temp.規格名漢字 = "";
                temp.口数 = gos.Count();
                temp.発注数量 = gos.Sum(o => o.重量);
                temp.重量 = gos.Sum(o => o.重量);
                temp.実際配送担当 = order.実際配送担当;
                temp.県別 = order.県別;
                temp.納品指示 = order.納品指示;
                temp.備考 = order.備考;
                temp.配送担当受信 = true;
                temp.配送担当受信時刻 = DateTime.Now;
                trans.Add(temp);
            }

            var normalOrders = orders.Where(o => !(o.社内伝番処理==1));

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
                temp.配送担当受信 = true;
                temp.配送担当受信時刻 = DateTime.Now;
                trans.Add(temp);
            }

            ctx.t_maruken_trans.AddRange(trans);

            sql = String.Format("UPDATE t_orderdata SET `Status`={3}, `最終出荷数`=`実際出荷数量`, `配送担当受信`=TRUE, `配送担当受信時刻`= NOW() WHERE `Status`={0} AND `実際配送担当`='{1}' AND `id受注データ` in ({2});", (int)OrderStatus.NotifyShipper, transportName, String.Join(",", orderIds.ToArray()), (int)OrderStatus.WaitToShip);

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

        public static int DeleteFaxOrder(int orderId)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                string sql = "DELETE  from t_orderdata WHERE `id受注データ`={0} AND `入力区分`=1;";
                count = ctx.Database.ExecuteSqlCommand(sql, orderId); 

            }
            return count;
        }

        // 当订单的数量被修改后，需要相应修改的字段
        public static void AfterOrderQtyChanged(t_orderdata order, t_itemlist item)
        {
            
            order.最終出荷数 = order.実際出荷数量;
            order.納品原価金額 = order.実際出荷数量 * order.原単価_税抜_;
            order.原価金額_税込_ = (int)(order.実際出荷数量 * order.原単価_税込_);
            order.税額 = (int)(order.納品原価金額 * order.税率);
            order.重量 = (int)(Convert.ToDecimal(item.単品重量) * order.実際出荷数量);

            if (item.PT入数 > 0)
            {
                order.納品口数 = (int)(order.実際出荷数量 / item.PT入数);
            }

            order.仕入金額 = order.実際出荷数量 * order.仕入原価;
            order.粗利金額 = order.納品原価金額 - order.仕入金額;

            // 更新出荷数量后更新运费

            order.運賃 = ComputeFreight( order );
                      
        }

        // 当订单的数量被修改后，需要相应修改的字段
        public static void AfterOrderQtyChanged(v_pendingorder order, t_itemlist item)
        {
            //`原価金額(税抜)`=0 ?

            order.最終出荷数 = order.実際出荷数量;
            order.納品原価金額 = order.実際出荷数量 * order.原単価_税抜_;
            order.原価金額_税込_ = (int)(order.実際出荷数量 * order.原単価_税込_);
            order.税額 = (int)(order.納品原価金額 * order.税率);
            order.重量 = (int)(Convert.ToDecimal(item.単品重量) * order.実際出荷数量);

            if (item.PT入数 > 0)
            {
                order.納品口数 = (int)(order.実際出荷数量 / item.PT入数);
            }
            // 更新出荷数量后更新运费
            order.運賃 = ComputeFreight(order);

        }


        // order status duplicated -> pending
        public static void ChangeOrderStatusToPending(GODDbContext ctx, t_orderdata order)
        {
            order.実際出荷数量 = order.発注数量;
            order.納品口数 = order.口数;
            order.ダブリ = "no";
            order.Status = OrderStatus.Pending;
            var product = ctx.t_itemlist.Find( order.自社コード);
            OrderSqlHelper.AfterOrderQtyChanged(order, product);
            ctx.SaveChanges();
        }


        /// <summary>
        /// 计算运费
        /// </summary>
        /// <param name="order"></param>
        /// <param name="itemprice"> 如果提供itemprice，使用 itemprice中的 fee 计算</param>
        /// <returns></returns>
        public static int ComputeFreight(t_orderdata order, decimal unitfee = 0, string columnname = null) 
        {
            int fee = 0;

            if (columnname == null)
            {
                var freight = GetFreightByOrder(order.店舗コード, order.自社コード, order.warehousename, order.実際配送担当);
                if (freight != null)
                {
                    columnname = freight.columnname;
                    unitfee = freight.fee;
                }
            }
           
            if (columnname != null)
            {
                fee = OrderHelper.ComputeFreight(order, unitfee, columnname);

            }
           
            return fee;
        }

        public static int ComputeFreight(v_pendingorder order, decimal unitfee = 0, string columnname = null)
        {
            int fee = 0;

            if (columnname == null)
            {
                var freight = GetFreightByOrder(order.店舗コード, order.自社コード, order.warehousename, order.実際配送担当);
                if (freight != null)
                {
                    columnname = freight.columnname;
                    unitfee = freight.fee;
                }
            }

            if (columnname != null)
            {
                 
                fee = OrderHelper.ComputeFreight(order, unitfee, columnname);
            }

            return fee;
        }
        

        public static List<v_itemprice> GetItemPriceList(GODDbContext ctx, List<int> productids = null, List<int> shopids = null){
        
//            List<v_itemprice> prices = (from i in ctx.t_itemlist
//                                        join p in ctx.t_pricelist on i.自社コード equals p.自社コード
//                                        join g in ctx.t_genre on i.ジャンル equals g.idジャンル
//                                        join f in ctx.t_freights on
//                                        new { p.transport_id, p.warehouse_id, p.自社コード, shop_id= p.店番 } equals
//                                        new { f.transport_id, f.warehouse_id, f.自社コード, f.shop_id  }
//                                      select new v_itemprice {  
//                                          ジャンル = g.idジャンル, 
//                                          ジャンル名 = g.ジャンル名,
//                                          自社コード = i.自社コード,
//                                          商品コード = i.商品コード,
//                                          JANコード = i.JANコード,
//                                          商品名 = i.商品名,
//                                          規格 = i.規格,
//                                          PT入数 = i.PT入数,
//                                          単品重量 = i.単品重量,
//                                          単位 = i.単位,
//                                          配送担当 = p.配送担当,
//                                          仕入原価 = p.仕入原価,
//                                          原単価 = p.通常原単価,
//                                          売単価 = p.売単価,
//                                          fee = f.fee,
//                                          columnname = f.columnname
//                                      }).ToList();
            string sql = @"select g.idジャンル as ジャンル,  g.ジャンル名, g.社内伝番処理, i.自社コード, i.商品コード, i.JANコード, i.商品名, i.規格,
i.PT入数,i.単品重量, i.単位, p.配送担当, p.仕入原価, p.通常原単価, p.売単価, p.店番, p.県別, p.warehousename, p.warehouse_id, p.配送担当, p.transport_id,  IFNULL(f.fee, -1) as fee,  IFNULL(f.columnname, '') as columnname  
from t_itemlist i
left join  t_pricelist p on i.自社コード = p.自社コード left join t_genre g on i.ジャンル = g.idジャンル 
left join t_freights f on p.transport_id = f.transport_id and p.warehouse_id =f.warehouse_id and p.自社コード =  f.自社コード and f.shop_id= p.店番 ";
            var conditions = new List<string>();
            if (productids != null) {
                conditions.Add(  string.Format("i.自社コード in ({0})", string.Join(",", productids)) );
            }

            if (shopids != null)
            {
                conditions.Add(string.Format("f.shop_id in ({0})", string.Join(",", shopids)));
            }

            if (conditions.Count > 0) {

                sql += string.Format(" where {0}", string.Join(" AND ", conditions ));
            }

            List<v_itemprice> prices = ctx.Database.SqlQuery<v_itemprice>(sql).ToList();
            return prices;

        }
       
        /// <summary>
        /// 取得商店信息，包括location信息
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="shopids"></param>
        /// <returns></returns>
        public static List<v_shop> GetShopList(GODDbContext ctx, List<int> shopids = null)
        {
            string sql = @"select s.店番 as 店番,  s.店名, s.県別, s.customerId, l.id as locationid, 
IFNULL(l.納品場所コード, -1) as 納品場所コード,  IFNULL(l.納品場所名漢字, '') as 納品場所名漢字,  IFNULL(l.納品場所名カナ, '') as 納品場所名カナ
from t_shoplist s
left join  t_locations l on l.店舗コード = s.店番 and l.isdefault=true ";
            var conditions = new List<string>();
            if (shopids != null)
            {
                conditions.Add(string.Format("s.店番 in ({0})", string.Join(",", shopids)));
            }


            if (conditions.Count > 0)
            {

                sql += string.Format(" where {0}", string.Join(" AND ", conditions));
            }

            List<v_shop> prices = ctx.Database.SqlQuery<v_shop>(sql).ToList();
            return prices;
        }

        private static t_freights GetFreightByOrder(int shopId, int productId, string warehousename, string transportname)
        {
            t_freights freight = null;
            using (var ctx = new GODDbContext())
            {

                    freight = (from t_freights t in ctx.t_freights
                               where t.自社コード == productId && t.warehousename == warehousename && t.transportname == transportname && t.shop_id == shopId
                                   select t).FirstOrDefault();                    
            }
            return freight;
        }


       
    }
}