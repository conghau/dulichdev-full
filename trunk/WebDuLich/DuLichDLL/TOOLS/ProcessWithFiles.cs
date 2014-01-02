using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuLichDLL.TOOLS
{
    public class ProcessWithFiles
    {
        public bool DeleteFile(string filepath)
        {
            // Delete a file by using File class static method... 
            if (System.IO.File.Exists(filepath))
            {
                // Use a try block to catch IOExceptions, to 
                // handle the case of the file already being 
                // opened by another process. 
                try
                {
                    System.IO.File.Delete(filepath);
                    return true;
                }
                catch (System.IO.IOException)
                {
                    return false;
                }
            }
            return false;

        }
    }
}
