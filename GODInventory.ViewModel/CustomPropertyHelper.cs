using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.ViewModel
{
    public class CustomPropertyHelper
    {
        public static int GetOrderWeekEndDay()
        {
            return Properties.Settings.Default.OrderWeekEndDay;
        }

        public static int SetOrderWeekEndDay(int newEndDay)
        {
            Properties.Settings.Default.OrderWeekEndDay = newEndDay;
            return newEndDay;
        }
    }
}
