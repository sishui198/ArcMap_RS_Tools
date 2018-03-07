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
        private IDictionary<String, Boolean> _fileList = new Dictionary<String, Boolean>();

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

        }

        #endregion

        #region Methods

        private void Initalize()
        {
            LoadFileTypeList();

            cbo_TileIndex.Items.Clear();
            cbo_TileIndex.Items.AddRange(_utilitiesArcMap.FeatureLayer("Polygon").Selectable(item => item.Name).ToArray());
            if (cbo_TileIndex.Items.Count > 0)
            {
                cbo_TileIndex.SelectedIndex = 0;
            } else
            {
                MessageBox.Show("Add A Polygon Layer to the Map", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


    }
}
