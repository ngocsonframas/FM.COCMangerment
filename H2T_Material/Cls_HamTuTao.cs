using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;


namespace H2T_Material
{
    public class Cls_HamTuTao
    {
        public string Right(string param, int length)
        {
            string result = "";
            //do a length check first so we don't  cause an error
            //if length is longer than the string length then just get
            //the whole string.
            if (param.Length > 0)
            {
                if (length > param.Length)
                {
                    length = param.Length;
                }
                //start at the index based on the length of the string minus
                //the specified length and assign it a variable
                result = param.Substring(param.Length - length, length);
            }
            //return the result of the operation
            return result;
        }
        public string Left(string param, int length)
        {
            string result = "";
            //do a length check first so we don't  cause an error
            //if length is longer than the string length then just get
            //the whole string.
            if (param.Length > 0)
            {
                if (length > param.Length)
                {
                    length = param.Length;
                }
                //start at the beginning and get
                //the specified length and assign it a variable
                result = param.Substring(0, length);
            }
            //return the result of the operation
            return result;
        }
        public string Mid(string param, int start, int length)
        {
            string result = "";
            //do a length check first so we don't  cause an error
            //if length is longer than the string length then just get
            //the rest of the string.
            if ((param.Length > 0) && (start < param.Length))
            {
                if (start + length > param.Length)
                {
                    length = param.Length - start;
                }
                result = param.Substring(start, length);
            }
            //return the result of the operation
            return result;
        }
        public string UCase(string param)
        {
            string result = "";
            char[] array = param.ToCharArray();
            if (array.Length >= 1)
            {
                result = param.ToUpper();
            }
            return result;
        }
        /// <summary>
        /// Ham lay du lieu tu dataset dua vao combobox cua system.window.form
        /// </summary>
        /// <param name="vcom"> ten cbo</param>
        /// <param name="ds">dataset</param>
        /// <param name="dMember">gia tri hien thi</param>
        /// <param name="vMember">gia tri ben trong</param>
        public void initCbo(ref System.Windows.Forms.ComboBox vcom, DataSet ds, string dMember, string vMember)
       {
            try
            {
                if (ds == null)
                {
                   vcom.DataSource = null;
              }
               else
                {
                    vcom.DataSource = ds.Tables[0];
                    vcom.ValueMember = vMember;
                    vcom.DisplayMember = dMember;
               }
         }
         catch (Exception)
           {
               MessageBox.Show("Lỗi đưa dữ liệu vào ComBoBox!");
           }

        }
        //public bool FindRow_Grid(ref FpSpread grd, string StrEx, int col)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //        if (grd.ActiveSheet.Cells[i, 1].Text == StrEx)
        //        {
        //            f = true;
        //            break;
        //        }
        //        else
        //            f = false;
        //    }
        //    return f;
        //}
        /// <summary>
        /// lock dong trong grd
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="StrEx"></param>
        /// <param name="col"></param>
        /// <param name="l">lock=true;unlock=false</param>
        /// <returns></returns>
        //public bool LockRow_Grid(ref FpSpread grd, string StrEx, int col,bool l)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //        if (grd.ActiveSheet.Cells[i, col].Text == StrEx)
        //        {
        //            grd.ActiveSheet.Rows[i].Locked = l;
        //            f = true;
        //        }
        //    }
        //    return f;
        //}
        /// <summary>
        /// lock dong trong grd
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="StrEx"></param>
        /// <param name="col"></param>
        /// <param name="l">lock=true;unlock=false</param>
        /// <returns></returns>
        //public bool LockRow_GridCellUL(ref FpSpread grd, string StrEx, int col, bool l, int cellUL, bool lCell)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //        if (grd.ActiveSheet.Cells[i, col].Text == StrEx)
        //        {
        //            grd.ActiveSheet.Rows[i].Locked = l;
        //            grd.ActiveSheet.Cells[i, cellUL].Locked = lCell;
        //            f = true;
        //        }
        //    }
        //    return f;
        //}
        ///// <summary>
        ///// lock column trong grd
        ///// </summary>
        ///// <param name="grd"></param>
        ///// <param name="StrEx"></param>
        ///// <param name="col"></param>
        ///// <param name="l">lock=true;unlock=false</param>
        ///// <returns></returns>
        //public bool LockColumn_Grid(ref FpSpread grd, string StrEx, int col, bool l,int vtricolUN)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //        if (grd.ActiveSheet.Cells[i, col].Text == StrEx)
        //        {
        //            for (int j = 0; j < grd.Sheets[0].ColumnCount - 1; j++)
        //            {
        //                if (j != vtricolUN)
        //                {
        //                    grd.ActiveSheet.Columns[j].Locked = l;//
        //                }
        //            }
        //            f = true;
        //        }
        //    }
        //    return f;
        //}
        ///// <summary>
        ///// lock column trong grd
        ///// </summary>
        ///// <param name="grd"></param>
        ///// <param name="StrEx"></param>
        ///// <param name="col"></param>
        ///// <param name="l">lock=true;unlock=false</param>
        ///// <returns></returns>
        //public bool LockAllColumn_Grid(ref FpSpread grd, bool l, int vtricolUN)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //            for (int j = 0; j < grd.Sheets[0].ColumnCount - 1; j++)
        //            {
        //                if (j != vtricolUN)
        //                {
        //                    grd.ActiveSheet.Columns[j].Locked = l;//
        //                }
        //            }
        //            f = true;
        //    }
        //    return f;
        //}
        /// <summary>
        /// lock Cell trong grd
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="StrEx"></param>
        /// <param name="col"></param>
        /// <param name="l">lock=true;unlock=false</param>
        /// <returns></returns>
        //public bool LockCell_Grid(ref FpSpread grd, string StrEx, int col, bool l, int vtricolUN)
        //{
        //    bool f = false;
        //    for (int i = 0; i <= grd.Sheets[0].RowCount - 1; i++)
        //    {
        //        if (grd.ActiveSheet.Cells[i, col].Text == StrEx)
        //        {
        //            for (int j = 0; j < grd.Sheets[0].ColumnCount - 1; j++)
        //            {
        //                if (j != vtricolUN)
        //                {
        //                    grd.ActiveSheet.Cells[i,j].Locked = l;//
        //                }
        //            }
        //            f = true;
        //        }
        //    }
        //    return f;
        //}
        ///// <summary>
        ///// Ham lam hien thi dong hien hanh thanh ma`u do
        ///// </summary>
        ///// <param name="grd"> luoi can the hien</param>
        ///// <param name="value">gia tri tim` kiem</param>
        ///// <param name="pos">vi tri</param>
        ///// <returns></returns>
        //public int active_grd_Color(ref FpSpread grd, string value, int pos)
        //{
        //    int row = 0;
        //    int col = 0;
        //    int oldrow = grd.ActiveSheet.ActiveRowIndex;
        //    grd.Search(0, value, false, false, false, false, 0, 0, ref row, ref col);
        //    if ((oldrow == -1))
        //        oldrow = 0;
        //    if ((row < 0 | row > grd.ActiveSheet.Rows.Count - 1))
        //        row = oldrow;
        //    for (int i = 0; i <= (grd.ActiveSheet.Rows.Count - 1); i++)
        //    {
        //        if ((grd.ActiveSheet.Cells[i, 1].BackColor.Equals(System.Drawing.Color.Red)))
        //        {
        //            if (i % 2 == 0)
        //            {
        //                grd.ActiveSheet.Cells[i, 1].BackColor = System.Drawing.Color.White;
        //            }
        //            else
        //            {
        //                grd.ActiveSheet.Cells[i, 1].BackColor = System.Drawing.Color.AliceBlue;
        //            }
        //        }
        //    }
        //    grd.ActiveSheet.SetActiveCell(row, 1);
        //    grd.ActiveSheet.Cells[row, 1].BackColor = System.Drawing.Color.Red;
        //    return row;
        //}
        public string NullTextEdit(TextEdit textedit)
        {
            string result = "";
            if (textedit.EditValue == null)
            {
                return result;
            }
            else
            {
                result = textedit.EditValue.ToString().Trim();
            }
            return result;
        }
        /// <summary>
        /// Tao col cho luoi 
        /// </summary>
        /// <param name="dt"> datasource</param>
        /// <param name="gridView1">luoi</param>
        public void CreateGrid(DataTable dt, DevExpress.XtraGrid.Views.Grid.GridView gridView1)

