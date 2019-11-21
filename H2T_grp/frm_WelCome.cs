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
    public partial class frm_WelCome : Form
    {
        public frm_WelCome()
        {
            InitializeComponent();
        }

        private void frm_WelCome_Load(object sender, EventArgs e)
        {
            double i;
            for (i = 0; i <= 8; i += 0.005)
            {
                this.Opacity = i;
                this.Refresh();
            }
            this.Hide();
            // goi form Home
            frm_Home fr_H = new frm_Home();
            fr_H.ShowDialog();
            fr_H.Close();
            fr_H.Dispose();
            //System.Diagnostics.Process.Start(path)
        }

    }
}
