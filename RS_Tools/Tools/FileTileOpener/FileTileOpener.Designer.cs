namespace RS_Tools.Tools.FileTileOpener
{
    partial class FileTileOpener
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTileOpener));
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblTileIndex = new System.Windows.Forms.Label();
            this.lblNameField = new System.Windows.Forms.Label();
            this.cboNameField = new System.Windows.Forms.ComboBox();
            this.cboTileIndex = new System.Windows.Forms.ComboBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.lblFileWorkspace = new System.Windows.Forms.Label();
            this.txbFileWorkspace = new System.Windows.Forms.TextBox();
            this.lblLine01 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txbCustomExtension = new System.Windows.Forms.TextBox();
            this.lblCusomExtension = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitialize.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnInitialize.Location = new System.Drawing.Point(12, 12);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(82, 23);
            this.btnInitialize.TabIndex = 7;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(34, 56);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(33, 33);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblTileIndex
            // 
            this.lblTileIndex.AutoSize = true;
            this.lblTileIndex.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileIndex.Location = new System.Drawing.Point(107, 9);
            this.lblTileIndex.Name = "lblTileIndex";
            this.lblTileIndex.Size = new System.Drawing.Size(55, 13);
            this.lblTileIndex.TabIndex = 16;
            this.lblTileIndex.Text = "Tile Index";
            // 
            // lblNameField
            // 
            this.lblNameField.AutoSize = true;
            this.lblNameField.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameField.Location = new System.Drawing.Point(238, 9);
            this.lblNameField.Name = "lblNameField";
            this.lblNameField.Size = new System.Drawing.Size(64, 13);
            this.lblNameField.TabIndex = 17;
            this.lblNameField.Text = "Name Field";
            // 
            // cboNameField
            // 
            this.cboNameField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNameField.FormattingEnabled = true;
            this.cboNameField.Location = new System.Drawing.Point(241, 25);
            this.cboNameField.Name = "cboNameField";
            this.cboNameField.Size = new System.Drawing.Size(121, 21);
            this.cboNameField.TabIndex = 19;
            // 
            // cboTileIndex
            // 
            this.cboTileIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileIndex.FormattingEnabled = true;
            this.cboTileIndex.Location = new System.Drawing.Point(109, 25);
            this.cboTileIndex.Name = "cboTileIndex";
            this.cboTileIndex.Size = new System.Drawing.Size(121, 21);
            this.cboTileIndex.TabIndex = 18;
            this.cboTileIndex.SelectedIndexChanged += new System.EventHandler(this.cboTileIndex_SelectedIndexChanged);
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrowseDir.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDir.Image")));
            this.btnBrowseDir.Location = new System.Drawing.Point(338, 81);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseDir.TabIndex = 22;
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseLas_Click);
            // 
            // lblFileWorkspace
            // 
            this.lblFileWorkspace.AutoSize = true;
            this.lblFileWorkspace.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileWorkspace.Location = new System.Drawing.Point(105, 56);
            this.lblFileWorkspace.Name = "lblFileWorkspace";
            this.lblFileWorkspace.Size = new System.Drawing.Size(85, 13);
            this.lblFileWorkspace.TabIndex = 21;
            this.lblFileWorkspace.Text = "File Workspace";
            // 
            // txbFileWorkspace
            // 
            this.txbFileWorkspace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFileWorkspace.Location = new System.Drawing.Point(108, 83);
            this.txbFileWorkspace.Name = "txbFileWorkspace";
            this.txbFileWorkspace.ReadOnly = true;
            this.txbFileWorkspace.Size = new System.Drawing.Size(224, 22);
            this.txbFileWorkspace.TabIndex = 20;
            // 
            // lblLine01
            // 
            this.lblLine01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine01.Location = new System.Drawing.Point(10, 112);
            this.lblLine01.Name = "lblLine01";
            this.lblLine01.Size = new System.Drawing.Size(350, 2);
            this.lblLine01.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(10, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(98, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txbCustomExtension
            // 
            this.txbCustomExtension.Location = new System.Drawing.Point(262, 141);
            this.txbCustomExtension.Name = "txbCustomExtension";
            this.txbCustomExtension.Size = new System.Drawing.Size(96, 22);
            this.txbCustomExtension.TabIndex = 26;
            // 
            // lblCusomExtension
            // 
            this.lblCusomExtension.AutoSize = true;
            this.lblCusomExtension.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusomExtension.Location = new System.Drawing.Point(259, 120);
            this.lblCusomExtension.Name = "lblCusomExtension";
            this.lblCusomExtension.Size = new System.Drawing.Size(99, 13);
            this.lblCusomExtension.TabIndex = 27;
            this.lblCusomExtension.Text = "Custom Extension";
            // 
            // FileTileOpener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(370, 174);
            this.ControlBox = false;
            this.Controls.Add(this.lblCusomExtension);
            this.Controls.Add(this.txbCustomExtension);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblLine01);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.lblFileWorkspace);
            this.Controls.Add(this.txbFileWorkspace);
            this.Controls.Add(this.cboNameField);
            this.Controls.Add(this.cboTileIndex);
            this.Controls.Add(this.lblNameField);
            this.Controls.Add(this.lblTileIndex);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnInitialize);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileTileOpener";
            this.ShowInTaskbar = false;
            this.Text = "File Tile Opener";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblTileIndex;
        private System.Windows.Forms.Label lblNameField;
        private System.Windows.Forms.ComboBox cboNameField;
        private System.Windows.Forms.ComboBox cboTileIndex;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.Label lblFileWorkspace;
        private System.Windows.Forms.TextBox txbFileWorkspace;
        private System.Windows.Forms.Label lblLine01;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txbCustomExtension;
        private System.Windows.Forms.Label lblCusomExtension;
    }
}