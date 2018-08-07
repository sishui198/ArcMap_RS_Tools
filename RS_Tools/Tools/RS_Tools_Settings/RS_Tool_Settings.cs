using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using RS_Tools.Tools.Inspector;
using RS_Tools.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RS_Tools.Tools.RS_Tools_Settings
{
    public class RS_Tools_Settings : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        Settings settings = new Settings();


        public RS_Tools_Settings()
        {
            // Setup Delegates

            // Inspector
        }


        protected override void OnSave(System.IO.Stream outStrm)
        {
            //outStrm.Write(settings, 1, 1);
            base.OnSave(outStrm);
        }

        protected override void OnLoad(System.IO.Stream inStrm)
        {
            //inStrm.Read(1, 1, 1);
            base.OnLoad(inStrm);
        }

        #region Methods

        private void Load_Settings()
        {
            
        }

        internal void Save_Inspector_Ratio(double OKNextRatio)
        {
            MessageBox.Show("CHRIS STAYTE");
        }

        #endregion

    }

}
