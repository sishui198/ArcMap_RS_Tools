using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using RS_Tools.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RS_Tools.Tools.AutoSave
{
    public partial class AutoSave : Form
    {
        #region Fields
        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private IMxDocument _mxdocument;
        IEditor3 _editor;
        private Utilities_ArcMap _utilitiesArcmap;
        private string _targetlayer = string.Empty;
        private bool _dialogdismissed = true;

        private IEditEvents_Event _editEvents;

        #endregion

        #region Constructor

        public AutoSave(IApplication application)
        {
            _application = application;
            InitializeComponent();
            Initialize();
        }

        #endregion

        #region Events

        private void AutoSave_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void numTimeInterval_ValueChanged(object sender, EventArgs e)
        {
            UpdateInterval();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_editor.EditState == esriEditState.esriStateNotEditing)
            {
                MessageBox.Show("Start an edit session first!");
                return;
            }
            UpdateInterval();
            timer1.Enabled = true;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.rdAutoSave.Checked) AutoSave_Save();
            if (this.rdRemindMe.Checked) RemindMe();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _targetlayer = this.cboTargetLayer.Text;
            this.Visible = false;
        }

        #endregion

        #region Methods

        private void Initialize()
        {

            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActiveView;

            _editor = GetEditorFromArcMap(_application as IMxApplication);
            _editEvents = (IEditEvents_Event)_editor;

            _editEvents.OnStopEditing += new IEditEvents_OnStopEditingEventHandler(OnStopEditing);

            _utilitiesArcmap = new Utilities_ArcMap(_map);
            if (this.cboTargetLayer.Items.Count > 0) this.cboTargetLayer.Items.Clear();
            this.cboTargetLayer.Items.AddRange(_utilitiesArcmap.FeatureLayers().Select(item => item.Name).ToArray());
            if (this.cboTargetLayer.Items.Count > 0)
            {
                this.cboTargetLayer.SelectedIndex = 0;
                if (this.cboTargetLayer.Items.IndexOf(_targetlayer) > -1) this.cboTargetLayer.Text = _targetlayer;
            }
        }

        private void UpdateInterval()
        {
            this.timer1.Interval = Decimal.ToInt32(this.numTimeInterval.Value) * 60000;
        }

        private void RemindMe()
        {
            if (!CheckRequirements()) return;
            if (!IsSaveable()) return;

            if (_dialogdismissed == true)
            {
                _dialogdismissed = false;
                DialogResult dialogresult = MessageBox.Show("Time to save your work", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogresult == System.Windows.Forms.DialogResult.OK) _dialogdismissed = true;
            }
        }

        private void AutoSave_Save()
        {
            if (!CheckRequirements()) return;
            if (!IsSaveable()) return;

            ITrackCancel trackcancel = new CancelTrackerClass();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = 1;
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Saving...";
            IProgressDialog2 progressdialog = (IProgressDialog2)stepprogressor; // Creates and displays
            progressdialog.CancelEnabled = true;
            progressdialog.Description = "Saving...";
            progressdialog.Title = "Saving...";
            progressdialog.Animation = esriProgressAnimationTypes.esriDownloadFile;
            try
            {
                ILayer layer = _utilitiesArcmap.Layer(this.cboTargetLayer.Text);
                IFeatureLayer featurelayer = layer as IFeatureLayer;

                if (!(featurelayer == null))
                {
                    IFeatureClass featureclass = featurelayer.FeatureClass;
                    IWorkspace2 workspace = ((IDataset)featureclass).Workspace as IWorkspace2;
                    IWorkspaceEdit2 workspaceedit = (IWorkspaceEdit2)workspace;
                    workspaceedit.StopEditing(true);
                    workspaceedit.StartEditing(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ABE Calculators", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                trackcancel = null;
                stepprogressor = null;
                progressdialog.HideDialog();
                progressdialog = null;
                this.btnClose.Enabled = true;
            }
        }

        private bool CheckRequirements()
        {
            try
            {
                if (_utilitiesArcmap == null)
                {
                    _mxdocument = (IMxDocument)_application.Document;
                    _map = _mxdocument.FocusMap;
                    _activeView = _mxdocument.ActiveView;
                    if (_utilitiesArcmap == null) _utilitiesArcmap = new Utilities_ArcMap(_map);
                }

                if (this.cboTargetLayer.Items.Count == 0) return false;

                

                if (_editor == null) return false;

                if (_editor.EditState != esriEditState.esriStateEditing) return false;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return true;
        }

        private bool IsSaveable()
        {
            if (this.cboTargetLayer.Items.Count == 0) return false;

            ILayer layer = _utilitiesArcmap.Layer(this.cboTargetLayer.Text);
            IFeatureLayer featurelayer = layer as IFeatureLayer;

            if (!(featurelayer == null))
            {
                IFeatureClass featureclass = featurelayer.FeatureClass;
                IWorkspace2 workspace = ((IDataset)featureclass).Workspace as IWorkspace2;
                IWorkspaceEdit2 workspaceedit = (IWorkspaceEdit2)workspace;

                if (!workspaceedit.IsBeingEdited()) return false;

                bool hasedits = false;
                workspaceedit.HasEdits(ref hasedits);
                if (!hasedits) return false;

                if (workspaceedit.IsInEditOperation) return false;

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

        private void OnStopEditing(bool save)
        {
            //btnStop_Click(null, null);
        }


        #endregion
    }
}
