using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Framework;

namespace RS_Tools.Tools.CollapseAllLayers
{
    public class CollapseAllLayers : ESRI.ArcGIS.Desktop.AddIns.Button
    {

        #region Properties

        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private IMxDocument _mxdocument;
        private IContentsView _contentsView;

        #endregion

        public CollapseAllLayers()
        {
            _application = this.Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActivatedView;
            _contentsView = _mxdocument.get_ContentsView(0); // The TOC 
        }

        protected override void OnClick()
        {
            ILayer layer = null;
            for (int i = 0; i < _map.LayerCount; i++)
            {
                layer = _map.get_Layer(i);
                CycleLayer(layer);
            }
            _contentsView.Refresh(null);
        }

        protected override void OnUpdate()
        {
        }

        private void CycleLayer(ILayer layer)
        {
            if (layer is IGroupLayer)
            {
                ICompositeLayer group = (ICompositeLayer)layer;
                for (int i = 0; i < group.Count; i++)
                {
                    ILayer groupLayer = group.Layer[i];
                    CycleLayer(groupLayer);
                }
                
            } else
            {
                CollapseGroup(layer);
            }
            

        }

        private void CollapseGroup(ILayer layer)
        {
            try
            {
                ILegendInfo info = (ILegendInfo)layer;
                ILegendGroup group = (ILegendGroup)info.get_LegendGroup(0);
                group.Visible = false;
            }
            catch (Exception) { }
        }
    }
}
 