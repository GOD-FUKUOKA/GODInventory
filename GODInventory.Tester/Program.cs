using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using System.Data.Linq;
using GODInventory.MyLinq;
using GODInventory;
using GODInventory.NAFCO.EDI;
using MySql.Data;
using MySql.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Data.Entity.Validation;
using GODInventory.NAFCO;
using System.Collections;

namespace GODInventory.Tester
{
    class Program
    {

        private static GODDbContext DbContext = new GODDbContext();

        static void Main(string[] args)
        {

            //DbInterception.Add(new EFIntercepterLogging());
            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            
            Console.WriteLine(Properties.Settings.Default.DBConnectionString);
            //DbContext.Database.Log =  Console.Write;
            //ApplicastionCustomInitializer.CreateInstance().Setup();
            Console.WriteLine("hello word!");

            //TestLinq();
            //TestText();
            //BytesRelated();
            //ReadOrderText();
            //ReadReceivedText();

            //ExportASNText();
            TestGenerateMid();
            Console.Read();
            //ApplicastionCustomInitializer.CreateInstance().Down();
        }

        static void TestGenerateMid() {
            ArrayList arr = new ArrayList();
             //(Int64[] rs = new Int64[1000];
          for(var i=0;i<1000; i++){
              var r = NafcoOrderHelper.GenerateMid();
              arr.Add( r );
          }
          int num=0;
          foreach (var s in arr.ToArray().GroupBy(c => c))
            {
                Console.WriteLine(s.Key + "重现了:" + s.Count()+"次");
                if (s.Count()!=1)
                {
                    num += s.Count();
                }
              
            }
            Console.WriteLine("重复出现1次以上的次数和：" + num + "个");

          
        }

        static void TestText() {
            string path = @"D:\项目\在庫管理\translated\data\HACCYU_1.txt";

            //EDITxtHandler.ImportOrderTxt(path);
        }


        static void TestLinq() {
            DbSet <t_orderdata> order_entity = DbContext.t_orderdata;
            List<t_orderdata> orders = order_entity.ToList();
            List<t_shoplist> shops = DbContext.t_shoplist.ToList();
            int count = orders.Count;

            //t_orderdata order = orders.ToArray().First();
            Console.WriteLine("order.count= {0},{1}", count, shops.Count);
            //Console.WriteLine("order.伝票番号= {0}", order.伝票番号);
            //Console.WriteLine("order.shop= {0}", order.t_shoplist.店名);
            var order = orders.First();
            count = OrderSqlHelper.ASNCountByStore( order.法人コード, order.店舗コード );
            Console.WriteLine("asn order.count= {0}", count );

            /*
            IDbSet<GenreEntity> genres = DbContext.Genres;
            GenreEntity genre = genres.Find(1);
            Console.WriteLine("orders.count= {0}, genre.name = #{1}", genre.Id, genre.ジャンル名);
            List<ProductEntity> products = DbContext.Products.ToList();

            Console.WriteLine("products.count= {0}", products.Count);
            ProductsViewModel products2 = new ProductsViewModel();
            Console.WriteLine("products2.count= {0}", products2.Count);

            PendingOrdersViewModel orders = new PendingOrdersViewModel();
            Console.WriteLine("orders.count= {0}", orders.Count);

            IList<OrderEntity>  orders2 = DbContext.Orders.ToList();
            Console.WriteLine("orders2.count= {0}", orders2.Count);
            */
        }

        static void BytesRelated() {
            string s = "abcdef";
            byte[] padding_bytes = EDITxtHandler.PadLeftBytes(Encoding.Default.GetBytes(s), 9);
            //padding_bytes.ToString();
            Console.WriteLine("original string '{0}', padding string = '{1}'", s, Encoding.Default.GetString(padding_bytes));
        }

        static void ReadOrderText()
        {
            List<OrderModel> order_models = new List<OrderModel>();
            string path = @"D:\项目\在庫管理\translated\data\HACCYU_1.txt";


            try
            {
                //byte[] first_line = null;
                //byte[] line = null;
                using (BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    OrderHeadModel order_head = new OrderHeadModel(br);
                    Console.WriteLine(" write head ={0}", order_head.DetailCount);
                    for (var i = 0; i < order_head.DetailCount; i++)
                    {
                        var received = new OrderModel(br);
                        order_models.Add(received);
                        Console.WriteLine(" Read {0}/{1}, ", i, order_head.DetailCount);
                    }
                    //while (line = br.ReadBytes(702))
                    //{
                    //}
                }
            }
            catch (EndOfStreamException e)
            {

            }

        }

        static void ReadReceivedText()
        {
            List<ReceivedOrderModel> order_models = new List<ReceivedOrderModel>();
            string path = @"D:\项目\在庫管理\translated\data\JURYOU_2.txt";


            try
            {
                //byte[] first_line = null;
                //byte[] line = null;
                using (BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    ReceivedOrderHeadModel order_head = new ReceivedOrderHeadModel(br);
                    Console.WriteLine(" write head ={0}", order_head.DetailCount);
                    for (var i = 0; i < order_head.DetailCount; i++)
                    {
                        var received = new ReceivedOrderModel(br);
                        order_models.Add(received);
                        Console.WriteLine(" Read {0}/{1}, ", i, order_head.DetailCount);
                    }
                    //while (line = br.ReadBytes(702))
                    //{
                    //}
                }
            }
            catch (EndOfStreamException e)
            {

            }

        }
       
        static void ExportASNText()
        {
            string path = @"D:\项目\在庫管理\translated\data\NYOTEI_exp.txt";
            List<t_orderdata> orders;

            using ( var ctx = new GODDbContext())
            {
                 orders = (from o in ctx.t_orderdata
                         where o.出荷日 != null && !o.受領確認
                         select o).ToList();
            }
                

            using (BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {

                ASNHeadModel order_head = new ASNHeadModel(orders);

                order_head.Serialize( bw);

                Console.WriteLine(" write head ={0}", order_head.DetailCount);
               
            }

        }

        static void ImportOrderTxt(string path)
        {


            //File.ReadAllBytes(path);

            //var lines = ConvertToUtf8Strings(path);
            //List<OrderModel> order_models = new List<OrderModel>();

            //try
            //{
            //    //byte[] first_line = null;
            //    //byte[] line = null;
            //    using (BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            //    {
            //        OrderHeadModel order_head = new OrderHeadModel(br);
            //        Console.WriteLine(" write head ={0}", order_head.DetailCount);

            //        for (var i = 0; i < order_head.DetailCount; i++)
            //        {
            //            order_models.Add(new OrderModel(br));
            //        }
            //        //while (line = br.ReadBytes(702))
            //        //{
            //        //}
            //    }
            //}
            //catch (EndOfStreamException e)
            //{

            //}

            using (var ctx = new GODDbContext())
            {
                try
                {
                    //var orders = order_models.Select(x => x.ConverToEntity());
                    //var result = ctx.Entry(orders.First()).GetValidationResult();
                    //ctx.t_orderdata.AddRange(orders);
                    //ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

    }
}
