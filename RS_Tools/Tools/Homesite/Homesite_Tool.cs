using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Desktop.AddIns;

namespace RS_Tools.Tools.Homesite
{
    public class Homesite_Tool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private static RS_Tools.Tools.Homesite.Homesite _form;
        //ICommandItem _previousCommand = null;
        public Homesite_Tool()
        {
            _form = RS_Tools.Tools.Homesite.Homesite.instance;
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);
            _form.CreateHomesite(arg.X, arg.Y);
            
            /// This was to allow for continual use of the tool
            //ArcMap.Application.CurrentTool = _previousCommand;
        }

        protected override void OnUpdate()
        {

        }
    }

}
