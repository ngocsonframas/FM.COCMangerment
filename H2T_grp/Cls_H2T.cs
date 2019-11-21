using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace H2T_grp
{
    public class Cls_H2T
    {
        public int MaPB { get; set; }
        public string UserID { get; set; }
        public string gTime { get; set; }
        public string gDate { get; set; }
        public string ApplicationPath { get; set; }
        public string SourcePath { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public object cnConnect { get; set; }
        public string PhanHanh { get; set; }
        public string Right { get; set; }
        public string SanPhamPath { get; set; }
        public string ConnectionString { get; set; }

        public void ShowForm(string sFormName, Form FRM)
        {
            Cls_HamTuTao cls_Ham = new Cls_HamTuTao();
            string str = cls_Ham.UCase(sFormName);
            Form oForm = null;
            switch (str)
            {
                case "FRM_HOME":
                    FRM.Dispose();
                    // mod_Main.Return_Main();
                    break;
                case "FRM_MAIN":
                    oForm = new frm_Main();
                    break;
            }
            oForm.Show();
        }
    }
}

