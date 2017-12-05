using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.FileTileOpener
{
    public class FileTileOpenerSettings_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public FileTileOpenerSettings_Button()
        {
        }

        protected override void OnClick()
        {
            RS_Tools.Tools.FileTileOpener.FileTileOpener form = RS_Tools.Tools.FileTileOpener.FileTileOpener.instance;

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
