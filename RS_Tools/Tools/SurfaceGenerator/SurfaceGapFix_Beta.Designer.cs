namespace RS_Tools.Tools.SurfaceGenerator
{
    partial class SurfaceGapFix_Beta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurfaceGapFix_Beta));
            this.btnRunScripts = new System.Windows.Forms.Button();
            this.btnOpenLASTools = new System.Windows.Forms.Button();
            this.tbxLASToolsFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numProcesses = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLASFolder = new System.Windows.Forms.Button();
            this.tbxLASFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboTileNameField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTileLayoutLayer = new System.Windows.Forms.ComboBox();
            this.chkUseSelected = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateOverlapMap = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunScripts
            // 
            this.btnRunScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunScripts.Location = new System.Drawing.Point(373, 252);
            this.btnRunScripts.Name = "btnRunScripts";
            this.btnRunScripts.Size = new System.Drawing.Size(150, 33);
            this.btnRunScripts.TabIndex = 101;
            this.btnRunScripts.Text = "Run Scripts";
            this.btnRunScripts.UseVisualStyleBackColor = true;
            this.btnRunScripts.Click += new System.EventHandler(this.btnRunScripts_Click);
            // 
            // btnOpenLASTools
            // 
            this.btnOpenLASTools.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLASTools.Image")));
            this.btnOpenLASTools.Location = new System.Drawing.Point(498, 165);
            this.btnOpenLASTools.Name = "btnOpenLASTools";
            this.btnOpenLASTools.Size = new System.Drawing.Size(25, 23);
            this.btnOpenLASTools.TabIndex = 100;
            this.btnOpenLASTools.UseVisualStyleBackColor = true;
            this.btnOpenLASTools.Click += new System.EventHandler(this.btnOpenLASTools_Click);
            // 
            // tbxLASToolsFolder
            // 
            this.tbxLASToolsFolder.Location = new System.Drawing.Point(121, 166);
            this.tbxLASToolsFolder.Name = "tbxLASToolsFolder";
            this.tbxLASToolsFolder.Size = new System.Drawing.Size(374, 20);
            this.tbxLASToolsFolder.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "LAS Tools Folder";
            // 
            // numProcesses
            // 
            this.numProcesses.Location = new System.Drawing.Point(121, 139);
            this.numProcesses.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numProcesses.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numProcesses.Name = "numProcesses";
            this.numProcesses.Size = new System.Drawing.Size(76, 20);
            this.numProcesses.TabIndex = 97;
            this.numProcesses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Processes";
            // 
            // btnLASFolder
            // 
            this.btnLASFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnLASFolder.Image")));
            this.btnLASFolder.Location = new System.Drawing.Point(498, 102);
            this.btnLASFolder.Name = "btnLASFolder";
            this.btnLASFolder.Size = new System.Drawing.Size(25, 23);
            this.btnLASFolder.TabIndex = 95;
            this.btnLASFolder.UseVisualStyleBackColor = true;
            this.btnLASFolder.Click += new System.EventHandler(this.btnLASFolder_Click);
            // 
            // tbxLASFolder
            // 
            this.tbxLASFolder.Location = new System.Drawing.Point(121, 102);
            this.tbxLASFolder.Name = "tbxLASFolder";
            this.tbxLASFolder.Size = new System.Drawing.Size(374, 20);
            this.tbxLASFolder.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "LAS Folder";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(196, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 22);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboTileNameField
            // 
            this.cboTileNameField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileNameField.FormattingEnabled = true;
            this.cboTileNameField.Location = new System.Drawing.Point(121, 74);
            this.cboTileNameField.Name = "cboTileNameField";
            this.cboTileNameField.Size = new System.Drawing.Size(208, 21);
            this.cboTileNameField.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Tile Layout";
            // 
            // cboTileLayoutLayer
            // 
            this.cboTileLayoutLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileLayoutLayer.FormattingEnabled = true;
            this.cboTileLayoutLayer.Location = new System.Drawing.Point(121, 17);
            this.cboTileLayoutLayer.Name = "cboTileLayoutLayer";
            this.cboTileLayoutLayer.Size = new System.Drawing.Size(374, 21);
            this.cboTileLayoutLayer.TabIndex = 88;
            this.cboTileLayoutLayer.SelectedIndexChanged += new System.EventHandler(this.cboTileLayoutLayer_SelectedIndexChanged);
            // 
            // chkUseSelected
            // 
            this.chkUseSelected.AutoSize = true;
            this.chkUseSelected.Location = new System.Drawing.Point(121, 46);
            this.chkUseSelected.Name = "chkUseSelected";
            this.chkUseSelected.Size = new System.Drawing.Size(90, 17);
            this.chkUseSelected.TabIndex = 89;
            this.chkUseSelected.Text = "Use Selected";
            this.chkUseSelected.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Tile Name Field";
            // 
            // btnCreateOverlapMap
            // 
            this.btnCreateOverlapMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOverlapMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOverlapMap.Location = new System.Drawing.Point(373, 209);
            this.btnCreateOverlapMap.Name = "btnCreateOverlapMap";
            this.btnCreateOverlapMap.Size = new System.Drawing.Size(150, 37);
            this.btnCreateOverlapMap.TabIndex = 86;
            this.btnCreateOverlapMap.Text = "Create Overlap Map";
            this.btnCreateOverlapMap.UseVisualStyleBackColor = true;
            this.btnCreateOverlapMap.Click += new System.EventHandler(this.btnCreateOverlapMap_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 280);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 102;
            // 
            // SurfaceGapFix_Beta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 302);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnRunScripts);
            this.Controls.Add(this.btnOpenLASTools);
            this.Controls.Add(this.tbxLASToolsFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numProcesses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLASFolder);
            this.Controls.Add(this.tbxLASFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboTileNameField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTileLayoutLayer);
            this.Controls.Add(this.chkUseSelected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreateOverlapMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SurfaceGapFix_Beta";
            this.Text = "Surface Gap Fix (Beta)";
            this.Load += new System.EventHandler(this.TileOrganizer_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunScripts;
        private System.Windows.Forms.Button btnOpenLASTools;
        private System.Windows.Forms.TextBox tbxLASToolsFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLASFolder;
        private System.Windows.Forms.TextBox tbxLASFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboTileNameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTileLayoutLayer;
        private System.Windows.Forms.CheckBox chkUseSelected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateOverlapMap;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblVersion;
    }
}