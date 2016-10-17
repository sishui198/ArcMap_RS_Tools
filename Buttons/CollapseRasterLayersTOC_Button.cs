using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using System.Windows.Forms;


namespace EsriTools.Buttons
{
    public class CollapseRasterLayersTOC_Button : ESRI.ArcGIS.Desktop.AddIns.Button
    {

        #region Properties

        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private IMxDocument _mxdocument;
        private IContentsView _contentsView;

        #endregion

        #region Contructor(s)

        public CollapseRasterLayersTOC_Button()
        {
            _application = this.Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActivatedView;
            _contentsView = _mxdocument.get_ContentsView(0); // The TOC 
        }

        #endregion

        #region Event(s)

        protected override void OnClick()
        {
            // This only goes one layer deep. Needs to be refactored to a recursive function to allow infinite 
            // depth of trees (nodes)
            ILayer layer = null;
            for (int i = 0; i < _map.LayerCount; i++)
            {
                layer = _map.get_Layer(i);
                if (layer is IRasterLayer)
                {
                    try
                    {
                        ILegendInfo info = (ILegendInfo)layer;
                        ILegendGroup group = (ILegendGroup)info.get_LegendGroup(0);
                        group.Visible = false;
                    }
                    catch (Exception) { }
                    
                }
                else if (layer is IGroupLayer)
                {
                    ICompositeLayer cLayer = (ICompositeLayer)layer;
                    for (int j = 0; j < cLayer.Count; j++)
                    {
                        try
                        {
                            layer = cLayer.get_Layer(j);
                            ILegendInfo info = (ILegendInfo)layer;
                            ILegendGroup group = (ILegendGroup)info.get_LegendGroup(0);
                            group.Visible = false;
                        }
                        catch (Exception) { }
                        
                    }
                }
            }
            _contentsView.Refresh(null);
        }

        protected override void OnUpdate()
        {
        }

        #endregion
    }
}
