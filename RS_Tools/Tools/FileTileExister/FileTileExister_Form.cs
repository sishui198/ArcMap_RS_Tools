using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Ookii.Dialogs;
using RS_Tools.Utilities;
using RS_Tools.Model;
using System.Diagnostics;
using ESRI.ArcGIS.Editor;

namespace RS_Tools.Tools.FileTileExister
{
    public partial class FileTileExister_Form : Form
    {
        #region Properties

        // Instantiating A Singleton
        private static volatile FileTileExister_Form _instance;
        public static FileTileExister_Form instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FileTileExister_Form();
                    }
                }
                return _instance;
            }
        }

        private static object _syncRoot = new object();

        private const string MB_TITLE = "FTE";
        private const string FIELD_NAME = "FileExists";
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private IEditor _editor;
        private Utilities_ArcMap _utilitiesArcMap;
        private IDictionary<string, Boolean> _fileList = new Dictionary<string, Boolean>(); // File Path, If The File Exists

        private string _saveFolder = String.Empty;
        private string _saveFile = "ExtensionList.txt";
        private string _saveFullPath = String.Empty;
        private List<String> _fileTypeHistory = new List<String>();

        #endregion

        #region Constructor
        public FileTileExister_Form()
        {
            InitializeComponent();

            _saveFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"RS_Tools\ArcMap\FileTileExister");
            _saveFullPath = System.IO.Path.Combine(_saveFolder, _saveFile);
            GetStandardPlayers();
        }

        #endregion

        #region Events

        private void btn_initialize_Click(object sender, EventArgs e)
        {
            LoadFileTypeList();
            GetStandardPlayers();

            cbo_layers.Items.Clear();
            cbo_fieldname.Items.Clear();

            List<ILayer> layers = _utilitiesArcMap.PolygonLayers();
            List<CustomLayer> customLayers = new List<CustomLayer>();

            foreach (ILayer layer in layers)
            {
                customLayers.Add(new CustomLayer(layer));
            }

            cbo_layers.Items.AddRange(customLayers.ToArray());

            if (cbo_layers.Items.Count < 1)
                MessageBox.Show("Add A Polygon Layer To The Map", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (CheckRequirements())
            {
                BuildFileList();

                CheckForExistence();

                WriteToTable();
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(txb_folderpath.Text))
            {
                folderBrowserDialog.SelectedPath = txb_folderpath.Text;
            }

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.txb_folderpath.Text = folderBrowserDialog.SelectedPath;

        }

        private void cbo_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_fieldname.Items.Clear();
            cbo_fieldname.Items.AddRange(_utilitiesArcMap.TextFields(((CustomLayer)cbo_layers.SelectedItem).Layer).ToArray());
        }

        private void btn_createfield_Click(object sender, EventArgs e)
        {
            try { CreateField(); }
            catch { MessageBox.Show("ERROR", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error); }          
        }

        #endregion

        #region Methods

        private void GetStandardPlayers()
        {
            _application = ArcMap.Application;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilitiesArcMap = new Utilities_ArcMap(_map);
            _editor = _utilitiesArcMap.GetEditorFromArcMap((IMxApplication)_application);
        }

        private bool CheckRequirements()
        {
            if (cbo_layers.SelectedIndex < 0)
            {
                MessageBox.Show("Choose A Layer", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbo_fieldname.SelectedIndex < 0)
            {
                MessageBox.Show("Choose A Field Name", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(cbo_extension.Text) || String.IsNullOrWhiteSpace(cbo_extension.Text))
            {
                MessageBox.Show("Set An Extension", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txb_folderpath.Text) || string.IsNullOrWhiteSpace(txb_folderpath.Text))
            {
                MessageBox.Show("Set A Folder Path", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(txb_folderpath.Text))
            {
                MessageBox.Show("Folder Path Does Not Exist", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rb_all.Checked && !rb_selected.Checked)
            {
                MessageBox.Show("Choose A Method", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            CustomLayer customLayer = cbo_layers.SelectedItem as CustomLayer;

            if (customLayer == null)
            {
                MessageBox.Show("Error", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IFeatureClass featureClass = customLayer.FeatureClass();

            int fieldIndex = featureClass.FindField(FIELD_NAME);

            if (fieldIndex < 0)
            {
                MessageBox.Show("Please Create Field", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IField field = featureClass.Fields.Field[fieldIndex];

            if (field.Type != esriFieldType.esriFieldTypeString)
            {
                MessageBox.Show("Recreate Field, Wrong Type (text)", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (field.Length < 20)
            {
                MessageBox.Show("Recreate Field, Wrong Size (>= 20)", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rb_selected.Checked)
            {
                IFeatureSelection selection = customLayer.FeatureLayer() as IFeatureSelection;

                if (selection.SelectionSet.Count == 0)
                {
                    MessageBox.Show("Select At Least One Feature", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_editor.EditState != esriEditState.esriStateEditing)
            {
                MessageBox.Show("Start and Edit Operation");
                return false;
            }

            return true;
        }

        private string GetExtension()
        {
            string extension = String.Empty;

            if (cbo_extension.Text != String.Empty)
            {
                extension = cbo_extension.Text;
                if (extension.Contains("."))
                    extension = extension.Replace(".", "");
                return "." + extension.ToLower();
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

        private void BuildFileList()
        {
            _fileList.Clear();

            IFeatureLayer featureLayer = ((CustomLayer)cbo_layers.SelectedItem).FeatureLayer();
            IFeatureClass featureClass = ((CustomLayer)cbo_layers.SelectedItem).FeatureClass();


            if (rb_all.Checked)
            {
                IFeatureCursor cursor = featureClass.Search(null, false);
                IFields fields = cursor.Fields;
                int fieldIndex = _utilitiesArcMap.FindField(featureClass, cbo_fieldname.Text);

                IFeature feature = cursor.NextFeature();

                while (feature != null)
                {
                    //string fileName = Utilities.Utilities_General.AddPrefixAndSuffixToFileName(Convert.ToString(feature.get_Value(fieldIndex)), txb_prefix.Text, txb_suffix.Text);
                    string fileName = Convert.ToString(feature.get_Value(fieldIndex));
                    if (!_fileList.ContainsKey(fileName))
                    {
                        _fileList.Add(fileName, false);
                    }

                    feature = cursor.NextFeature();
                }
            }

            if (rb_selected.Checked)
            {
                IFeatureSelection selection = featureLayer as IFeatureSelection;
                IEnumIDs IDs = selection.SelectionSet.IDs;
                IDs.Reset();

                int oid = IDs.Next();

                while(oid != -1)
                {
                    IFeature feature = featureClass.GetFeature(oid);
                    if (feature != null)
                    {
                        int fieldIndex = _utilitiesArcMap.FindField(featureClass, cbo_fieldname.Text);
                        string fileName = Convert.ToString(feature.get_Value(fieldIndex));
                        if (!_fileList.ContainsKey(fileName))
                        {
                            _fileList.Add(fileName, false);
                        }

                        oid = IDs.Next();
                    }
                }
            }

        }

        private void CreateField()
        {
            if (_editor.EditState != esriEditState.esriStateNotEditing)
            {
                MessageBox.Show("Stop Editing First", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbo_layers.SelectedIndex < 0)
            {
                MessageBox.Show("Select A Layer", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CustomLayer customLayer = (CustomLayer)cbo_layers.SelectedItem;
            IFeatureClass FeatureClass = customLayer.FeatureClass();
            IFields fields = FeatureClass.Fields;

            int fieldIndex = _utilitiesArcMap.FindField(FeatureClass, FIELD_NAME);

            if (fieldIndex > -1)
            {
                IField field = FeatureClass.Fields.Field[fieldIndex];
                if (field.Type != esriFieldType.esriFieldTypeString)
                {
                    if (MessageBox.Show("Field exists as wrong field type. It needs to  be 'Text' Field. Should I delete and re-create?", 
                        MB_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    FeatureClass.DeleteField(field);
                } 
                else
                {
                    if (field.Length < 20)
                    {
                        if (MessageBox.Show("Field exists as wrong size. It needs to  be at least 20 in length. Should I delete and re-create?",
                        MB_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        FeatureClass.DeleteField(field);
                    }
                    else
                    {
                        return;
                    }                
                }
            }

            IFieldEdit2 newField = new FieldClass() as IFieldEdit2;
            newField.Name_2 = FIELD_NAME;
            newField.Type_2 = esriFieldType.esriFieldTypeString;
            newField.Length_2 = 20;
            newField.DefaultValue_2 = "Unchecked";

            ISchemaLock schemaLock = (ISchemaLock)FeatureClass;

            try
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                FeatureClass.AddField(newField);
            }
            catch
            {
                MessageBox.Show("Cannot Aquire Exclusive Lock. Did Not Add Field", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }         
        }

        private void CheckForExistence()
        {
            var files = Directory.GetFiles(txb_folderpath.Text, "*.*",
                cb_subfolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).
                Where(file => Path.GetExtension(file).ToLower() == GetExtension());

            var fileNames = new List<String>();
            

            foreach (string file in files)
            {
                fileNames.Add(Path.GetFileNameWithoutExtension(file));
            }

            IDictionary<String, Boolean> newList = new Dictionary<String, Boolean>();

            foreach (KeyValuePair<string, Boolean> file in _fileList)
            {
                newList.Add(file.Key, fileNames.Contains(Utilities.Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_prefix.Text, txb_suffix.Text)) ? true : false);
            }

            _fileList = newList;
        }

        private void WriteToTable()
        {
            CustomLayer customLayer = (CustomLayer)cbo_layers.SelectedItem;
            IFeatureLayer featureLayer = customLayer.FeatureLayer();
            IFeatureClass featureClass = customLayer.FeatureClass();
            int fieldIndexName = featureClass.FindField(cbo_fieldname.Text);
            int fieldIndexStatus = featureClass.FindField(FIELD_NAME);


            ISchemaLock schemaLock = (ISchemaLock)featureClass;

            try
            {               
                //schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);

                if (rb_all.Checked)
                {
                    _editor.StartOperation();

                    IFeatureCursor cursor = featureClass.Search(null, false);
                    IFields fields = cursor.Fields;

                    IFeature feature = cursor.NextFeature();

                    while (feature != null)
                    {
                        string value = Convert.ToString(feature.get_Value(fieldIndexName));
                        bool exists = _fileList[value];
                        feature.set_Value(fieldIndexStatus, exists ? "Exists" : "Missing");
                        feature.Store();
                        feature = cursor.NextFeature();
                    }
                    SaveFileTypeList(GetExtension());
                    _editor.StopOperation("File Tile Exister Ran");
                }

                if (rb_selected.Checked)
                {
                    _editor.StartOperation();

                    IFeatureSelection selection = featureLayer as IFeatureSelection;
                    IEnumIDs IDs = selection.SelectionSet.IDs;
                    IDs.Reset();

                    int oid = IDs.Next();

                    while (oid != -1)
                    {
                        IFeature feature = featureClass.GetFeature(oid);
                        if (feature != null)
                        {
                            bool exists = _fileList[Convert.ToString(feature.get_Value(fieldIndexName))];
                            feature.set_Value(fieldIndexStatus, exists ? "Exists" : "Missing");
                            feature.Store();
                            oid = IDs.Next();
                        }
                    }
                    SaveFileTypeList(GetExtension());
                    _editor.StopOperation("File Tile Exister Ran");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Could Not Get Exclusive Schmea Lock\n{0}", ex.Message));
            }
            finally
            {
                //schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }

            
        }

        #endregion
    }
}
