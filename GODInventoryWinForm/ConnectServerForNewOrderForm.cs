﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class ConnectServerForNewOrderForm : Form
    {
        public ConnectServerForNewOrderForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
            this.msgLabel.Text = "";
        }
        // TODO
        // 根据当前选择的客户，调用相应的订单接收程序

        private void ReceiveForm_Shown(object sender, EventArgs e)
        {
            long ecode;
            Process proc = null;
            string receive_bat_path = Properties.Settings.Default.NFWEInstallDir + @"\install\receive.bat";
            string receive_log_path = Properties.Settings.Default.NFWEInstallDir + @"\status\status_receive_last.txt";
            if (File.Exists(receive_bat_path))
            {

                try
                {

                    proc = new Process();
                    proc.StartInfo.WorkingDirectory = Properties.Settings.Default.NFWEInstallDir + @"\install";

                    proc.StartInfo.FileName = receive_bat_path;
                    proc.StartInfo.Arguments = string.Format("A01");//this is argument
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                    proc.WaitForExit();
                    ecode = proc.ExitCode;
                    if (ecode == 0)
                    {
                        this.processMsgLabel2.Text = String.Format("{0} 正常終了", DateTime.Now.ToString());
                        if (File.Exists(receive_log_path))
                        {
                            string[] original_messages = File.ReadAllLines(receive_log_path, Encoding.Default);
                            //string msg = ConvertShiftJisToUtf8( File.ReadAllBytes(receive_log_path) );
                            msgLabel.Text = String.Format("{0} {1}", original_messages[0], original_messages[1]);
                            int ireturn = Convert.ToInt16(original_messages[0]);
                            if (ireturn == 0) //正常終了しました
                            {

                            }
                        }
                        string path = Properties.Settings.Default.NFWEInstallDir + @"\haccyu\HACCYU.txt";                        
                        if (File.Exists(path))
                        {
                            new ImportOrderTextForm_Auto( path ).ShowDialog();
                        }
                    }


                    //if (ecode == Process)
                    //lStatus = "起動中"
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                }
            }
            else {
                msgLabel.Text = String.Format("Can not file {0}.", receive_bat_path);
            }
        }
        public string  ConvertShiftJisToUtf8(byte[] shift_jis_bytes) {
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
            Encoding utf8 = Encoding.UTF8;


            // Perform the conversion from one encoding to the other.
            byte[] utf8_bytes = Encoding.Convert(shift_jis, utf8, shift_jis_bytes);

            return utf8.GetString(utf8_bytes);

        }
        public string ConvertUtf8ToShiftJis(string  text )
        {
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
            Encoding utf8 = Encoding.UTF8;

            byte[] utf8_bytes;
            utf8_bytes = utf8.GetBytes(text);
            utf8_bytes = System.Text.Encoding.Convert(utf8, shift_jis, utf8_bytes);
            //返回转换后的字符   
            return shift_jis.GetString(utf8_bytes);

        }

        private void okButton1_Click(object sender, EventArgs e)
        {

        }
        private List<string> GetFileName(string dirPath)
        {
            List<string> FileNameList = new List<string>();
            ArrayList list = new ArrayList();

            if (Directory.Exists(dirPath))
            {
                list.AddRange(Directory.GetFiles(dirPath));
            }
            if (list.Count > 0)
            {
                foreach (object item in list)
                {
                    FileNameList.Add(item.ToString().Replace(dirPath + "\\", ""));
                }
            }

            return FileNameList;
        }
    }
}