        {
            gridView1.Columns.Clear();
            string[] fields = new string[dt.Columns.Count];
            string[] captions = new string[dt.Columns.Count];
            // String[] str_col = str_Caption.Split(new Char[] { '|' });
            for (int t = 0; t < dt.Columns.Count; t++)
            {
                try
                {
                    fields[t] = dt.Columns[t].ColumnName;
                    captions[t] = dt.Columns[t].Caption;// str_col[t]; //
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = captions[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
        } /// <summary>
        /// set data source for grid
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="_dts"></param>
        public void SetDataSourceGrid(GridControl gridControl, DataSet _dts)
        {
            DataViewManager dvm = new DataViewManager(_dts);
            DataView dv = dvm.CreateDataView(_dts.Tables[0]);
            gridControl.DataSource = dv;
        }
        /// <summary>
        /// Fit column grid
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="gridView"></param>
        public void FitColGird(GridControl gridControl, GridView gridView)
        {
            gridControl.ForceInitialize();
            gridView.BestFitColumns();
            GridViewInfo vInfo = (GridViewInfo)gridView.GetViewInfo();
            int delta = vInfo.ViewRects.ColumnPanelWidth - vInfo.ViewRects.ColumnTotalWidth;
            if (delta > 0)
            {
                delta /= gridView.VisibleColumns.Count;
                foreach (GridColumn column in gridView.Columns)
                {
                    if (column.Visible)
                    {
                        column.Width += delta;
                    }
                }
            }
        }
        /// <summary>
        /// tao col checkbox trong grid 
        /// </summary>
        /// <param name="col1"></param>
        public void CreColCheckBox(GridControl grid, DevExpress.XtraGrid.Columns.GridColumn col1)
        {
            RepositoryItemCheckEdit chk;
            chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = 1;
            chk.ValueUnchecked = 0;
            chk.ValueGrayed = "";
            grid.RepositoryItems.Add(chk);
            col1.ColumnEdit = chk;
        }
        /// <summary>
        /// set thuoc tinh edit nhieu col trong luoi
        /// </summary>
        /// <param name="grv"></param>
        /// <param name="dt"></param>
        /// <param name="f"></param>
        /// <param name="StrCol"></param>
        public void SetStrColEditable(DevExpress.XtraGrid.Views.Grid.GridView grv, bool f, string StrCol)
        {
            // col1.OptionsColumn.AllowEdit = f;
            String[] col = StrCol.Split(new Char[] { ',' });
            foreach (var item in col)
            {
                try
                {
                    grv.Columns.ColumnByFieldName(item.ToString()).OptionsColumn.AllowEdit = f;
                }
                catch (Exception)
                {
                }

            }
        }
        /// <summary>
        /// set thuoc tinh visible cho col in luoi 
        /// </summary>
        /// <param name="grv"></param>
        /// <param name="dt"></param>
        /// <param name="f"></param>
        /// <param name="StrCol"></param>
        public void SetStrColVisible(DevExpress.XtraGrid.Views.Grid.GridView grv, bool f, string StrCol)
        {
            // col1.OptionsColumn.AllowEdit = f;
            String[] col = StrCol.Split(new Char[] { ',' });
            foreach (var item in col)

                try
                {
                    grv.Columns.ColumnByFieldName(item.ToString()).Visible = f;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }
        /// <summary>
        /// kiem tra dataset rong
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns>true:Empty</returns>
        public bool IsEmpty(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
                if (table.Rows.Count != 0)
                    return false;
            return true;
        }
        public string GetSelectedValues_cbo(GridView view, int index)
        {

            if (view.SelectedRowsCount == 0)
                return "";

            const string CellDelimiter = "\t";

            const string LineDelimiter = "\r\n";

            string result = "";

            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {

                int row = view.GetSelectedRows()[i];

                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {

                    result += view.GetRowCellValue(row, view.VisibleColumns[j]);

                    if (j != view.VisibleColumns.Count - 1)

                        result += CellDelimiter;

                }

                if (i != 0)

                    result += LineDelimiter;

            }
            string[] strs;
            strs = result.Split('\t');
            string str = strs[index];
            return str;
        }

        public string GetSelectedValues(GridView view, int index)
        {

            if (view.SelectedRowsCount == 0)
                return "";

            const string CellDelimiter = "\t";

            const string LineDelimiter = "\r\n";

            string result = "";

            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {

                int row = view.GetSelectedRows()[i];

                for (int j = 0; j < view.Columns.Count; j++)
                {

                    result += view.GetRowCellDisplayText(row, view.Columns[j]);

                    if (j != view.Columns.Count - 1)

                        result += CellDelimiter;

                }

                if (i != 0)

                    result += LineDelimiter;

            }
            string[] strs;
            strs = result.Split('\t');
            string str = strs[index];
            return str;

        }
    }
}
