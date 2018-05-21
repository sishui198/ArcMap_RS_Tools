using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace RS_Tools.Tools.DomainAppointer
{
    public class Domain_17 : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ApplyDomainDelegate domain;
        public Domain_17()
        {
        }

        protected override void OnClick()
        {
            if (domain != null)
                domain(DomainCode.Code17);
            else
                MessageBox.Show("Initalize Tool Settings");
        }

        protected override void OnUpdate()
        {
        }
    }
}
