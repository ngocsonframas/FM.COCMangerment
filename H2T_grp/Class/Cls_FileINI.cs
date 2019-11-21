using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace H2T_grp
{
    class Cls_FileINI
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        //public Cls_FileINI(string thePath)
        //{
        //    this.path = thePath;
        //}

        public string ReadValue(string section, string key, string path)
        {
            StringBuilder tmp = new StringBuilder(225);
            int i = GetPrivateProfileString(section, key, "", tmp, 255, path);
            return tmp.ToString();
        }

        public void WriteValue(string section, string key, string val, string path)
        {
            WritePrivateProfileString(section, key, val, path);
        }
    }
}
