﻿namespace RS_Tools.Tools.FileTileCloner
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
            this.btn_browse = new System.Windows.Forms.Button();
            this.txb_FileWorkspace = new System.Windows.Forms.TextBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_CloneFile
            // 
            this.btn_CloneFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloneFile.Location = new System.Drawing.Point(220, 299);
            this.btn_CloneFile.Name = "btn_CloneFile";
            this.btn_CloneFile.Size = new System.Drawing.Size(100, 23);
            this.btn_CloneFile.TabIndex = 38;
            this.btn_CloneFile.Text = "Clone Files";
            this.btn_CloneFile.UseVisualStyleBackColor = true;
            // 
            // rb_selected
            // 
            this.rb_selected.AutoSize = true;
            this.rb_selected.Location = new System.Drawing.Point(53, 299);
            this.rb_selected.Name = "rb_selected";
            this.rb_selected.Size = new System.Drawing.Size(67, 17);
            this.rb_selected.TabIndex = 37;
            this.rb_selected.TabStop = true;
            this.rb_selected.Text = "Selected";
            this.rb_selected.UseVisualStyleBackColor = true;
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(9, 299);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(36, 17);
            this.rb_all.TabIndex = 36;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "All";
            this.rb_all.UseVisualStyleBackColor = true;
            // 
            // lbl_FileCloningMethod
            // 
            this.lbl_FileCloningMethod.AutoSize = true;
            this.lbl_FileCloningMethod.Location = new System.Drawing.Point(9, 274);
            this.lbl_FileCloningMethod.Name = "lbl_FileCloningMethod";
            this.lbl_FileCloningMethod.Size = new System.Drawing.Size(103, 13);
            this.lbl_FileCloningMethod.TabIndex = 35;
            this.lbl_FileCloningMethod.Text = "File Loading Method";
            // 
            // lbl_SourceWorkspace
            // 
            this.lbl_SourceWorkspace.AutoSize = true;
            this.lbl_SourceWorkspace.Location = new System.Drawing.Point(9, 155);
            this.lbl_SourceWorkspace.Name = "lbl_SourceWorkspace";
            this.lbl_SourceWorkspace.Size = new System.Drawing.Size(99, 13);
            this.lbl_SourceWorkspace.TabIndex = 34;
            this.lbl_SourceWorkspace.Text = "Source Workspace";
            // 
            // btn_browse
            // 
            this.btn_browse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_browse.BackgroundImage")));
            this.btn_browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_browse.Location = new System.Drawing.Point(299, 176);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(24, 24);
            this.btn_browse.TabIndex = 33;
            this.btn_browse.UseVisualStyleBackColor = true;
            // 
            // txb_FileWorkspace
            // 
            this.txb_FileWorkspace.Location = new System.Drawing.Point(12, 176);
            this.txb_FileWorkspace.Name = "txb_FileWorkspace";
            this.txb_FileWorkspace.ReadOnly = true;
            this.txb_FileWorkspace.Size = new System.Drawing.Size(281, 20);
            this.txb_FileWorkspace.TabIndex = 32;
            // 
            // cbo_extension
            // 
            this.cbo_extension.FormattingEnabled = true;
            this.cbo_extension.Location = new System.Drawing.Point(223, 123);
            this.cbo_extension.Name = "cbo_extension";
            this.cbo_extension.Size = new System.Drawing.Size(100, 21);
            this.cbo_extension.TabIndex = 31;
            // 
            // lbl_extension
            // 
            this.lbl_extension.AutoSize = true;
            this.lbl_extension.Location = new System.Drawing.Point(220, 101);
            this.lbl_extension.Name = "lbl_extension";
            this.lbl_extension.Size = new System.Drawing.Size(53, 13);
            this.lbl_extension.TabIndex = 30;
            this.lbl_extension.Text = "Extension";
            // 
            // lbl_suffix
            // 
            this.lbl_suffix.AutoSize = true;
            this.lbl_suffix.Location = new System.Drawing.Point(114, 101);
            this.lbl_suffix.Name = "lbl_suffix";
            this.lbl_suffix.Size = new System.Drawing.Size(33, 13);
            this.lbl_suffix.TabIndex = 29;
            this.lbl_suffix.Text = "Suffix";
            // 
            // txb_Suffix
            // 
            this.txb_Suffix.Location = new System.Drawing.Point(117, 123);
            this.txb_Suffix.Name = "txb_Suffix";
            this.txb_Suffix.Size = new System.Drawing.Size(100, 20);
            this.txb_Suffix.TabIndex = 28;
            // 
            // txb_Prefix
            // 
            this.txb_Prefix.Location = new System.Drawing.Point(12, 123);
            this.txb_Prefix.Name = "txb_Prefix";
            this.txb_Prefix.Size = new System.Drawing.Size(100, 20);
            this.txb_Prefix.TabIndex = 27;
            // 
            // lbl_prefix
            // 
            this.lbl_prefix.AutoSize = true;
            this.lbl_prefix.Location = new System.Drawing.Point(12, 101);
            this.lbl_prefix.Name = "lbl_prefix";
            this.lbl_prefix.Size = new System.Drawing.Size(33, 13);
            this.lbl_prefix.TabIndex = 26;
            this.lbl_prefix.Text = "Prefix";
            // 
            // lbl_TileNameField
            // 
            this.lbl_TileNameField.AutoSize = true;
            this.lbl_TileNameField.Location = new System.Drawing.Point(168, 51);
            this.lbl_TileNameField.Name = "lbl_TileNameField";
            this.lbl_TileNameField.Size = new System.Drawing.Size(80, 13);
            this.lbl_TileNameField.TabIndex = 25;
            this.lbl_TileNameField.Text = "Tile Name Field";
            // 
            // lbl_TileIndex
            // 
            this.lbl_TileIndex.AutoSize = true;
            this.lbl_TileIndex.Location = new System.Drawing.Point(13, 51);
            this.lbl_TileIndex.Name = "lbl_TileIndex";
            this.lbl_TileIndex.Size = new System.Drawing.Size(53, 13);
            this.lbl_TileIndex.TabIndex = 24;
            this.lbl_TileIndex.Text = "Tile Index";
            // 
            // cbo_FieldName
            // 
            this.cbo_FieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FieldName.FormattingEnabled = true;
            this.cbo_FieldName.Location = new System.Drawing.Point(171, 75);
            this.cbo_FieldName.Name = "cbo_FieldName";
            this.cbo_FieldName.Size = new System.Drawing.Size(152, 21);
            this.cbo_FieldName.TabIndex = 23;
            // 
            // cbo_TileIndex
            // 
            this.cbo_TileIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TileIndex.FormattingEnabled = true;
            this.cbo_TileIndex.Location = new System.Drawing.Point(12, 75);
            this.cbo_TileIndex.Name = "cbo_TileIndex";
            this.cbo_TileIndex.Size = new System.Drawing.Size(152, 21);
            this.cbo_TileIndex.TabIndex = 22;
            this.cbo_TileIndex.SelectedIndexChanged += new System.EventHandler(this.cbo_TileIndex_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(248, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 21;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_initilaize
            // 
            this.btn_initilaize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_initilaize.Location = new System.Drawing.Point(12, 12);
            this.btn_initilaize.Name = "btn_initilaize";
            this.btn_initilaize.Size = new System.Drawing.Size(75, 23);
            this.btn_initilaize.TabIndex = 20;
            this.btn_initilaize.Text = "Initialize";
            this.btn_initilaize.UseVisualStyleBackColor = true;
            this.btn_initilaize.Click += new System.EventHandler(this.btn_initilaize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Destination Workspace";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(299, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 40;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 39;
            // 
            // FileTileCloner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_CloneFile);
            this.Controls.Add(this.rb_selected);
            this.Controls.Add(this.rb_all);
            this.Controls.Add(this.lbl_FileCloningMethod);
            this.Controls.Add(this.lbl_SourceWorkspace);
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
            this.Name = "FileTileCloner_Form";
            this.Text = "FileTileCloner_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CloneFile;
        private System.Windows.Forms.RadioButton rb_selected;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.Label lbl_FileCloningMethod;
        private System.Windows.Forms.Label lbl_SourceWorkspace;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txb_FileWorkspace;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}