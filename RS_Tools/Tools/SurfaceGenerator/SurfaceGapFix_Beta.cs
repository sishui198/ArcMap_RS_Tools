using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using RS_Tools.Utilities;
using System;
using System.IO;
using System.Windows.Forms;


namespace RS_Tools.Tools.SurfaceGenerator
{
    public partial class SurfaceGapFix_Beta : Form
    {

        #region Fields

        public IApplication _application;
        private IMap _map;
        private IActiveView _activeView;
        private Utilities_ArcMap _utilities;
        private IMxDocument _mxdocument;
        private Util _util;
        private BoundaryProblem _bp;

        #endregion

        #region Constructor
        public SurfaceGapFix_Beta(IApplication application)
        {
            _application = application;
            InitializeComponent();
            _util = new Util();
        }

        #endregion

        #region Events

        private void TileOrganizer_Form_Load(object sender, EventArgs e)
        {
            this.lblVersion.Text = "Version: " + this.ProductVersion;

            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActiveView;

            if (_utilities == null) _utilities = new Utilities_ArcMap(_map);

            this.cboTileLayoutLayer.Items.AddRange(_utilities.PolygonLayers().ToArray());
            if (this.cboTileLayoutLayer.Items.Count > 0) this.cboTileLayoutLayer.SelectedIndex = 0;

            this.tbxLASFolder.Text = _util.LASFOLDER;
            this.tbxLASToolsFolder.Text = _util.LASTOOLSFOLDER;
            this.numProcesses.Value = _util.PROCESSES;

        }

        private void cboTileLayoutLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTileNameField.Items.Count > 0) this.cboTileNameField.Items.Clear();

            this.cboTileNameField.Items.AddRange(_utilities.TextFields(this.cboTileLayoutLayer.Text).ToArray());
            if (this.cboTileNameField.Items.Count > 0) this.cboTileNameField.SelectedIndex = 0;
            if (this.cboTileNameField.Items.IndexOf("Tilename") > -1) this.cboTileNameField.SelectedIndex = this.cboTileNameField.Items.IndexOf("Tilename");

            ILayer tilelayoutlayer = _utilities.Layer(this.cboTileLayoutLayer.Text);
            IFeatureLayer tilelayoutfeaturelayer = tilelayoutlayer as IFeatureLayer;
            IFeatureSelection tilelayoutfeatureselection = tilelayoutfeaturelayer as IFeatureSelection;
            if (tilelayoutfeatureselection.SelectionSet.Count > 0)
            {
                this.chkUseSelected.Text = "Use selection (" + tilelayoutfeatureselection.SelectionSet.Count.ToString() + ")";
                this.chkUseSelected.Checked = true;
                this.chkUseSelected.Enabled = true;
            }
            else
            {
                this.chkUseSelected.Text = "Use selection";
                this.chkUseSelected.Checked = false;
                this.chkUseSelected.Enabled = false;
            }

        }

        private void btnLASFolder_Click(object sender, EventArgs e)
        {
            if (this.tbxLASFolder.Text.Length > 0)
            {
                if (Directory.Exists(this.tbxLASFolder.Text))
                    this.folderBrowserDialog1.SelectedPath = this.tbxLASFolder.Text;
            }
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.tbxLASFolder.Text = this.folderBrowserDialog1.SelectedPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not find folder from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnOpenLASTools_Click(object sender, EventArgs e)
        {
            if (this.tbxLASToolsFolder.Text.Length > 0)
            {
                if (Directory.Exists(this.tbxLASToolsFolder.Text))
                    this.folderBrowserDialog1.SelectedPath = this.tbxLASToolsFolder.Text;
            }
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.tbxLASToolsFolder.Text = this.folderBrowserDialog1.SelectedPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not find folder from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnCreateOverlapMap_Click(object sender, EventArgs e)
        {
            ILayer tilelayoutlayer = _utilities.Layer(this.cboTileLayoutLayer.Text);

            this.btnClose.Enabled = false;
            try
            {
                if (tilelayoutlayer != null)
                {
                    IFeatureLayer tilelayoutfeaturelayer = tilelayoutlayer as IFeatureLayer;
                    IFeatureClass tilelayoutfeatureclass = tilelayoutfeaturelayer.FeatureClass;
                    IFeatureSelection centerlinesfeatureselection = tilelayoutfeaturelayer as IFeatureSelection;

                    int tilenamefieldindex = GDBUtilities.FindField(tilelayoutfeatureclass, this.cboTileNameField.Text);
                    if ((tilenamefieldindex > -1) && (this.tbxLASFolder.Text.Length > 0))
                    {
                        _bp = new BoundaryProblem(_application, _utilities);
                        _bp.Solve(tilelayoutfeaturelayer, tilelayoutfeatureclass, this.tbxLASFolder.Text,
                            this.tbxLASToolsFolder.Text, this.chkUseSelected.Checked, tilenamefieldindex, this.numProcesses.Value);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Boundary Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.btnClose.Enabled = true;
            }
        }

        private void btnRunScripts_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("You are going to run all the scripts. Do you wish to proceed?", "Boundary Problems", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (results == DialogResult.Yes && _bp != null)
            {
                this.btnClose.Enabled = false;
                try
                {
                    _bp.Run(this.tbxLASFolder.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Boundary Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.btnClose.Enabled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TileOrganizer_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _util.LASFOLDER = this.tbxLASFolder.Text;
            _util.LASTOOLSFOLDER = this.tbxLASToolsFolder.Text;
            _util.PROCESSES = this.numProcesses.Value;
            _util.SaveSettings();
        }

        #endregion
    }
}
