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

namespace RS_Tools.Tools.FileTileCloner
{
    public partial class FileTileCloner_Form : Form
    {
        #region Properties

        private static volatile FileTileCloner_Form _instance; // Instantiating A Singleton
        public static FileTileCloner_Form instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FileTileCloner_Form(ArcMap.Application);
                    }
                }
                return _instance;
            }
        }

        private static object _syncRoot = new object();
        private const string MB_TITLE = "FTC";
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private Utilities_ArcMap _utilitiesArcMap;
        private IDictionary<String, Boolean> _fileList = new Dictionary<String, Boolean>(); // File Path, If the File Exists

        private string _saveFolder = String.Empty;
        private string _saveFile = "ExtensionList.txt";
        private string _saveFullPath = String.Empty;
        private List<String> _fileTypeHistory = new List<String>();

        #endregion

        #region Constructor

        public FileTileCloner_Form(IApplication application)
        {
            InitializeComponent();

            // Get Standard Players
            _application = application;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilitiesArcMap = new Utilities_ArcMap(_map);

            _saveFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"RS_Tools\ArcMap\FileTileCloner");
            _saveFullPath = System.IO.Path.Combine(_saveFolder, _saveFile);

        }

        #endregion

        #region Events
        private void btn_initilaize_Click(object sender, EventArgs e)
        {
            Initalize();
        }

        private void cbo_TileIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_FieldName.Items.Clear();
            ILayer tileIndex = _utilitiesArcMap.Layer(cbo_TileIndex.Text);
            cbo_FieldName.Items.AddRange(_utilitiesArcMap.AllFields(tileIndex).ToArray());
        }

        private void btn_browseSrc_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.txb_FileWorkspaceSrc.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.txb_FileWorkspaceSrc.Text = folderBrowserDialog.SelectedPath;
        }

        private void btn_browseDst_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.txb_FileWorkspaceDst.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.txb_FileWorkspaceDst.Text = folderBrowserDialog.SelectedPath;
        }

        private void btn_CloneFile_Click(object sender, EventArgs e)
        {
            if (CheckRequirements())
            {
                GenerateFileList();
                ValidateFileList();
                CloneFileList();
            }
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            if (CheckRequirements())
            {
                GenerateFileList();
                ValidateFileList();
                CreateBatchFile();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        #endregion

        #region Methods

        private void Initalize()
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

        private bool CheckRequirements()
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

            if (String.IsNullOrEmpty(txb_FileWorkspaceSrc.Text))
            {
                Utilities_MessageBox.ErrorBox("Select File Workspace Source", MB_TITLE);
                return false;
            }

            if (String.IsNullOrEmpty(txb_FileWorkspaceDst.Text))
            {
                Utilities_MessageBox.ErrorBox("Select File Workspace Destination", MB_TITLE);
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

                if (!Directory.Exists(txb_FileWorkspaceSrc.Text))
                {
                    Utilities_MessageBox.ErrorBox("Source is Invalid", MB_TITLE);
                    return false;
                }

                if (!Directory.Exists(txb_FileWorkspaceDst.Text))
                {
                    Utilities_MessageBox.ErrorBox("Destination is Invalid", MB_TITLE);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
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
            int cloneCount = 1; // labeling the processor bar
            ITrackCancel trackcancel = new CancelTracker();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = _fileList.Count;
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Validating...";
            IProgressDialog2 progressdialog = (IProgressDialog2)stepprogressor; // Creates and displays
            progressdialog.CancelEnabled = false;
            progressdialog.Description = "Validating {_fileList.Count} files...";
            progressdialog.Title = MB_TITLE;
            progressdialog.Animation = esriProgressAnimationTypes.esriProgressSpiral;



            IDictionary<String, Boolean> newList = new Dictionary<String, Boolean>();

            foreach (KeyValuePair<String, Boolean> file in _fileList)
            {
                progressdialog.Description = string.Format("Validating {0} of {1}...", cloneCount, _fileList.Count);
                string filePath = txb_FileWorkspaceSrc.Text + "\\" + Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();
                if (!File.Exists(filePath))
                    newList.Add(file.Key, false);
                else
                    newList.Add(file.Key, file.Value);
                stepprogressor.Step();
                cloneCount++;

            }
            _fileList = newList;



            trackcancel = null;
            stepprogressor = null;
            progressdialog.HideDialog();
            progressdialog = null;
            //_activeView.Refresh();
        }

        private void CloneFileList()
        {
            bool itWorked = false;



            int cloneCount = 1; // labeling the processor bar
            ITrackCancel trackcancel = new CancelTracker();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = _fileList.Count;
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Copying...";
            IProgressDialog2 progressdialog = (IProgressDialog2)stepprogressor; // Creates and displays
            progressdialog.CancelEnabled = false;
            progressdialog.Description = "Copying {_fileList.Count} files...";
            progressdialog.Title = MB_TITLE;
            progressdialog.Animation = esriProgressAnimationTypes.esriProgressSpiral;


            foreach (KeyValuePair<String, Boolean> file in _fileList)
            {
                if (file.Value)
                {
                    progressdialog.Description = string.Format("Copying File {0} of {1}...", cloneCount, _fileList.Count);
                    if (!itWorked)
                        SaveFileTypeList(GetExtension());
                    itWorked = true;

                    try
                    {
                        var sourceFile = txb_FileWorkspaceSrc.Text + @"\" + Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();
                        var destinationFile = txb_FileWorkspaceDst.Text + @"\" + Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();

                        System.IO.File.Copy(sourceFile, destinationFile);
                    }
                    catch (Exception yourBest) // but you don't succeed
                    {
                        yourBest.ToString();
                       // Just So We Get No Crashes ;) 
                    }
                    stepprogressor.Step();
                    cloneCount++;
                }
                
            }
            trackcancel = null;
            stepprogressor = null;
            progressdialog.HideDialog();
            progressdialog = null;
            //_activeView.Refresh();
            
        }

        private void CreateBatchFile()
        {
            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            } 

            if (!Directory.Exists(path))
            {
                Utilities_MessageBox.ErrorBox("Path Does Not Exist", MB_TITLE);
                return;
            }

            int versionCount = 1; // This is used to make mutiple files so the batch file don't overwrite on another.
            string filePath = path + string.Format(@"\{0}_{1}_{2}.bat", cbo_TileIndex.Text, "CopyFiles", versionCount);
            while (File.Exists(filePath))
            {
                versionCount++;
                filePath = path + string.Format(@"\{0}_{1}_{2}.bat", cbo_TileIndex.Text, "CopyFiles", versionCount);
            }

            


            bool itWorked = false;



            int cloneCount = 1; // labeling the processor bar
            ITrackCancel trackcancel = new CancelTracker();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = _fileList.Count;
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Generating...";
            IProgressDialog2 progressdialog = (IProgressDialog2)stepprogressor; // Creates and displays
            progressdialog.CancelEnabled = false;
            progressdialog.Description = "Prepping {_fileList.Count} files...";
            progressdialog.Title = MB_TITLE;
            progressdialog.Animation = esriProgressAnimationTypes.esriProgressSpiral;


            foreach (KeyValuePair<String, Boolean> file in _fileList)
            {
                if (file.Value)
                {
                    progressdialog.Description = string.Format("Adding File {0} of {1}...", cloneCount, _fileList.Count);
                    if (!itWorked)
                        SaveFileTypeList(GetExtension());
                    itWorked = true;

                    try
                    {
                        var sourceFile = txb_FileWorkspaceSrc.Text + @"\" + Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();
                        var destinationFile = txb_FileWorkspaceDst.Text + @"\" + Utilities_General.AddPrefixAndSuffixToFileName(file.Key, txb_Prefix.Text, txb_Suffix.Text) + GetExtension();

                        using (System.IO.StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine(String.Format("copy {0} {1}", sourceFile, destinationFile));
                        }

                    }
                    catch (Exception yourBest) // but you don't succeed
                    {
                        yourBest.ToString();
                        // Just So We Get No Crashes ;) 
                    }
                    stepprogressor.Step();
                    cloneCount++;
                }

            }
            trackcancel = null;
            stepprogressor = null;
            progressdialog.HideDialog();
            progressdialog = null;
            //_activeView.Refresh();
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
