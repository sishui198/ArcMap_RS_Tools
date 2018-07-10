using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RS_Tools.Tools.DomainAppointer
{
    public class Domain_Null : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ApplyDomainNullDelegate domain;
        public Domain_Null()
        {
        }

        protected override void OnClick()
        {
            if (domain != null)
                domain();
            else
                MessageBox.Show("Initalize Tool Settings");
        }

        protected override void OnUpdate()
        {
        }
    }
}
