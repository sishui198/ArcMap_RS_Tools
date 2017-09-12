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

namespace RS_Tools.Tools.RasterTileLoader
{
    public partial class RasterTileLoader_Form : Form
    {

        #region Properties 

        private static volatile RasterTileLoader_Form _instance;  // Instantiating A Singleton
        public static RasterTileLoader_Form instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new RasterTileLoader_Form(ArcMap.Application);
                    }
                }
                return _instance;
            }
        }


        private static object _syncRoot = new object();
        private const string MB_TITLE = "RTL";
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private ArcUtilities _utilities;
        private IDictionary<String, Boolean> rasterList = new Dictionary<String, Boolean>();

        private string _saveFolder = String.Empty;
        private string _saveFile = "ExtensionList.txt";
        private string _saveFullPath = String.Empty;
        private List<String> fileTypeHistory = new List<String>();

        #endregion

        #region Constructor

        public RasterTileLoader_Form(IApplication application)
        {
            _application = application;

            InitializeComponent();

            _saveFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"RS_Tools\ArcMap\RasterTileLoader");
            _saveFullPath = System.IO.Path.Combine(_saveFolder, _saveFile);
        }

        #endregion

        #region Methods

        #endregion
    }
}
