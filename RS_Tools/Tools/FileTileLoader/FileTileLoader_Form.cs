using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Ookii.Dialogs;
using RS_Tools.Utilities;

namespace RS_Tools.Tools.FileTileLoader
{
    public partial class FileTileLoader_Form : Form
    {

        #region Properties 

        private static volatile FileTileLoader_Form _instance;  // Instantiating A Singleton
        public static FileTileLoader_Form instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FileTileLoader_Form(ArcMap.Application);
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
        private IDictionary<String, Boolean> _fileList = new Dictionary<String, Boolean>();

        private string _saveFolder = String.Empty;
        private string _saveFile = "ExtensionList.txt";
        private string _saveFullPath = String.Empty;
        private List<String> _fileTypeHistory = new List<String>();

        //private ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler _itemAddedEventHandler;
        //private ESRI.ArcGIS.Carto.IActiveViewEvents_ItemDeletedEventHandler _itemDeletedEventHandler;
        //private ESRI.ArcGIS.Carto.IActiveViewEvents_ItemReorderedEventHandler _itemReorderedEventHandler;

        #endregion

        #region Constructor

        public FileTileLoader_Form(IApplication application)
        {
            InitializeComponent();

            // Get Standard Players
            _application = application;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilitiesArcMap = new Utilities_ArcMap(_map);

            // Add Methods To Delegates

            //_itemAddedEventHandler = new IActiveViewEvents_ItemAddedEventHandler(OnActiveViewEventsItemAdded);
            //_itemDeletedEventHandler = new IActiveViewEvents_ItemDeletedEventHandler(OnActiveViewEventsItemDeleted);
            //_itemReorderedEventHandler = new IActiveViewEvents_ItemReorderedEventHandler(OnActiveViewEventsItemReordered);

            // Setup Event Delegates
            //IActiveViewEvents_Event activeViewEvents = _map as IActiveViewEvents_Event;

            //activeViewEvents.ItemAdded += _itemAddedEventHandler;
            //activeViewEvents.ItemDeleted += _itemDeletedEventHandler;
            //activeViewEvents.ItemReordered += _itemReorderedEventHandler;


            // Setup Save Folder Path
            _saveFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"RS_Tools\ArcMap\FileTileLoader");
            _saveFullPath = System.IO.Path.Combine(_saveFolder, _saveFile);
        }

        #endregion

        #region Events 

        private void btn_initilaize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void cbo_TileIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_FieldName.Items.Clear();
            ILayer tileIndex = _utilitiesArcMap.Layer(cbo_TileIndex.Text);
            cbo_FieldName.Items.AddRange(_utilitiesArcMap.AllFields(tileIndex).ToArray());
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            if (CheckRequirments())
            {
                GenerateFileList();
                ValidateFileList();
                LoadFileList();
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            string previousFolderDst = txb_FileWorkspace.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.txb_FileWorkspace.Text = folderBrowserDialog.SelectedPath;
        }

