﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    public class ModelCallback
    {
        //新增加店铺时，选择同一县内的已有店铺，将其价格信息复制过去。
        public static t_shoplist AfterStoreCreated(t_shoplist store)
        {
            if (store.参考店舗 > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    List<t_pricelist> newPrices = new List<t_pricelist>();
                    var prices = ctx.t_pricelist.Where(o => o.店番 == store.参考店舗).ToList();
                    foreach (var price in prices)
                    {
                        var newPrice = new t_pricelist()
                        {
                            店番 = store.店番,
                            店名 = store.店名,
                            県別 = store.県別,
                            自社コード = price.自社コード,
                            通常原単価 = price.通常原単価,
                            売単価 = price.売単価
                        };
                        newPrices.Add(newPrice);
                    }
                    ctx.t_pricelist.AddRange(newPrices);
                    ctx.SaveChanges();
                }
            }
            return store;
        }

        //新增商品时，先针对所有店铺按照统一价格增加新记录，再根据需要，对某个县（或某家店）的所有店铺的价格进行修改
        public static t_itemlist AfterProductCreated(t_itemlist product)
        {
            using (var ctx = new GODDbContext())
            {
                List<t_pricelist> newPrices = new List<t_pricelist>();
                var stores = ctx.t_shoplist.ToList();
                foreach (var store in stores)
                {
                    var newPrice = new t_pricelist()
                    {
                        店番 = store.店番,
                        店名 = store.店名,
                        県別 = store.県別,
                        自社コード = product.自社コード,
                        通常原単価 = product.通常原単価,
                        売単価 = product.売単価
                    };
                    newPrices.Add(newPrice);
                }
                ctx.t_pricelist.AddRange(newPrices);
                ctx.SaveChanges();
            }
            return product;
        }
    }
}
