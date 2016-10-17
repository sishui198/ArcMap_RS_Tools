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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;

namespace EsriTools.DockWins
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class HydroTrackerUpdate_Dock : UserControl
    {
        #region User Control

        public HydroTrackerUpdate_Dock(object hook)
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
            private HydroTrackerUpdate_Dock m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new HydroTrackerUpdate_Dock(this.Hook);
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

        #region Field(s)
        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private IMxDocument _mxdocument;
        private IEditor3 _editor;
        private Classes.Utilities _utilities;
        private IList<string> _creatorValues = new List<string>();
        private const string MB_TITLE = "Hydro Tracker Updater";

        #endregion

        #region Event(s)
        private void HydroTrackerUpdateDock_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void cboTileLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCreatorName.Items.Count > 0) this.cboCreatorName.Items.Clear();
            this.cboDrawingOrQC.SelectedIndex = 0;
        }

        private void cboDrawingOrQC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCreatorName.Items.Count > 0) this.cboCreatorName.Items.Clear();
            if (this.cboTileLayout.SelectedIndex > -1)
            {
                IFeatureLayer featurelayer = _utilities.FeatureLayer(cboTileLayout.Text);
                if (cboDrawingOrQC.SelectedIndex > 0)
                {
                    string creatortype = cboDrawingOrQC.Text;
                    IList<string> creatorlist = Get_Creators(featurelayer, creatortype);
                    foreach (string creator in creatorlist) { this.cboCreatorName.Items.Add(creator); }
                }
            }
        }

        private void btnUpdateTracker_Click(object sender, EventArgs e)
        {
            if (CheckUpdateTrackerRequirements())
            {
                ILayer ilayer = _utilities.Layer(this.cboTileLayout.Text); // This is the tile layout feature layer
                IFeatureLayer featurelayer = ilayer as IFeatureLayer;
                if (featurelayer != null)
                {
                    IFeatureSelection featureselection = featurelayer as IFeatureSelection;
                    if (featureselection.SelectionSet.Count > 0)
                        Update_Tracker(featurelayer);
                }
            }
        }

        #endregion

        #region Method(s)

        private void Initialize()
        {
            CheckInitialRequirements();

            // -----------------Use this to set up error message about no layers in the table of contents--------------
            //if (!CheckInitialRequirements())
            //    MessageBox.Show("Add layers", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private bool CheckInitialRequirements()
        {
            _application = this.Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActivatedView;

            _utilities = new Classes.Utilities(_map);

            cboTileLayout.Items.Clear();

            this.cboTileLayout.Items.AddRange(_utilities.PolygonLayers().ToArray());
            if (this.cboTileLayout.Items.Count > 0) this.cboTileLayout.SelectedIndex = 0;

            return (cboTileLayout.Items.Count != 0) ? true : false;
        }

        private bool CheckUpdateTrackerRequirements()
        {
            try
            {

                _editor = _utilities.GetEditorFromArcMap(_application as IMxApplication);

                if (_editor == null)
                {
                    MessageBox.Show("Editor version of ArcMap Required", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (_editor.EditState != esriEditState.esriStateEditing)
                {
                    MessageBox.Show("Start an edit session first", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (this.cboTileLayout.Items.Count == 0)
                {
                    MessageBox.Show("Add polygon layers to the table of contents", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (this.cboDrawingOrQC.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Drawing or QC", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (this.cboCreatorName.Text.Length == 0)
                {
                    MessageBox.Show("Select Creator", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private IList<string> Get_Creators(IFeatureLayer feature_layer, string creatortype)
        {
            try
            {
                if (string.Compare(creatortype, "Drawing", true) == 0)
                {
                    _creatorValues = _utilities.GetCodedDomainItems(feature_layer, "Hydro_Tech", Classes.Utilities.DomainItemType.Value);
                    return _utilities.GetCodedDomainItems(feature_layer, "Hydro_Tech", Classes.Utilities.DomainItemType.Combined);
                }
                if (string.Compare(creatortype, "Quality Check", true) == 0)
                {
                    _creatorValues = _utilities.GetCodedDomainItems(feature_layer, "QC_Tech", Classes.Utilities.DomainItemType.Value);
                    return _utilities.GetCodedDomainItems(feature_layer, "QC_Tech", Classes.Utilities.DomainItemType.Combined);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void Update_Tracker(IFeatureLayer feature_layer)
        {
            IFeatureSelection feature_selection = feature_layer as IFeatureSelection;
            IFeatureClass feature_class = feature_layer.FeatureClass;
            IEnumIDs enumIDs = feature_selection.SelectionSet.IDs;
            enumIDs.Reset();
            int intOID = enumIDs.Next();
            int selectedcreatorindex = cboCreatorName.SelectedIndex;

            int processcount = 1; // labeling the processor bar
            ITrackCancel trackcancel = new CancelTracker();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = feature_selection.SelectionSet.Count;
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Updating...";
            IProgressDialog2 progressdialog = (IProgressDialog2)stepprogressor; // Creates and displays
            progressdialog.CancelEnabled = false;
            progressdialog.Description = "Updating...";
            progressdialog.Title = MB_TITLE;
            progressdialog.Animation = esriProgressAnimationTypes.esriProgressSpiral;
            while (intOID != -1)
            {
                IFeature feature = feature_class.GetFeature(intOID);
                if (feature != null)
                {
                    progressdialog.Description = "Updating...(" + processcount + " of " + feature_selection.SelectionSet.Count + " )"; // update the status
                    int completeindex;
                    int techindex;
                    int dateindex;
                    if (string.Compare(cboDrawingOrQC.Text, "Drawing", true) == 0)
                    {
                        completeindex = _utilities.FindField(feature_class, "Hydro_Complete");
                        techindex = _utilities.FindField(feature_class, "Hydro_Tech");
                        dateindex = _utilities.FindField(feature_class, "Hydro_Date");
                        _utilities.WriteValue(_editor, feature, completeindex, 1);
                        _utilities.WriteValue(_editor, feature, techindex, _creatorValues[selectedcreatorindex]);
                        _utilities.WriteValue(_editor, feature, dateindex, _utilities.GetCurrrentDate());
                    }
                    if (string.Compare(cboDrawingOrQC.Text, "Quality Check", true) == 0)
                    {
                        completeindex = _utilities.FindField(feature_class, "QC_Complete");
                        techindex = _utilities.FindField(feature_class, "QC_Tech");
                        dateindex = _utilities.FindField(feature_class, "QC_Date");
                        _utilities.WriteValue(_editor, feature, completeindex, 1);
                        _utilities.WriteValue(_editor, feature, techindex, _creatorValues[selectedcreatorindex]);
                        _utilities.WriteValue(_editor, feature, dateindex, _utilities.GetCurrrentDate());
                    }
                    stepprogressor.Step(); // step the loading bar on the dialog
                    processcount++; 
                }
                intOID = enumIDs.Next();
            }
            trackcancel = null;
            stepprogressor = null;
            progressdialog.HideDialog();
            progressdialog = null;
            _activeView.Refresh();
        }

        #endregion
    }
}