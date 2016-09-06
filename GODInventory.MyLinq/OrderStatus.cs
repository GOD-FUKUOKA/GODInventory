﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    //New = 0,
    public enum OrderStatus { Pending = 0, NotifyShipper = 2, WaitToShip = 3, PendingShipment = 5, ASN = 6, Shipped = 7, Received = 8, Completed = 10, Cancelled = 14, Duplicated = 22 }


    public enum OrderDateEnum { 不限 = 0, 発注日 = 1, 出荷日 = 2, 納品日 = 3 }
}
