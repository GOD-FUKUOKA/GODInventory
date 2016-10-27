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
using System.Globalization;
using System.Threading;
using System.Drawing.Text;
using System.Drawing;
using GODInventoryWinForm.Controls;

namespace GODInventoryWinForm
{
    static class Program
    {
        static string Fontitem;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (IsAlreadyRunning())
            {
                MessageBox.Show("受注管理システムすでに実行中です!");
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
            //https://msdn.microsoft.com/en-us/library/dd318661(vs.85).aspx
            //https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx
            //if (Thread.CurrentThread.CurrentCulture.Name != "ja-JP") //zh-CN
            //{
            //    // If current culture is not fr-FR, set culture to fr-FR.
            //    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP");
            //    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("ja-JP");
            //}   
#if DEBUG   
            DbInterception.Add(new EFIntercepterLogging());
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // https://msdn.microsoft.com/en-us/library/system.windows.forms.application.threadexception.aspx
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            #region 字体设置
      

            List<string> list = Fontlist();
            Fontitem = list.Find(s => s.ToString() == "microsoft P Gothic");
            if (Fontitem == null)
                Fontitem = System.Drawing.SystemFonts.DefaultFont.Name;

          //  PendingOrderForm frm = new PendingOrderForm();
          //  frm.Font = new Font(Fontitem, 12);
          //  IterateControlsSetTextBox(frm.Controls, Fontitem);

            #endregion
            Application.Run(new MainForm());

        }

        static void StartDbConfiguration()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DBConfigurationForm());
            MessageBox.Show(String.Format("{0}",
                "データベースに接続できません。設定ファイルInventoryDemo.exe.config中のGOD DBContext内容を修正してください !"));
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


            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windowsフォームに致命的なエラーが発生しました", eventArgs.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Windowsフォームに致命的なエラーが発生しました",
                        "Windowsフォームに致命的なエラーが発生しました", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
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


        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "アプリケーションのエラーが発生しました。システム管理者にご連絡ください " +
                    "以下の情報:\n\n";

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("ユーザ画面には致命的なエラーが発生しました",
                        "イベントログにエラー情報を書き込めませんでした。理由： "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "アプリケーションのエラーが発生しました。システム管理者にご連絡ください" +
                "以下の情報:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nスタックトレース:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }



        //窗体字体设置 
        static void IterateControlsSetTextBox(Control.ControlCollection ctls, string Fontitem)
        {
            foreach (Control control in ctls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Enter += new EventHandler(SetTextBoxOnEnterStyle);
                    (control as TextBox).Leave += new EventHandler(SetTextBoxOnLeaveStyle);
                }
                if (control is Label)
                {
                    (control as Label).Enter += new EventHandler(SetTextBoxOnEnterStyle);
                    (control as Label).Leave += new EventHandler(SetTextBoxOnLeaveStyle);
                    control.Font = new Font(Fontitem, 60);
                }

                if (control.Controls.Count > 0)
                {
                    IterateControlsSetTextBox(control.Controls, Fontitem);
                }
            }
        }
        static void SetTextBoxOnEnterStyle(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
               TextBox tbox = sender as TextBox;
                //if (!tbox.ReadOnly)
                //{
                //    tbox.BackColor = Color.Yellow;
                //}

                tbox.Font = new Font(Fontitem, 12);
            }
            if (sender is Label)
            {
                Label tbox = sender as Label;
                //if (!tbox.ReadOnly)
                //{
                //    tbox.BackColor = Color.Yellow;
                //}
                tbox.Font = new Font(Fontitem, 12);
            }


        }
        static void SetTextBoxOnLeaveStyle(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tbox = sender as TextBox;
                if (!tbox.ReadOnly)
                {
                    //tbox.BackColor = Color.White;
                    tbox.Font = new Font(Fontitem, 12);
                }
            }
        }


        static List<string> Fontlist()
        {
            List<string> list = new List<string>();
            List<object> colorlist = new List<object>();

            InstalledFontCollection MyFont = new InstalledFontCollection();
            FontFamily[] MyFontFamilies = MyFont.Families;

            InstalledFontCollection fc = new InstalledFontCollection();
            foreach (FontFamily font in fc.Families)
            {
                //ListItem tmp = new ListItem(font.Name, font.Name);
                //this.styleFont.Items.Add(tmp);
                list.Add(font.Name);
            }

            Array colors = System.Enum.GetValues(typeof(KnownColor));
            foreach (object colorName in colors)
            {
                //ListItem tmp = new ListItem(colorName.ToString(), colorName.ToString());
                //this.styleColor.Items.Add(tmp);
                colorlist.Add(colorName);
            }
            //System.Drawing.SystemFonts.DefaultFont.Name

            return list;
        }


    }
}
