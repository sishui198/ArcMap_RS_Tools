using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ookii.Dialogs;
using RS_Tools.Utilities;

namespace RS_Tools.Tools.FileTileOpener
{
    public partial class FileTileOpener : Form
    {

        #region Properties
        private static volatile FileTileOpener _instance;  // Instantiating A Singleton
        public static FileTileOpener instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FileTileOpener(ArcMap.Application);
                    }
                }
                return _instance;
            }
        }

        private static object _syncRoot = new object();
        private const string MB_TITLE = "FTL";
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private Utilities_ArcMap _utilitiesArcMap;

        private string _fileDirectory = string.Empty;
        private string _tileIndex = string.Empty;
        private string _fieldName = string.Empty;
        
        private int previousTileIndex = -1;
        private int previousNameField = -1;
        private string previousFileWorkspace;
        #endregion

        #region Constructor
        public FileTileOpener()
        {
            InitializeComponent();
        }
        public FileTileOpener(IApplication application)
        {
            _application = application;
            InitializeComponent();
        }
        #endregion

        #region Event(s)

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (previousTileIndex > -2)
                cboTileIndex.SelectedIndex = previousTileIndex;
            if (previousTileIndex > -2)
                cboNameField.SelectedIndex = previousNameField;
            txbFileWorkspace.Text = previousFileWorkspace;
            this.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            previousTileIndex = cboTileIndex.SelectedIndex;
            previousNameField = cboNameField.SelectedIndex;
            previousFileWorkspace = txbFileWorkspace.Text;
            this.Visible = false;
        }

        private void cboTileIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNameField.Items.Clear();
            ILayer tile_index = _utilitiesArcMap.Layer(cboTileIndex.Text);
            cboNameField.Items.AddRange(_utilitiesArcMap.AllFields(tile_index).ToArray());
            // This will auto select the first field in the tile_index attribute table
            //if (cboNameField.Items.Count > -1)
            //    cboNameField.SelectedIndex = 0;
        }

        private void btnBrowseLas_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.txbFileWorkspace.Text;

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (Directory.Exists(previousFolderDst))
            //    fbd.SelectedPath = previousFolderDst;
            //DialogResult result = new DialogResult();

            //result = fbd.ShowDialog();

            //if (result == DialogResult.OK)
            //    txbLasWorkspace.Text = fbd.SelectedPath;

            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = txbFileWorkspace.Text;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                txbFileWorkspace.Text = (folderBrowserDialog.SelectedPath);
        }

        private void FileTileOpenerLoader_VisibleChanged(object sender, EventArgs e)
        {
            previousTileIndex = cboTileIndex.SelectedIndex;
            previousNameField = cboNameField.SelectedIndex;
            previousFileWorkspace = txbFileWorkspace.Text;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FileTileOpenerHelp help = new FileTileOpenerHelp();
            help.ShowDialog();
        }

        #endregion

        #region Method(s)

        private void Initialize()
        {
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilitiesArcMap = new RS_Tools.Utilities.Utilities_ArcMap(_map);
            cboTileIndex.Items.Clear();
            cboTileIndex.Items.AddRange(_utilitiesArcMap.PolygonLayers().ToArray());
            if (cboTileIndex.Items.Count > 0)
            {
                cboTileIndex.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Add Some Polygon Layers to Arcmap", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private bool CheckRequirments()
        {
            if (String.IsNullOrEmpty(cboTileIndex.Text) || String.IsNullOrEmpty(cboNameField.Text) || String.IsNullOrEmpty(txbFileWorkspace.Text))
            {
                Utilities_MessageBox.ErrorBox("Initialize Tool Settings", MB_TITLE);
                this.Visible = true;
                return false;
            }
            if (String.IsNullOrEmpty(txbCustomExtension.Text))
            {
                Utilities_MessageBox.ErrorBox("Enter A Custom Extension (eg. '.tif' or 'las')", MB_TITLE);
                this.Visible = true;
                return false;
            }
            try
            {
                IFeatureLayer tile_index1 = _utilitiesArcMap.FeatureLayer(cboTileIndex.Text);
                if (tile_index1 == null)
                    return false;
                IFeatureClass tile_index2 = tile_index1.FeatureClass;
                if (tile_index2 == null)
                    return false;
                IFields fields = tile_index2.Fields;
                if (!(fields.FindField(cboNameField.Text) > -1))
                    return false;
                if (!Directory.Exists(txbFileWorkspace.Text))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private void LoadFile(String FilePath)
        {
            String extension = String.Empty;

            if (txbCustomExtension.Text != String.Empty)
            {
                extension = txbCustomExtension.Text;
                if (extension.Contains("."))
                    extension = extension.Replace(".", "");
                if (File.Exists(FilePath + extension))
                {
                    Process.Start(FilePath + extension);
                    return;
                }
                else
                {
                    string message = "No Such File with '" + extension + "' extension";
                    MessageBox.Show(message, MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        internal void LoadFile(int X, int Y)
        {
            if (CheckRequirments())
            {
                try
                {
                    ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = (_application.Document as IMxDocument).ActiveView.ScreenDisplay;
                    ESRI.ArcGIS.Geometry.IPoint point = screenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    ESRI.ArcGIS.Carto.IFeatureLayer tilefeaturelayer = _utilitiesArcMap.FeatureLayer(cboTileIndex.Text);
                    IFeatureClass tilefeatureclass = tilefeaturelayer.FeatureClass;

                    ISpatialFilter spatialfilter = new SpatialFilter();
                    spatialfilter.GeometryField = tilefeatureclass.ShapeFieldName;
                    spatialfilter.Geometry = point;
                    spatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    IFeatureCursor tilefeaturecursor = tilefeatureclass.Search(spatialfilter, false);
                    IFeature tilefeature = null;

                    while ((tilefeature = tilefeaturecursor.NextFeature()) != null)
                    {
                        object obj = tilefeature.get_Value(_utilitiesArcMap.FindField(tilefeature, this.cboNameField.Text));
                        if (obj != DBNull.Value)
                        {
                            string tilename = obj.ToString();
                            LoadFile(txbFileWorkspace.Text + "\\" + tilename + ".");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

    }
}
