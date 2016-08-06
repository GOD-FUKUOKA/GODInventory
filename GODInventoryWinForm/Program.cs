using GODInventory.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using GODInventory.MyLinq;
using System.IO;
using System.Diagnostics;

namespace GODInventoryWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (IsAlreadyRunning())
            {
                MessageBox.Show("The tool is running!");
                return;
            }

            FileInfo Log4NetFile = new FileInfo("./Log4Net.Config");
            log4net.Config.XmlConfigurator.Configure(Log4NetFile);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);




            Database.SetInitializer<GODDbContext>(null);
            if (DbConnectable())
            {
                LogHelper.WriteLog("Start application GodInventory");
                StartMainForm();
            }
            else
            {

                StartDbConfiguration();
            }



        }

        static void StartMainForm()
        {
#if DEBUG   
            DbInterception.Add(new EFIntercepterLogging());
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.Run(new MainForm());

        }

        static void StartDbConfiguration()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DBConfigurationForm());
            MessageBox.Show(String.Format("{0}",
                "Can not connect to mysql, please correct GODDBContext in file InventoryDemo.exe.config !"));
        }

        static bool DbConnectable()
        {
            bool success = false;
            string msg = "";
            //连接字符串拼装  
            var myconn = new MySqlConnection(DBConfiguration.GetConnectionString("GODDbContext"));


            //连接 
            try
            {
                myconn.Open();

                if (myconn.State.ToString() == "Open")
                {
                    LogHelper.WriteLog("Connect DB successfully");
                    success = true;
                }

            }
            catch (MySqlException exception)
            {
                LogHelper.WriteLog("DB open error", exception);
                LogHelper.WriteLog(string.Format("DB connection string is {0}", DBConfiguration.GetConnectionString("GODDbContext")));
            }
            finally
            {

                myconn.Close();
            }

            return success;
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs eventArgs)
        {
            LogHelper.WriteLog("ThreadException", eventArgs.Exception);
            log4net.ILog objLogger = log4net.LogManager.GetLogger("SystemExceptionLogger");
            string message = string.Format("{0}\r\nThis is serial error， please call system administrator!", eventArgs.Exception.Message);
            MessageBox.Show(message);

            {
                Application.Exit();
            }
        }

      


        static bool IsAlreadyRunning()
        {
            Process processCurrent = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (processCurrent.Id != process.Id)
                {
                    if (processCurrent.ProcessName == process.ProcessName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
