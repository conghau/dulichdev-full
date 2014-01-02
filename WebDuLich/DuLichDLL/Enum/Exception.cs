using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuLichDLL.Enum
{
    public class ExceptionMessage
    {
        public static string throwEx(Exception ex, string method)
        {
            try
            {
                string str = method + "\t" + ex.Message + "\t" + ex.StackTrace;
                return str;
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
