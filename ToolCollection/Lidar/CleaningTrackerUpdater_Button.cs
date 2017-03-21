using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;


namespace RS_Tools.ToolCollection.Lidar
{
    public class CleaningTrackerUpdater_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        #region Field(s)

        private static IDockableWindow _dockWindow;

        #endregion

        #region UserControl

        public CleaningTrackerUpdater_Button()
        {
        }

        #endregion

        #region Event(s)

        protected override void OnClick()
        {
            if (_dockWindow == null)
            {
                UID dockWinID = new UIDClass();
                dockWinID.Value = ThisAddIn.IDs.RS_Tools_DockWins_CleaningTrackerUpdate_Dock;
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

        #endregion
    }
}
