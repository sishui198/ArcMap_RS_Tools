using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RS_Tools.Tools.FileTileLoader
{
    public class FileTileLoader_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public FileTileLoader_Button()
        {
        }

        protected override void OnClick()
        {
            FileTileLoader_Form form = FileTileLoader_Form.instance;

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
