﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{


    public enum StockIoEnum
    {
       全部=0, 入庫 = 1, 出庫 = 2
    }


    public enum StockIoProgressEnum
    {
        完了= 0, 仮 =1
    }

    public enum StockIoClueEnum
    {
        //清点库存(日文： 棚卸)
        棚卸 = 0,
        EDI出荷 = 1
    }

    public enum StockInClueEnum {
        仕入 = 2
    }

    public enum StockStateEnum { 
        あり = 10,
        一部不足 = 1,
        なし = 0,
    }
}
