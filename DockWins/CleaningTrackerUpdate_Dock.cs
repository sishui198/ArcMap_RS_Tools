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
    public partial class CleaningTrackerUpdate_Dock : UserControl
    {
        #region UserControl

        public CleaningTrackerUpdate_Dock(object hook)
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
            private CleaningTrackerUpdate_Dock m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new CleaningTrackerUpdate_Dock(this.Hook);
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
        private IList<string> _cleanersValues = new List<string>();
        private const string MB_TITLE = "Cleaning Tracker Updater";

        #endregion

        #region Event(s)

        private void CleaningTrackerUpdateDock_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnIntialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void cboTileLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCleanerName.Items.Count > 0) this.cboCleanerName.Items.Clear();
            this.cboCleaningOrQC.SelectedIndex = 0;
        }

        private void cboCleaningOrQC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCleanerName.Items.Count > 0) this.cboCleanerName.Items.Clear();
            if (this.cboTileLayout.SelectedIndex > -1)
            {
                IFeatureLayer featurelayer = _utilities.FeatureLayer(cboTileLayout.Text);
                if (cboCleaningOrQC.SelectedIndex > 0)
                {
                    IList<string> creatorlist = Get_Creators(featurelayer);
                    foreach (string creator in creatorlist) { this.cboCleanerName.Items.Add(creator); }
                }
            }
        }

        private void btnUpdateTracker_Click(object sender, EventArgs e)
        {
            if (CheckUpdateTrackerRequirements())
            {
                ILayer ilayer = _utilities.Layer(this.cboTileLayout.Text);
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

                if (this.cboCleaningOrQC.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Cleaning or QC", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (this.cboCleanerName.Text.Length == 0)
                {
                    MessageBox.Show("Select Cleaner", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private IList<string> Get_Creators(IFeatureLayer feature_layer)
        {
            try
            {
                _cleanersValues = _utilities.GetCodedDomainItems(feature_layer, "TECH", Classes.Utilities.DomainItemType.Value);
                return _utilities.GetCodedDomainItems(feature_layer, "TECH", Classes.Utilities.DomainItemType.Combined);
            }
            catch (Exception ex){MessageBox.Show(ex.Message);}
            return null;
        }

        private void Update_Tracker(IFeatureLayer feature_layer)
        {
            IFeatureSelection feature_selection = feature_layer as IFeatureSelection;
            IFeatureClass feature_class = feature_layer.FeatureClass;
            IEnumIDs enumIDs = feature_selection.SelectionSet.IDs;
            enumIDs.Reset();
            int intOID = enumIDs.Next();
            int selectedcleanerindex = cboCleanerName.SelectedIndex;

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
                progressdialog.Description = "Updating...(" + processcount + " of " + feature_selection.SelectionSet.Count + " )"; // update the status
                IFeature feature = feature_class.GetFeature(intOID);
                if (feature != null)
                {
                    int completeindex;
                    int techindex;
                    int dateindex;
                    int commentsindex;

                    if (string.Compare(cboCleaningOrQC.Text, "Cleaning", true) == 0)
                    {
                        completeindex = _utilities.FindField(feature_class, "COMPLETE");
                        techindex = _utilities.FindField(feature_class, "TECH");
                        dateindex = _utilities.FindField(feature_class, "DATE");
                        _utilities.WriteValue(_editor, feature, completeindex, 1);
                        _utilities.WriteValue(_editor, feature, techindex, _cleanersValues[selectedcleanerindex]);
                        _utilities.WriteValue(_editor, feature, dateindex, _utilities.GetCurrrentDate());
                    }
                    if (string.Compare(cboCleaningOrQC.Text, "Quality Check", true) == 0)
                    {
                        completeindex = _utilities.FindField(feature_class, "QC_Complete");
                        commentsindex = _utilities.FindField(feature_class, "COMMENTS");
                        _utilities.WriteValue(_editor, feature, completeindex, 1);
                        string commentsoutput = "QC'd by " + _cleanersValues[selectedcleanerindex] + " - " + _utilities.GetCurrrentDate();
                        _utilities.WriteValue(_editor, feature, commentsindex, commentsoutput);
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
