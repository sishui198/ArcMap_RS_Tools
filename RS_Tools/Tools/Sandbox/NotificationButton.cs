using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.ArcMapUI;

namespace RS_Tools.Tools.Sandbox
{
    public class NotificationButton : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public NotificationButton()
        {
        }

        protected override void OnClick()
        {
            IApplication application = this.Hook as IApplication;
            IStatusBar statusBar = application.StatusBar;
            statusBar.Message[0] = "look Here";


        }




        protected override void OnUpdate()
        {
        }


    }
}