        private void cbo_extension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void rb_selected_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    btn_LoadFile.Text = "Load Selected";
                }
            }
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    btn_LoadFile.Text = "Load All";
                }
            }
        }

        /*** Future Progress
        private void OnActiveViewEventsItemAdded(System.Object Item) 
        {
            //MessageBox.Show("Item type is " + Item.GetType().ToString());
        }

        private void OnActiveViewEventsItemDeleted(System.Object Item)
        {
            //MessageBox.Show("Item type is " + Item.GetType().ToString());
        }

        private void OnActiveViewEventsItemReordered(System.Object Item, System.Int32 toIndex)
        {
            //MessageBox.Show("Item Type is " + Item.GetType().ToString() + "\nItem Index is " + toIndex);
        }
        ***/

        #endregion

        #region Methods

        private void Initialize()
        {
            LoadFileTypeList();

            cbo_TileIndex.Items.Clear();
            cbo_TileIndex.Items.AddRange(_utilitiesArcMap.FeatureLayers("Polygon").Select(item => item.Name).ToArray());
            if (cbo_TileIndex.Items.Count > 0)
            {
                cbo_TileIndex.SelectedIndex = 0;
            } else
            {
                MessageBox.Show("Add A Polygon Layer to the Map", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void GetFeatureList()
        {
            cbo_TileIndex.Items.Clear();

        }

        private bool CheckRequirments()
        {
            if (String.IsNullOrEmpty(cbo_TileIndex.Text))
            {
                Utilities_MessageBox.ErrorBox("Initialize Tool Settings", MB_TITLE);
                return false;
            }

            if (String.IsNullOrEmpty(cbo_FieldName.Text))
            {
                Utilities_MessageBox.ErrorBox("Select Field", MB_TITLE);
                return false;
            }

            if (String.IsNullOrEmpty(txb_FileWorkspace.Text))
            {
                Utilities_MessageBox.ErrorBox("Select File Workspace", MB_TITLE);
                return false;
            }

            try
            {
                IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cbo_TileIndex.Text);
                if (featureLayer == null) return false;

                IFeatureClass featureClass = featureLayer.FeatureClass;
                if (featureClass == null) return false;

                IFields fields = featureClass.Fields;
                if (!(_utilitiesArcMap.FindField(featureClass, cbo_FieldName.Text) > -1)) return false;

                if (rb_selected.Checked == false && rb_all.Checked == false)
                {
                    Utilities_MessageBox.ErrorBox("Select A File Loading Method", MB_TITLE);
                    return false;
                }


                // If selected file loading method check if anything is selected
                if (rb_selected.Checked)
                {
                    IFeatureSelection featureSelection = featureLayer as IFeatureSelection;

                    if (featureSelection.SelectionSet.Count == 0)
                    {
                        Utilities_MessageBox.ErrorBox("Select At Least One Feature", MB_TITLE);
                        return false;
                    }
                }

                if (!Directory.Exists(txb_FileWorkspace.Text))
                {
                    Utilities_MessageBox.ErrorBox("File Workspace Is Invalid", MB_TITLE);
                    return false;
                }
                return true;

            } catch (Exception ex)
            {
                Utilities_MessageBox.ErrorBox(ex.Message, MB_TITLE);
            }

            return false;
        }

        private void GenerateFileList()
        {
            // Clear File List
            _fileList.Clear();

            IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cbo_TileIndex.Text);
            IFeatureClass featureClass = featureLayer.FeatureClass;

            if (rb_all.Checked)  // Grab All Of The Raster :) 
            {

                IFeatureCursor cursor = featureClass.Search(null, false);

                IFields fields = cursor.Fields;
                int fieldIndex = _utilitiesArcMap.FindField(featureClass, cbo_FieldName.Text);

                IFeature feature = cursor.NextFeature();

                while (feature != null)
                {
                    // Default To True I will validate After Adding All To Dictonary
                    if (!_fileList.ContainsKey(Convert.ToString(feature.get_Value(fieldIndex))))
                    {
                        _fileList.Add(Convert.ToString(feature.get_Value(fieldIndex)), true);
                    }

                    feature = cursor.NextFeature();
                }
            }
            else // Grab Only The Selected Tiles
            {
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                enumIDs.Reset();
                int intOID = enumIDs.Next();
                while (intOID != -1)
                {
                    IFeature feature = featureClass.GetFeature(intOID);
                    if (feature != null)
                    {
                        int fieldIndex = _utilitiesArcMap.FindField(featureClass, cbo_FieldName.Text);
                        // Default To True I will validate After Adding All To Dictonary
                        if (!_fileList.ContainsKey(Convert.ToString(feature.get_Value(fieldIndex))))
                        {
                            _fileList.Add(Convert.ToString(feature.get_Value(fieldIndex)), true);
                        }
                    }
                    intOID = enumIDs.Next();
                }

            }
        }

        private void ValidateFileList()
        {
            IDictionary<String, Boolean> newList = new Dictionary<String, Boolean>();

            foreach (KeyValuePair<String, Boolean> file in _fileList)
            {
                string filePath = txb_FileWorkspace.Text + "\\" +  Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();
                if (!File.Exists(filePath))
                    newList.Add(file.Key, false);
                else
                    newList.Add(file.Key, file.Value);

            }
            _fileList = newList;
        }

        private void LoadFileList()
        {
            bool itWorked = false;
            GroupLayer rasterGroup = null; 
            if (_fileList.Count > 0)
            {
                rasterGroup = new GroupLayer();
                rasterGroup.Name = "New Files";
            }

            foreach (KeyValuePair<String, Boolean> file in _fileList)
            {
                if (file.Value == true)
                {
                    if (!itWorked)
                        //SaveFileTypeList(GetExtension());
                    itWorked = true;

                    string filePath = txb_FileWorkspace.Text + "\\" + Utilities.Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();
                    try
                    {
                        IRasterLayer rasterLayer = new RasterLayer();
                        rasterLayer.CreateFromFilePath(filePath);
                        ILegendGroup group = ((ILegendInfo)rasterLayer).get_LegendGroup(0);
                        group.Visible = false;
                        rasterGroup.Add(rasterLayer);
                       
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        // Just So ArcMap doesn't crash ;) 
                    }

                }
            }
            if (itWorked)
            {
                if (rasterGroup != null) _mxdocument.AddLayer(rasterGroup);
                _mxdocument.ActivatedView.Refresh();
            }

            _fileList.Clear();
        }

        private string GetExtension()
        {
            string extension = String.Empty;

            if (cbo_extension.Text != String.Empty)
            {
                extension = cbo_extension.Text;
                if (extension.Contains("."))
                    extension = extension.Replace(".", "");
                return "." + extension;
            }
            return "NO EXTENSION LOADED";
        }

        private void LoadFileTypeList()
        {
            cbo_extension.Items.Clear();
            _fileTypeHistory.Clear();

            if (!Directory.Exists(_saveFolder))
                Directory.CreateDirectory(_saveFolder);

            if (File.Exists(_saveFolder + "\\" + _saveFile))
            {
                using (StreamReader sStreamReader = new StreamReader(_saveFolder + "\\" + _saveFile))
                {
                    string AllData = sStreamReader.ReadToEnd();
                    _fileTypeHistory.AddRange(AllData.Split(",".ToCharArray()));
                    cbo_extension.Items.AddRange(_fileTypeHistory.ToArray());
                }

            }
        }

        private void SaveFileTypeList(string type)
        {
            if (!_fileTypeHistory.Contains(type, StringComparer.OrdinalIgnoreCase) && !String.IsNullOrEmpty(type))
            {
                _fileTypeHistory.Add(type);
            }
            using (TextWriter tw = new StreamWriter(_saveFolder + "\\" + _saveFile))
            {
                tw.Write(String.Join(",", _fileTypeHistory));
            }
        }

        #endregion


    }
}
