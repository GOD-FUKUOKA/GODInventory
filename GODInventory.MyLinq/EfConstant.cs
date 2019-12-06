using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace GODInventory.MyLinq
{

   public class EfConstant
    {

        const string KEY_64 = "12345678";
        const string IV_64 = "87654321";
       /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["EncryptedGODDbContext"].ConnectionString; ;
                _connectionString = EfConstant.DESDecrypt(_connectionString);
                Console.WriteLine("Connect DB {0}", _connectionString);
                return _connectionString;
            }
        }

        /// <summary>  
        /// C# DES解密方法  
        /// </summary>  
        /// <param name="encryptedValue">待解密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">向量</param>  
        /// <returns>解密后的字符串</returns>  
        public static string DESDecrypt(string encryptedValue )
        {
            using (DESCryptoServiceProvider sa =
                new DESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(KEY_64), IV = Encoding.UTF8.GetBytes(IV_64) })
            {
                //DESCryptoServiceProvider Model CBC  Padding PKCS7
                Console.WriteLine("DESCryptoServiceProvider Model {0}  Padding {1}", sa.Mode.ToString(), sa.Padding.ToString());
                using (ICryptoTransform ct = sa.CreateDecryptor())
                {
                    byte[] byt = Convert.FromBase64String(encryptedValue);

                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(byt, 0, byt.Length);
                            cs.FlushFinalBlock();
                        }
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>  
        /// C# DES加密方法  
        /// </summary>  
        /// <param name="encryptedValue">要加密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">向量</param>  
        /// <returns>加密后的字符串</returns>  
        public static string DESEncrypt(string originalValue )
        {
            using (DESCryptoServiceProvider sa
                = new DESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(KEY_64), IV = Encoding.UTF8.GetBytes(IV_64) })
            {
                using (ICryptoTransform ct = sa.CreateEncryptor())
                {
                    byte[] by = Encoding.UTF8.GetBytes(originalValue);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct,
                                                         CryptoStreamMode.Write))
                        {
                            cs.Write(by, 0, by.Length);
                            cs.FlushFinalBlock();
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }  
    
    }


 
}
