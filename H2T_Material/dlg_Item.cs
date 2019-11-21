using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace H2T_Material
{
    public partial class dlg_Item : Form
    {
        // khai bao 1 su kien cua delegate
        public event Material_fireEventTransferData fireEventData = null;
        Cls_HamTuTao clsHam = new Cls_HamTuTao();

        public dlg_Item()
        {
            InitializeComponent();
        }
        string txt,param;
        public dlg_Item(string ItemName, string NameForm,string para)
          : this()
        {
            txt = ItemName;
            param = para;
            this.Text = NameForm;
        }
        DataSet ds = new DataSet();
        Info_BoM info = new Info_BoM();
        Cls_HamTuTao cls = new Cls_HamTuTao();
        Cls_HamTuTao cls_h = new Cls_HamTuTao();

        private void dlg_Tooling_Load(object sender, EventArgs e)
        {
            if (this.Text == "ItemNo")
            {
                ds = info.GetItemByID(txt);
            }
            else if (this.Text == "ItemName")
            {
                ds = info.GetItemByName(txt);
            }
            else if (this.Text == "ColorName")
            {
                ds = info.GetColordlgByItem(txt,param);
            }
            //cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cls.initCbo(ref cbo, ctr.LoadToolingByName(txt), "ToolingName", "ToolingID");

            DataViewManager dvManager = new DataViewManager(ds);
            DataView dv = dvManager.CreateDataView(ds.Tables[0]);

            grd.DataSource = dv;
            gridView1.BestFitColumns();
            gridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;

            if (this.Text == "ItemNo")
            {
              // string StrColVis = "ToolingID";
              //  clsHam.SetStrColVisible(gridView1, false, StrColVis);
            }
            else if (this.Text == "ColorName")
            {
                string StrColVis = "ColorNo,ItemColor_ID";
                clsHam.SetStrColVisible(gridView1, false, StrColVis);
            }
           
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }

        private void cbo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.btnClose_Click(sender, e);
            else if (e.KeyCode == Keys.Enter)
            {
                    this.btnOK_Click(sender, e);
            }  else if (e.KeyCode == Keys.Home)
            {
                gridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // truyen data qua form qua su kien cua delegate o day 
            if (fireEventData != null)
            {
                if (this.Text == "ItemNo" || this.Text == "ItemName")
	            {
                    fireEventData(this, new M_TransferDataEventArgs { ItemNo = cls_h.GetSelectedValues(gridView1, 0), ItemName = cls_h.GetSelectedValues(gridView1, 1) });
	            }
                else if (this.Text == "ColorName")
                {
                    fireEventData(this, new M_TransferDataEventArgs { ColorName = cls_h.GetSelectedValues(gridView1, 0), ColorNo = cls_h.GetSelectedValues(gridView1, 1), ItemColorID = long.Parse(cls_h.GetSelectedValues(gridView1,2)) });
                }
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grd_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.btnClose_Click(sender, e);
            else if (e.KeyCode == Keys.Home)
            {
                gridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                    this.btnOK_Click(sender, e);
            }
        }
        int idx = 0;
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            idx = e.RowHandle;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.btnOK_Click(sender, e);
        }

     
    }
}
