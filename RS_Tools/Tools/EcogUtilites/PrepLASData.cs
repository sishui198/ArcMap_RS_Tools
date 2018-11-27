namespace RS_Tools.Tools.EcogUtilites
{
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using Ookii.Dialogs;
    using RS_Tools.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="PrepLASData" />
    /// </summary>
    public partial class PrepLASData : Form
    {
        /// <summary>
        /// Defines the _instance
        /// </summary>
        private static volatile PrepLASData _instance;// Instantiating A Singleton

        /// <summary>
        /// Gets the instance
        /// </summary>
        public static PrepLASData instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new PrepLASData(ArcMap.Application);
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Defines the _syncRoot
        /// </summary>
        private static object _syncRoot = new object();

        /// <summary>
        /// Defines the MB_TITLE
        /// </summary>
        private const string MB_TITLE = "PLD";

        /// <summary>
        /// Defines the _application
        /// </summary>
        private IApplication _application;

        /// <summary>
        /// Defines the _map
        /// </summary>
        private IMap _map;

        /// <summary>
        /// Defines the _mxdocument
        /// </summary>
        private IMxDocument _mxdocument;

        /// <summary>
        /// Defines the _utilitiesArcMap
        /// </summary>
        private Utilities_ArcMap _utilitiesArcMap;

        /// <summary>
        /// Defines the _output_las_merged_folder
        /// </summary>
        private string _output_las_merged_folder = "";

        /// <summary>
        /// Defines the _output_las_clipped_folder
        /// </summary>
        private string _output_las_clipped_folder = "";

        /// <summary>
        /// Defines the _output_shp_buffered_folder
        /// </summary>
        private string _output_shp_buffered_folder = "";

        /// <summary>
        /// Defines the _output_shp_original_folder
        /// </summary>
        private string _output_shp_original_folder = "";

        /// <summary>
        /// Defines the _output_batch_folder
        /// </summary>
        private string _output_batch_folder = "";

        /// <summary>
        /// Defines the _output_list_folder
        /// </summary>
        private string _output_list_folder = "";

        /// <summary>
        /// Defines the _report_missingLasFileCount
        /// </summary>
        private int _report_missingLasFileCount = 0;

        /// <summary>
        /// Defines the _report_foundLASFileCount
        /// </summary>
        private int _report_foundLASFileCount = 0;

        /// <summary>
        /// Defines the _report_orthoFileWithoutFullCoverageCount
        /// </summary>
        private int _report_orthoFileWithoutFullCoverageCount = 0;

        /// <summary>
        /// Defines the _report_totalLASTileCount
        /// </summary>
        private int _report_totalLASTileCount = 0;

        /// <summary>
        /// Defines the _report_totalOrthoTileCount
        /// </summary>
        private int _report_totalOrthoTileCount = 0;

        /// <summary>
        /// Defines the _report_totalBufferedSHPOutput
        /// </summary>
        private int _report_totalBufferedSHPOutput = 0;

        /// <summary>
        /// Defines the _report_totalOriginalSHPOutput
        /// </summary>
        private int _report_totalOriginalSHPOutput = 0;

        /// <summary>
        /// Defines the _report_batchFilesWritten
        /// </summary>
        private int _report_batchFilesWritten = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrepLASData"/> class.
        /// </summary>
        /// <param name="application">The application<see cref="IApplication"/></param>
        public PrepLASData(IApplication application)
        {
            InitializeComponent();

            // Get Standard Players
            _application = application;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _utilitiesArcMap = new Utilities_ArcMap(_map);
        }

        /// <summary>
        /// The PrepLASData_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void PrepLASData_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The btn_close_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// The btn_reload_layers_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_reload_layers_Click(object sender, EventArgs e)
        {
            Initalize();
        }

        /// <summary>
        /// The cb_tile_layout_las_SelectedIndexChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void cb_tile_layout_las_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_field_las.Items.Clear();
            ILayer las_layer = _utilitiesArcMap.Layer(cb_tile_layout_las.Text);
            cb_field_las.Items.AddRange(_utilitiesArcMap.AllFields(las_layer).ToArray());
        }

        /// <summary>
        /// The cb_tile_layout_ortho_SelectedIndexChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void cb_tile_layout_ortho_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_field_ortho.Items.Clear();
            ILayer ortho_layer = _utilitiesArcMap.Layer(cb_tile_layout_ortho.Text);
            cb_field_ortho.Items.AddRange(_utilitiesArcMap.AllFields(ortho_layer).ToArray());
        }

        /// <summary>
        /// The btn_folder_Las_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_folder_Las_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.tb_las_folder.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.tb_las_folder.Text = folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// The btn_folder_las_tools_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_folder_las_tools_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.tb_erdastools.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                this.tb_erdastools.Text = folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// The btn_folder_output_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_folder_output_Click(object sender, EventArgs e)
        {
            string previousFolderDst = this.tb_output.Text;

            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (Directory.Exists(previousFolderDst))
                folderBrowserDialog.SelectedPath = previousFolderDst;

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.tb_output.Text = folderBrowserDialog.SelectedPath;
                _output_las_merged_folder = $"{tb_output.Text}\\LAS_Merged";
                _output_las_clipped_folder = $"{tb_output.Text}\\LAS_Clipped";
                _output_shp_buffered_folder = $"{tb_output.Text}\\Tiles_Buffered";
                _output_shp_original_folder = $"{tb_output.Text}\\Tiles_ForRasterClip";
                _output_batch_folder = $"{tb_output.Text}\\BatchFiles";
                _output_list_folder = $"{tb_output.Text}\\Merge_List";
            }
        }

        /// <summary>
        /// The btn_create_batch_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btn_create_batch_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> lasFiles = new Dictionary<string, string>();
            Dictionary<string, List<string>> lasOrthoFiles = new Dictionary<string, List<string>>();

            //Reset the report numbers
            _report_missingLasFileCount = 0;
            _report_foundLASFileCount = 0;
            _report_orthoFileWithoutFullCoverageCount = 0;
            _report_totalLASTileCount = 0;
            _report_totalOrthoTileCount = 0;
            _report_totalBufferedSHPOutput = 0;
            _report_totalOriginalSHPOutput = 0;
            _report_batchFilesWritten = 0;

            try
            {
                switch (tc_select_type.SelectedIndex)
                {
                    case 0:
                        if (CheckRequirements() && CheckRequirements_LAS())
                        {
                            if (Create_LAS_List(lasFiles))
                            {
                                if (Export_SHP_Tiles_LAS(lasFiles))
                                {
                                    ExportMergeCommands_LAS(lasFiles);
                                }
                            }
                            ShowReport_LAS();
                        }
                        return;
                    case 1:
                        if (CheckRequirements() && CheckRequirements_LAS_Ortho())
                        {
                            if (Create_LAS_List_Ortho(lasOrthoFiles))
                            {
                                if (Export_SHP_Tiles_LAS_Ortho(lasOrthoFiles))
                                {
                                    ExportMergeCommands_LAS_Ortho(lasOrthoFiles);
                                }
                            }
                            ShowReport_LASOrtho();
                        }
                        return;
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The Initalize
        /// </summary>
        private void Initalize()
        {
            // Tile Layout Layers
            cb_tile_layout_las.Items.Clear();
            cb_tile_layout_ortho.Items.Clear();

            // Fields Clear
            cb_field_las.Items.Clear();
            cb_field_ortho.Items.Clear();

            // Add Layers
            cb_tile_layout_las.Items.AddRange(_utilitiesArcMap.FeatureLayers("Polygon").Select(item => item.Name).ToArray());
            if (cb_tile_layout_las.Items.Count > 0)
            {
                cb_tile_layout_las.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Add Polygon Layer to the Map", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cb_tile_layout_ortho.Items.AddRange(_utilitiesArcMap.FeatureLayers("Polygon").Select(item => item.Name).ToArray());
            if (cb_tile_layout_ortho.Items.Count > 0)
            {
                cb_tile_layout_ortho.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The CheckRequirements
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool CheckRequirements()
        {
            try
            {
                if (_utilitiesArcMap == null)
                {
                    MessageBox.Show("Cannot Initalize Arc Utilites", MB_TITLE);
                }

                if (this.cb_tile_layout_las.Items.Count == 0)
                {
                    MessageBox.Show("Add a layer to inspect to the table of contents", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (cb_tile_layout_las.SelectedIndex < 0)
                {
                    MessageBox.Show("Select a LAS Tile Layout", MB_TITLE);
                    return false;
                }

                if (cb_field_las.SelectedIndex < 0)
                {
                    MessageBox.Show("Select a field for the LAS Tile Layout that corrisponds to the LAS file name", MB_TITLE);
                    return false;
                }

                ILayer tilelayout_las_layer = _utilitiesArcMap.Layer(this.cb_tile_layout_las.Text);

                if (tilelayout_las_layer == null)
                {
                    MessageBox.Show("LAS Tile Layout Does Not Exist", MB_TITLE);
                    return false;
                }

                int fieldIndex = _utilitiesArcMap.FindField(tilelayout_las_layer, cb_field_las.Text);
                if (fieldIndex < 0)
                {
                    MessageBox.Show("LAS Field Does Not Exist", MB_TITLE);
                    return false;
                }

                if (!Directory.Exists(tb_las_folder.Text))
                {
                    MessageBox.Show("Folder containing LAS Data does not exist", MB_TITLE);
                    return false;
                }

                var ext = new List<String> { ".las", ".LAS" };
                var lasFiles = Directory.GetFiles(tb_las_folder.Text, "*.*",
                    chb_recursion_las.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(
                    file => ext.Contains(System.IO.Path.GetExtension(file)));

                if (lasFiles.Count() < 1)
                {
                    MessageBox.Show("Folder contains no LAS Files");
                    return false;
                }

                if (!Directory.Exists(tb_erdastools.Text))
                {
                    MessageBox.Show("Folder Containing ERDAS tools does not exist.", MB_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    return false;
                }

                if (!Directory.Exists(tb_geoexpress.Text))
                {
                    MessageBox.Show("Folder Containing GeoExpress tools does not exist.", MB_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    return false;
                }

                if (!Directory.Exists(tb_output.Text))
                {
                    MessageBox.Show("Output Folder Does Not Exist", MB_TITLE);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR CODE: 2034982034\n\n{ex.Message}", MB_TITLE);
                return false;
            }
            return true;
        }

        /// <summary>
        /// The CreateOverlapPolygon
        /// </summary>
        /// <param name="feature">The feature<see cref="IFeature"/></param>
        /// <returns>The <see cref="IPolygon"/></returns>
        private IPolygon CreateOverlapPolygon(IFeature feature)
        {
            IEnvelope envelope = feature.Shape.Envelope;
            double longestSide = (envelope.Width > envelope.Height) ? envelope.Width : envelope.Height;
            double buffer = longestSide * .05;
            ITopologicalOperator topoop = feature.ShapeCopy as ITopologicalOperator;
            IGeometry geometry = topoop.Buffer(buffer);
            IPolygon polygon = geometry as IPolygon;
            return polygon;
        }

        /// <summary>
        /// The CreateShapefile
        /// </summary>
        /// <param name="polygon">The polygon<see cref="IPolygon"/></param>
        /// <param name="path">The path<see cref="string"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        private void CreateShapefile(IPolygon polygon, string path, string name)
        {
            try
            {
                ISpatialReference spatialReference = polygon.SpatialReference;

                IFields outputFields = new FieldsClass();
                IFieldsEdit outputFieldsEdit = (IFieldsEdit)outputFields;

                // Create FID Field
                IField fidField = new FieldClass();
                IFieldEdit fidFieldEdit = (IFieldEdit)fidField;
                fidFieldEdit.AliasName_2 = "FID";
                fidFieldEdit.Name_2 = "ID";
                fidFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;

                outputFieldsEdit.AddField(fidField);

                //Create shape field (1)
                IField shapefield = new FieldClass();
                IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

                //Geometry definition
                IGeometryDef geometrydef = new GeometryDefClass();
                IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
                geometrydefedit.AvgNumPoints_2 = 5;
                geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                geometrydefedit.GridCount_2 = 1;
                geometrydefedit.set_GridSize(0, 200);
                geometrydefedit.HasM_2 = false;
                geometrydefedit.HasZ_2 = false;
                IClone clone = (IClone)spatialReference;
                ISpatialReference spatialreference2 = (ISpatialReference)clone;
                geometrydefedit.SpatialReference_2 = spatialreference2;
                shapefieldedit.Name_2 = "SHAPE";
                shapefieldedit.AliasName_2 = "SHAPE";
                shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                shapefieldedit.GeometryDef_2 = geometrydef;
                shapefieldedit.IsNullable_2 = true;
                shapefieldedit.Required_2 = true;
                outputFieldsEdit.AddField(shapefield);

                // Create Feature Class
                IWorkspaceName outputWorkspaceName = new WorkspaceNameClass();
                outputWorkspaceName.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapeFileWorkspaceFactory.1";
                outputWorkspaceName.PathName = path;
                IName outputName = (IName)outputWorkspaceName;
                IWorkspace outputWorkspace = (IWorkspace)outputName.Open();

                IFieldChecker outputFieldChecker = new FieldCheckerClass();
                outputFieldChecker.ValidateWorkspace = outputWorkspace;

                IEnumFieldError enumFieldError;
                IClone iClone = (IClone)outputFields;
                IFields cloneFields = (IFields)iClone.Clone();
                IFields newOutputFields;
                outputFieldChecker.Validate(cloneFields, out enumFieldError, out newOutputFields);

                IFeatureClass outputFeatureClass;
                IFeatureWorkspace outputFeatureWorkspace = (IFeatureWorkspace)outputWorkspace;
                outputFeatureClass = outputFeatureWorkspace.CreateFeatureClass(name, newOutputFields, null, null, esriFeatureType.esriFTSimple, "SHAPE", "");

                // Add Polygon To Feature Class
                IFeature newFeature = outputFeatureClass.CreateFeature();
                newFeature.Shape = polygon;
                newFeature.Store();
                newFeature = null;
                outputFeatureClass = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error Exporting Shapfile {name}", MB_TITLE);
            }
        }

        /// <summary>
        /// The GetListOfLasFiles
        /// </summary>
        /// <returns>The <see cref="IEnumerable{string}"/></returns>
        private IEnumerable<string> GetListOfLasFiles()
        {
            // Get List of all LAS Files                       
            var ext = new List<String> { ".las", ".LAS" };
            var lasFilesFound = Directory.GetFiles(tb_las_folder.Text, "*.*",
                    chb_recursion_las.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(
                    file => ext.Contains(System.IO.Path.GetExtension(file)));
            return lasFilesFound;
        }

        /// <summary>
        /// The ValidateBoundaryFiles
        /// </summary>
        /// <param name="tiles">The tiles<see cref="List{String}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool ValidateBoundaryFiles(List<String> tiles)
        {
            var lasFilesFound = GetListOfLasFiles();

            bool AllFound = true;

            foreach (string tile in tiles)
            {
                var match = lasFilesFound.FirstOrDefault(lasFileFound => lasFileFound.Contains(tile));

                if (match == null)
                {
                    AllFound = false;
                }
            }

            return AllFound;
        }

        /// <summary>
        /// The GetLasPathFromTileName
        /// </summary>
        /// <param name="tilename">The tilename<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string GetLasPathFromTileName(string tilename)
        {
            var lasFilesFound = GetListOfLasFiles();
            var match = lasFilesFound.FirstOrDefault(lasFileFound => lasFileFound.Contains(tilename));

            return match == null ? "" : match;
        }

        /// <summary>
        /// The CheckRequirements_LAS
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool CheckRequirements_LAS()
        {
            try
            {
                if (chb_selected_las_tiles.Checked)
                {
                    IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
                    IFeatureSelection featureSelection = featureLayer as IFeatureSelection;

                    if (featureSelection.SelectionSet.Count < 1)
                    {
                        MessageBox.Show("Select an LAS Tile", MB_TITLE);
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Code: 230492801\n\n{ex.Message}");
                return false;
            }


            return true;
        }

        /// <summary>
        /// The Create_LAS_List
        /// </summary>
        /// <param name="lasFiles">The lasFiles<see cref="Dictionary{string, string}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool Create_LAS_List(Dictionary<string, string> lasFiles)
        {
            // Get List of all LAS Files                       
            var ext = new List<String> { ".las", ".LAS" };
            var lasFilesFound = Directory.GetFiles(tb_las_folder.Text, "*.*",
                    chb_recursion_las.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(
                    file => ext.Contains(System.IO.Path.GetExtension(file)));

            // Get Layer Ready
            IFeatureLayer tilelayout_las_layer = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
            IFeatureClass tilelayout_las_fc = tilelayout_las_layer.FeatureClass;
            int FieldIndex = _utilitiesArcMap.FindField(tilelayout_las_fc, cb_field_las.Text);

            // Gets a list of all the tile names
            List<String> lasTileNames = new List<string>();

            if (chb_selected_las_tiles.Checked)
            {
                IFeatureSelection featureSelection = tilelayout_las_layer as IFeatureSelection;
                int featurecount = featureSelection.SelectionSet.Count;

                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                enumIDs.Reset();
                int intOID = enumIDs.Next();
                while (intOID != -1 && intOID > -1)
                {
                    IFeature feature = tilelayout_las_fc.GetFeature(intOID);
                    if (feature != null)
                    {
                        string tilename = feature.get_Value(FieldIndex).ToString();
                        lasTileNames.Add(tilename);
                    }
                    intOID = enumIDs.Next();

                    // Add a tile found
                    _report_totalLASTileCount += 1;

                }
            }
            else
            {
                IFeatureCursor cursor = tilelayout_las_fc.Search(null, false);
                IFields fields = cursor.Fields;
                IFeature feature = null;

                while ((feature = cursor.NextFeature()) != null)
                {
                    string tilename = feature.get_Value(FieldIndex).ToString();
                    lasTileNames.Add(tilename);

                    // Add a tile found
                    _report_totalLASTileCount += 1;
                }
            }

            // Check for exitence
            Dictionary<string, string> missingLasFiles = new Dictionary<string, string>();


            foreach (string lasTileName in lasTileNames)
            {
                var match = lasFilesFound.FirstOrDefault(lasFileFound => lasFileFound.Contains(lasTileName));

                if (match != null)
                {
                    lasFiles.Add(lasTileName, match);

                    // Update Report
                    _report_foundLASFileCount += 1;
                }
                else
                {
                    missingLasFiles.Add(lasTileName, match);
                }
            }

            // Report Missing Tiles
            if (missingLasFiles.Count() > 0)
            {
                string missingFilesCSVPath = $"{tb_output.Text}\\Missing_LAS_Files.csv";

                var csv = new StringBuilder();

                foreach (KeyValuePair<string, string> missingFile in missingLasFiles)
                {
                    csv.AppendLine(missingFile.Key);
                }

                File.WriteAllText(missingFilesCSVPath, csv.ToString());

                //if (MessageBox.Show($"There are {missingLasFiles.Count()} missing LAS files. This could defeat the purpose. A CSV will be outputted with names of missing las files.\n\nWould you like to continue anyways?", MB_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                //{
                //    return false;
                //}

                // Update Report
                _report_missingLasFileCount = missingLasFiles.Count();
            }
            return true;
        }

        /// <summary>
        /// The Export_SHP_Tiles_LAS
        /// </summary>
        /// <param name="lasFiles">The lasFiles<see cref="Dictionary{String, String}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool Export_SHP_Tiles_LAS(Dictionary<String, String> lasFiles)
        {
            if (!Directory.Exists(_output_shp_original_folder))
                System.IO.Directory.CreateDirectory(_output_shp_original_folder);
            if (!Directory.Exists(_output_shp_buffered_folder))
                System.IO.Directory.CreateDirectory(_output_shp_buffered_folder);

            IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
            IFeatureClass featureClass = featureLayer.FeatureClass;
            int fieldIndex = _utilitiesArcMap.FindField(featureClass, cb_field_las.Text);

            if (chb_selected_las_tiles.Checked)
            {
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                enumIDs.Reset();
                int intOID = enumIDs.Next();
                while (intOID != null && intOID > -1)
                {
                    IFeature feature = featureClass.GetFeature(intOID);

                    if (feature != null)
                    {
                        string tileName = feature.get_Value(fieldIndex).ToString();
                        if (lasFiles.ContainsKey(tileName))
                        {
                            try
                            {
                                // Original File
                                string shapefileOutputPath = $"{_output_shp_original_folder}\\{tileName}.shp";
                                IPolygon exportPolygon = feature.Shape as IPolygon;
                                if (!File.Exists(shapefileOutputPath))
                                    CreateShapefile(exportPolygon, _output_shp_original_folder, tileName);

                                // Update Report
                                _report_totalOriginalSHPOutput += 1;
                            }
                            catch (Exception ex)
                            {

                            }

                            try
                            {
                                // Buffered File
                                IPolygon exportBufferedPolygon = CreateOverlapPolygon(feature);
                                string shapefileBufferedOutputPath = $"{_output_shp_buffered_folder}\\{tileName}.shp";
                                if (!File.Exists(shapefileBufferedOutputPath))
                                    CreateShapefile(exportBufferedPolygon, _output_shp_buffered_folder, tileName);

                                // Update Report
                                _report_totalBufferedSHPOutput += 1;
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                    intOID = enumIDs.Next();
                }

            }
            else
            {
                IFeatureCursor cursor = featureClass.Search(null, false);
                IFields fields = cursor.Fields;
                IFeature feature = null;
                while ((feature = cursor.NextFeature()) != null)
                {
                    string tileName = feature.get_Value(fieldIndex).ToString();
                    if (lasFiles.ContainsKey(tileName))
                    {
                        try
                        {
                            // Original File
                            string shapefileOutputPath = $"{_output_shp_original_folder}\\{tileName}.shp";
                            IPolygon exportPolygon = feature.Shape as IPolygon;
                            if (!File.Exists(shapefileOutputPath))
                                CreateShapefile(exportPolygon, _output_shp_original_folder, tileName);

                            // Update Report
                            _report_totalOriginalSHPOutput += 1;
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            // Buffered File
                            IPolygon exportBufferedPolygon = CreateOverlapPolygon(feature);
                            string shapefileBufferedOutputPath = $"{_output_shp_buffered_folder}\\{tileName}.shp";
                            if (!File.Exists(shapefileBufferedOutputPath))
                                CreateShapefile(exportBufferedPolygon, _output_shp_buffered_folder, tileName);

                            // Update Report
                            _report_totalBufferedSHPOutput += 1;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// The ExportMergeCommands_LAS
        /// </summary>
        /// <param name="lasFiles">The lasFiles<see cref="Dictionary{String, String}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool ExportMergeCommands_LAS(Dictionary<String, String> lasFiles)
        {
            if (!Directory.Exists(_output_batch_folder))
                Directory.CreateDirectory(_output_batch_folder);
            if (!Directory.Exists(_output_las_merged_folder))
                Directory.CreateDirectory(_output_las_merged_folder);
            if (!Directory.Exists(_output_las_clipped_folder))
                Directory.CreateDirectory(_output_las_clipped_folder);
            if (!Directory.Exists(_output_list_folder))
                Directory.CreateDirectory(_output_list_folder);

            IFeatureLayer featureLayer = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
            IFeatureClass featureClass = featureLayer.FeatureClass;
            int fieldIndex = _utilitiesArcMap.FindField(featureClass, cb_field_las.Text);


            if (chb_selected_las_tiles.Checked)
            {
                List<String> tilesThatSuccessfullyPassedForMerging = new List<string>();
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                enumIDs.Reset();
                int intOID;
                while ((intOID = enumIDs.Next()) > -1)
                {
                    IFeature feature = featureClass.GetFeature(intOID);
                    string tilename = feature.get_Value(fieldIndex).ToString();
                    string outputListFile = $"{_output_list_folder}\\{tilename}.list";

                    if (feature != null)
                    {
                        ISpatialFilter spatialFilter = new SpatialFilterClass();
                        spatialFilter.Geometry = CreateOverlapPolygon(feature);
                        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        spatialFilter.GeometryField = featureClass.ShapeFieldName;
                        IFeatureCursor cursor = featureClass.Search(spatialFilter, false);
                        IFeature feature2 = null;

                        List<string> foundTiles = new List<String>();

                        while ((feature2 = cursor.NextFeature()) != null)
                        {
                            foundTiles.Add(feature2.get_Value(fieldIndex).ToString());
                        }

                        // This is useless, just wrote the functionality if it become an issue could come up with warning or error 
                        if (!ValidateBoundaryFiles(foundTiles))
                        {
                            //continue; Export Reguardless
                        }

                        // Build List
                        var outputList = new StringBuilder();

                        foreach (string tile in foundTiles)
                        {
                            var lasFilePath = GetLasPathFromTileName(tile);
                            if (lasFilePath != "")
                                outputList.AppendLine(lasFilePath);
                        }

                        File.WriteAllText(outputListFile, outputList.ToString());
                    }

                    var command = new StringBuilder();
                    command.AppendLine($"set PATH=\"{tb_erdastools.Text}\";\"{tb_geoexpress.Text}\"");

                    command.AppendLine($"mrsidgeoencoder -i {outputListFile} -o {_output_las_merged_folder}\\{tilename}.las");

                    command.AppendLine($"pointcloudtoolscommand -t filter -i {_output_las_merged_folder}\\{tilename}.las -o {_output_las_clipped_folder}\\{tilename}.las -classification '' -include {_output_shp_buffered_folder}\\{tilename}.shp -return ''");

                    if (cb_deleteMergedLAS.Checked)
                        command.Append($"del {_output_las_merged_folder}\\{tilename}.las");

                    string batchFilePath = $"{_output_batch_folder}\\{tilename}.bat";

                    File.WriteAllText(batchFilePath, command.ToString());

                    // Update Report
                    _report_batchFilesWritten += 1;
                }
            }
            else
            {
                List<String> tilesThatSuccessfullyPassedForMerging = new List<string>();

                IFeatureCursor cursor = featureClass.Search(null, false);
                IFields fields = cursor.Fields;
                IFeature feature = null;
                while ((feature = cursor.NextFeature()) != null)
                {
                    var command = new StringBuilder();
                    command.AppendLine($"set PATH=\"{tb_erdastools.Text}\";\"{tb_geoexpress.Text}\"");

                    string tilename = feature.get_Value(fieldIndex).ToString();
                    string outputListFile = $"{_output_list_folder}\\{tilename}.list";

                    ISpatialFilter spatialFilter = new SpatialFilterClass();
                    spatialFilter.Geometry = CreateOverlapPolygon(feature);
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    spatialFilter.GeometryField = featureClass.ShapeFieldName;
                    IFeatureCursor cursor2 = featureClass.Search(spatialFilter, false);
                    IFeature feature2 = null;

                    List<string> foundTiles = new List<String>();

                    while ((feature2 = cursor2.NextFeature()) != null)
                    {
                        foundTiles.Add(feature2.get_Value(fieldIndex).ToString());
                    }

                    // This is useless, just wrote the functionality if it become an issue could come up with warning or error 
                    if (!ValidateBoundaryFiles(foundTiles))
                    {
                        continue;
                    }

                    // Build List
                    var outputList = new StringBuilder();


                    foreach (string tile in foundTiles)
                    {
                        var lasFilePath = GetLasPathFromTileName(tile);
                        if (lasFilePath != "")
                            outputList.AppendLine(lasFilePath);
                    }

                    File.WriteAllText(outputListFile, outputList.ToString());

                    command.AppendLine($"mrsidgeoencoder -i {outputListFile} -o {_output_las_merged_folder}\\{tilename}.las");

                    command.Append($"pointcloudtoolscommand -t filter -i {_output_las_merged_folder}\\{tilename}.las -o {_output_las_clipped_folder}\\{tilename}.las -classification '' -include {_output_shp_buffered_folder}\\{tilename}.shp -return ''");

                    if (cb_deleteMergedLAS.Checked)
                        command.Append($"del {_output_las_merged_folder}\\{tilename}.las");

                    string batchFilePath = $"{_output_batch_folder}\\{tilename}.bat";

                    File.WriteAllText(batchFilePath, command.ToString());

                    // Update Report
                    _report_batchFilesWritten += 1;
                }

            }

            return true;
        }

        /// <summary>
        /// The ShowReport_LAS
        /// </summary>
        private void ShowReport_LAS()
        {
            var report = new StringBuilder();

            report.AppendLine($"Completed Processing {_report_totalLASTileCount} LAS Tiles");
            report.AppendLine($"---------------------------------------------------------------------");
            report.AppendLine($"LAS Files Found:                   {_report_foundLASFileCount}");
            report.AppendLine($"LAS Files Missing:                 {_report_missingLasFileCount}");
            if (_report_missingLasFileCount > 0)
                report.AppendLine("You can find a csv file in the output folder with the name of each missing las file");
            report.AppendLine("");
            report.AppendLine($"Original Shapefile Tiles Exported: {_report_totalOriginalSHPOutput}");
            report.AppendLine($"Buffered Shapefile Tiles Exported: {_report_totalBufferedSHPOutput}");
            report.AppendLine("");
            report.AppendLine($"Batch Files Exported:              {_report_batchFilesWritten}");

            var reportForm = new Report(report.ToString());
            reportForm.ShowDialog();
            
        }

        /// <summary>
        /// The CheckRequirements_LAS_Ortho
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool CheckRequirements_LAS_Ortho()
        {
            try
            {
                if (cb_tile_layout_ortho.SelectedIndex < 0)
                {
                    MessageBox.Show("Select an Ortho Tile Layout", MB_TITLE);
                    return false;
                }

                if (cb_field_ortho.SelectedIndex < 0)
                {
                    MessageBox.Show("Select a fieldf or the Ortho Tile Layout that corrisponds to the LAS file name");
                    return false;
                }

                ILayer tilelayout_ortho_layer = _utilitiesArcMap.Layer(this.cb_tile_layout_ortho.Text);

                if (tilelayout_ortho_layer == null)
                {
                    MessageBox.Show("Ortho Tile Layout Does Not Exist", MB_TITLE);
                    return false;
                }


                int fieldindex = _utilitiesArcMap.FindField(tilelayout_ortho_layer, cb_field_ortho.Text);
                if (fieldindex < 0)
                {
                    MessageBox.Show("Ortho Field Does NOt Exist", MB_TITLE);
                    return false;
                }

                if (chb_selected_ortho_tiles.Checked)
                {
                    IFeatureSelection featureSelection = tilelayout_ortho_layer as IFeatureSelection;

                    if (featureSelection.SelectionSet.Count < 1)
                    {
                        MessageBox.Show("Select an Ortho Tile", MB_TITLE);
                        return false;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error 1230954012: Please Close and Try Again", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// The Create_LAS_List_Ortho
        /// </summary>
        /// <param name="lasOrthoFiles">The lasOrthoFiles<see cref="Dictionary{string, List{String}}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool Create_LAS_List_Ortho(Dictionary<string, List<String>> lasOrthoFiles)
        {
            // Get List of all LAS Files Found
            var lasFilesFound = GetListOfLasFiles();

            // Get Layer Ready
            IFeatureLayer featureLayerLAS = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
            IFeatureLayer featureLayerOrtho = _utilitiesArcMap.FeatureLayer(cb_tile_layout_ortho.Text);

            // Get Feature Class Ready
            IFeatureClass featureClassLAS = featureLayerLAS.FeatureClass;
            IFeatureClass featureClassOrtho = featureLayerOrtho.FeatureClass;

            // Get Field Indexs
            int fieldIndexLAS = _utilitiesArcMap.FindField(featureClassLAS, cb_field_las.Text);
            int fieldIndexOrtho = _utilitiesArcMap.FindField(featureClassOrtho, cb_field_ortho.Text);

            // Where I will save data, then I will check each las file existence and add it to the argument
            Dictionary<String, List<String>> tilesFoundPrelim = new Dictionary<string, List<string>>();

            // Las Tile Names found on intersect
            List<string> foundTilesLAS = new List<string>();

            if (chb_selected_ortho_tiles.Checked)
            {
                // Get The Ortho Tilelayout features that are selected
                IFeatureSelection featureSelection = featureLayerOrtho as IFeatureSelection;

                IEnumIDs ids = featureSelection.SelectionSet.IDs;
                ids.Reset();

                int oid = ids.Next();
                while (oid != -1 && oid > -1)
                {
                    // Clear LAS Tile List
                    foundTilesLAS = new List<string>();

                    IFeature feature = featureClassOrtho.GetFeature(oid);
                    string orthoTileName = feature.get_Value(fieldIndexOrtho).ToString();

                    if (feature != null)
                    {
                        ISpatialFilter spatialFilter = new SpatialFilterClass();
                        spatialFilter.Geometry = CreateOverlapPolygon(feature);
                        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        spatialFilter.GeometryField = featureClassLAS.ShapeFieldName;
                        IFeatureCursor cursor = featureClassLAS.Search(spatialFilter, false);
                        IFeature feature2 = null;

                        while ((feature2 = cursor.NextFeature()) != null)
                        {
                            foundTilesLAS.Add(feature2.get_Value(fieldIndexLAS).ToString());

                            // Add a las tile found
                            _report_totalLASTileCount += 1;
                        }

                        tilesFoundPrelim.Add(orthoTileName, foundTilesLAS);
                    }
                    oid = ids.Next();

                    // Add a ortho tile found
                    _report_totalOrthoTileCount += 1;
                }
            }
            else
            {
                IFeatureCursor cursor = featureClassOrtho.Search(null, false);
                IFeature feature = null;

                while ((feature = cursor.NextFeature()) != null)
                {
                    // Clear LAS Tile List
                    foundTilesLAS = new List<string>();

                    string tileName = feature.get_Value(fieldIndexOrtho).ToString();

                    ISpatialFilter spatialFilter = new SpatialFilterClass();
                    spatialFilter.Geometry = CreateOverlapPolygon(feature);
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    spatialFilter.GeometryField = featureClassLAS.ShapeFieldName;
                    IFeatureCursor cursor2 = featureClassLAS.Search(spatialFilter, false);
                    IFeature feature2 = null;

                    while ((feature2 = cursor2.NextFeature()) != null)
                    {
                        foundTilesLAS.Add(feature2.get_Value(fieldIndexLAS).ToString());

                        // Add a las tile found
                        _report_totalLASTileCount += 1;
                    }
                    tilesFoundPrelim.Add(tileName, foundTilesLAS);

                    // Add a ortho tile found
                    _report_totalOrthoTileCount += 1;
                }
            }

            // Check for exitence
            HashSet<string> missingLasFiles = new HashSet<string>();
            HashSet<string> foundLASFiles = new HashSet<string>();
           
            foreach (string orthoTile in tilesFoundPrelim.Keys)
            {
                List<string> lasFilesCoveringOrthoTile = new List<string>();


                foreach (string lasTile in tilesFoundPrelim[orthoTile])
                {
                    string path = GetLasPathFromTileName(lasTile);

                    if (path == "")
                    {
                        missingLasFiles.Add(lasTile);
                    }
                    else
                    {
                        foundLASFiles.Add(lasTile);
                        lasFilesCoveringOrthoTile.Add(lasTile);
                    }                    
                }

                if (missingLasFiles.Count() > 0)
                {
                    // Update Report
                    _report_orthoFileWithoutFullCoverageCount += 1;
                }

                lasOrthoFiles.Add(orthoTile, lasFilesCoveringOrthoTile);
            }

            // Update Report
            _report_missingLasFileCount = missingLasFiles.Count();
            _report_foundLASFileCount = foundLASFiles.Count();

            if (missingLasFiles.Count() > 0)
            {
                string missingFilesCSVPath = $"{tb_output.Text}\\Missing_LAS_Files.csv";

                var csv = new StringBuilder();

                foreach (string missingFile in missingLasFiles)
                {
                    csv.AppendLine(missingFile);
                }

                File.WriteAllText(missingFilesCSVPath, csv.ToString());

            }
            return true;
        }

        /// <summary>
        /// The Export_SHP_Tiles_LAS_Ortho
        /// </summary>
        /// <param name="lasOrthoFiles">The lasOrthoFiles<see cref="Dictionary{String, List{String}}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool Export_SHP_Tiles_LAS_Ortho(Dictionary<String, List<String>> lasOrthoFiles)
        {
            if (!Directory.Exists(_output_shp_original_folder))
                System.IO.Directory.CreateDirectory(_output_shp_original_folder);
            if (!Directory.Exists(_output_shp_buffered_folder))
                System.IO.Directory.CreateDirectory(_output_shp_buffered_folder);

            // Get Layer Ready
            IFeatureLayer featureLayerOrtho = _utilitiesArcMap.FeatureLayer(cb_tile_layout_ortho.Text);

            // Get Feature Class Ready
            IFeatureClass featureClassOrtho = featureLayerOrtho.FeatureClass;

            // Get Field Indexs
            int fieldIndexOrtho = _utilitiesArcMap.FindField(featureClassOrtho, cb_field_ortho.Text);

            if (chb_selected_ortho_tiles.Checked)
            {
                IFeatureSelection featureSelection = featureLayerOrtho as IFeatureSelection;
                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                enumIDs.Reset();
                int intOID = enumIDs.Next();
                while (intOID > -1)
                {
                    IFeature featureOrtho = featureClassOrtho.GetFeature(intOID);

                    if (featureOrtho != null)
                    {
                        string tileNameOrtho = featureOrtho.get_Value(fieldIndexOrtho).ToString();

                        if (lasOrthoFiles.ContainsKey(tileNameOrtho))
                        {
                            try
                            {
                                // Original File
                                string shapefileOutputPath = $"{_output_shp_original_folder}\\{tileNameOrtho}.shp";
                                IPolygon exportPolygon = featureOrtho.Shape as IPolygon;
                                if (!File.Exists(shapefileOutputPath))
                                    CreateShapefile(exportPolygon, _output_shp_original_folder, tileNameOrtho);

                                // Update Report
                                _report_totalOriginalSHPOutput += 1;
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {
                                // Buffered File
                                IPolygon exportBufferedPolygon = CreateOverlapPolygon(featureOrtho);
                                string shapefileBufferedOutputPath = $"{_output_shp_buffered_folder}\\{tileNameOrtho}.shp";
                                if (!File.Exists(shapefileBufferedOutputPath))

                                    CreateShapefile(exportBufferedPolygon, _output_shp_buffered_folder, tileNameOrtho);

                                // Update Report
                                _report_totalBufferedSHPOutput += 1;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }

                    intOID = enumIDs.Next();
                }
            }
            else
            {
                IFeatureCursor cursor = featureClassOrtho.Search(null, false);
                IFeature feature = null;
                while ((feature = cursor.NextFeature()) != null)
                {
                    string tileNameOrtho = feature.get_Value(fieldIndexOrtho).ToString();
                    if (lasOrthoFiles.ContainsKey(tileNameOrtho))
                    {
                        try
                        {
                            // Original File
                            string shapefileOutputPath = $"{_output_shp_original_folder}\\{tileNameOrtho}.shp";
                            IPolygon exportPolygon = feature.Shape as IPolygon;
                            if (!File.Exists(shapefileOutputPath))
                                CreateShapefile(exportPolygon, _output_shp_original_folder, tileNameOrtho);

                            // Update Report
                            _report_totalOriginalSHPOutput += 1;
                        }
                        catch (Exception ex) { }

                        try
                        {
                            // Buffered File
                            IPolygon exportBufferedPolygon = CreateOverlapPolygon(feature);
                            string shapefileBufferedOutputPath = $"{_output_shp_buffered_folder}\\{tileNameOrtho}.shp";
                            if (!File.Exists(shapefileBufferedOutputPath))
                                CreateShapefile(exportBufferedPolygon, _output_shp_buffered_folder, tileNameOrtho);

                            // Update Report
                            _report_totalBufferedSHPOutput += 1;
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// The ExportMergeCommands_LAS_Ortho
        /// </summary>
        /// <param name="lasOrthoFiles">The lasOrthoFiles<see cref="Dictionary{String, List{String}}"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool ExportMergeCommands_LAS_Ortho(Dictionary<String, List<String>> lasOrthoFiles)
        {
            if (!Directory.Exists(_output_batch_folder))
                Directory.CreateDirectory(_output_batch_folder);
            if (!Directory.Exists(_output_las_merged_folder))
                Directory.CreateDirectory(_output_las_merged_folder);
            if (!Directory.Exists(_output_las_clipped_folder))
                Directory.CreateDirectory(_output_las_clipped_folder);
            if (!Directory.Exists(_output_list_folder))
                Directory.CreateDirectory(_output_list_folder);

            // Get Layer Ready
            IFeatureLayer featureLayerLAS = _utilitiesArcMap.FeatureLayer(cb_tile_layout_las.Text);
            IFeatureLayer featureLayerOrtho = _utilitiesArcMap.FeatureLayer(cb_tile_layout_ortho.Text);

            // Get Feature Class Ready
            IFeatureClass featureClassLAS = featureLayerLAS.FeatureClass;
            IFeatureClass featureClassOrtho = featureLayerOrtho.FeatureClass;

            // Get Field Indexs
            int fieldIndexLAS = _utilitiesArcMap.FindField(featureClassLAS, cb_field_las.Text);
            int fieldIndexOrtho = _utilitiesArcMap.FindField(featureClassOrtho, cb_field_ortho.Text);


            foreach (KeyValuePair<string, List<string>> tile in lasOrthoFiles)
            {
                try
                {

                    var outputList = new StringBuilder();
                    string outputListFile = $"{_output_list_folder}\\{tile.Key}.list";

                    if (!ValidateBoundaryFiles(tile.Value))
                    {
                        continue;
                    }


                    foreach (string lasTile in tile.Value)
                    {
                        var lasFilePath = GetLasPathFromTileName(lasTile);
                        if (lasFilePath != "")
                            outputList.AppendLine(lasFilePath);
                    }

                    File.WriteAllText(outputListFile, outputList.ToString());

                    var command = new StringBuilder();
                    command.AppendLine($"set PATH=\"{tb_erdastools.Text}\";\"{tb_geoexpress.Text}\"");

                    command.AppendLine($"mrsidgeoencoder -i {outputListFile} -o {_output_las_merged_folder}\\{tile.Key}.las");

                    command.AppendLine($"pointcloudtoolscommand -t filter -i {_output_las_merged_folder}\\{tile.Key}.las -o {_output_las_clipped_folder}\\{tile.Key}.las -classification '' -include {_output_shp_buffered_folder}\\{tile.Key}.shp -return ''");

                    if (cb_deleteMergedLAS.Checked)
                        command.Append($"del {_output_las_merged_folder}\\{tile.Key}.las");

                    string batchFilePath = $"{_output_batch_folder}\\{tile.Key}.bat";

                    File.WriteAllText(batchFilePath, command.ToString());

                    _report_batchFilesWritten += 1;
                }
                catch (Exception ex)
                {

                }

                

            }

            return true;
        }

        /// <summary>
        /// The ShowReport_LASOrtho
        /// </summary>
        private void ShowReport_LASOrtho()
        {
            var report = new StringBuilder();

            report.AppendLine($"Completed Processing {_report_totalOrthoTileCount} Ortho Tiles");
            report.AppendLine($"---------------------------------------------------------------------");
            report.AppendLine($"Ortho Tiles Without Full LAS Coverage: {_report_orthoFileWithoutFullCoverageCount}");
            report.AppendLine("");
            report.AppendLine($"LAS Files Found:                   {_report_foundLASFileCount}");
            report.AppendLine($"LAS Files Missing:                 {_report_missingLasFileCount}");
            if (_report_missingLasFileCount > 0)
                report.AppendLine("You can find a csv file in the output folder with the name of each missing las file");
            report.AppendLine("");
            report.AppendLine($"Original Shapefile Tiles Exported: {_report_totalOriginalSHPOutput}");
            report.AppendLine($"Buffered Shapefile Tiles Exported: {_report_totalBufferedSHPOutput}");
            report.AppendLine("");
            report.AppendLine($"Batch Files Exported:              {_report_batchFilesWritten}");

            var reportForm = new Report(report.ToString());
            reportForm.ShowDialog();
        }
    }
}
