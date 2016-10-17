using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;


namespace EsriTools.ToolCollection.Lidar
{
    public class HydroTrackerUpdater_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        #region Field(s)

        private static IDockableWindow _dockWindow;

        #endregion

        #region UserControl

        public HydroTrackerUpdater_Button()
        {
        }

        #endregion

        #region Event(s)

        protected override void OnClick()
        {
            if (_dockWindow == null)
            {
                UID dockWinId = new UIDClass();
                dockWinId.Value = ThisAddIn.IDs.EsriTools_DockWins_HydroTrackerUpdate_Dock;
                _dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinId);
            }
            if (_dockWindow == null)
                return;

            _dockWindow.Show(!_dockWindow.IsVisible());
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
        #endregion
    }
}
