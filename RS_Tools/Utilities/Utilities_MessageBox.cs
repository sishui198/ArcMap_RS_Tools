using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_Tools.Utilities
{
    static class Utilities_MessageBox
    {
        static public void ErrorBox(String errorMessage, string mb_title)
        {
            MessageBox.Show(errorMessage, mb_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
