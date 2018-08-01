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
            this.rb100 = new System.Windows.Forms.RadioButton();
            this.rb125 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rb150 = new System.Windows.Forms.RadioButton();
            this.rb200 = new System.Windows.Forms.RadioButton();
            this.rb250 = new System.Windows.Forms.RadioButton();
            this.rb300 = new System.Windows.Forms.RadioButton();
            this.rb350 = new System.Windows.Forms.RadioButton();
            this.rb400 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_CopyStatus
            // 
            this.btn_CopyStatus.Image = ((System.Drawing.Image)(resources.GetObject("btn_CopyStatus.Image")));
            this.btn_CopyStatus.Location = new System.Drawing.Point(6, 405);
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
            this.lblReport.Size = new System.Drawing.Size(96, 17);
            this.lblReport.TabIndex = 14;
            this.lblReport.Text = "......................";
            // 
            // btnOKStay
            // 
            this.btnOKStay.ForeColor = System.Drawing.Color.Blue;
            this.btnOKStay.Image = ((System.Drawing.Image)(resources.GetObject("btnOKStay.Image")));
            this.btnOKStay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKStay.Location = new System.Drawing.Point(6, 329);
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
            this.btnOKNextScale.Location = new System.Drawing.Point(6, 291);
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
            this.btnNext.Location = new System.Drawing.Point(6, 367);
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
            this.btnOKNext.Location = new System.Drawing.Point(6, 253);
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
            this.btnInitialize.Location = new System.Drawing.Point(6, 43);
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
            this.cboBuildingLayer.Size = new System.Drawing.Size(134, 24);
            this.cboBuildingLayer.TabIndex = 8;
            this.cboBuildingLayer.SelectedIndexChanged += new System.EventHandler(this.cboBuildingLayer_SelectedIndexChanged);
            // 
            // rb100
            // 
            this.rb100.AutoSize = true;
            this.rb100.Checked = true;
            this.rb100.Location = new System.Drawing.Point(9, 138);
            this.rb100.Name = "rb100";
            this.rb100.Size = new System.Drawing.Size(69, 21);
            this.rb100.TabIndex = 16;
            this.rb100.TabStop = true;
            this.rb100.Text = "100 %";
            this.rb100.UseVisualStyleBackColor = true;
            // 
            // rb125
            // 
            this.rb125.AutoSize = true;
            this.rb125.Location = new System.Drawing.Point(9, 165);
            this.rb125.Name = "rb125";
            this.rb125.Size = new System.Drawing.Size(65, 21);
            this.rb125.TabIndex = 17;
            this.rb125.Text = "125%";
            this.rb125.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "OK, Next Scale";
            // 
            // rb150
            // 
            this.rb150.AutoSize = true;
            this.rb150.Location = new System.Drawing.Point(9, 192);
            this.rb150.Name = "rb150";
            this.rb150.Size = new System.Drawing.Size(65, 21);
            this.rb150.TabIndex = 19;
            this.rb150.Text = "150%";
            this.rb150.UseVisualStyleBackColor = true;
            // 
            // rb200
            // 
            this.rb200.AutoSize = true;
            this.rb200.Location = new System.Drawing.Point(9, 219);
            this.rb200.Name = "rb200";
            this.rb200.Size = new System.Drawing.Size(65, 21);
            this.rb200.TabIndex = 20;
            this.rb200.Text = "200%";
            this.rb200.UseVisualStyleBackColor = true;
            // 
            // rb250
            // 
            this.rb250.AutoSize = true;
            this.rb250.Location = new System.Drawing.Point(84, 138);
            this.rb250.Name = "rb250";
            this.rb250.Size = new System.Drawing.Size(65, 21);
            this.rb250.TabIndex = 21;
            this.rb250.Text = "250%";
            this.rb250.UseVisualStyleBackColor = true;
            // 
            // rb300
            // 
            this.rb300.AutoSize = true;
            this.rb300.Location = new System.Drawing.Point(84, 165);
            this.rb300.Name = "rb300";
            this.rb300.Size = new System.Drawing.Size(65, 21);
            this.rb300.TabIndex = 22;
            this.rb300.Text = "300%";
            this.rb300.UseVisualStyleBackColor = true;
            // 
            // rb350
            // 
            this.rb350.AutoSize = true;
            this.rb350.Location = new System.Drawing.Point(84, 192);
            this.rb350.Name = "rb350";
            this.rb350.Size = new System.Drawing.Size(65, 21);
            this.rb350.TabIndex = 23;
            this.rb350.Text = "350%";
            this.rb350.UseVisualStyleBackColor = true;
            // 
            // rb400
            // 
            this.rb400.AutoSize = true;
            this.rb400.Location = new System.Drawing.Point(84, 219);
            this.rb400.Name = "rb400";
            this.rb400.Size = new System.Drawing.Size(65, 21);
            this.rb400.TabIndex = 24;
            this.rb400.Text = "400%";
            this.rb400.UseVisualStyleBackColor = true;
            // 
            // Inspector
            // 
            this.Controls.Add(this.rb400);
            this.Controls.Add(this.rb350);
            this.Controls.Add(this.rb300);
            this.Controls.Add(this.rb250);
            this.Controls.Add(this.rb200);
            this.Controls.Add(this.rb150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb125);
            this.Controls.Add(this.rb100);
            this.Controls.Add(this.btn_CopyStatus);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnOKStay);
            this.Controls.Add(this.btnOKNextScale);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnOKNext);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.cboBuildingLayer);
            this.Name = "Inspector";
            this.Size = new System.Drawing.Size(214, 657);
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
        private System.Windows.Forms.RadioButton rb100;
        private System.Windows.Forms.RadioButton rb125;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb150;
        private System.Windows.Forms.RadioButton rb200;
        private System.Windows.Forms.RadioButton rb250;
        private System.Windows.Forms.RadioButton rb300;
        private System.Windows.Forms.RadioButton rb350;
        private System.Windows.Forms.RadioButton rb400;
    }
}
