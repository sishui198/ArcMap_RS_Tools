using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.FileTileCloner
{
    public class FileTileCloner_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public FileTileCloner_Button()
        {
        }

        protected override void OnClick()
        {
            FileTileCloner_Form form = FileTileCloner_Form.instance;

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
