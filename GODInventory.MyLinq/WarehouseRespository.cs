using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{

    public class WarehouseRespository { 
        
        static List<MockEntity> list;
        static WarehouseRespository()
        {
            list = new List<MockEntity>(10);
            list.Add(new MockEntity { Id = 1, FullName = "GOD" });
            list.Add(new MockEntity { Id = 2, FullName = "MKL " });
            list.Add(new MockEntity { Id = 3, FullName = "マツモト産業" });
        }
        public static List<MockEntity> ToList()
        {

            return list;
        }

        public static string OptionTextAll
        {
            get { return "全部"; }
        }
    }
}
