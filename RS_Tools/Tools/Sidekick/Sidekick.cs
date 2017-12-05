using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using System;
using System.IO;
using System.Windows.Forms;


namespace RS_Tools.Tools.Sidekick
{
    public class Sidekick : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        #region Fields

        private string APPFOLDER = "DClone";
        private IApplication _application;
        private IActiveView _activeview;
        private IMxDocument _mxdocument;
        private IMap _map;
        private IActiveViewEvents_ViewRefreshedEventHandler _activevieweventsviewrefreshed;
        private IDocumentEvents_CloseDocumentEventHandler m_evtCloseDocument;
        private IActiveViewEvents_AfterDrawEventHandler m_evtAfterDraw;
        private IEnvelope _currentExtent;
        private bool _firstRefresh = true;
        private string _workingdirectory;
        private string _extentfile;
        private bool _samescale = false;
        private bool _isthisadmin = false;
        private bool _iscloned = false;
        private bool _hasdocumentbeenclosed = false;

        #endregion

        public Sidekick()
        {
            _application = ArcMap.Application;
            UpdateEvents();
        }

        protected override void OnClick()
        {
            try
            {
                if (_hasdocumentbeenclosed)
                {
                    UpdateEvents();
                }

                _iscloned = !_iscloned;

                _workingdirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"RS_Tools\ArcMap\Sidekick");
                if (!Directory.Exists(_workingdirectory)) Directory.CreateDirectory(_workingdirectory);
                _extentfile = System.IO.Path.Combine(_workingdirectory, "extent.txt");

                _currentExtent = _mxdocument.ActiveView.Extent;

                string adminlock = System.IO.Path.Combine(_workingdirectory, "_lock");
                if (!_isthisadmin)
                {
                    if (System.IO.File.Exists(adminlock))
                    {
                        _isthisadmin = false;
                        FileSystemWatcher watcher = new FileSystemWatcher();
                        watcher.Path = _workingdirectory;
                        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                        watcher.Filter = "*.txt";
                        watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                        if (_iscloned & !_isthisadmin)
                        {
                            watcher.EnableRaisingEvents = true;
                        }
                        else
                        {
                            watcher.EnableRaisingEvents = false;
                        }
                        if (_iscloned)
                        {
                            DialogResult results = MessageBox.Show("Follow at the same map scale?", "The Clones!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (results == DialogResult.Yes) _samescale = true;
                            else _samescale = false;
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(adminlock))
                        {
                            sw.WriteLine("D'OH!, you weren't supposed to look in here!");
                        }
                        //DialogResult results = MessageBox.Show("Follow at the same map scale?", "The Clones!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (results == DialogResult.Yes) _samescale = true;
                        //else _samescale = false;
                        _isthisadmin = true;
                    }
                }
                else
                {
                    if (_iscloned)
                    {
                        //    DialogResult results = MessageBox.Show("Follow at the same map scale?", "The Clones!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (results == DialogResult.Yes) _samescale = true;
                        //    else _samescale = false;
                        _isthisadmin = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Clone Army", MessageBoxButtons.OK);
            }
        }

        protected override void OnUpdate()
        {
            this.Checked = _iscloned;
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!_iscloned) return;
            try
            {
                using (StreamReader sr = new StreamReader(_extentfile))
                {
                    double xmin, xmax, ymin, ymax, scale;
                    string readline = sr.ReadLine();
                    double.TryParse(readline, out xmin);
                    readline = sr.ReadLine();
                    double.TryParse(readline, out xmax);
                    readline = sr.ReadLine();
                    double.TryParse(readline, out ymin);
                    readline = sr.ReadLine();
                    double.TryParse(readline, out ymax);
                    IPoint point = new PointClass();
                    double x = xmin + ((xmax - xmin) / 2);
                    double y = ymin + ((ymax - ymin) / 2);
                    point.PutCoords(x, y);
                    IEnvelope extent = new EnvelopeClass();
                    extent.XMin = xmin;
                    extent.XMax = xmax;
                    extent.YMin = ymin;
                    extent.YMax = ymax;
                    readline = sr.ReadLine();
                    double.TryParse(readline, out scale);
                    if (_samescale)
                    {
                        _activeview.Extent = extent;
                        // _map.MapScale = scale;
                    }
                    else
                    {
                        extent = _activeview.Extent;
                        extent.CenterAt(point);
                        _activeview.Extent = extent;
                    }
                    //if (sr.Peek() > -1)
                    //{
                    //    readline = sr.ReadLine();
                    //    double.TryParse(readline, out scale);
                    //    _activeview.Extent = extent;
                    //    //_map.MapScale = scale;
                    //}
                    //else
                    //{
                    //    extent = _activeview.Extent;
                    //    extent.CenterAt(point);
                    //    _activeview.Extent = extent;
                    //}
                    _activeview.Refresh();
                }
            }
            catch (Exception ex)
            {
                string mesage = ex.Message;
            }
        }

        private void OnAfterDraw(IDisplay display, esriViewDrawPhase phase)
        {
            if (!_iscloned) return;
            if (!_isthisadmin) return;
            try
            {
                //reset this flag so next time active view is changed, the 'refresh view handler' code executes
                _firstRefresh = true;

            }
            catch (Exception ex)
            {
                string mesage = ex.Message;
            }
        }

        private void OnActiveViewEventsViewRefreshed(ESRI.ArcGIS.Carto.IActiveView view, ESRI.ArcGIS.Carto.esriViewDrawPhase phase, System.Object data, ESRI.ArcGIS.Geometry.IEnvelope envelope)
        {
            if (!_iscloned) return;
            if (!_isthisadmin) return;
            try
            {
                //first check if the map extent has changed
                if (ExtentHasChanged())
                {
                    //this flag is to avoid an infinite loop; any change to the map will cause this 'view refresh' 
                    //event to be fired again
                    if (_firstRefresh)
                    {
                        _firstRefresh = false;
                        using (StreamWriter sw = new StreamWriter(_extentfile))
                        {
                            sw.WriteLine(_currentExtent.XMin.ToString());
                            sw.WriteLine(_currentExtent.XMax.ToString());
                            sw.WriteLine(_currentExtent.YMin.ToString());
                            sw.WriteLine(_currentExtent.YMax.ToString());
                            sw.WriteLine(Math.Round(_map.MapScale).ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private bool ExtentHasChanged()
        {
            if (!_iscloned) return false;
            if (!_isthisadmin) return false;

            bool changed = false;

            if (_currentExtent != null)
            {
                if (_currentExtent.XMin == _mxdocument.ActiveView.Extent.XMin)
                    if (_currentExtent.XMax == _mxdocument.ActiveView.Extent.XMax)
                        if (_currentExtent.YMin == _mxdocument.ActiveView.Extent.YMin)
                            if (_currentExtent.YMax == _mxdocument.ActiveView.Extent.YMax)
                                return changed;
                //if any of the if statements are false (a change has occurred), this code executes              
                changed = true;
                _currentExtent = _mxdocument.ActiveView.Extent;
            }
            else
                _currentExtent = _mxdocument.ActiveView.Extent;
            return changed;
        }

        private void OnCloseDocument()
        {
            _hasdocumentbeenclosed = true;
            if (!_isthisadmin) return;
            string adminlock = System.IO.Path.Combine(_workingdirectory, "_lock");
            if (System.IO.File.Exists(adminlock))
            {
                System.IO.File.Delete(adminlock);
            }
        }

        private void UpdateEvents()
        {

            _mxdocument = (IMxDocument)_application.Document;
            _activeview = _mxdocument.ActiveView;
            _map = _mxdocument.FocusMap;
            Map map = _mxdocument.FocusMap as Map;

            IActiveViewEvents_Event activeviewevents = _map as IActiveViewEvents_Event;

            _activevieweventsviewrefreshed = new ESRI.ArcGIS.Carto.IActiveViewEvents_ViewRefreshedEventHandler(OnActiveViewEventsViewRefreshed);
            activeviewevents.ViewRefreshed += _activevieweventsviewrefreshed;
            m_evtCloseDocument = (OnCloseDocument);
            ((IDocumentEvents_Event)_mxdocument).CloseDocument += m_evtCloseDocument;
            m_evtAfterDraw = OnAfterDraw;
            map.AfterDraw += m_evtAfterDraw;

        }
    }
}
