using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RS_Tools.Tools.Inspector
{
    public class InspectorSorter_Launcher : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public InspectorSorter_Launcher()
        {
        }

        protected override void OnClick()
        {
            var form = new InspectorSorter(ArcMap.Application);
            form.ShowDialog();
            return;
        }

        protected override void OnUpdate()
        {
        }
    }
}
