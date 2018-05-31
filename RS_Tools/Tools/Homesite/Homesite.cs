using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using RS_Tools.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_Tools.Tools.Homesite
{
    public partial class Homesite : Form
    {
        #region Properties

        private static volatile Homesite _instance; // instantiating a singleton

        public static Homesite instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Homesite(ArcMap.Application);
                        }
                    }
                }
                return _instance;
            }
        }

        private static object _syncRoot = new object();

        private const string MB_TITLE = "Homesite";

        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private IActiveView _activeView;
        private Utilities_ArcMap _utilitiesArcMap;
        private IEditor3 _editor;

        private int previousFeatureClassIndex = -1; // The index of the combobox

        #endregion

        #region Constructor

        public Homesite()
        {
            InitializeComponent();
        }

        public Homesite(IApplication application)
        {
            _application = application;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActiveView;
            _utilitiesArcMap = new RS_Tools.Utilities.Utilities_ArcMap(_map);

            InitializeComponent();
        }

        #endregion

        #region Events

        private void btn_intialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btn_okay_Click(object sender, EventArgs e)
        {
            previousFeatureClassIndex = cbo_featureclass.SelectedIndex;
            this.Visible = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cbo_featureclass.SelectedIndex = previousFeatureClassIndex;
            this.Visible = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initalizes The Tool
        /// </summary>
        private void Initialize()
        {

            cbo_featureclass.Items.Clear();
            cbo_featureclass.Items.AddRange(_utilitiesArcMap.PolygonLayers().ToArray());

            if (cbo_featureclass.Items.Count > 0)
            {
                cbo_featureclass.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Add Some Polygon Layers to Arcmap", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Checks to see if the correct settings are setup for the tool to run
        /// </summary>
        /// <returns></returns>
        private bool CheckRequirements()
        {
            if (string.IsNullOrEmpty(cbo_featureclass.Text))
            {
                Utilities_MessageBox.ErrorBox("Initialize Tool Settings", MB_TITLE);
                this.Visible = true;
                return false;
            }

            try
            {
                _editor = _utilitiesArcMap.GetEditorFromArcMap(_application as IMxApplication);
                if (_editor == null)
                {
                    Utilities_MessageBox.ErrorBox("Editor version of ArcMap required.", MB_TITLE);
                    return false;
                }
                if (_editor.EditState != esriEditState.esriStateEditing)
                {
                    MessageBox.Show("Start an edit session first.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                IFields fields = _utilitiesArcMap.FeatureLayer(cbo_featureclass.Text)?.FeatureClass?.Fields;
                if (fields == null)
                {
                    Utilities_MessageBox.ErrorBox("Error...Not a feature class", MB_TITLE);
                    return false;
                }
                return true;
            } catch (Exception ex)
            {
                Utilities_MessageBox.ErrorBox(ex.Message, MB_TITLE);
            }
            try
            {
                IFeatureLayer feature_layer = _utilitiesArcMap.FeatureLayer(cbo_featureclass.Text);
                IFeatureClass feature_calss = feature_layer.FeatureClass;
                return true;
            } catch (Exception ex)
            {
                RS_Tools.Utilities.Utilities_MessageBox.ErrorBox(ex.Message, MB_TITLE);
            }
            return false;

        }

        
        /// <summary>
        ///  Used to pass in the X and Y coordiante from the Homesite Tool
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        internal void CreateHomesite(int X, int Y)
        {
            if (CheckRequirements())
            {
                var homesitePolygon = CreateHomesitePolygon(X, Y);

                if (homesitePolygon == null)
                    return;

                StampPolygonIntoHomesiteLayer(homesitePolygon);

                // Refresh the view to see changes;
                _activeView.Refresh();
            }
        }

        /// <summary>
        /// Returns a polygon with a centroid at the given x and y exactly 1 acre in size
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private IPolygon CreateHomesitePolygon(int X, int Y)
        {
            try
            {
                ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = (_application.Document as IMxDocument).ActiveView.ScreenDisplay;
                ESRI.ArcGIS.Geometry.IPoint point = screenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                ITopologicalOperator topologicalOperator = point as ITopologicalOperator;
                IGeometry geometry = topologicalOperator.Buffer(104.3551628); // radius of circle --> envelope is 1 square acre :) 
                IPolygon polygon = geometry as IPolygon;

                // Might be able to skip this
                ISegmentCollection segmentcollection = polygon as ISegmentCollection;
                segmentcollection.SetRectangle(polygon.Envelope);

                return segmentcollection as IPolygon;
            } catch (Exception ex)
            {
                RS_Tools.Utilities.Utilities_MessageBox.ErrorBox(ex.Message, MB_TITLE);
            }
            return null;
        }

        /// <summary>
        /// Will take a given polygon and 'cookie cut' it into the chosen layer
        /// </summary>
        /// <param name="homesite_polygon"></param>
        private void StampPolygonIntoHomesiteLayer(IPolygon homesite_polygon)
        {
            
            try
            {
                IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cbo_featureclass.Text);
                IFeatureClass featureClass = featureLayer.FeatureClass;

                _editor.StartOperation();

                ISpatialFilter spatialFilter = new SpatialFilter();
                spatialFilter.GeometryField = featureClass.ShapeFieldName;
                spatialFilter.Geometry = homesite_polygon;
                spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                IFeatureCursor featureCursor = featureClass.Search(spatialFilter, false);
                IFeature feature = null;

                while ((feature = featureCursor.NextFeature()) != null)
                {
                    ITopologicalOperator topologicalOperator = feature.Shape as ITopologicalOperator;
                    IGeometry geometry = topologicalOperator.Difference(homesite_polygon);
                    IPolygon polygon = geometry as IPolygon;


                    IFeature newFeature = featureClass.CreateFeature();
                    newFeature.Shape = polygon as IPolygon;

                    // This caused a problem with memory allocation. It would not delete the orignal data. 
                    ArrayList fields = _utilitiesArcMap.NumberFieldsWithDomain(featureLayer);

                    // Set the attribute back to the old ones. 
                    foreach (string field in fields)
                    {
                        newFeature.set_Value(newFeature.Fields.FindField(field), feature.get_Value(feature.Fields.FindField(field)));
                    }


                    newFeature.Store();
                    feature.Delete();
                    
                }

                IFeature homesite = featureClass.CreateFeature();
                homesite.Shape = homesite_polygon;
                homesite.Store();

                _editor.StopOperation("Homesite");
            } catch (Exception ex)
            {
                RS_Tools.Utilities.Utilities_MessageBox.ErrorBox(ex.Message, MB_TITLE);
            }
            

            

            
        }

        #endregion    
    }
}
