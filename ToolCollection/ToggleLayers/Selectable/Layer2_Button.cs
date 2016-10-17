using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using EsriTools.DockWins;


namespace EsriTools.ToolCollection.ToggleLayers.Selectable
{
    public class Layer2_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {

        private static IDockableWindow _dockWindow;

        public Layer2_Button()
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
            if (_dockWindow == null) return;

            ToggleSelectability_Dock.AddinImpl winImpl = AddIn.FromID<ToggleSelectability_Dock.AddinImpl>(ThisAddIn.IDs.EsriTools_DockWins_ToggleSelectability_Dock);
            ToggleSelectability_Dock toggleselctable = winImpl.UI;

            toggleselctable.ToggleSelectability(2);
        }

        protected override void OnUpdate()
        {
        }
    }
}
