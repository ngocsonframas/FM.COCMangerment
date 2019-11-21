using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H2T_grp
{
    public class Cls_HamTuTao
    {
        public string Right(string param, int length)
        {
            string result = "";

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
    }
}
