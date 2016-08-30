using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    //New = 0,
    public enum OrderStatus { Pending = 0, NotifyShipper = 2, WaitToShip = 3, PendingShipment = 5, ASN = 6, Received = 8, Completed = 10, Cancelled = 14, Duplicated = 22 }
}
