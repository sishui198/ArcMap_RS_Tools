using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;


namespace RS_Tools.Tools.Inspector
{
    public class OKNextScale : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private static IDockableWindow s_dockWindow;
        public OKNextScale()
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
            if (s_dockWindow == null) return;

            Inspector.AddinImpl winImpl = AddIn.FromID<Inspector.AddinImpl>(ThisAddIn.IDs.RS_Tools_Tools_Inspector_Inspector);
            Inspector inspector = winImpl.UI;

            if (inspector != null)
                inspector.OKNextScale();
            else
            {
                Utilities.Utilities_MessageBox.ErrorBox("Critical Error", "SOORRY!");
            }
        }

        protected override void OnUpdate()
        {
        }
    }
}
