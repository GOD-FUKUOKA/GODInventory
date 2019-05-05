using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GODInventory;
using GODInventory.MyLinq;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Globalization;


/// <summary>
/// NAFCO客户需要的订单管理功能
/// 这里的操作需要查询客户订单表，即t_orderdata
/// </summary>
/// 
namespace GODInventory.NAFCO
{
    public class OrderSqlHelper
    {

        // 把客户订单表中新下载的订单导入到内部订单表中
        // params: 
        //  groupId: 受注管理連番
        public static int ImportOrderFromCusotmerOrders(int groupId)
        {
            //Insert into Table2(field1,field2,...) select value1,value2,... from Table1
            return 0;
        }
       
    }
}