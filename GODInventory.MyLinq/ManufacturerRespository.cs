using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{

    public class ManufactureRespository { 

        static List<MockEntity> list;
        static ManufactureRespository() {
            list = new List<MockEntity>(10);
            list.Add(new MockEntity { Id = 1, FullName = "青島華天" });
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
