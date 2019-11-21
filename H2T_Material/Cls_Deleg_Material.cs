using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H2T_Material
{
    public delegate void Material_fireEventTransferData(object sender, M_TransferDataEventArgs e);

    public class M_TransferDataEventArgs : EventArgs
    {

        //use for Item
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string AllData { get; set; }

        // use for MRP

        public string PoNum { get; set; }
        public int OrderID { get; set; }
        public string ItemNo_MRP { get; set; }
        public string ItemName_MRP { get; set; }
        public string ColorName_MRP { get; set; }
        public string SizeName_MRP { get; set; }
        public long ItemColorID_MRP { get; set; }
        public long ItemSizeID_MRP { get; set; }

        // use for Color Item
        public string ColorName { get; set; }
        public string ColorNo { get; set; }
        public long ItemColorID { get; set; }

    }
}
