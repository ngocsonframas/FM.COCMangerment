using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace H2T_grp
{
    public partial class frm_DangNhap : Form
    {
        // form 2
        private frm_Home frm_H;
        private bool blogIn;
        public bool LogIn
        {
            get
            {
                return blogIn;
            }
            set
            {
                blogIn = value;
            }
        }
        public frm_DangNhap(frm_Home frm_H)
        {
            InitializeComponent();
            this.frm_H = frm_H;
            // Khou tao company code 
            List<RecordCompanyCode> list = new List<RecordCompanyCode>();
            for (int i = 1; i < 7; i++)
            {
                switch (i)
                {
                    case 1:
                        list.Add(new RecordCompanyCode() { IDCCode = "VNT1", NameCCode = "Framas Viet Nam" });
                        break;
                    case 2:
                        list.Add(new RecordCompanyCode() { IDCCode = "1FFH", NameCCode = "Framas FZ" });
                        break;
                    case 3:
                        list.Add(new RecordCompanyCode() { IDCCode = "05FI", NameCCode = "Framas Indo" });
                        break;
                    case 4:
                        list.Add(new RecordCompanyCode() { IDCCode = "KVT2", NameCCode = "Framas Korea Vina" });
                        break;
                        //case 4:
                        //    list.Add(new RecordCompanyCode() { IDCCode = "0" + i.ToString(), NameCCode = "Lào" });
                        //    break;
                        //case 5:
                        //    list.Add(new RecordCompanyCode() { IDCCode = "0" + i.ToString(), NameCCode = "Đà Nẵng" });
                        //    break;
                        //case 6:
                        //    list.Add(new RecordCompanyCode() { IDCCode = "0" + i.ToString(), NameCCode = "Nguyễn Đình Chiểu" });
                        //    break;

                }
            }
            var recs = from rec in list
                       select rec;
            if (recs.Count() > 0)
                lke_ComCode.Properties.DataSource = recs.ToList();
            lke_ComCode.Properties.DisplayMember = "NameCCode";
            lke_ComCode.Properties.ValueMember = "IDCCode";
            lke_ComCode.EditValue = "VNT1";
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            Program.getInfoApplication();
            txtMSNV.Text = Program.gsAccount;
            txtMM.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            blogIn = false;
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Cls_Main oClsMain = new Cls_Main();
            Contr_DangNhap objCtr = new Contr_DangNhap();

            oClsMain.err_Main += show_err;
            if (oClsMain.ConnectDataBase() == false)
            {
                blogIn = false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtMM.Text))
                {
                    blogIn = false;
                    return;
                }
                objCtr.err_DangNhap += show_err;
                if (objCtr.Test_Password(txtMM.Text, txtMSNV.Text) == true)
                {
                    Cls_FileINI cls = new Cls_FileINI();
                    //GetIni.Get_ini_Cls oGetIni = new GetIni.Get_ini_Cls();
                    //oGetIni.WRITE_KEY_INI(out "user", out "account", out txtAccount.Text, out modBienToanCuc.gsApplicationPath + "\\Extension\\KHKD.ini");
                    cls.WriteValue("user", "account", txtMSNV.Text, Program.gsApplicationPath + "\\Extension\\H2T.ini");
                    Program.gsAccount = txtMSNV.Text;
                    Program.gsUserID = objCtr.LoadUserID();
                    // ktra user co quyen vao site nay ko??
                    if (objCtr.LoadUser_CCode(txtMSNV.Text, lke_ComCode.EditValue.ToString()) == 0)
                    {
                        MessageBox.Show("User have not permission into site (" + lke_ComCode.EditValue.ToString() + ")");
                        return;
                    }
                    Program.gsCompanyCode = lke_ComCode.EditValue.ToString();
                    // Program.gsTranfer = objCtr.Loadtranfer(txtMSNV.Text);
                    ///  oGetIni = null;
                    // goi frm_Home --> goi ham dong.


                    blogIn = true;
                    this.Close();
                    this.Dispose();

                    // goi form Main va` lay' phan` ha`nh
                    frm_Main frmM = new frm_Main();
                    frmM.ShowDialog();
                }
                else
                {
                    if (Program.gcnConnect.State == ConnectionState.Open)
                        Program.gcnConnect.Close();
                    blogIn = false;
                }
            }
        }

        class RecordCompanyCode
        {
            public string IDCCode { get; set; }
            public string NameCCode { get; set; }
        }

        private void show_err(string s)
        {
            MessageBox.Show(s);
        }

        private void txtMSNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab)
                txtMM.Focus();
        }

        private void txtMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab)
                btnDangNhap.Focus();
        }

        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blogIn == true)
            {
                frm_H.Close();
                frm_H.Dispose();
            }
        }
    }
}
