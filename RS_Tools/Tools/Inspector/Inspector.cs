using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using RS_Tools.Utilities;

namespace RS_Tools.Tools.Inspector
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class Inspector : UserControl
    {

        #region User Control
        public Inspector(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private Inspector m_windowUI;

            public Inspector UI { get { return m_windowUI; } }

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new Inspector(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }
        #endregion

        #region Fields
        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private Utilities_ArcMap _utilitiesArcMap;
        private IMxDocument _mxdocument;
        private IEditor3 _editor;
        private double _initialfeaturecount = -1;
        private double _initialcompletedrows = -1;
        private String _status;
        #endregion

        #region Events

        private void BuildingInspector_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void cboBuildingLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_restartreport = true;
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnOKNext_Click(object sender, EventArgs e)
        {
            if (!CheckRequirements()) return;

            ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
            try
            {
                if (buildingslayer != null)
                {
                    int inspectionfieldindex = _utilitiesArcMap.FindField(buildingslayer, "rsi");
                    IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                    IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                    IFeatureSelection buildingsfeatureselection = buildingsfeaturelayer as IFeatureSelection;
                    if (buildingsfeatureselection.SelectionSet.Count > 0)
                        Update(1, buildingsfeaturelayer);

                    IQueryFilter queryfilter = new QueryFilterClass();
                    queryfilter.WhereClause = "\"rsi\" IS NULL";
                    IFeatureCursor featurecursor = buildingsfeatureclass.Search(queryfilter, false);
                    IFeature feature = null;

                    while ((feature = featurecursor.NextFeature()) != null)
                    {
                        IPolygon polygon = feature.Shape as IPolygon;
                        IPolyline polyline = feature.Shape as IPolyline;

                        if ((polygon != null) || (polyline != null))
                        {
                            buildingsfeatureselection.Clear();
                            buildingsfeatureselection.Add(feature);
                            buildingsfeatureselection.SelectionChanged();
                            IEnumGeometry enumgeometry = new EnumFeatureGeometryClass();
                            IEnumGeometryBind enumgeometrybind = enumgeometry as IEnumGeometryBind;
                            enumgeometrybind.BindGeometrySource(null, buildingsfeatureselection.SelectionSet);
                            IGeometryFactory geometryfactory = new GeometryEnvironmentClass();
                            IGeometry geometry = geometryfactory.CreateGeometryFromEnumerator(enumgeometry);

                            IEnvelope envelope = geometry.Envelope;
                            envelope.Expand(2.5, 2.5, true);
                            _activeView.Extent = envelope;
                            _activeView.Refresh();

                            GetStatus();
                            return;

                        }

                        IPoint point = feature.Shape as IPoint;
                        if (point != null)
                        {
                            buildingsfeatureselection.Clear();
                            buildingsfeatureselection.Add(feature);
                            buildingsfeatureselection.SelectionChanged();
                            IEnvelope envelope = _activeView.Extent;
                            envelope.CenterAt(point);
                            _activeView.Extent = envelope;
                            _map.MapScale = 1000;
                            _activeView.Refresh();

                            GetStatus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                //_restartreport = false;
            }
        }

        private void btnDeleteNext_Click(object sender, EventArgs e)
        {
            if (!CheckRequirements()) return;

            ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
            try
            {
                if (buildingslayer != null)
                {
                    int inspectionfieldindex = _utilitiesArcMap.FindField(buildingslayer, "rsi");
                    IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                    IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                    IFeatureSelection buildingsfeatureselection = buildingsfeaturelayer as IFeatureSelection;
                    if (buildingsfeatureselection.SelectionSet.Count > 0)
                        Delete(buildingsfeaturelayer);

                    IQueryFilter queryfilter = new QueryFilterClass();
                    queryfilter.WhereClause = "\"rsi\" IS NULL";
                    IFeatureCursor featurecursor = buildingsfeatureclass.Search(queryfilter, false);
                    IFeature feature = null;

                    while ((feature = featurecursor.NextFeature()) != null)
                    {
                        IPolygon polygon = feature.Shape as IPolygon;

                        buildingsfeatureselection.Clear();
                        buildingsfeatureselection.Add(feature);
                        buildingsfeatureselection.SelectionChanged();
                        IEnumGeometry enumgeometry = new EnumFeatureGeometryClass();
                        IEnumGeometryBind enumgeometrybind = enumgeometry as IEnumGeometryBind;
                        enumgeometrybind.BindGeometrySource(null, buildingsfeatureselection.SelectionSet);
                        IGeometryFactory geometryfactory = new GeometryEnvironmentClass();
                        IGeometry geometry = geometryfactory.CreateGeometryFromEnumerator(enumgeometry);

                        IEnvelope envelope = geometry.Envelope;
                        envelope.Expand(2.5, 2.5, true);
                        _activeView.Extent = envelope;
                        _activeView.Refresh();

                        GetStatus();

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                //_restartreport = false;
            }
        }

        private void btnOKStay_Click(object sender, EventArgs e)
        {
            if (!CheckRequirements()) return;

            ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
            try
            {
                if (buildingslayer != null)
                {
                    int inspectionfieldindex = _utilitiesArcMap.FindField(buildingslayer, "rsi");
                    IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                    IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                    IFeatureSelection buildingsfeatureselection = buildingsfeaturelayer as IFeatureSelection;
                    if (buildingsfeatureselection.SelectionSet.Count > 0)
                        Update(1, buildingsfeaturelayer);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                //_restartreport = false;
            }
        }

        private void btnOKNextScale_Click(object sender, EventArgs e)
        {
            if (!CheckRequirements()) return;

            ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
            try
            {
                if (buildingslayer != null)
                {
                    int inspectionfieldindex = _utilitiesArcMap.FindField(buildingslayer, "rsi");
                    IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                    IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                    IFeatureSelection buildingsfeatureselection = buildingsfeaturelayer as IFeatureSelection;
                    if (buildingsfeatureselection.SelectionSet.Count > 0)
                        Update(1, buildingsfeaturelayer);

                    IQueryFilter queryfilter = new QueryFilterClass();
                    queryfilter.WhereClause = "\"rsi\" IS NULL";
                    IFeatureCursor featurecursor = buildingsfeatureclass.Search(queryfilter, false);
                    IFeature feature = null;

                    while ((feature = featurecursor.NextFeature()) != null)
                    {
                        IPolygon polygon = feature.Shape as IPolygon;
                        IPolyline polyline = feature.Shape as IPolyline;

                        if ((polygon != null) || (polyline != null))
                        {
                            buildingsfeatureselection.Clear();
                            buildingsfeatureselection.Add(feature);
                            buildingsfeatureselection.SelectionChanged();
                            IEnumGeometry enumgeometry = new EnumFeatureGeometryClass();
                            IEnumGeometryBind enumgeometrybind = enumgeometry as IEnumGeometryBind;
                            enumgeometrybind.BindGeometrySource(null, buildingsfeatureselection.SelectionSet);
                            IGeometryFactory geometryfactory = new GeometryEnvironmentClass();
                            IGeometry geometry = geometryfactory.CreateGeometryFromEnumerator(enumgeometry);

                            double scale = _map.MapScale;
                            IEnvelope envelope = geometry.Envelope;
                            _activeView.Extent = envelope;
                            _map.MapScale = scale;
                            _activeView.Refresh();

                            GetStatus();

                            return;
                        }

                        IPoint point = feature.Shape as IPoint;
                        if (point != null)
                        {
                            buildingsfeatureselection.Clear();
                            buildingsfeatureselection.Add(feature);
                            buildingsfeatureselection.SelectionChanged();
                            double scale = _map.MapScale;
                            IEnvelope envelope = _activeView.Extent;
                            envelope.CenterAt(point);
                            _activeView.Extent = envelope;
                            _map.MapScale = scale;
                            _activeView.Refresh();

                            GetStatus();

                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                //_restartreport = false;
            }
        }

        private void btn_CopyStatus_Click(object sender, EventArgs e)
        {
            var clipboardtext = "NO STATUS _ UPDATE";
            if (!String.IsNullOrEmpty(_status))
            {
                clipboardtext = _status;
                if (!String.IsNullOrEmpty(cboBuildingLayer.Text))
                {
                    clipboardtext += " - " + cboBuildingLayer.Text;
                }
            }
            Clipboard.SetText(clipboardtext);

        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _application = this.Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActiveView;

            _utilitiesArcMap = new RS_Tools.Utilities.Utilities_ArcMap(_map);
            if (this.cboBuildingLayer.Items.Count > 0) this.cboBuildingLayer.Items.Clear();
            this.cboBuildingLayer.Items.AddRange(_utilitiesArcMap.PolygonLayers().ToArray());
            this.cboBuildingLayer.Items.AddRange(_utilitiesArcMap.PolylineLayers().ToArray());
            this.cboBuildingLayer.Items.AddRange(_utilitiesArcMap.PointLayers().ToArray());
            if (this.cboBuildingLayer.Items.Count > 0) this.cboBuildingLayer.SelectedIndex = 0;
        }

        private void Update(int status, IFeatureLayer buildingsfeaturelayer)
        {
            //Get the editor
            _editor = GetEditorFromArcMap(_application as IMxApplication);
            if (_editor == null)
            {
                MessageBox.Show("Editor version of ArcMap required.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (_editor.EditState != esriEditState.esriStateEditing)
            {
                MessageBox.Show("Start an edit session first.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            IFeatureSelection featureselection = buildingsfeaturelayer as IFeatureSelection;
            if (featureselection.SelectionSet.Count == 0)
            {
                MessageBox.Show("Select at least one feature.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            IFeatureClass featureclass = buildingsfeaturelayer.FeatureClass;
            IEnumIDs enumIDs = featureselection.SelectionSet.IDs;
            enumIDs.Reset();
            int intOID = enumIDs.Next();
            while (intOID != -1)
            {
                IFeature feature = featureclass.GetFeature(intOID);
                if (feature != null)
                {
                    int inspectionfieldindex = _utilitiesArcMap.FindField(featureclass, "rsi");
                    if (inspectionfieldindex > -1)
                    {
                        _editor.StartOperation();
                        feature.set_Value(inspectionfieldindex, status);
                        _editor.StopOperation("Status updated!" + feature.OID);
                        feature.Store();
                    }
                    else
                    {
                        throw new Exception("Selected layer does not have the 'rsi field'.");
                    }
                }
                intOID = enumIDs.Next();
            }

            _activeView.Refresh();

            GetStatus();
        }

        private void Delete(IFeatureLayer buildingsfeaturelayer)
        {
            //Get the editor
            _editor = GetEditorFromArcMap(_application as IMxApplication);
            if (_editor == null)
            {
                MessageBox.Show("Editor version of ArcMap required.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (_editor.EditState != esriEditState.esriStateEditing)
            {
                MessageBox.Show("Start an edit session first.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            IFeatureSelection featureselection = buildingsfeaturelayer as IFeatureSelection;
            if (featureselection.SelectionSet.Count == 0)
            {
                MessageBox.Show("Select at least one feature.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            IFeatureClass featureclass = buildingsfeaturelayer.FeatureClass;
            IEnumIDs enumIDs = featureselection.SelectionSet.IDs;
            enumIDs.Reset();
            int intOID = enumIDs.Next();
            while (intOID != -1)
            {
                IFeature feature = featureclass.GetFeature(intOID);
                if (feature != null)
                {
                    _editor.StartOperation();
                    feature.Delete();
                    _editor.StopOperation("Status updated!" + feature.OID);
                    feature.Store();
                }
                intOID = enumIDs.Next();
            }

            _activeView.Refresh();
        }

        private bool CheckRequirements()
        {
            try
            {
                if (_utilitiesArcMap == null)
                {
                    _application = this.Hook as IApplication;
                    _mxdocument = (IMxDocument)_application.Document;
                    _map = _mxdocument.FocusMap;
                    _activeView = _mxdocument.ActiveView;
                    if (_utilitiesArcMap == null) _utilitiesArcMap = new Utilities_ArcMap(_map);
                }

                if (this.cboBuildingLayer.Items.Count == 0)
                {
                    MessageBox.Show("Add a layer to inspect to the table of contents", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
                int inspectionfieldindex = _utilitiesArcMap.FindField(buildingslayer, "rsi");
                if (inspectionfieldindex < 0)
                {
                    MessageBox.Show("Add 'rsi' field, short integer!", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                _editor = GetEditorFromArcMap(_application as IMxApplication);
                if (_editor == null)
                {
                    MessageBox.Show("Editor version of ArcMap required.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (_editor.EditState != esriEditState.esriStateEditing)
                {
                    MessageBox.Show("Start an edit session first.", "Building Inspector", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                _initialfeaturecount = buildingsfeatureclass.FeatureCount(null);
                IQueryFilter queryfilter = new QueryFilterClass();
                queryfilter.WhereClause = "\"rsi\" = 1";
                _initialcompletedrows = buildingsfeatureclass.FeatureCount(queryfilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private IEditor3 GetEditorFromArcMap(IMxApplication mxApplication)
        {
            if (mxApplication == null)
            {
                return null;
            }
            ESRI.ArcGIS.esriSystem.UID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "{F8842F20-BB23-11D0-802B-0000F8037368}";
            ESRI.ArcGIS.Framework.IApplication application = mxApplication as ESRI.ArcGIS.Framework.IApplication; // Dynamic Cast
            ESRI.ArcGIS.esriSystem.IExtension extension = application.FindExtensionByCLSID(uid);
            ESRI.ArcGIS.Editor.IEditor3 editor3 = extension as ESRI.ArcGIS.Editor.IEditor3; // Dynamic Cast

            return editor3;
        }

        internal void OKNextScale()
        {
            btnOKNextScale_Click(null, null);
        }

        internal void OKNext()
        {
            btnOKNext_Click(null, null);
        }

        internal void DeleteNext()
        {
            btnDeleteNext_Click(null, null);
        }

        internal void OKStay()
        {
            btnOKStay_Click(null, null);
        }

        internal void GetStatus()
        {
            try
            {
                if (_initialfeaturecount > -1)
                {
                    ILayer buildingslayer = _utilitiesArcMap.Layer(this.cboBuildingLayer.Text);
                    IFeatureLayer buildingsfeaturelayer = buildingslayer as IFeatureLayer;
                    IFeatureClass buildingsfeatureclass = buildingsfeaturelayer.FeatureClass;
                    _initialfeaturecount = buildingsfeatureclass.FeatureCount(null);
                    IQueryFilter queryfilter = new QueryFilterClass();
                    queryfilter.WhereClause = "\"rsi\" = 1";
                    double completedthissession = buildingsfeatureclass.FeatureCount(queryfilter);
                    completedthissession = completedthissession - _initialcompletedrows;
                    double percentcomplete = Math.Round(((completedthissession + _initialcompletedrows) / _initialfeaturecount) * 100, 2);

                    _status = (completedthissession + _initialcompletedrows).ToString() + " of " + _initialfeaturecount.ToString() + " (" + percentcomplete.ToString() + "%)";
                    lblReport.Text = _status;
                }
            } catch (Exception ex)
            {
                string message = ex.Message;
            }
            
        }
        #endregion

    }
}
