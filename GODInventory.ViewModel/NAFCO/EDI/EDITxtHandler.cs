
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GODInventory.NAFCO.EDI
{
    using GODInventory.MyLinq;
    using System.Data.Entity.Validation;

    public class EDITxtHandler
    {
        public static string ASNFileName = "NYOTEI.txt";
        public static string ASNFolder = "nyotei";

        public static string ASNRelativePath
        {
            get { return Path.Combine(ASNFolder, ASNFileName); }
        }

        public static string NYOTEL_ID
        {
            get { return "C01"; }
        }

        public static int 出荷業務仕入先コード
        {

            get { return 249706; }
        }

        public static int レコード長
        {

            get { return 500; }
        }

        public static byte[] NR = new byte[2] { 0x0D, 0x0A };

        public static Byte[] DateToBytes(DateTime? nullable_datetime)
        {
            DateTime datetime = nullable_datetime ?? DateTime.Now;
            return Encoding.ASCII.GetBytes(datetime.ToString("yyyyMMdd"));
        }
        public static Byte[] TimeToBytes(DateTime datetime)
        {
            return Encoding.ASCII.GetBytes(datetime.ToString("HHmmss"));
        }
        public static Byte[] TimeTo4Bytes(DateTime datetime)
        {
            return Encoding.ASCII.GetBytes(datetime.ToString("HHmm"));
        }

        // lenght(2) => "  "
        public static byte[] GetSpacedBytes(int length)
        {
            List<Byte> list = new List<byte>(length);
            for (var i = 0; i < length; i++)
            {
                list.Add(0x20);
            }
            return list.ToArray();
        }

        // lenght(2) => "00"
        public static byte[] GetZeroedBytes(int length)
        {
            List<Byte> list = new List<byte>(length);
            for (var i = 0; i < length; i++)
            {
                list.Add(0x30);
            }
            return list.ToArray();
        }

        // pad left with ' '
        public static byte[] PadLeftBytes(byte[] bytes, int length)
        {
            List<byte> new_bytes = new List<byte>(length);
            int delta = length - bytes.Length;

            if (delta > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (delta - i > 0)
                    {
                        new_bytes.Add(0x20);
                    }
                    else
                    {
                        new_bytes.Add(bytes[i - delta]);
                    }

                }
                return new_bytes.ToArray();
            }
            else if (delta < 0)
            {
                while (new_bytes.Count < length)
                {
                    new_bytes.Add(bytes[new_bytes.Count]);
                }
                return new_bytes.ToArray();
            }
            else
            {
                return bytes;
            }

        }

        // pad right with ' '
        public static byte[] ShiftJisSpacePadRight(byte[] bytes, int length)
        {

            List<byte> new_bytes = null;
            int delta = length - bytes.Length;

            if (delta > 0)
            {
                new_bytes = new List<byte>(bytes);
                while (new_bytes.Count < length)
                {
                    new_bytes.Add(0x81);
                    new_bytes.Add(0x40);
                }
                return new_bytes.ToArray();
            }
            else if (delta < 0)
            {
                new_bytes = new List<byte>(length);
                while (new_bytes.Count < length)
                {
                    new_bytes.Add(bytes[new_bytes.Count]);
                }
                return new_bytes.ToArray();
            }
            else
            {
                return bytes;
            }
        }

        // pad right with ' '
        public static byte[] PadRightBytes(byte[] bytes, int length)
        {
            List<byte> new_bytes = new List<byte>(length);
            int delta = length - bytes.Length;

            if (delta > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i < bytes.Length)
                    {
                        new_bytes.Add(bytes[i]);
                    }
                    else
                    {
                        new_bytes.Add(0x20);
                    }
                }
                return new_bytes.ToArray();
            }
            else if (delta < 0)
            {
                while (new_bytes.Count < length)
                {
                    new_bytes.Add(bytes[new_bytes.Count]);
                }
                return new_bytes.ToArray();
            }
            else
            {
                return bytes;
            }

        }

        public static bool IsSpaceOnly(byte[] bytes)
        {
            bool allspace = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] != 0x20)
                {
                    allspace = false;
                    break;
                }
            }
            return allspace;
        }

        // t_orderdata为内部订单表
        public static ASNHeadModel GenerateASNTxt(string path, List<t_orderdata> orders)
        {
            var directory_path = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory_path))
            {
                Directory.CreateDirectory(directory_path);
            }


            ASNHeadModel order_head;
            using (BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {

                order_head = new ASNHeadModel(orders);

                order_head.Serialize(bw);

                Console.WriteLine(" write head ={0}", order_head.DetailCount);
            }

            return order_head;
        }


        public static string BuildASNFilePath(long mid)
        {

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EDITxtHandler.ASNFolder, "NYOTEI_" + mid.ToString() + ".txt");
        }

     
        // get ship no for order  
        public static long GenerateEDIShipNO(GODDbContext ctx, t_orderdata order)
        {
            //一般六个月不能重复。
            var date = DateTime.Now.AddMonths(-6);
            //var orders = (from t_orderdata o in ctx.t_orderdata
            //              where order_ids.Contains(o.id受注データ)
            //              select o).ToList();

            //var grouped_orders = orders.GroupBy( o => new { o.法人コード, o.店舗コード }, o=>o );

            string sql = "SELECT max(`出荷No`) as chuHeNo FROM t_orderdata WHERE `店舗コード`={0} AND `法人コード`={1} AND `発注日`>{2} ";

            //int count = (from t_orderdata o in ctx.t_orderdata
            //             where o.店舗コード == order.店舗コード && o.法人コード == order.法人コード && o.発注日 > date
            //             group o by o.出荷No into g
            //             select g
            //        ).Count();

            var max = ctx.Database.SqlQuery<long>(sql, order.店舗コード, order.法人コード, date).FirstOrDefault();
            long chuHeNo = 0;
            if ( max == 0)
            {                 
                string s = String.Format("{0}{1}{2}{3}{4}", order.法人コード.ToString("D2"), order.店舗コード.ToString("D3"), EDITxtHandler.出荷業務仕入先コード, "03", ( 1).ToString("D5"));
                chuHeNo = Convert.ToInt64(s);
            }
            else {
                chuHeNo = max + 1;
            }
            return chuHeNo;
        }

       
        // generate 管理連番  length = 13 
        public static long GenerateMID(GODDbContext ctx)
        {

            int count = 0;
            var today = DateTime.Now.Date;
            var tommorrow = today.AddDays(1);
            count = (from t_edidata o in ctx.t_edidata
                     where o.created_at >= today && o.created_at < tommorrow && o.データID == "CH1"
                     select o).Count();


            var s = today.ToString("yyyyMMdd") + (count + 1).ToString("D5");
            return Convert.ToInt64(s);
        }

        //public static string GenerateMID()
        //{
        //    string s;           
        //    using (var ctx = new GODDbContext())
        //    {
        //        s = GenerateMID(ctx);
        //    }
        //    return s;
        //}

        private static string[] ConvertToUtf8Strings(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string text_in_utf8 = EncodingUtility.ConvertShiftJisToUtf8(bytes);
            return text_in_utf8.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }


        //说 明：Encoding.Default.GetByteCount(c.ToString());会返回字符占用的空间个数，返回1表示半角，返回2表示 全角，测试通过
        /// <summary>
        /// 根据GetByteCount返回的值判断半角和全角
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsAllQuanjiaoJapan(string parStr)
        {
            foreach (char c in parStr.ToCharArray())
            {
                int k = Encoding.Default.GetByteCount(c.ToString());  //k=1 半角  k=2全角
                if (k == 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
