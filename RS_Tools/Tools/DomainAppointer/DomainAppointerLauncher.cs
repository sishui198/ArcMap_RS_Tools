using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;


namespace RS_Tools.Tools.DomainAppointer
{
    public class DomainAppointerLauncher : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private static IDockableWindow s_dockWindow;
        public DomainAppointerLauncher()
        {
        }

        protected override void OnClick()
        {
            UID dockWinUID = new UIDClass();
            dockWinUID.Value = ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_DomainAppointer;
            s_dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinUID);

            if (s_dockWindow == null)
                return;
            s_dockWindow.Show(!s_dockWindow.IsVisible());
        }

        protected override void OnUpdate()
        {
            if (s_dockWindow == null)
                Enabled = ArcMap.Application != null;
            else
                Checked = s_dockWindow.IsVisible();
        }
    }
}
