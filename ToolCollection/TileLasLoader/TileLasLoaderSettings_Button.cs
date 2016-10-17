using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace EsriTools.ToolCollection.TileLasLoader
{
    public class TileLasLoaderSettings_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {


        public TileLasLoaderSettings_Button()
        {
        }

        protected override void OnClick()
        {
            //var form = (EsriTools.Forms.TileLasLoader_Form)Application.OpenForms["TileLasLoader_Form"];
            EsriTools.Forms.TileLasLoader_Form form = EsriTools.Forms.TileLasLoader_Form.instance;

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
