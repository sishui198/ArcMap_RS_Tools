using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.AutoSave
{
    public class AutoSaveSettings : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private static AutoSave form;
        public AutoSaveSettings()
        {
        }

        protected override void OnClick()
        {
            if (form == null)
            {
                form = new AutoSave(ArcMap.Application);
                form.ShowDialog();
                return;
            }
            if (form == null) return;

            form.ShowDialog();
        }

        protected override void OnUpdate()
        {
        }
    }
}
