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

namespace EsriTools.Forms
{
    public sealed partial class TileLasLoader_Form : Form
    {
        #region Field(s)
        private static volatile TileLasLoader_Form _instance;  // Instantiating A Singleton
        private static object _syncRoot = new object();
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private Classes.Utilities _utilities;
        private string _lasDirectory = string.Empty;
        private string _tileIndex = string.Empty;
        private string _fieldName = string.Empty;
        private const string MB_TITLE = "LAS Loader";
        private int previousTileIndex;
        private int previousNameField;
        private string previousLasWorkspace;

        #endregion

        #region Properties

        public static TileLasLoader_Form instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new TileLasLoader_Form(ArcMap.Application);
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Contructor(s)

        public TileLasLoader_Form(IApplication application)
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
            cboTileIndex.SelectedIndex = previousTileIndex;
            cboNameField.SelectedIndex = previousNameField;
            txbLasWorkspace.Text = previousLasWorkspace;
            this.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cboTileIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNameField.Items.Clear();
            ILayer tile_index = _utilities.Layer(cboTileIndex.Text);
            cboNameField.Items.AddRange(_utilities.AllFields(tile_index).ToArray());
            // This will auto select the first field in the tile_index attribute table
            //if (cboNameField.Items.Count > -1)
            //    cboNameField.SelectedIndex = 0;
        }

        private void btnBrowseLas_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.txbLasWorkspace.Text;

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (Directory.Exists(previousFolderDst))
            //    fbd.SelectedPath = previousFolderDst;
            //DialogResult result = new DialogResult();

            //result = fbd.ShowDialog();

            //if (result == DialogResult.OK)
            //    txbLasWorkspace.Text = fbd.SelectedPath;

            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = txbLasWorkspace.Text;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                txbLasWorkspace.Text = (folderBrowserDialog.SelectedPath);

            

        }

        private void TileLasLoader_Form_VisibleChanged(object sender, EventArgs e)
        {
            previousTileIndex = cboTileIndex.SelectedIndex;
            previousNameField = cboNameField.SelectedIndex;
            previousLasWorkspace = txbLasWorkspace.Text;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            TileLasLoaderHelp_Form help = new TileLasLoaderHelp_Form();
            help.ShowDialog();
        }

        #endregion

        #region Method(s)

        private void Initialize()
        {
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilities = new Classes.Utilities(_map);
            cboTileIndex.Items.Clear();
            cboTileIndex.Items.AddRange(_utilities.PolygonLayers().ToArray());
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
            if (String.IsNullOrEmpty(cboTileIndex.Text) || String.IsNullOrEmpty(cboNameField.Text) || String.IsNullOrEmpty(txbLasWorkspace.Text))
            {
                MessageBox.Show("Initialize Tool Settings", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Visible = true;
                return false;
            }
            try
            {
                IFeatureLayer tile_index1 = _utilities.FeatureLayer(cboTileIndex.Text);
                if (tile_index1 == null)
                    return false;
                IFeatureClass tile_index2 = tile_index1.FeatureClass;
                if (tile_index2 == null)
                    return false;
                IFields fields = tile_index2.Fields;
                if (!(fields.FindField(cboNameField.Text) > -1))
                    return false;
                if (!Directory.Exists(txbLasWorkspace.Text))
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
                    string message = "No Such File with '" + extension + "' extension\nNow Trying LAS";
                    MessageBox.Show(message, MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            if (File.Exists(FilePath + "las"))
            {
                Process.Start(FilePath + "las");
            }
            else
            {
                string message = "No Such File with 'las' extension";
                MessageBox.Show(message, MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal void LoadLasFile(int X, int Y)
        {
            if (CheckRequirments())
            {
                try
                {
                    ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = (_application.Document as IMxDocument).ActiveView.ScreenDisplay;
                    ESRI.ArcGIS.Geometry.IPoint point = screenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    ESRI.ArcGIS.Carto.IFeatureLayer tilefeaturelayer = _utilities.FeatureLayer(cboTileIndex.Text);
                    IFeatureClass tilefeatureclass = tilefeaturelayer.FeatureClass;

                    ISpatialFilter spatialfilter = new SpatialFilter();
                    spatialfilter.GeometryField = tilefeatureclass.ShapeFieldName;
                    spatialfilter.Geometry = point;
                    spatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    IFeatureCursor tilefeaturecursor = tilefeatureclass.Search(spatialfilter, false);
                    IFeature tilefeature = null;

                    while ((tilefeature = tilefeaturecursor.NextFeature()) != null)
                    {
                        object obj = tilefeature.get_Value(_utilities.FindField(tilefeature, this.cboNameField.Text));
                        if (obj != DBNull.Value)
                        {
                            string tilename = obj.ToString();
                            LoadFile(txbLasWorkspace.Text + "\\" + tilename + ".");
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

        private void TileLasLoader_Form_Load(object sender, EventArgs e)
        {

        }

       

        
    }
}
