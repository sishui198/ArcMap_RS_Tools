using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace RS_Tools.ToolCollection.TileLasLoader
{
    public class TileLasLoaderSettings_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {


        public TileLasLoaderSettings_Button()
        {
        }

        protected override void OnClick()
        {
            //var form = (RS_Tools.Forms.TileLasLoader_Form)Application.OpenForms["TileLasLoader_Form"];
            RS_Tools.Forms.TileLasLoader_Form form = RS_Tools.Forms.TileLasLoader_Form.instance;

            if (form == null)
                return;
            // Come Back to this Settings Button Not Popping Up Error
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
