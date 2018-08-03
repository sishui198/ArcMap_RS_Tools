namespace RS_Tools.Tools.Inspector
{
    partial class Inspector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspector));
            this.btn_CopyStatus = new System.Windows.Forms.Button();
            this.lblReport = new System.Windows.Forms.Label();
            this.btnOKStay = new System.Windows.Forms.Button();
            this.btnOKNextScale = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnOKNext = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.cboBuildingLayer = new System.Windows.Forms.ComboBox();
            this.lb_scaleRatio = new System.Windows.Forms.Label();
            this.tb_scale = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scale)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CopyStatus
            // 
            this.btn_CopyStatus.Image = ((System.Drawing.Image)(resources.GetObject("btn_CopyStatus.Image")));
            this.btn_CopyStatus.Location = new System.Drawing.Point(3, 316);
            this.btn_CopyStatus.Name = "btn_CopyStatus";
            this.btn_CopyStatus.Size = new System.Drawing.Size(155, 33);
            this.btn_CopyStatus.TabIndex = 15;
            this.btn_CopyStatus.UseVisualStyleBackColor = true;
            this.btn_CopyStatus.Click += new System.EventHandler(this.btn_CopyStatus_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(3, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(96, 17);
            this.lblReport.TabIndex = 14;
            this.lblReport.Text = "......................";
            // 
            // btnOKStay
            // 
            this.btnOKStay.ForeColor = System.Drawing.Color.Blue;
            this.btnOKStay.Image = ((System.Drawing.Image)(resources.GetObject("btnOKStay.Image")));
            this.btnOKStay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKStay.Location = new System.Drawing.Point(3, 240);
            this.btnOKStay.Name = "btnOKStay";
            this.btnOKStay.Size = new System.Drawing.Size(155, 32);
            this.btnOKStay.TabIndex = 13;
            this.btnOKStay.Text = "OK, Stay";
            this.btnOKStay.UseVisualStyleBackColor = true;
            this.btnOKStay.Click += new System.EventHandler(this.btnOKStay_Click);
            // 
            // btnOKNextScale
            // 
            this.btnOKNextScale.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnOKNextScale.Image = ((System.Drawing.Image)(resources.GetObject("btnOKNextScale.Image")));
            this.btnOKNextScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKNextScale.Location = new System.Drawing.Point(3, 202);
            this.btnOKNextScale.Name = "btnOKNextScale";
            this.btnOKNextScale.Size = new System.Drawing.Size(152, 32);
            this.btnOKNextScale.TabIndex = 12;
            this.btnOKNextScale.Text = "OK, Same Scale";
            this.btnOKNextScale.UseVisualStyleBackColor = true;
            this.btnOKNextScale.Click += new System.EventHandler(this.btnOKNextScale_Click);
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(3, 278);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(155, 32);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Delete";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnDeleteNext_Click);
            // 
            // btnOKNext
            // 
            this.btnOKNext.ForeColor = System.Drawing.Color.Green;
            this.btnOKNext.Image = ((System.Drawing.Image)(resources.GetObject("btnOKNext.Image")));
            this.btnOKNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKNext.Location = new System.Drawing.Point(3, 164);
            this.btnOKNext.Name = "btnOKNext";
            this.btnOKNext.Size = new System.Drawing.Size(152, 32);
            this.btnOKNext.TabIndex = 10;
            this.btnOKNext.Text = "OK, Next";
            this.btnOKNext.UseVisualStyleBackColor = true;
            this.btnOKNext.Click += new System.EventHandler(this.btnOKNext_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Image = ((System.Drawing.Image)(resources.GetObject("btnInitialize.Image")));
            this.btnInitialize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInitialize.Location = new System.Drawing.Point(3, 20);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(155, 29);
            this.btnInitialize.TabIndex = 9;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // cboBuildingLayer
            // 
            this.cboBuildingLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuildingLayer.DropDownWidth = 400;
            this.cboBuildingLayer.FormattingEnabled = true;
            this.cboBuildingLayer.Location = new System.Drawing.Point(3, 55);
            this.cboBuildingLayer.Name = "cboBuildingLayer";
            this.cboBuildingLayer.Size = new System.Drawing.Size(155, 24);
            this.cboBuildingLayer.TabIndex = 8;
            this.cboBuildingLayer.SelectedIndexChanged += new System.EventHandler(this.cboBuildingLayer_SelectedIndexChanged);
            // 
            // lb_scaleRatio
            // 
            this.lb_scaleRatio.AutoSize = true;
            this.lb_scaleRatio.Location = new System.Drawing.Point(3, 82);
            this.lb_scaleRatio.Name = "lb_scaleRatio";
            this.lb_scaleRatio.Size = new System.Drawing.Size(96, 17);
            this.lb_scaleRatio.TabIndex = 18;
            this.lb_scaleRatio.Text = "Scale Ratio: 1";
            // 
            // tb_scale
            // 
            this.tb_scale.Location = new System.Drawing.Point(3, 102);
            this.tb_scale.Maximum = 1000;
            this.tb_scale.Minimum = 100;
            this.tb_scale.Name = "tb_scale";
            this.tb_scale.Size = new System.Drawing.Size(152, 56);
            this.tb_scale.TabIndex = 25;
            this.tb_scale.TickFrequency = 25;
            this.tb_scale.Value = 100;
            this.tb_scale.ValueChanged += new System.EventHandler(this.tb_scale_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.lblReport);
            this.flowLayoutPanel1.Controls.Add(this.btnInitialize);
            this.flowLayoutPanel1.Controls.Add(this.cboBuildingLayer);
            this.flowLayoutPanel1.Controls.Add(this.lb_scaleRatio);
            this.flowLayoutPanel1.Controls.Add(this.tb_scale);
            this.flowLayoutPanel1.Controls.Add(this.btnOKNext);
            this.flowLayoutPanel1.Controls.Add(this.btnOKNextScale);
            this.flowLayoutPanel1.Controls.Add(this.btnOKStay);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btn_CopyStatus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 428);
            this.flowLayoutPanel1.TabIndex = 26;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // Inspector
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Inspector";
            this.Size = new System.Drawing.Size(203, 428);
            this.Load += new System.EventHandler(this.BuildingInspector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_scale)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CopyStatus;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Button btnOKStay;
        private System.Windows.Forms.Button btnOKNextScale;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnOKNext;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.ComboBox cboBuildingLayer;
        private System.Windows.Forms.Label lb_scaleRatio;
        private System.Windows.Forms.TrackBar tb_scale;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
