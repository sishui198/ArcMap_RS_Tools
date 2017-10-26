namespace RS_Tools.Tools.FileTileLoader
{
    partial class FileTileLoader_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTileLoader_Form));
            this.btn_initilaize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cbo_TileIndex = new System.Windows.Forms.ComboBox();
            this.cbo_FieldName = new System.Windows.Forms.ComboBox();
            this.lbl_TileIndex = new System.Windows.Forms.Label();
            this.lbl_TileNameField = new System.Windows.Forms.Label();
            this.lbl_prefix = new System.Windows.Forms.Label();
            this.txb_Prefix = new System.Windows.Forms.TextBox();
            this.txb_Suffix = new System.Windows.Forms.TextBox();
            this.lbl_suffix = new System.Windows.Forms.Label();
            this.lbl_extension = new System.Windows.Forms.Label();
            this.cbo_extension = new System.Windows.Forms.ComboBox();
            this.txb_FileWorkspace = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_FileWorkspace = new System.Windows.Forms.Label();
            this.lbl_FileLoadingMethod = new System.Windows.Forms.Label();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.rb_selected = new System.Windows.Forms.RadioButton();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_initilaize
            // 
            this.btn_initilaize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_initilaize.Location = new System.Drawing.Point(12, 12);
            this.btn_initilaize.Name = "btn_initilaize";
            this.btn_initilaize.Size = new System.Drawing.Size(75, 23);
            this.btn_initilaize.TabIndex = 0;
            this.btn_initilaize.Text = "Initialize";
            this.btn_initilaize.UseVisualStyleBackColor = true;
            this.btn_initilaize.Click += new System.EventHandler(this.btn_initilaize_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(248, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // cbo_TileIndex
            // 
            this.cbo_TileIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TileIndex.FormattingEnabled = true;
            this.cbo_TileIndex.Location = new System.Drawing.Point(12, 75);
            this.cbo_TileIndex.Name = "cbo_TileIndex";
            this.cbo_TileIndex.Size = new System.Drawing.Size(152, 21);
            this.cbo_TileIndex.TabIndex = 2;
            this.cbo_TileIndex.SelectedIndexChanged += new System.EventHandler(this.cbo_TileIndex_SelectedIndexChanged);
            // 
            // cbo_FieldName
            // 
            this.cbo_FieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FieldName.FormattingEnabled = true;
            this.cbo_FieldName.Location = new System.Drawing.Point(171, 75);
            this.cbo_FieldName.Name = "cbo_FieldName";
            this.cbo_FieldName.Size = new System.Drawing.Size(152, 21);
            this.cbo_FieldName.TabIndex = 3;
            // 
            // lbl_TileIndex
            // 
            this.lbl_TileIndex.AutoSize = true;
            this.lbl_TileIndex.Location = new System.Drawing.Point(13, 51);
            this.lbl_TileIndex.Name = "lbl_TileIndex";
            this.lbl_TileIndex.Size = new System.Drawing.Size(55, 13);
            this.lbl_TileIndex.TabIndex = 4;
            this.lbl_TileIndex.Text = "Tile Index";
            // 
            // lbl_TileNameField
            // 
            this.lbl_TileNameField.AutoSize = true;
            this.lbl_TileNameField.Location = new System.Drawing.Point(168, 51);
            this.lbl_TileNameField.Name = "lbl_TileNameField";
            this.lbl_TileNameField.Size = new System.Drawing.Size(84, 13);
            this.lbl_TileNameField.TabIndex = 5;
            this.lbl_TileNameField.Text = "Tile Name Field";
            // 
            // lbl_prefix
            // 
            this.lbl_prefix.AutoSize = true;
            this.lbl_prefix.Location = new System.Drawing.Point(12, 101);
            this.lbl_prefix.Name = "lbl_prefix";
            this.lbl_prefix.Size = new System.Drawing.Size(35, 13);
            this.lbl_prefix.TabIndex = 6;
            this.lbl_prefix.Text = "Prefix";
            // 
            // txb_Prefix
            // 
            this.txb_Prefix.Location = new System.Drawing.Point(12, 123);
            this.txb_Prefix.Name = "txb_Prefix";
            this.txb_Prefix.Size = new System.Drawing.Size(100, 22);
            this.txb_Prefix.TabIndex = 7;
            // 
            // txb_Suffix
            // 
            this.txb_Suffix.Location = new System.Drawing.Point(117, 123);
            this.txb_Suffix.Name = "txb_Suffix";
            this.txb_Suffix.Size = new System.Drawing.Size(100, 22);
            this.txb_Suffix.TabIndex = 8;
            // 
            // lbl_suffix
            // 
            this.lbl_suffix.AutoSize = true;
            this.lbl_suffix.Location = new System.Drawing.Point(114, 101);
            this.lbl_suffix.Name = "lbl_suffix";
            this.lbl_suffix.Size = new System.Drawing.Size(36, 13);
            this.lbl_suffix.TabIndex = 10;
            this.lbl_suffix.Text = "Suffix";
            // 
            // lbl_extension
            // 
            this.lbl_extension.AutoSize = true;
            this.lbl_extension.Location = new System.Drawing.Point(220, 101);
            this.lbl_extension.Name = "lbl_extension";
            this.lbl_extension.Size = new System.Drawing.Size(57, 13);
            this.lbl_extension.TabIndex = 11;
            this.lbl_extension.Text = "Extension";
            // 
            // cbo_extension
            // 
            this.cbo_extension.FormattingEnabled = true;
            this.cbo_extension.Location = new System.Drawing.Point(223, 123);
            this.cbo_extension.Name = "cbo_extension";
            this.cbo_extension.Size = new System.Drawing.Size(100, 21);
            this.cbo_extension.TabIndex = 12;
            this.cbo_extension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_extension_KeyPress);
            // 
            // txb_FileWorkspace
            // 
            this.txb_FileWorkspace.Location = new System.Drawing.Point(12, 176);
            this.txb_FileWorkspace.Name = "txb_FileWorkspace";
            this.txb_FileWorkspace.ReadOnly = true;
            this.txb_FileWorkspace.Size = new System.Drawing.Size(281, 22);
            this.txb_FileWorkspace.TabIndex = 13;
            // 
            // btn_browse
            // 
            this.btn_browse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_browse.BackgroundImage")));
            this.btn_browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_browse.Location = new System.Drawing.Point(299, 176);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(24, 24);
            this.btn_browse.TabIndex = 14;
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lbl_FileWorkspace
            // 
            this.lbl_FileWorkspace.AutoSize = true;
            this.lbl_FileWorkspace.Location = new System.Drawing.Point(9, 155);
            this.lbl_FileWorkspace.Name = "lbl_FileWorkspace";
            this.lbl_FileWorkspace.Size = new System.Drawing.Size(85, 13);
            this.lbl_FileWorkspace.TabIndex = 15;
            this.lbl_FileWorkspace.Text = "File Workspace";
            // 
            // lbl_FileLoadingMethod
            // 
            this.lbl_FileLoadingMethod.AutoSize = true;
            this.lbl_FileLoadingMethod.Location = new System.Drawing.Point(12, 211);
            this.lbl_FileLoadingMethod.Name = "lbl_FileLoadingMethod";
            this.lbl_FileLoadingMethod.Size = new System.Drawing.Size(114, 13);
            this.lbl_FileLoadingMethod.TabIndex = 16;
            this.lbl_FileLoadingMethod.Text = "File Loading Method";
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(12, 236);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(38, 17);
            this.rb_all.TabIndex = 17;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "All";
            this.rb_all.UseVisualStyleBackColor = true;
            this.rb_all.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_selected
            // 
            this.rb_selected.AutoSize = true;
            this.rb_selected.Location = new System.Drawing.Point(56, 236);
            this.rb_selected.Name = "rb_selected";
            this.rb_selected.Size = new System.Drawing.Size(68, 17);
            this.rb_selected.TabIndex = 18;
            this.rb_selected.TabStop = true;
            this.rb_selected.Text = "Selected";
            this.rb_selected.UseVisualStyleBackColor = true;
            this.rb_selected.CheckedChanged += new System.EventHandler(this.rb_selected_CheckedChanged);
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadFile.Location = new System.Drawing.Point(223, 236);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(100, 23);
            this.btn_LoadFile.TabIndex = 19;
            this.btn_LoadFile.Text = "Load File";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // FileTileLoader_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(335, 265);
            this.ControlBox = false;
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.rb_selected);
            this.Controls.Add(this.rb_all);
            this.Controls.Add(this.lbl_FileLoadingMethod);
            this.Controls.Add(this.lbl_FileWorkspace);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.txb_FileWorkspace);
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
            this.Name = "FileTileLoader_Form";
            this.Text = "File Tile Loader";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_initilaize;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox cbo_TileIndex;
        private System.Windows.Forms.ComboBox cbo_FieldName;
        private System.Windows.Forms.Label lbl_TileIndex;
        private System.Windows.Forms.Label lbl_TileNameField;
        private System.Windows.Forms.Label lbl_prefix;
        private System.Windows.Forms.TextBox txb_Prefix;
        private System.Windows.Forms.TextBox txb_Suffix;
        private System.Windows.Forms.Label lbl_suffix;
        private System.Windows.Forms.Label lbl_extension;
        private System.Windows.Forms.ComboBox cbo_extension;
        private System.Windows.Forms.TextBox txb_FileWorkspace;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lbl_FileWorkspace;
        private System.Windows.Forms.Label lbl_FileLoadingMethod;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.RadioButton rb_selected;
        private System.Windows.Forms.Button btn_LoadFile;
    }
}