using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H2T_Material
{
    public class Cls_BoM
    {
        // header 
        public long BoMHeaderID { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string ColorName { get; set; }
        public string ColorNo { get; set; }
        public long ItemColorID_Header { get; set; }
        public string TypeBoM { get; set; }
        public string UserCre { get; set; }
        public string DateCre { get; set; }  
        public string Role { get; set; } //1:Insert,2:Update;3:View
        // Color    
        public long BoMColorID { get; set; }
        public long ItemColorID { get; set; }
        public string Remark { get; set; }
        // Size
        public long BoMSizeID { get; set; }
        public string MaterialNo { get; set; }
        public double Weight { get; set; }
        public double WeghitRunner { get; set; }
        public int MachineType { get; set; }
        public double DefectPercent { get; set; }
        public double RecyclePercent  { get; set; }
        public long ParentID { get; set; }
        public double CycleTimeMax { get; set; }
        public long CompItemID { get; set; }
        public long ItemSizeID { get; set; }
        public int level { get; set; } //0:comp; 1:size ; 2:color
    }
}
