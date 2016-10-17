using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;


namespace EsriTools.ToolCollection.ToggleLayers.Selectable
{
    public class ToggleSelectabilitySettings_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private static IDockableWindow _dockWindow;


        public ToggleSelectabilitySettings_Button()
        {
        }

        protected override void OnClick()
        {
            if (_dockWindow == null)
            {
                UID dockWinID = new UIDClass();
                dockWinID.Value = ThisAddIn.IDs.EsriTools_DockWins_ToggleSelectability_Dock;
                _dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
            }
            if (_dockWindow == null)
            {
                return;
            }
            _dockWindow.Show(!_dockWindow.IsVisible());
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }
}
