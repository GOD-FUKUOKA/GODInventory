﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    public enum OrderStatus { New = 0, Pending = 1, WaitToShip = 3, PendingShipment = 5, ASN = 6, Received = 8, Completed = 10, Cancelled = 14 }
}
