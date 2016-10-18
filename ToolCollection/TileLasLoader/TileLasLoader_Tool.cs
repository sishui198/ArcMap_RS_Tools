using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;

namespace EsriTools.ToolCollection.TileLasLoader
{
    public class TileLasLoader_Tool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private static EsriTools.Forms.TileLasLoader_Form _form;
        ICommandItem _previousCommand = null;

        public TileLasLoader_Tool()
        {
            _form = EsriTools.Forms.TileLasLoader_Form.instance;
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);
            _form.LoadLasFile(arg.X, arg.Y);

            // Was Going to be used to reset user back to previous tool but proved to resource exaustive. ie: tracking tools
            ArcMap.Application.CurrentTool = _previousCommand;
        }

    }
}
