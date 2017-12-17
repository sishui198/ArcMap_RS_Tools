using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RS_Tools.Tools.DomainAppointer
{
    public class Domain_12 : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ApplyDomainDelegate domain;
        public Domain_12()
        {
        }

        protected override void OnClick()
        {
            if (domain != null)
            {
                domain(DomainCode.Code12);
            }
            else
            {
                MessageBox.Show("Initialize Tool Settings");
            }
        }

        protected override void OnUpdate()
        {
        }
    }
}
