﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RS_Tools.Tools.DomainAppointer
{
    public class Domain_07 : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ApplyDomainDelegate domain;
        public Domain_07()
        {
        }

        protected override void OnClick()
        {
            if (domain != null)
            {
                domain(DomainCode.Code7);
            }
            else
            {
                MessageBox.Show("Initialize Tool Settings");
            }
        }

        protected override void OnUpdate()
        {
        }
    }
}