namespace RS_Tools.Tools.RasterTileLoader
{
    partial class RasterTileLoader_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterTileLoader_Form));
            this.btn_initilaize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cbo_TileIndex = new System.Windows.Forms.ComboBox();
            this.cbo_FieldName = new System.Windows.Forms.ComboBox();
            this.lbl_TileIndex = new System.Windows.Forms.Label();
            this.lbl_TileNameField = new System.Windows.Forms.Label();
            this.lbl_prefix = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_suffix = new System.Windows.Forms.Label();
            this.lbl_extension = new System.Windows.Forms.Label();
            this.cbo_extension = new System.Windows.Forms.ComboBox();
            this.txb_RasterWorkspace = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_RasterWorkspace = new System.Windows.Forms.Label();
            this.lbl_RasterLoadingMethod = new System.Windows.Forms.Label();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.rb_selected = new System.Windows.Forms.RadioButton();
            this.btn_LoadRaster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_initilaize
            // 
            this.btn_initilaize.Location = new System.Drawing.Point(12, 12);
            this.btn_initilaize.Name = "btn_initilaize";
            this.btn_initilaize.Size = new System.Drawing.Size(75, 23);
            this.btn_initilaize.TabIndex = 0;
            this.btn_initilaize.Text = "Initialize";
            this.btn_initilaize.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(248, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // cbo_TileIndex
            // 
            this.cbo_TileIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TileIndex.FormattingEnabled = true;
            this.cbo_TileIndex.Location = new System.Drawing.Point(12, 70);
            this.cbo_TileIndex.Name = "cbo_TileIndex";
            this.cbo_TileIndex.Size = new System.Drawing.Size(152, 21);
            this.cbo_TileIndex.TabIndex = 2;
            // 
            // cbo_FieldName
            // 
            this.cbo_FieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FieldName.FormattingEnabled = true;
            this.cbo_FieldName.Location = new System.Drawing.Point(171, 70);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(117, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 8;
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
            this.cbo_extension.Location = new System.Drawing.Point(223, 118);
            this.cbo_extension.Name = "cbo_extension";
            this.cbo_extension.Size = new System.Drawing.Size(100, 21);
            this.cbo_extension.TabIndex = 12;
            // 
            // txb_RasterWorkspace
            // 
            this.txb_RasterWorkspace.Location = new System.Drawing.Point(12, 171);
            this.txb_RasterWorkspace.Name = "txb_RasterWorkspace";
            this.txb_RasterWorkspace.ReadOnly = true;
            this.txb_RasterWorkspace.Size = new System.Drawing.Size(281, 22);
            this.txb_RasterWorkspace.TabIndex = 13;
            // 
            // btn_browse
            // 
            this.btn_browse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_browse.BackgroundImage")));
            this.btn_browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_browse.Location = new System.Drawing.Point(299, 171);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(24, 24);
            this.btn_browse.TabIndex = 14;
            this.btn_browse.UseVisualStyleBackColor = true;
            // 
            // lbl_RasterWorkspace
            // 
            this.lbl_RasterWorkspace.AutoSize = true;
            this.lbl_RasterWorkspace.Location = new System.Drawing.Point(9, 155);
            this.lbl_RasterWorkspace.Name = "lbl_RasterWorkspace";
            this.lbl_RasterWorkspace.Size = new System.Drawing.Size(99, 13);
            this.lbl_RasterWorkspace.TabIndex = 15;
            this.lbl_RasterWorkspace.Text = "Raster Workspace";
            // 
            // lbl_RasterLoadingMethod
            // 
            this.lbl_RasterLoadingMethod.AutoSize = true;
            this.lbl_RasterLoadingMethod.Location = new System.Drawing.Point(12, 211);
            this.lbl_RasterLoadingMethod.Name = "lbl_RasterLoadingMethod";
            this.lbl_RasterLoadingMethod.Size = new System.Drawing.Size(128, 13);
            this.lbl_RasterLoadingMethod.TabIndex = 16;
            this.lbl_RasterLoadingMethod.Text = "Raster Loading Method";
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
            // 
            // btn_LoadRaster
            // 
            this.btn_LoadRaster.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadRaster.Location = new System.Drawing.Point(223, 236);
            this.btn_LoadRaster.Name = "btn_LoadRaster";
            this.btn_LoadRaster.Size = new System.Drawing.Size(100, 23);
            this.btn_LoadRaster.TabIndex = 19;
            this.btn_LoadRaster.Text = "Load Raster";
            this.btn_LoadRaster.UseVisualStyleBackColor = true;
            // 
            // RasterTileLoader_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 265);
            this.ControlBox = false;
            this.Controls.Add(this.btn_LoadRaster);
            this.Controls.Add(this.rb_selected);
            this.Controls.Add(this.rb_all);
            this.Controls.Add(this.lbl_RasterLoadingMethod);
            this.Controls.Add(this.lbl_RasterWorkspace);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.txb_RasterWorkspace);
            this.Controls.Add(this.cbo_extension);
            this.Controls.Add(this.lbl_extension);
            this.Controls.Add(this.lbl_suffix);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
            this.Name = "RasterTileLoader_Form";
            this.Text = "Raster Tile Loader";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl_suffix;
        private System.Windows.Forms.Label lbl_extension;
        private System.Windows.Forms.ComboBox cbo_extension;
        private System.Windows.Forms.TextBox txb_RasterWorkspace;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lbl_RasterWorkspace;
        private System.Windows.Forms.Label lbl_RasterLoadingMethod;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.RadioButton rb_selected;
        private System.Windows.Forms.Button btn_LoadRaster;
    }
}