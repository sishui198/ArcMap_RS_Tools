using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using RS_Tools.DockWins;


namespace RS_Tools.ToolCollection.ToggleLayers.Selectable
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
                dockWinID.Value = ThisAddIn.IDs.RS_Tools_DockWins_ToggleSelectability_Dock;
                _dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
            }
            if (_dockWindow == null) return;

            ToggleSelectability_Dock.AddinImpl winImpl = AddIn.FromID<ToggleSelectability_Dock.AddinImpl>(ThisAddIn.IDs.RS_Tools_DockWins_ToggleSelectability_Dock);
            ToggleSelectability_Dock toggleselctable = winImpl.UI;

            toggleselctable.ToggleSelectability(1);
        }

        protected override void OnUpdate()
        {
        }
    }
}
