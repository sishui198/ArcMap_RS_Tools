namespace EsriTools.Forms
{
    partial class TileLasLoader_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileLasLoader_Form));
            this.btnInitialize = new System.Windows.Forms.Button();
            this.lblLine01 = new System.Windows.Forms.Label();
            this.lblTileIndex = new System.Windows.Forms.Label();
            this.cboTileIndex = new System.Windows.Forms.ComboBox();
            this.lblLasNameField = new System.Windows.Forms.Label();
            this.cboNameField = new System.Windows.Forms.ComboBox();
            this.txbLasWorkspace = new System.Windows.Forms.TextBox();
            this.lblLasWorkspace = new System.Windows.Forms.Label();
            this.btnBrowseLas = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnInitialize.Location = new System.Drawing.Point(6, 12);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(75, 23);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // lblLine01
            // 
            this.lblLine01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine01.Location = new System.Drawing.Point(6, 43);
            this.lblLine01.Name = "lblLine01";
            this.lblLine01.Size = new System.Drawing.Size(350, 2);
            this.lblLine01.TabIndex = 9;
            // 
            // lblTileIndex
            // 
            this.lblTileIndex.AutoSize = true;
            this.lblTileIndex.Location = new System.Drawing.Point(9, 49);
            this.lblTileIndex.Name = "lblTileIndex";
            this.lblTileIndex.Size = new System.Drawing.Size(53, 13);
            this.lblTileIndex.TabIndex = 2;
            this.lblTileIndex.Text = "Tile Index";
            // 
            // cboTileIndex
            // 
            this.cboTileIndex.FormattingEnabled = true;
            this.cboTileIndex.Location = new System.Drawing.Point(13, 66);
            this.cboTileIndex.Name = "cboTileIndex";
            this.cboTileIndex.Size = new System.Drawing.Size(121, 21);
            this.cboTileIndex.TabIndex = 3;
            this.cboTileIndex.SelectedIndexChanged += new System.EventHandler(this.cboTileIndex_SelectedIndexChanged);
            // 
            // lblLasNameField
            // 
            this.lblLasNameField.AutoSize = true;
            this.lblLasNameField.Location = new System.Drawing.Point(227, 49);
            this.lblLasNameField.Name = "lblLasNameField";
            this.lblLasNameField.Size = new System.Drawing.Size(83, 13);
            this.lblLasNameField.TabIndex = 4;
            this.lblLasNameField.Text = "LAS Name Field";
            // 
            // cboNameField
            // 
            this.cboNameField.FormattingEnabled = true;
            this.cboNameField.Location = new System.Drawing.Point(230, 65);
            this.cboNameField.Name = "cboNameField";
            this.cboNameField.Size = new System.Drawing.Size(121, 21);
            this.cboNameField.TabIndex = 5;
            // 
            // txbLasWorkspace
            // 
            this.txbLasWorkspace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbLasWorkspace.Location = new System.Drawing.Point(12, 109);
            this.txbLasWorkspace.Name = "txbLasWorkspace";
            this.txbLasWorkspace.ReadOnly = true;
            this.txbLasWorkspace.Size = new System.Drawing.Size(310, 20);
            this.txbLasWorkspace.TabIndex = 6;
            // 
            // lblLasWorkspace
            // 
            this.lblLasWorkspace.AutoSize = true;
            this.lblLasWorkspace.Location = new System.Drawing.Point(9, 90);
            this.lblLasWorkspace.Name = "lblLasWorkspace";
            this.lblLasWorkspace.Size = new System.Drawing.Size(85, 13);
            this.lblLasWorkspace.TabIndex = 7;
            this.lblLasWorkspace.Text = "LAS Workspace";
            // 
            // btnBrowseLas
            // 
            this.btnBrowseLas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrowseLas.Image = global::EsriTools.Properties.Resources.searches_folder;
            this.btnBrowseLas.Location = new System.Drawing.Point(328, 107);
            this.btnBrowseLas.Name = "btnBrowseLas";
            this.btnBrowseLas.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseLas.TabIndex = 8;
            this.btnBrowseLas.UseVisualStyleBackColor = true;
            this.btnBrowseLas.Click += new System.EventHandler(this.btnBrowseLas_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(281, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TileLasLoader_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 138);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowseLas);
            this.Controls.Add(this.lblLasWorkspace);
            this.Controls.Add(this.txbLasWorkspace);
            this.Controls.Add(this.cboNameField);
            this.Controls.Add(this.lblLasNameField);
            this.Controls.Add(this.cboTileIndex);
            this.Controls.Add(this.lblTileIndex);
            this.Controls.Add(this.lblLine01);
            this.Controls.Add(this.btnInitialize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileLasLoader_Form";
            this.ShowInTaskbar = false;
            this.Text = "Tile LAS Loader";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.TileLasLoader_Form_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Label lblLine01;
        private System.Windows.Forms.Label lblTileIndex;
        private System.Windows.Forms.ComboBox cboTileIndex;
        private System.Windows.Forms.Label lblLasNameField;
        private System.Windows.Forms.ComboBox cboNameField;
        private System.Windows.Forms.TextBox txbLasWorkspace;
        private System.Windows.Forms.Label lblLasWorkspace;
        private System.Windows.Forms.Button btnBrowseLas;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}