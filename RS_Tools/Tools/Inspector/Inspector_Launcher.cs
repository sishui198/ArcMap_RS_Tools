using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;

namespace RS_Tools.Tools.Inspector
{
    public class Inspector_Launcher : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private static IDockableWindow s_dockWindow;

        public Inspector_Launcher()
        {
        }

        protected override void OnClick()
        {
            if (s_dockWindow == null)
            {
                UID dockWinID = new UIDClass();
                dockWinID.Value = ThisAddIn.IDs.RS_Tools_Tools_Inspector_Inspector;
                s_dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
            }
            if (s_dockWindow == null)
            {
                return;
            }
            s_dockWindow.Show(!s_dockWindow.IsVisible());
        }

        protected override void OnUpdate()
        {
            if (s_dockWindow == null)
            {
                Enabled = ArcMap.Application != null;
            }
            else
            {
                Checked = s_dockWindow.IsVisible();
            }
        }
    }
}
