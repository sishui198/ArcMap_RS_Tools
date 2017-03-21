using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RS_Tools.DockWins
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class ToggleSelectability_Dock : UserControl
    {
        #region UserControl

        public ToggleSelectability_Dock(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private ToggleSelectability_Dock m_windowUI;

            public AddinImpl()
            {
            }

            internal ToggleSelectability_Dock UI
            {
                get { return m_windowUI; }
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new ToggleSelectability_Dock(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        #endregion

        #region Field(s)

        public IApplication _application;
        private IMap _map;
        private IContentsView _contentsView;
        private IMxDocument _mxdocument;
        private Classes.Utilities _utilities;
        private const string MB_TITLE = "Toggle Selectable Layers";

        #endregion

        #region Event(s)

        private void ToggleSelectorDock_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void cboLayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer layer = _utilities.FeatureLayer(cboLayer1.Text);
            if (layer.Selectable == true)
            {
                lblLayer1.Text = "Selectable";
                lblLayer1.ForeColor = Color.Green;
            }
            else
            {
                lblLayer1.Text = "Not Selectable";
                lblLayer1.ForeColor = Color.Red;
            }
            
        }

        private void cboLayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer layer = _utilities.FeatureLayer(cboLayer2.Text);
            if (layer.Selectable == true)
            {
                lblLayer2.Text = "Selectable";
                lblLayer2.ForeColor = Color.Green;
            }
            else
            {
                lblLayer2.Text = "Not Selectable";
                lblLayer2.ForeColor = Color.Red;
            }
        }

        private void cboLayer3_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer layer = _utilities.FeatureLayer(cboLayer3.Text);
            if (layer.Selectable == true)
            {
                lblLayer3.Text = "Selectable";
                lblLayer3.ForeColor = Color.Green;
            }
            else
            {
                lblLayer3.Text = "Not Selectable";
                lblLayer3.ForeColor = Color.Red;
            }
        }

        private void cboLayer4_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer layer = _utilities.FeatureLayer(cboLayer4.Text);
            if (layer.Selectable == true)
            {
                lblLayer4.Text = "Selectable";
                lblLayer4.ForeColor = Color.Green;
            }
            else
            {
                lblLayer4.Text = "Not Selectable";
                lblLayer4.ForeColor = Color.Red;
            }
        }

        #endregion

        #region Method(s)

        private void Initialize()
        {
            CheckInitialRequirments();
        }

        private bool CheckInitialRequirments()
        {
            _application = this.Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _contentsView = _mxdocument.get_ContentsView(3); // The Selction View in TOC 

            _utilities = new Classes.Utilities(_map);

            cboLayer1.Items.Clear();
            cboLayer2.Items.Clear();
            cboLayer3.Items.Clear();
            cboLayer4.Items.Clear();

            cboLayer1.Items.AddRange(_utilities.FeatureLayers().ToArray());
            cboLayer2.Items.AddRange(_utilities.FeatureLayers().ToArray());
            cboLayer3.Items.AddRange(_utilities.FeatureLayers().ToArray());
            cboLayer4.Items.AddRange(_utilities.FeatureLayers().ToArray());

            if (this.cboLayer1.Items.Count > 0) this.cboLayer1.SelectedIndex = 0;
            if (this.cboLayer2.Items.Count > 1) this.cboLayer2.SelectedIndex = 1;
            if (this.cboLayer3.Items.Count > 2) this.cboLayer3.SelectedIndex = 2;
            if (this.cboLayer4.Items.Count > 3) this.cboLayer4.SelectedIndex = 3;

            return (cboLayer1.Items.Count != 0) ? true : false;
        }

        private bool CheckToggleRequirments(int layer_count)
        {
            IFeatureLayer featurelayer;
            try
            {
                if (cboLayer1.Items.Count < 1)
                {
                    MessageBox.Show("Add feature layers", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                switch (layer_count)
                {
                    case 1:
                        featurelayer = _utilities.FeatureLayer(cboLayer1.Text);
                        if (featurelayer.FeatureClass == null)
                            return false;
                        break;
                    case 2:
                        featurelayer = _utilities.FeatureLayer(cboLayer2.Text);
                        if (featurelayer.FeatureClass == null)
                            return false;
                        break;
                    case 3:
                        featurelayer = _utilities.FeatureLayer(cboLayer3.Text);
                        if (featurelayer.FeatureClass == null)
                            return false;
                        break;
                    case 4:
                        featurelayer = _utilities.FeatureLayer(cboLayer4.Text);
                        if (featurelayer.FeatureClass == null)
                            return false;
                        break;
                }
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public void ToggleSelectability(int layer_count)
        {
            IFeatureLayer featurelayer;
            if (CheckToggleRequirments(layer_count))
            {
                switch (layer_count)
                {
                    case 1:
                        featurelayer = _utilities.FeatureLayer(cboLayer1.Text);
                        if (featurelayer.Selectable == true) { featurelayer.Selectable = false; }
                        else { featurelayer.Selectable = true; } 
                        //cboLayer1_SelectedIndexChanged(new object(), new EventArgs());
                        break;
                    case 2:
                        featurelayer = _utilities.FeatureLayer(cboLayer2.Text);
                        if (featurelayer.Selectable == true) { featurelayer.Selectable = false; }
                        else { featurelayer.Selectable = true; }
                        //cboLayer2_SelectedIndexChanged(new object(), new EventArgs());
                        break;
                    case 3:
                        featurelayer = _utilities.FeatureLayer(cboLayer3.Text);
                        if (featurelayer.Selectable == true) { featurelayer.Selectable = false; }
                        else{ featurelayer.Selectable = true; }
                        //cboLayer3_SelectedIndexChanged(new object(), new EventArgs());
                        break;
                    case 4:
                        featurelayer = _utilities.FeatureLayer(cboLayer4.Text);
                        if (featurelayer.Selectable == true) { featurelayer.Selectable = false; }
                        else { featurelayer.Selectable = true; }
                        //cboLayer4_SelectedIndexChanged(new object(), new EventArgs());
                        break;
                }
            }
            try
            {
                cboLayer1_SelectedIndexChanged(new object(), new EventArgs());
                cboLayer2_SelectedIndexChanged(new object(), new EventArgs());
                cboLayer3_SelectedIndexChanged(new object(), new EventArgs());
                cboLayer4_SelectedIndexChanged(new object(), new EventArgs());
            }
            catch (Exception){} // "Meaningless" error catching needed
            _contentsView.Refresh(null);
        }

        #endregion   
    }
}
