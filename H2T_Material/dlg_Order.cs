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
    public partial class dlg_Order : Form
    {
        // khai bao 1 su kien cua delegate
        public event Material_fireEventTransferData fireEventData = null;
        Cls_HamTuTao clsHam = new Cls_HamTuTao();
        public dlg_Order()
        {
            InitializeComponent();
        }
           string txt;
           public dlg_Order(string PONum)
          : this()
        {
            txt = PONum;
        }
           DataSet ds = new DataSet();
           Info_BoM info = new Info_BoM();
           Cls_HamTuTao cls = new Cls_HamTuTao();
           Cls_HamTuTao cls_h = new Cls_HamTuTao();

        private void btnOK_Click(object sender, EventArgs e)
        {
            // truyen data qua form qua su kien cua delegate o day 
            if (fireEventData != null)
            {
                fireEventData(this, new M_TransferDataEventArgs { PoNum = cls_h.GetSelectedValues(gridView1, 0), OrderID = int.Parse(cls_h.GetSelectedValues(gridView1, 1)), ItemNo_MRP = cls_h.GetSelectedValues(gridView1, 3),
                                                                  ItemName_MRP = cls_h.GetSelectedValues(gridView1, 4),
                                                                  ColorName_MRP = cls_h.GetSelectedValues(gridView1, 5),
                                                                  SizeName_MRP = cls_h.GetSelectedValues(gridView1, 6),
                                                                  ItemColorID_MRP = long.Parse(cls_h.GetSelectedValues(gridView1, 8)),
                });
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlg_Order_Load(object sender, EventArgs e)
        {
            ds = info.GetOrder_PoNumV(txt);
            //cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cls.initCbo(ref cbo, ctr.LoadToolingByName(txt), "ToolingName", "ToolingID");

            DataViewManager dvManager = new DataViewManager(ds);
            DataView dv = dvManager.CreateDataView(ds.Tables[0]);

            grd.DataSource = dv;
            gridView1.BestFitColumns();
            gridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;

            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();

            string StrColVis = "OrderID,ItemColor_ID";
            cls_h.SetStrColVisible(gridView1, false, StrColVis);
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
