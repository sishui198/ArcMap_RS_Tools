using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using RS_Tools.Utilities;
using System.Linq;

namespace RS_Tools.Tools.DomainAppointer
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class DomainAppointer : UserControl
    {
        #region Properties

        private const string MB_TITLE = "Domain Appointer";
        private IApplication _application;
        private IMap _map;
        private IMxDocument _mxdocument;
        private IActiveView _activeView;
        private IEditor3 _editor;
        private Utilities_ArcMap _utilities;

        #endregion

        #region Constructor

        public DomainAppointer(object hook)
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
            

            private DomainAppointer m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new DomainAppointer(this.Hook);
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

        #region Events

        private void DomainAppointer_Load(object sender, EventArgs e)
        {
            //Initialize();
        }

        private void btn_Initialize_Click(object sender, EventArgs e)
        {
            setupDelegates();
            Initialize();
        }

        private void cboFeatureLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboField.Items.Clear();
            ILayer featureLayer = _utilities.Layer(cboFeatureLayer.Text);
            cboField.Items.AddRange(_utilities.NumberFieldsWithDomain(featureLayer).ToArray());
        }

        #endregion

        #region Methods

        private void setupDelegates()
        {
            Domain_00 button0 = AddIn.FromID<Domain_00>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_00);
            Domain_01 button1 = AddIn.FromID<Domain_01>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_01);
            Domain_02 button2 = AddIn.FromID<Domain_02>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_02);
            Domain_03 button3 = AddIn.FromID<Domain_03>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_03);
            Domain_04 button4 = AddIn.FromID<Domain_04>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_04);
            Domain_05 button5 = AddIn.FromID<Domain_05>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_05);
            Domain_06 button6 = AddIn.FromID<Domain_06>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_06);
            Domain_07 button7 = AddIn.FromID<Domain_07>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_07);
            Domain_08 button8 = AddIn.FromID<Domain_08>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_08);
            Domain_09 button9 = AddIn.FromID<Domain_09>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_09);
            Domain_10 button10 = AddIn.FromID<Domain_10>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_10);
            Domain_11 button11 = AddIn.FromID<Domain_11>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_11);
            Domain_12 button12 = AddIn.FromID<Domain_12>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_12);
            Domain_13 button13 = AddIn.FromID<Domain_13>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_13);
            Domain_14 button14 = AddIn.FromID<Domain_14>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_14);
            Domain_15 button15 = AddIn.FromID<Domain_15>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_15);
            Domain_16 button16 = AddIn.FromID<Domain_16>(ThisAddIn.IDs.RS_Tools_Tools_DomainAppointer_Domain_16);


            button0.domain = ApplyDomain;
            button1.domain = ApplyDomain;
            button2.domain = ApplyDomain;
            button3.domain = ApplyDomain;
            button4.domain = ApplyDomain;
            button5.domain = ApplyDomain;
            button6.domain = ApplyDomain;
            button7.domain = ApplyDomain;
            button8.domain = ApplyDomain;
            button9.domain = ApplyDomain;
            button10.domain = ApplyDomain;
            button11.domain = ApplyDomain;
            button12.domain = ApplyDomain;
            button13.domain = ApplyDomain;
            button14.domain = ApplyDomain;
            button15.domain = ApplyDomain;
            button16.domain = ApplyDomain;
        }

        private void ApplyDomain(DomainCode code)
        {
            if (CheckRequirements())
            {
                IFeatureLayer featureLayer = _utilities.FeatureLayer(cboFeatureLayer.Text);
                IFeatureClass featureClass = featureLayer.FeatureClass;
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                IEnumIDs enumIDs = featureSelection.SelectionSet.IDs;
                int fieldIndex = _utilities.FindField(featureClass, cboField.Text);

                enumIDs.Reset();

                int intOID = enumIDs.Next();

                while (intOID != -1)
                {
                    IFeature feature = featureClass.GetFeature(intOID);
                    if (feature != null)
                    {
                        _editor.StartOperation();
                        feature.set_Value(fieldIndex, (int)code);
                        _editor.StopOperation("Update Class Type " + feature.OID);
                        feature.Store();
                    }
                    intOID = enumIDs.Next();
                }

                _activeView.Refresh();
            }
        }

        private void Initialize()
        {
            _application = Hook as IApplication;
            _mxdocument = (IMxDocument)_application.Document;
            _map = _mxdocument.FocusMap;
            _activeView = _mxdocument.ActivatedView;

            _utilities = new Utilities_ArcMap(_map);

            cboFeatureLayer.Items.Clear();
            cboField.Items.Clear();

            cboFeatureLayer.Items.AddRange(_utilities.FeatureLayers().Select(item => item.Name).ToArray());

            if (cboFeatureLayer.Items.Count > 0) cboFeatureLayer.SelectedIndex = 0;
        }

        private bool CheckRequirements()
        {
            _editor = _utilities.GetEditorFromArcMap(_application as IMxApplication);

            if (_editor == null)
            {
                MessageBox.Show("Editor verion of ArcMap Required", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (_editor.EditState != esriEditState.esriStateEditing)
            {
                MessageBox.Show("Start an edit session first", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (String.IsNullOrEmpty(cboFeatureLayer.Text))
            {
                MessageBox.Show("Initialize Tool Settings", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrEmpty(cboField.Text))
            {
                MessageBox.Show("Choose Field", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            IFeatureLayer featureLayer = _utilities.FeatureLayer((cboFeatureLayer.Text));
            if (featureLayer == null)
            {
                MessageBox.Show("Feature Layer Failed To Load", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IFeatureClass featureClass = featureLayer.FeatureClass;
            if (featureClass == null)
            {
                MessageBox.Show("Feature Class Failed To Load", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(_utilities.FindField(featureClass, cboField.Text) > -1))
            {
                MessageBox.Show("Can't Find Fields", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;

            if (featureSelection.SelectionSet.Count <= 0)
            {
                MessageBox.Show("Select at least one feature", MB_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }


        #endregion

        
    }
}
