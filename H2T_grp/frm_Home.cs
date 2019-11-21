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
    public partial class frm_Home : Form
    {
        //form 1
        private frm_DangNhap obj_frm;
        public frm_Home()
        {
            InitializeComponent();
        }
        //obj_frm  = new frm_DangNhap(this);
        private void lblThoat_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void lblQTHT_Click(object sender, EventArgs e)
        {
            lblQTHT.Tag = 1;
            LoadMain((int)lblQTHT.Tag);
        }

        private void lblKDKH_Click(object sender, EventArgs e)
        {
        }

        private void lblKT_Click(object sender, EventArgs e)
        {
            lblKT.Tag = 3;
            LoadMain((int)lblKT.Tag);
        }

        private void lblQTHT_MouseDown(object sender, MouseEventArgs e)
        {
            lblThoat.BorderStyle = BorderStyle.Fixed3D;
        }
        private void LoadMain(int nPhanHanh)
        {
            Program.gnPhanHanh = nPhanHanh;
            if (Login() == true)
            {
                //Program.gnPhanHanh = nPhanHanh;
                this.Close();
                this.Dispose();
            }
            else
            {
                obj_frm.LogIn = false;
            }
        }
        private bool Login()
        {
            try
            {
                obj_frm.ShowDialog();
                if (obj_frm.LogIn == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }

        private void frm_Home_Load(object sender, EventArgs e)
        {
            obj_frm = new frm_DangNhap(this);
        }

        private void lblUSER_Click(object sender, EventArgs e)
        {
            lblUSER.Tag = 2;
            LoadMain((int)lblUSER.Tag);
        }


    }
}
