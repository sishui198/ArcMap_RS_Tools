using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Tools.Utilities
{
    static class Utilities_General
    {
        static public string AddPrefixAndSuffixToFileName(string fileName, string prefix, string suffix)
        {
            string filename = String.Empty;
            string temp = String.Empty;

            if (!String.IsNullOrEmpty(prefix))
            {
                temp = prefix;
                temp = temp.Replace(" ", string.Empty);
                filename += temp;
            }

            filename += fileName;

            if (!String.IsNullOrEmpty(suffix))
            {
                temp = suffix;
                temp = temp.Replace(" ", string.Empty);
                filename += temp;
            }
            return filename;
        }
    }
}
