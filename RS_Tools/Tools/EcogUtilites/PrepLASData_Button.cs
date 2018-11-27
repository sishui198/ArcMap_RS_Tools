using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.EcogUtilites
{
    public class PrepLASData_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public PrepLASData_Button()
        {
        }

        protected override void OnClick()
        {
            PrepLASData form = PrepLASData.instance;

            if (form == null)
            {
                return;
            }
            if (form.Visible == false) {
                form.Visible = true;
                return;
            }
            form.Visible = false;
        }

        protected override void OnUpdate()
        {
        }
    }
}
