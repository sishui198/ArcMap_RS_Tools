using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.Homesite
{
    public class HomesiteSettings_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public HomesiteSettings_Button()
        {
        }

        protected override void OnClick()
        {
            Homesite form = Homesite.instance;

            if (form == null)
                return;
            if (form.Visible == false)
            {
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
