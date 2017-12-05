using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;


namespace RS_Tools.Tools.FileTileOpener
{
    public class FileTileOpener_Tool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private static RS_Tools.Tools.FileTileOpener.FileTileOpener _form;
        ICommandItem _previousCommand = null;
        public FileTileOpener_Tool()
        {
            _form = RS_Tools.Tools.FileTileOpener.FileTileOpener.instance;
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);
            _form.LoadFile(arg.X, arg.Y);

            ArcMap.Application.CurrentTool = _previousCommand;
        }

        protected override void OnUpdate()
        {
        }
    }
}
