using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDemo.Extentions
{
    public static class FileExtention
    {
        public static string GetThisFilePath([System.Runtime.CompilerServices.CallerFilePath] string path = null)
        {
            return path;
        }
    }
}
