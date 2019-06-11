using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory
{

    // A接收、录入、修改订单数据
    // B打印纳品书
    // C上传发货数据
    // D维护仓库、运输公司信息
    // E确认、修正运费信息
    // F录入及修改入库、出库数据等

    public enum PermissionEnum  {
        AdminOrders = 11,
        DownloadNewOrders = 12,
        DownloadReceivedOrders = 19,
        AdminInventory = 21,
        AdminWarehouses = 31,
        AdminTransports = 41,
        AdminProducts = 51,
        AdminStores = 61,
        AdminSettings = 71,
        AdminOrderImport = 81,

    }


    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class LoginUser
    {
        // 定义一个静态变量来保存类的实例
        private static LoginUser uniqueInstance;

        // 定义私有构造函数，使外界不能创建该类实例
        public v_staffs Current { get; set; }

        private LoginUser()
        {
            
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static LoginUser GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueInstance == null)
            {
                uniqueInstance = new LoginUser();
            }
            return uniqueInstance;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool Can(PermissionEnum permission){
            // admin, officer, sales(可能是总公司，或分公司), 
            if (this.isAdmin())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 取得这个用户负责的店铺
        /// </summary>
        /// <returns> null: 负责所有
        /// </returns>
        public List<int> GetStoreIds() {
            List<int> storeids = null;
            if (this.isSales() && !this.isRootBranch()) {
                storeids = new List<int> { 1, 2, 3, 4, 7, 15, 17, 20, 22, 24, 26, 28, 30 };
            }
            return storeids;        
        }

        /// <summary>
        /// 是否为管理员
        /// </summary>
        /// <returns></returns>
        public bool isAdmin()
        {
            return this.Current.role.Equals("admin");
        }

        /// <summary>
        /// 是否为办公室事务员
        /// </summary>
        /// <returns></returns>
        public bool isOfficer()
        {
            return this.Current.role.Equals("officer");
        }

        /// <summary>
        /// 是否为销售人员
        /// </summary>
        /// <returns></returns>
        public bool isSales()
        {
            return this.Current.role.Equals("sales");
        }

        /// <summary>
        /// 是否来自总公司
        /// </summary>
        /// <returns></returns>
        public bool isRootBranch()
        {
            return this.Current.IsRootBranch;
        }
    }
}
