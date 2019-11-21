using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2T_Material
{
    public class Cls_ItemColorSize
    {
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string CateID { get; set; }
        public int Kind { get; set; }
        public string ItemNoWL { get; set; }
        public double CycleTime { get; set; }
        //color
        public int ColorID { get; set; }
        public string ColorNo { get; set; }
        public string ColorName { get; set; }
        public string ColorNoWL { get; set; }
        //Size
        public int SizeID { get; set; }
        public string SizeNo { get; set; }
        public string SizeName { get; set; }
        public int FlagICS { get; set; }
        public string ParentItem { get; set; }
        public string CodeColorSize { get; set; }
        public int IDColorSize { get; set; }
        public string SizeNoWL { get; set; }
    }
}
