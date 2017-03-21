using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using RS_Tools.DockWins;

namespace RS_Tools.ToolCollection.ToggleLayers.Visible
{
    public class Layer1_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {

        private static IDockableWindow _dockWindow;

        public Layer1_Button()
        {
        }

        protected override void OnClick()
        {
            if (_dockWindow == null)
            {
                UID dockWinID = new UIDClass();
                dockWinID.Value = ThisAddIn.IDs.RS_Tools_DockWins_ToggleVisibility_Dock;
                _dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
            }
            if (_dockWindow == null) return;

            ToggleVisibility_Dock.AddinImpl winImpl = AddIn.FromID<ToggleVisibility_Dock.AddinImpl>(ThisAddIn.IDs.RS_Tools_DockWins_ToggleVisibility_Dock);
            ToggleVisibility_Dock togglevisible = winImpl.UI;

            togglevisible.ToggleVisibility(1);
        }

        protected override void OnUpdate()
        {
        }
    }
}
