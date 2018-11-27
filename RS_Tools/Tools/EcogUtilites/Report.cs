using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_Tools.Tools.EcogUtilites
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        public Report(string report)
        {
            InitializeComponent();

            rtb_report.Text = report;
        }
    }
}
