using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace H2T_StartUp
{
    public partial class Form1 : Form
    {
        Cls_FileINI cls = new Cls_FileINI();
        Cls_HamTuTao clsH = new Cls_HamTuTao();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Copy();
        }

        private void Copy()
        {
            string gsExePath = null; // duong dan den file exe
            string gsApplicationPath = null; //duong dan ung dung den file bin
            string gsSourcePath = null; //duong dan den source
            int sLc = 0;
            int sSv = 0;

            gsApplicationPath = Application.StartupPath;
            //..\bin
            gsExePath = gsApplicationPath;
            //neu dich thi bo dong duoi va them 2 dau \
            gsApplicationPath = gsApplicationPath + "\\";
            gsExePath = gsExePath + "\\";

            gsSourcePath = cls.ReadValue("Source", "Path", gsApplicationPath + "\\Extension\\Version.ini");
            pcB.Value = 1;
            // exe chay
            sLc = Convert.ToInt32(cls.ReadValue("Source", "EXE", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Source", "EXE", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
               // MessageBox.Show(gsSourcePath);
               // MessageBox.Show(gsApplicationPath);
                File.Copy(gsSourcePath + "\\H2T_grp.exe", gsApplicationPath + "\\H2T_grp.exe", true);

            }
            pcB.Value = 18;
            // cac dll cua tung module 
            // module he thong
            sLc = Convert.ToInt32(cls.ReadValue("Source", "H2T_QuanTri", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Source", "H2T_QuanTri", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
                File.Copy(gsSourcePath + "\\H2T_QuanTri.dll", gsApplicationPath + "\\H2T_QuanTri.dll", true);
            }
            // module Material (Bom+ MRP)
            pcB.Value = 34;
            sLc = Convert.ToInt32(cls.ReadValue("Source", "H2T_Material", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Source", "H2T_Material", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
                File.Copy(gsSourcePath + "\\H2T_Material.dll", gsApplicationPath + "\\H2T_Material.dll", true);
                File.Copy(gsSourcePath + "\\db.mdb", "D:\\db.mdb", true); //gsApplicationPath + 
            }
            pcB.Value = 39;
            sLc = Convert.ToInt32(cls.ReadValue("Source", "H2T_BaseSys", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Source", "H2T_BaseSys", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
                File.Copy(gsSourcePath + "\\H2T_BaseSys.dll", gsApplicationPath + "\\H2T_BaseSys.dll", true);
            }
            pcB.Value = 42;

            // Report
            string[] Files = null;
            string element = null;
            //'Quan tri
            sLc = Convert.ToInt32(cls.ReadValue("Report", "H2T_QuanTri", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Report", "H2T_QuanTri", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
                Files = System.IO.Directory.GetFileSystemEntries(gsSourcePath + "\\Report");
                foreach (string element_loopVariable in Files)
                {
                    element = element_loopVariable;
                    File.Copy(element, gsApplicationPath + "\\Report\\" + element.ToString().Substring(clsH.Len(gsSourcePath + "\\Report"), clsH.Len(element.ToString()) - clsH.Len(gsSourcePath + "\\Report")), true);
                }
            }
            pcB.Value = 80;
            //'H2T_Material
            sLc = Convert.ToInt32(cls.ReadValue("Report", "H2T_Material", gsApplicationPath + "\\Extension\\Version.ini"));
            sSv = Convert.ToInt32(cls.ReadValue("Report", "H2T_Material", gsSourcePath + "\\Extension\\Version.ini"));
            if (sLc != sSv)
            {
                Files = System.IO.Directory.GetFileSystemEntries(gsSourcePath + "\\Report");
                foreach (string element_loopVariable in Files)
                {
                    element = element_loopVariable;
                    File.Copy(element, gsApplicationPath + "\\Report\\" + element.ToString().Substring(clsH.Len(gsSourcePath + "\\Report"), clsH.Len(element.ToString()) - clsH.Len(gsSourcePath + "\\Report")), true);
                }
            }
            pcB.Value = 90;
            //COPY FILE INI
            System.IO.File.Copy(gsSourcePath + "\\Extension\\Version.ini", gsApplicationPath + "\\Extension\\Version.ini", true);
            pcB.Value = 100;

            pcB.Visible = false;
            //cap nhat ten server chua databse vao file H2T.ini
            string sS = null;
            sS = cls.ReadValue("System", "ServerDB", gsSourcePath +  "\\Extension\\H2T.ini");
            cls.WriteValue("System", "ServerDB", sS, gsApplicationPath + "\\Extension\\H2T.ini");
            sS = cls.ReadValue("System", "ConnectionString", gsSourcePath + "\\Extension\\H2T.ini");
            sS.Replace("computername", Environment.GetEnvironmentVariable("COMPUTERNAME"));
            cls.WriteValue("System", "ConnectionString", sS, gsApplicationPath + "\\Extension\\H2T.ini");

            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = gsExePath + "\\H2T_grp.exe";
            Proc.Start();

            this.Close();
            this.Dispose();
        }
    }
}
