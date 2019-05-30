namespace RS_Tools.Tools.FileTileCloner
{
    partial class FileTileCloner_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTileCloner_Form));
            this.btn_CloneFile = new System.Windows.Forms.Button();
            this.rb_selected = new System.Windows.Forms.RadioButton();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.lbl_FileCloningMethod = new System.Windows.Forms.Label();
            this.lbl_SourceWorkspace = new System.Windows.Forms.Label();
            this.btn_browseSrc = new System.Windows.Forms.Button();
            this.txb_FileWorkspaceSrc = new System.Windows.Forms.TextBox();
            this.cbo_extension = new System.Windows.Forms.ComboBox();
            this.lbl_extension = new System.Windows.Forms.Label();
            this.lbl_suffix = new System.Windows.Forms.Label();
            this.txb_Suffix = new System.Windows.Forms.TextBox();
            this.txb_Prefix = new System.Windows.Forms.TextBox();
            this.lbl_prefix = new System.Windows.Forms.Label();
            this.lbl_TileNameField = new System.Windows.Forms.Label();
            this.lbl_TileIndex = new System.Windows.Forms.Label();
            this.cbo_FieldName = new System.Windows.Forms.ComboBox();
            this.cbo_TileIndex = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_initilaize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_browseDst = new System.Windows.Forms.Button();
            this.txb_FileWorkspaceDst = new System.Windows.Forms.TextBox();
            this.btn_CreateBatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CloneFile
            // 
            this.btn_CloneFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloneFile.Location = new System.Drawing.Point(296, 381);
            this.btn_CloneFile.Name = "btn_CloneFile";
            this.btn_CloneFile.Size = new System.Drawing.Size(103, 36);
            this.btn_CloneFile.TabIndex = 38;
            this.btn_CloneFile.Text = "Clone Files";
            this.btn_CloneFile.UseVisualStyleBackColor = true;
            this.btn_CloneFile.Click += new System.EventHandler(this.btn_CloneFile_Click);
            // 
            // rb_selected
            // 
            this.rb_selected.AutoSize = true;
            this.rb_selected.Location = new System.Drawing.Point(62, 370);
            this.rb_selected.Name = "rb_selected";
            this.rb_selected.Size = new System.Drawing.Size(99, 27);
            this.rb_selected.TabIndex = 37;
            this.rb_selected.TabStop = true;
            this.rb_selected.Text = "Selected";
            this.rb_selected.UseVisualStyleBackColor = true;
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(13, 370);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(54, 27);
            this.rb_all.TabIndex = 36;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "All";
            this.rb_all.UseVisualStyleBackColor = true;
            // 
            // lbl_FileCloningMethod
            // 
            this.lbl_FileCloningMethod.AutoSize = true;
            this.lbl_FileCloningMethod.Location = new System.Drawing.Point(9, 354);
            this.lbl_FileCloningMethod.Name = "lbl_FileCloningMethod";
            this.lbl_FileCloningMethod.Size = new System.Drawing.Size(166, 23);
            this.lbl_FileCloningMethod.TabIndex = 35;
            this.lbl_FileCloningMethod.Text = "File Loading Method";
            // 
            // lbl_SourceWorkspace
            // 
            this.lbl_SourceWorkspace.AutoSize = true;
            this.lbl_SourceWorkspace.Location = new System.Drawing.Point(9, 213);
            this.lbl_SourceWorkspace.Name = "lbl_SourceWorkspace";
            this.lbl_SourceWorkspace.Size = new System.Drawing.Size(149, 23);
            this.lbl_SourceWorkspace.TabIndex = 34;
            this.lbl_SourceWorkspace.Text = "Source Workspace";
            // 
            // btn_browseSrc
            // 
            this.btn_browseSrc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_browseSrc.BackgroundImage")));
            this.btn_browseSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_browseSrc.Location = new System.Drawing.Point(365, 242);
            this.btn_browseSrc.Name = "btn_browseSrc";
            this.btn_browseSrc.Size = new System.Drawing.Size(34, 22);
            this.btn_browseSrc.TabIndex = 33;
            this.btn_browseSrc.UseVisualStyleBackColor = true;
            this.btn_browseSrc.Click += new System.EventHandler(this.btn_browseSrc_Click);
            // 
            // txb_FileWorkspaceSrc
            // 
            this.txb_FileWorkspaceSrc.Location = new System.Drawing.Point(9, 244);
            this.txb_FileWorkspaceSrc.Name = "txb_FileWorkspaceSrc";
            this.txb_FileWorkspaceSrc.ReadOnly = true;
            this.txb_FileWorkspaceSrc.Size = new System.Drawing.Size(339, 29);
            this.txb_FileWorkspaceSrc.TabIndex = 32;
            // 
            // cbo_extension
            // 
            this.cbo_extension.FormattingEnabled = true;
            this.cbo_extension.Location = new System.Drawing.Point(273, 179);
            this.cbo_extension.Name = "cbo_extension";
            this.cbo_extension.Size = new System.Drawing.Size(126, 31);
            this.cbo_extension.TabIndex = 31;
            // 
            // lbl_extension
            // 
            this.lbl_extension.AutoSize = true;
            this.lbl_extension.Location = new System.Drawing.Point(269, 152);
            this.lbl_extension.Name = "lbl_extension";
            this.lbl_extension.Size = new System.Drawing.Size(83, 23);
            this.lbl_extension.TabIndex = 30;
            this.lbl_extension.Text = "Extension";
            // 
            // lbl_suffix
            // 
            this.lbl_suffix.AutoSize = true;
            this.lbl_suffix.Location = new System.Drawing.Point(129, 152);
            this.lbl_suffix.Name = "lbl_suffix";
            this.lbl_suffix.Size = new System.Drawing.Size(51, 23);
            this.lbl_suffix.TabIndex = 29;
            this.lbl_suffix.Text = "Suffix";
            // 
            // txb_Suffix
            // 
            this.txb_Suffix.Location = new System.Drawing.Point(133, 178);
            this.txb_Suffix.Name = "txb_Suffix";
            this.txb_Suffix.Size = new System.Drawing.Size(134, 29);
            this.txb_Suffix.TabIndex = 28;
            // 
            // txb_Prefix
            // 
            this.txb_Prefix.Location = new System.Drawing.Point(9, 178);
            this.txb_Prefix.Name = "txb_Prefix";
            this.txb_Prefix.Size = new System.Drawing.Size(118, 29);
            this.txb_Prefix.TabIndex = 27;
            // 
            // lbl_prefix
            // 
            this.lbl_prefix.AutoSize = true;
            this.lbl_prefix.Location = new System.Drawing.Point(8, 152);
            this.lbl_prefix.Name = "lbl_prefix";
            this.lbl_prefix.Size = new System.Drawing.Size(52, 23);
            this.lbl_prefix.TabIndex = 26;
            this.lbl_prefix.Text = "Prefix";
            // 
            // lbl_TileNameField
            // 
            this.lbl_TileNameField.AutoSize = true;
            this.lbl_TileNameField.Location = new System.Drawing.Point(206, 77);
            this.lbl_TileNameField.Name = "lbl_TileNameField";
            this.lbl_TileNameField.Size = new System.Drawing.Size(127, 23);
            this.lbl_TileNameField.TabIndex = 25;
            this.lbl_TileNameField.Text = "Tile Name Field";
            // 
            // lbl_TileIndex
            // 
            this.lbl_TileIndex.AutoSize = true;
            this.lbl_TileIndex.Location = new System.Drawing.Point(8, 77);
            this.lbl_TileIndex.Name = "lbl_TileIndex";
            this.lbl_TileIndex.Size = new System.Drawing.Size(83, 23);
            this.lbl_TileIndex.TabIndex = 24;
            this.lbl_TileIndex.Text = "Tile Index";
            // 
            // cbo_FieldName
            // 
            this.cbo_FieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FieldName.FormattingEnabled = true;
            this.cbo_FieldName.Location = new System.Drawing.Point(209, 106);
            this.cbo_FieldName.Name = "cbo_FieldName";
            this.cbo_FieldName.Size = new System.Drawing.Size(190, 31);
            this.cbo_FieldName.TabIndex = 23;
            // 
            // cbo_TileIndex
            // 
            this.cbo_TileIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TileIndex.FormattingEnabled = true;
            this.cbo_TileIndex.Location = new System.Drawing.Point(9, 106);
            this.cbo_TileIndex.Name = "cbo_TileIndex";
            this.cbo_TileIndex.Size = new System.Drawing.Size(193, 31);
            this.cbo_TileIndex.TabIndex = 22;
            this.cbo_TileIndex.SelectedIndexChanged += new System.EventHandler(this.cbo_TileIndex_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(319, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(80, 35);
            this.btn_close.TabIndex = 21;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_initilaize
            // 
            this.btn_initilaize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_initilaize.Location = new System.Drawing.Point(12, 12);
            this.btn_initilaize.Name = "btn_initilaize";
            this.btn_initilaize.Size = new System.Drawing.Size(106, 35);
            this.btn_initilaize.TabIndex = 20;
            this.btn_initilaize.Text = "Initialize";
            this.btn_initilaize.UseVisualStyleBackColor = true;
            this.btn_initilaize.Click += new System.EventHandler(this.btn_initilaize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "Destination Workspace";
            // 
            // btn_browseDst
            // 
            this.btn_browseDst.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_browseDst.BackgroundImage")));
            this.btn_browseDst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_browseDst.Location = new System.Drawing.Point(365, 308);
            this.btn_browseDst.Name = "btn_browseDst";
            this.btn_browseDst.Size = new System.Drawing.Size(34, 22);
            this.btn_browseDst.TabIndex = 40;
            this.btn_browseDst.UseVisualStyleBackColor = true;
            this.btn_browseDst.Click += new System.EventHandler(this.btn_browseDst_Click);
            // 
            // txb_FileWorkspaceDst
            // 
            this.txb_FileWorkspaceDst.Location = new System.Drawing.Point(11, 308);
            this.txb_FileWorkspaceDst.Name = "txb_FileWorkspaceDst";
            this.txb_FileWorkspaceDst.ReadOnly = true;
            this.txb_FileWorkspaceDst.Size = new System.Drawing.Size(339, 29);
            this.txb_FileWorkspaceDst.TabIndex = 39;
            // 
            // btn_CreateBatch
            // 
            this.btn_CreateBatch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateBatch.Location = new System.Drawing.Point(179, 380);
            this.btn_CreateBatch.Name = "btn_CreateBatch";
            this.btn_CreateBatch.Size = new System.Drawing.Size(110, 37);
            this.btn_CreateBatch.TabIndex = 42;
            this.btn_CreateBatch.Text = "Create Batch";
            this.btn_CreateBatch.UseVisualStyleBackColor = true;
            this.btn_CreateBatch.Click += new System.EventHandler(this.btn_CreateBatch_Click);
            // 
            // FileTileCloner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(411, 429);
            this.ControlBox = false;
            this.Controls.Add(this.btn_CreateBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_browseDst);
            this.Controls.Add(this.txb_FileWorkspaceDst);
            this.Controls.Add(this.btn_CloneFile);
            this.Controls.Add(this.rb_selected);
            this.Controls.Add(this.rb_all);
            this.Controls.Add(this.lbl_FileCloningMethod);
            this.Controls.Add(this.lbl_SourceWorkspace);
            this.Controls.Add(this.btn_browseSrc);
            this.Controls.Add(this.txb_FileWorkspaceSrc);
            this.Controls.Add(this.cbo_extension);
            this.Controls.Add(this.lbl_extension);
            this.Controls.Add(this.lbl_suffix);
            this.Controls.Add(this.txb_Suffix);
            this.Controls.Add(this.txb_Prefix);
            this.Controls.Add(this.lbl_prefix);
            this.Controls.Add(this.lbl_TileNameField);
            this.Controls.Add(this.lbl_TileIndex);
            this.Controls.Add(this.cbo_FieldName);
            this.Controls.Add(this.cbo_TileIndex);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_initilaize);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileTileCloner_Form";
            this.Text = "File Tile Cloner";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CloneFile;
        private System.Windows.Forms.RadioButton rb_selected;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.Label lbl_FileCloningMethod;
        private System.Windows.Forms.Label lbl_SourceWorkspace;
        private System.Windows.Forms.Button btn_browseSrc;
        private System.Windows.Forms.TextBox txb_FileWorkspaceSrc;
        private System.Windows.Forms.ComboBox cbo_extension;
        private System.Windows.Forms.Label lbl_extension;
        private System.Windows.Forms.Label lbl_suffix;
        private System.Windows.Forms.TextBox txb_Suffix;
        private System.Windows.Forms.TextBox txb_Prefix;
        private System.Windows.Forms.Label lbl_prefix;
        private System.Windows.Forms.Label lbl_TileNameField;
        private System.Windows.Forms.Label lbl_TileIndex;
        private System.Windows.Forms.ComboBox cbo_FieldName;
        private System.Windows.Forms.ComboBox cbo_TileIndex;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_initilaize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_browseDst;
        private System.Windows.Forms.TextBox txb_FileWorkspaceDst;
        private System.Windows.Forms.Button btn_CreateBatch;
    }
}