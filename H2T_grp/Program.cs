using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace H2T_grp
{
    static class Program
    {
        public static int gnPhanHanh;
        //quyen su dung tren menu : "VIEW" va "UPDATE"
        public static string gsRight;
        public static string gsConnectionString;
        public static SqlConnection gcnConnect = new SqlConnection();
        public static string gsAccount;
        //ho ten nguoi dang nhap
        public static string gsUserName;
        //id cua user tren SQLServer
        public static string gsUserID;
        //path chua nguon tren server de load exe chuong trinh
        public static string gsSourcePath;
        //path chua hinh san pham tren server
        public static string gsSanPhamPath;
        //duong dan file exe tren may client
        public static string gsApplicationPath;
        //format : dd/mm/yyyy la ngay cua server
        public static string gsDate;
        //format : hh:mm:ss xxxx la gio tren server
        public static string gsTime;
        //ma phong ban
        public static int gnMaPB;
        public static string gsCompanyCode;
        //ma menu
        public static string gsMenuCode;
        //ma quyen 
        public static string gsQuyenCode;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_WelCome());
        }
        //case "H2T_KHSX.Cls_KHSX":
        //    oProject = new H2T_KHSX.Cls_KHSX();
        //    break;

        //case "H2T_KT.Cls_KT":
        //    oProject = new H2T_KT.Cls_KT();
        //    break;

        public static void getInfoApplication()
        {
            Cls_FileINI cls = new Cls_FileINI();
            Cls_EnDeCrypt objEnDe = new Cls_EnDeCrypt();

            gsApplicationPath = Application.StartupPath;
            string path = gsApplicationPath + "\\Extension\\H2T.ini";
            //..\bin
            //neu dich thi bo dong duoi va them 1 dau \
            //gsApplicationPath = gsApplicationPath & "\"
            //gsApplicationPath = gsApplicationPath.Substring(1, gsApplicationPath.Length - "bin".Length);
            gsApplicationPath = gsApplicationPath.Substring(0, gsApplicationPath.Length - "bin".Length);
            //(gsApplicationPath, 1, Strings.Len(gsApplicationPath) - Strings.Len("bin"));
            //gsConnectionString = objEnDe.Encrypt(cls.ReadValue("system", "ConnectionString", path), true);
            gsConnectionString = objEnDe.Decrypt(cls.ReadValue("system", "ConnectionString", path), true);
            //gsConnectionString = cls.ReadValue("system","ConnectionString",path);
            gsAccount = cls.ReadValue("user",  "Account",  path);
            gsSourcePath = cls.ReadValue( "system",  "ServerSource", path);
            gsSanPhamPath = cls.ReadValue( "system",  "SanPhamPath", path);
        }
        public static Process GetProgramProcess()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(Assembly.GetExecutingAssembly().GetName().Name);
                if (processes.Length > 0)
                {
                    return processes[0];
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public static object GetCPUCounter()
        {
            var cpuCounter = new PerformanceCounter()
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
            dynamic firstvalues = cpuCounter.NextValue();
            Thread.Sleep(1000);
            dynamic secondvalues = cpuCounter.NextValue();
            return secondvalues;
        }
        public static long GetRAMCounter(Process p)
        {
            try
            {
                if (p != null)
                {
                    var ramCounter = new PerformanceCounter
                    {
                        CategoryName = "Process",
                        CounterName = "Working Set - Private",
                        InstanceName = p.ProcessName
                    };
                    return Convert.ToInt64(ramCounter.NextValue());
                }
                return 26214400;
            }
            catch
            {
                return 26214400;
            }
        }
        public static string GetUsageTimeProgram(int secondsInput)
        {
            int hours = 0, minutes = 0;
            string finalHours = "", finalMinutes = "", finalSeconds = "";
            hours = (secondsInput % 3600); finalHours = Convert.ToString(secondsInput / 3600);
            if (finalHours.Trim().Length == 1)
            {
                finalHours = String.Format("0{0}", finalHours);
            }
            minutes = (hours % 60);
            finalMinutes = Convert.ToString(hours / 60);
            if (finalMinutes.Trim().Length == 1)
            {
                finalMinutes = String.Format("0{0}", finalMinutes);
            }
            finalSeconds = Convert.ToString(minutes / 1);
            if (finalSeconds.Trim().Length == 1)
            {
                finalSeconds = String.Format("0{0}", finalSeconds);
            }
            return string.Format("{0}:{1}:{2}", finalHours, finalMinutes, finalSeconds);
        }
    }
}
