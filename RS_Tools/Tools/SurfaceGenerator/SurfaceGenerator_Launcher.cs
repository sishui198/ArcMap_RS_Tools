using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.SurfaceGenerator
{
    public class SurfaceGenerator_Launcher : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public SurfaceGenerator_Launcher()
        {
        }

        protected override void OnClick()
        {
            new SurfaceGapFix_Beta(ArcMap.Application).ShowDialog();
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }
}
