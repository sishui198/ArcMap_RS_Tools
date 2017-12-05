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
            this.SuspendLayout();
            // 
            // btn_CopyStatus
            // 
            this.btn_CopyStatus.Image = ((System.Drawing.Image)(resources.GetObject("btn_CopyStatus.Image")));
            this.btn_CopyStatus.Location = new System.Drawing.Point(6, 268);
            this.btn_CopyStatus.Name = "btn_CopyStatus";
            this.btn_CopyStatus.Size = new System.Drawing.Size(131, 33);
            this.btn_CopyStatus.TabIndex = 15;
            this.btn_CopyStatus.UseVisualStyleBackColor = true;
            this.btn_CopyStatus.Click += new System.EventHandler(this.btn_CopyStatus_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(3, 15);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(73, 13);
            this.lblReport.TabIndex = 14;
            this.lblReport.Text = "......................";
            // 
            // btnOKStay
            // 
            this.btnOKStay.ForeColor = System.Drawing.Color.Blue;
            this.btnOKStay.Image = ((System.Drawing.Image)(resources.GetObject("btnOKStay.Image")));
            this.btnOKStay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKStay.Location = new System.Drawing.Point(6, 193);
            this.btnOKStay.Name = "btnOKStay";
            this.btnOKStay.Size = new System.Drawing.Size(134, 32);
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
            this.btnOKNextScale.Location = new System.Drawing.Point(6, 116);
            this.btnOKNextScale.Name = "btnOKNextScale";
            this.btnOKNextScale.Size = new System.Drawing.Size(134, 32);
            this.btnOKNextScale.TabIndex = 12;
            this.btnOKNextScale.Text = "OK, Scale";
            this.btnOKNextScale.UseVisualStyleBackColor = true;
            this.btnOKNextScale.Click += new System.EventHandler(this.btnOKNextScale_Click);
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(6, 230);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 32);
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
            this.btnOKNext.Location = new System.Drawing.Point(6, 155);
            this.btnOKNext.Name = "btnOKNext";
            this.btnOKNext.Size = new System.Drawing.Size(134, 32);
            this.btnOKNext.TabIndex = 10;
            this.btnOKNext.Text = "OK, Next";
            this.btnOKNext.UseVisualStyleBackColor = true;
            this.btnOKNext.Click += new System.EventHandler(this.btnOKNext_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Image = ((System.Drawing.Image)(resources.GetObject("btnInitialize.Image")));
            this.btnInitialize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInitialize.Location = new System.Drawing.Point(3, 43);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(134, 29);
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
            this.cboBuildingLayer.Location = new System.Drawing.Point(6, 78);
            this.cboBuildingLayer.Name = "cboBuildingLayer";
            this.cboBuildingLayer.Size = new System.Drawing.Size(134, 21);
            this.cboBuildingLayer.TabIndex = 8;
            this.cboBuildingLayer.SelectedIndexChanged += new System.EventHandler(this.cboBuildingLayer_SelectedIndexChanged);
            // 
            // Inspector
            // 
            this.Controls.Add(this.btn_CopyStatus);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnOKStay);
            this.Controls.Add(this.btnOKNextScale);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnOKNext);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.cboBuildingLayer);
            this.Name = "Inspector";
            this.Size = new System.Drawing.Size(147, 363);
            this.Load += new System.EventHandler(this.BuildingInspector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
