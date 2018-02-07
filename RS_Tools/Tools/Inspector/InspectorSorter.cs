using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using RS_Tools.Utilities;
using System.Collections.Specialized;

namespace RS_Tools.Tools.Inspector
{
    public partial class InspectorSorter : Form
    {
        public InspectorSorter(IApplication application)
        {
            _application = application;
            InitializeComponent();

        }

        #region Fields
        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private Utilities_ArcMap _utilitiesArcMap;
        private IMxDocument _mxdocument;
        private IEditor3 _editor;
        private List<Dictionary<string, double>> _features = new List<Dictionary<string, double>>();
        private string MB_TITLE = "Inspector Sorter";


        #endregion

        #region Events
        private void InspectorSorter_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btn_GenerateIndex_Click(object sender, EventArgs e)
        {
            if (CheckRequirements())
            {
                if (GenerateFeaturesDictionary())
                {
                    SortFeatures();
                    PopulateFields();
                };
            };
        }
        #endregion

        #region Methods

        private void Initialize()
        {
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActivatedView;

            _utilitiesArcMap = new RS_Tools.Utilities.Utilities_ArcMap(_map);

            if (this.cbo_FeatureLayers.Items.Count > 0) this.cbo_FeatureLayers.Items.Clear();
            cbo_FeatureLayers.Items.AddRange(_utilitiesArcMap.FeatureLayers().Select(item => item.Name).ToArray());
            if (this.cbo_FeatureLayers.Items.Count > 0) this.cbo_FeatureLayers.SelectedIndex = 0;
        }

        private bool CheckRequirements()
        {
            if (!groupCorner.Controls.OfType<RadioButton>().Any(x=> x.Checked)) 
            {
                MessageBox.Show("Select A Corner", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!groupDirection.Controls.OfType<RadioButton>().Any(x => x.Checked))
            {
                MessageBox.Show("Select A Direction", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                if (_utilitiesArcMap == null)
                {
                    _mxdocument = (IMxDocument)_application.Document;
                    _map = _mxdocument.FocusMap;
                    _activeView = _mxdocument.ActiveView;
                    if (_utilitiesArcMap == null) _utilitiesArcMap = new Utilities_ArcMap(_map);
                }

                if (this.cbo_FeatureLayers.Items.Count == 0)
                {
                    MessageBox.Show("Add a layer to inspect to the table of contents", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer((cbo_FeatureLayers.Text));
                if (featureLayer == null)
                {
                    MessageBox.Show("Feature Layer Failed To Load", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                IFeatureClass featureClass = featureLayer.FeatureClass;
                if (featureClass == null)
                {
                    MessageBox.Show("Feature Class Failed To Load", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                ILayer layer = _utilitiesArcMap.Layer(this.cbo_FeatureLayers.Text);
                int inspectionfieldindex = _utilitiesArcMap.FindField(layer, "rsi_index");
                if (inspectionfieldindex < 0)
                {
                    MessageBox.Show("Add 'rsi_index' field, short integer!", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                _editor = _utilitiesArcMap.GetEditorFromArcMap(_application as IMxApplication);
                if (_editor == null)
                {
                    MessageBox.Show("Editor version of ArcMap required.", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (_editor.EditState != esriEditState.esriStateEditing)
                {
                    MessageBox.Show("Start an edit session first.", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool GenerateFeaturesDictionary()
        {

            _features.Clear();


            IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(this.cbo_FeatureLayers.Text);
            try
            {
                if (featureLayer != null)
                {
                    int fieldIndex = _utilitiesArcMap.FindField(featureLayer, "rsi_index");

                    IFeatureCursor featureCursor =  featureLayer.Search(null, false);

                    IFeature feature = null;
                    while ((feature = featureCursor.NextFeature()) != null) {
                        double? x = null;
                        double? y = null;


                        IPolygon polygon = feature.Shape as IPolygon;
                        IPolyline polyline = feature.Shape as IPolyline;
                        if ((polygon != null) || (polyline != null))
                        {
                            IArea area = feature.Shape as IArea;
                            if (area != null)
                            {
                                x = area.Centroid.X;
                                y = area.Centroid.Y;
                            }
                        }
                        IPoint point = feature.Shape as IPoint;
                       
                        if (point != null)
                        {
                            x = point.X;
                            y = point.Y;
                        }
                        
                        if (x == null || y == null)
                        {
                            MessageBox.Show("Feature Had No X,Y Coordinate. Run a repair geometry.", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        _features.Add(new Dictionary<string, double> {
                            {"oid", feature.OID},
                            {"x", (double)x },
                            {"y", (double)y }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MB_TITLE);
                return false;
            }

            return true;
        }

        private void SortFeatures()
        {
            if (rb_BottomLeft.Checked && rb_Column.Checked) // Bottom Left, Columns
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = a["x"].CompareTo(b["x"]);
                    if (xdiff != 0) return xdiff;
                    else return a["y"].CompareTo(b["y"]);
                });
            }

            if (rb_BottomLeft.Checked && rb_Row.Checked) // Bottom Left, Rows
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = a["y"].CompareTo(b["y"]);
                    if (xdiff != 0) return xdiff;
                    else return a["x"].CompareTo(b["x"]);
                });
            }
            
            if (rb_TopRight.Checked && rb_Column.Checked) // Top Right, Columns
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = b["x"].CompareTo(a["x"]);
                    if (xdiff != 0) return xdiff;
                    else return b["y"].CompareTo(a["y"]);
                });
            }

            if (rb_TopRight.Checked && rb_Row.Checked) // Top Right, Rows
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = b["y"].CompareTo(a["y"]);
                    if (xdiff != 0) return xdiff;
                    else return b["x"].CompareTo(a["x"]);
                });
            }

            if (rb_BottomRight.Checked && rb_Column.Checked) // Bottom Right, Columns
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = b["x"].CompareTo(a["x"]);
                    if (xdiff != 0) return xdiff;
                    else return a["y"].CompareTo(b["y"]);
                });
            }

            if (rb_BottomRight.Checked && rb_Row.Checked) // Bottom Right, Rows
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = a["y"].CompareTo(b["y"]);
                    if (xdiff != 0) return xdiff;
                    else return b["x"].CompareTo(a["x"]);
                });
            }

            if (rb_TopLeft.Checked && rb_Column.Checked) // Top Left, Columns
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = a["x"].CompareTo(b["x"]);
                    if (xdiff != 0) return xdiff;
                    else return b["y"].CompareTo(a["y"]);
                });
            }

            if (rb_TopLeft.Checked && rb_Row.Checked) // Top Left, Rows
            {
                _features.Sort(delegate (Dictionary<string, double> a, Dictionary<string, double> b)
                {
                    int xdiff = b["y"].CompareTo(a["y"]);
                    if (xdiff != 0) return xdiff;
                    else return a["x"].CompareTo(b["x"]);
                });
            }

        }

        private void PopulateFields()
        {
            IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cbo_FeatureLayers.Text);
            IFeatureClass featureClass = featureLayer.FeatureClass;

            try
            {
                if (featureLayer != null)
                {
                    int fieldIndex = _utilitiesArcMap.FindField(featureLayer, "rsi_index");

                    _editor.StartOperation();

                    for(var i = 0; i < _features.Count; i++)
                    {

                        double oid = _features[i]["oid"];

                        IFeature feature = featureClass.GetFeature((int)oid);

                        feature.set_Value(fieldIndex, i + 1);
                        feature.Store();

                    }
                    _editor.StopOperation("Generated Indicies");

                }
                
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        
    }
}
