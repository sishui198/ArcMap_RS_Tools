using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using RS_Tools.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RS_Tools.Tools.SurfaceGenerator
{
    class BoundaryProblem
    {

        #region Fields

        private IProgressDialog2 _progressdialog;
        public IApplication _application;
        private Utilities_ArcMap _utilities;
        private IList<string> _batches;

        #endregion

        #region Constructor

        public BoundaryProblem(IApplication application, Utilities_ArcMap utilities)
        {
            _application = application;
            _utilities = utilities;
        }

        #endregion

        #region Methods

        internal void Solve(IFeatureLayer tilelayoutfeaturelayer, IFeatureClass tilelayoutfeatureclass,
            string lasfolder, string lastoolsfolder, bool useselected, int tilenamefieldindex, decimal numberofprocesses)
        {

            _batches = new List<string>();

            ITrackCancel trackcancel = new CancelTrackerClass();
            IProgressDialogFactory progressdialogfactory = new ProgressDialogFactoryClass();
            IStepProgressor stepprogressor = progressdialogfactory.Create(trackcancel, _application.hWnd);
            stepprogressor.MinRange = 0;
            stepprogressor.MaxRange = tilelayoutfeatureclass.FeatureCount(null);
            stepprogressor.StepValue = 1;
            stepprogressor.Message = "Tiles";
            _progressdialog = (IProgressDialog2)stepprogressor; // Explict Cast
            _progressdialog.CancelEnabled = true;
            _progressdialog.Description = "Processing " + tilelayoutfeatureclass.FeatureCount(null).ToString() + " tile(s).";
            _progressdialog.Title = "Processing...";
            _progressdialog.Animation = esriProgressAnimationTypes.esriProgressSpiral;

            IGeoDataset geodataset = null;
            if (tilelayoutfeatureclass is ESRI.ArcGIS.Geodatabase.IGeoDataset)
                geodataset = (IGeoDataset)tilelayoutfeatureclass;
            else
            {
                MessageBox.Show("No projection found", "Boundary Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string mergedfolder = System.IO.Path.Combine(lasfolder, "merged");
            if (System.IO.Directory.Exists(mergedfolder))
            {
                try { System.IO.Directory.Delete(mergedfolder, true); }
                catch (Exception) { throw; }
                Thread.Sleep(1000);
            }
            try { System.IO.Directory.CreateDirectory(mergedfolder); }
            catch (Exception) { throw; }

            string shpfolder = System.IO.Path.Combine(lasfolder, "shp");
            if (System.IO.Directory.Exists(shpfolder))
            {
                try { System.IO.Directory.Delete(shpfolder, true); }
                catch (Exception) { throw; }
                Thread.Sleep(1000);
            }
            try { System.IO.Directory.CreateDirectory(shpfolder); }
            catch (Exception) { throw; }

            string clipfolder = System.IO.Path.Combine(lasfolder, "clipped");
            if (System.IO.Directory.Exists(clipfolder))
            {
                try { System.IO.Directory.Delete(clipfolder, true); }
                catch (Exception) { throw; }
                Thread.Sleep(1000);
            }
            try { System.IO.Directory.CreateDirectory(clipfolder); }
            catch (Exception) { throw; }

            try
            {
                int count = 1;
                StringBuilder indexbatchscript = new StringBuilder();
                indexbatchscript.AppendLine("set PATH=\"" + lastoolsfolder + "\"");
                StringBuilder mergebatchscript = new StringBuilder();
                bool writescripts = false;

                if (useselected)
                {
                    IFeatureSelection featureselection = tilelayoutfeaturelayer as IFeatureSelection;
                    int featurecount = featureselection.SelectionSet.Count;
                    stepprogressor.MaxRange = featureselection.SelectionSet.Count;
                    _progressdialog.Description = "Processing " + featureselection.SelectionSet.Count.ToString() + " tile(s).";
                    IEnumIDs enumIDs = featureselection.SelectionSet.IDs;
                    enumIDs.Reset();
                    int intOID = enumIDs.Next();
                    while (intOID != -1)
                    {
                        IFeature feature = tilelayoutfeatureclass.GetFeature(intOID);
                        if (feature != null)
                        {
                            IPolygon polygon = null;
                            string tilename = feature.get_Value(tilenamefieldindex).ToString();
                            string command = BuildMergedCommand(feature, tilename, lasfolder, tilelayoutfeatureclass, tilenamefieldindex, out polygon);
                            if (command.Length > 0)
                            {
                                string entry = "lasindex -i " + tilename + ".las";
                                indexbatchscript.AppendLine(entry);
                                entry = "lasmerge " + command + " -o merged\\" + tilename + ".las";
                                mergebatchscript.AppendLine(entry);
                                CreateShapefile(tilename, polygon, shpfolder, geodataset.SpatialReference);
                                writescripts = true;
                            }
                        }
                        intOID = enumIDs.Next();
                        bool cont = trackcancel.Continue();
                        if (!cont)
                            break;

                        stepprogressor.Message = "Processing segment " + count.ToString() + " of " + featurecount.ToString();
                        stepprogressor.Step();
                        count++;
                    }
                }
                else
                {
                    int featurecount = tilelayoutfeatureclass.FeatureCount(null);
                    IFeatureCursor featurecursor = tilelayoutfeatureclass.Search(null, false);
                    IFeature feature = null;
                    while ((feature = featurecursor.NextFeature()) != null)
                    {
                        IPolygon polygon = null;
                        string tilename = feature.get_Value(tilenamefieldindex).ToString();
                        string command = BuildMergedCommand(feature, tilename, lasfolder, tilelayoutfeatureclass, tilenamefieldindex, out polygon);
                        if (command.Length > 0)
                        {
                            string entry = "lasindex -i " + tilename + ".las";
                            indexbatchscript.AppendLine(entry);
                            entry = "lasmerge " + command + " -o merged\\" + tilename + ".las";
                            mergebatchscript.AppendLine(entry);
                            CreateShapefile(tilename, polygon, shpfolder, geodataset.SpatialReference);
                            writescripts = true;
                        }
                        bool cont = trackcancel.Continue();
                        if (!cont)
                            break;

                        stepprogressor.Message = "Processing segment " + count.ToString() + " of " + featurecount.ToString();
                        stepprogressor.Step();
                        count++;
                    }
                }
                if (writescripts)
                {
                    string mergefilepath = System.IO.Path.Combine(lasfolder, "_merge.bat");
                    if (System.IO.File.Exists(mergefilepath))
                    {
                        try { System.IO.File.Delete(mergefilepath); }
                        catch (Exception) { throw; }
                    }
                    string indexfilepath = System.IO.Path.Combine(lasfolder, "_index.bat");
                    if (System.IO.File.Exists(indexfilepath))
                    {
                        try { System.IO.File.Delete(indexfilepath); }
                        catch (Exception) { throw; }
                    }

                    //=====================
                    try
                    {
                        System.IO.File.WriteAllText(indexfilepath, indexbatchscript.ToString());
                        _batches.Add(indexfilepath);
                    }
                    catch (Exception) { throw; }
                    //=====================

                    //*****
                    if ((int)numberofprocesses == 1)
                    {
                        try
                        {
                            using (StreamWriter sr = new StreamWriter(mergefilepath))
                            {
                                sr.WriteLine("set PATH=\"" + lastoolsfolder + "\"");
                                sr.Write(mergebatchscript.ToString());
                            }
                            System.IO.File.WriteAllText(mergefilepath, mergebatchscript.ToString());
                            _batches.Add(mergefilepath);
                        }
                        catch (Exception) { throw; }
                    }
                    else
                    {
                        try
                        {
                            int linecount = 0, filecount = 0, batchlinecount = 0;
                            String[] lines = mergebatchscript.ToString().Split(System.Environment.NewLine.ToCharArray());
                            var newlines = new List<string>();
                            foreach (string line in lines)
                            {
                                string newline = line.Trim();
                                if (newline.Length > 0) newlines.Add(newline);
                            }
                            batchlinecount = (int)(newlines.Count / numberofprocesses) + 1;

                            do
                            {
                                if (batchlinecount >= (newlines.Count / numberofprocesses))
                                {
                                    batchlinecount = 0;
                                    filecount++;
                                    mergefilepath = System.IO.Path.Combine(lasfolder, "_merge_" + filecount + ".bat");
                                    if (System.IO.File.Exists(mergefilepath))
                                    {
                                        try { System.IO.File.Delete(mergefilepath); }
                                        catch (Exception) { throw; }
                                    }
                                    using (StreamWriter sw = new StreamWriter(mergefilepath, true))
                                    { sw.WriteLine("set PATH=\"" + lastoolsfolder + "\""); }
                                    _batches.Add(mergefilepath);
                                }

                                using (StreamWriter sw = new StreamWriter(mergefilepath, true))
                                {
                                    sw.WriteLine(newlines[linecount]);
                                    sw.WriteLine(BuildIndexCommand(newlines[linecount]));
                                    sw.WriteLine(BuildClipCommand(newlines[linecount]));
                                }
                                linecount++;
                                batchlinecount++;
                            } while (linecount < newlines.Count);

                        }
                        catch (Exception) { throw; }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Boundary Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                trackcancel = null;
                stepprogressor = null;
                _progressdialog.HideDialog();
                _progressdialog = null;
            }
        }

        internal void Run(string lasfolder)
        {
            if (_batches != null)
            {
                foreach (string batch in _batches)
                {
                    if (batch.IndexOf("_index.bat") > -1)
                        RunBatch(batch, lasfolder, true);
                    else
                        RunBatch(batch, lasfolder, false);
                }
            }
        }

        private bool CreateShapefile(string tilename, IPolygon polygon, string shpfolder, ISpatialReference sref)
        {
            string shapefile = System.IO.Path.Combine(shpfolder, tilename);
            if (GDBUtilities.DoesShapefileExist(shapefile)) return false;

            IFields outputfields = GDBUtilities.NewPolygonFields(sref);
            IFeatureClass outputfeatureclass = GDBUtilities.NewShapefile(shpfolder, tilename, outputfields);
            IFeature newfeature = outputfeatureclass.CreateFeature();
            newfeature.Shape = polygon;
            newfeature.Store();
            newfeature = null;
            outputfeatureclass = null;
            GC.Collect();
            return true;
        }

        private string BuildMergedCommand(IFeature feature, string currenttilename, string LASfolder,
            IFeatureClass tilelayoutfeatureclass, int tilenamefieldindex, out IPolygon polygon)
        {
            polygon = CreateOverlapShape(feature);
            string command = string.Empty;

            string tilepath = System.IO.Path.Combine(LASfolder, currenttilename + ".las");
            if (System.IO.File.Exists(tilepath))
            {
                ISpatialFilter spatialfilter = new SpatialFilterClass();
                spatialfilter.Geometry = polygon;
                spatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                spatialfilter.GeometryField = tilelayoutfeatureclass.ShapeFieldName;
                IFeatureCursor featurecursor = tilelayoutfeatureclass.Search(spatialfilter, false);
                IFeature feature2 = null;
                while ((feature2 = featurecursor.NextFeature()) != null)
                {
                    string tilename = feature2.get_Value(tilenamefieldindex).ToString();
                    if (string.Compare(tilename, currenttilename, true) != 0)
                    {
                        tilepath = System.IO.Path.Combine(LASfolder, tilename + ".las");
                        if (System.IO.File.Exists(tilepath))
                            command += " -i " + tilename + ".las";
                    }
                }
            }
            if (command.Length > 0)
            {
                command = "-i " + currenttilename + ".las" + command;
            }
            return command;
        }

        private string BuildClipCommand(string mergecommand)
        {
            string command = string.Empty;

            string[] split = mergecommand.Split(' ');
            string tilename = split[split.Length - 1].Replace("merged\\", string.Empty);
            tilename = tilename.Replace(".las", string.Empty);
            command = "lasclip -i merged\\" + tilename + ".las -poly shp\\" + tilename + ".shp -o clipped\\" + tilename + ".las";
            return command;
        }

        private string BuildIndexCommand(string mergecommand)
        {
            string command = string.Empty;

            string[] split = mergecommand.Split(' ');
            string tilename = split[split.Length - 1].Replace("merged\\", string.Empty);
            tilename = tilename.Replace(".las", string.Empty);
            command = "lasindex -i merged\\" + tilename + ".las";
            return command;
        }

        private IPolygon CreateOverlapShape(IFeature feature)
        {
            IEnvelope envelope = feature.Shape.Envelope;
            double longestside = (envelope.Width > envelope.Height) ? envelope.Width : envelope.Height;
            double buffer = longestside * 0.1;
            ITopologicalOperator topoop = feature.ShapeCopy as ITopologicalOperator;
            IGeometry geometry = topoop.Buffer(buffer);
            IPolygon polygon = geometry as IPolygon;
            return polygon;
        }

        private void RunBatch(string batchfilename, string workingdirectory, bool waitforexit)
        {
            try
            {

                Process startInfo = new Process();
                startInfo.StartInfo.FileName = batchfilename;
                startInfo.StartInfo.WorkingDirectory = workingdirectory;
                startInfo.EnableRaisingEvents = true;
                startInfo.StartInfo.UseShellExecute = true;
                startInfo.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.StartInfo.CreateNoWindow = true;

                startInfo.Start();
                if (waitforexit) startInfo.WaitForExit(); // blocks until finished

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        #endregion

    }
}
