using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.FileTileExister
{
    public class FileTileExister_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public FileTileExister_Button()
        {
        }

        protected override void OnClick()
        {
            FileTileExister_Form form = FileTileExister_Form.instance;

            if (form == null)
            {
                return;
            }
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
