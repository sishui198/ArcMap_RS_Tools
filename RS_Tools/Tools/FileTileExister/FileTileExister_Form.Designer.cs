namespace RS_Tools.Tools.FileTileExister
{
    partial class FileTileExister_Form
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
            this.btn_initialize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cbo_layers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_fieldname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_prefix = new System.Windows.Forms.TextBox();
            this.txb_suffix = new System.Windows.Forms.TextBox();
            this.cbo_extension = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_folderpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.rb_selected = new System.Windows.Forms.RadioButton();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_createfield = new System.Windows.Forms.Button();
            this.cb_subfolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_initialize
            // 
            this.btn_initialize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_initialize.Location = new System.Drawing.Point(13, 13);
            this.btn_initialize.Margin = new System.Windows.Forms.Padding(4);
            this.btn_initialize.Name = "btn_initialize";
            this.btn_initialize.Size = new System.Drawing.Size(126, 56);
            this.btn_initialize.TabIndex = 0;
            this.btn_initialize.Text = "Initialize";
            this.btn_initialize.UseVisualStyleBackColor = true;
            this.btn_initialize.Click += new System.EventHandler(this.btn_initialize_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(474, 13);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(126, 56);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // cbo_layers
            // 
            this.cbo_layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_layers.FormattingEnabled = true;
            this.cbo_layers.Location = new System.Drawing.Point(12, 153);
            this.cbo_layers.Name = "cbo_layers";
            this.cbo_layers.Size = new System.Drawing.Size(294, 36);
            this.cbo_layers.TabIndex = 2;
            this.cbo_layers.SelectedIndexChanged += new System.EventHandler(this.cbo_layers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tile Index";
            // 
            // cbo_fieldname
            // 
            this.cbo_fieldname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_fieldname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_fieldname.FormattingEnabled = true;
            this.cbo_fieldname.Location = new System.Drawing.Point(312, 153);
            this.cbo_fieldname.Name = "cbo_fieldname";
            this.cbo_fieldname.Size = new System.Drawing.Size(288, 36);
            this.cbo_fieldname.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tile Name Field";
            // 
            // txb_prefix
            // 
            this.txb_prefix.Location = new System.Drawing.Point(12, 273);
            this.txb_prefix.Name = "txb_prefix";
            this.txb_prefix.Size = new System.Drawing.Size(214, 34);
            this.txb_prefix.TabIndex = 6;
            // 
            // txb_suffix
            // 
            this.txb_suffix.Location = new System.Drawing.Point(232, 273);
            this.txb_suffix.Name = "txb_suffix";
            this.txb_suffix.Size = new System.Drawing.Size(208, 34);
            this.txb_suffix.TabIndex = 7;
            // 
            // cbo_extension
            // 
            this.cbo_extension.FormattingEnabled = true;
            this.cbo_extension.Location = new System.Drawing.Point(446, 271);
            this.cbo_extension.Name = "cbo_extension";
            this.cbo_extension.Size = new System.Drawing.Size(154, 36);
            this.cbo_extension.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Prefix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Suffix";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Extension";
            // 
            // txb_folderpath
            // 
            this.txb_folderpath.Location = new System.Drawing.Point(12, 386);
            this.txb_folderpath.Name = "txb_folderpath";
            this.txb_folderpath.Size = new System.Drawing.Size(459, 34);
            this.txb_folderpath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 28);
            this.label6.TabIndex = 13;
            this.label6.Text = "Folder Path To Data";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(477, 382);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(123, 43);
            this.btn_browse.TabIndex = 14;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Method";
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(12, 557);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(60, 32);
            this.rb_all.TabIndex = 16;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "All";
            this.rb_all.UseVisualStyleBackColor = true;
            // 
            // rb_selected
            // 
            this.rb_selected.AutoSize = true;
            this.rb_selected.Location = new System.Drawing.Point(83, 557);
            this.rb_selected.Name = "rb_selected";
            this.rb_selected.Size = new System.Drawing.Size(111, 32);
            this.rb_selected.TabIndex = 17;
            this.rb_selected.TabStop = true;
            this.rb_selected.Text = "Selected";
            this.rb_selected.UseVisualStyleBackColor = true;
            // 
            // btn_run
            // 
            this.btn_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_run.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(474, 545);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(126, 56);
            this.btn_run.TabIndex = 18;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_createfield
            // 
            this.btn_createfield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createfield.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createfield.Location = new System.Drawing.Point(312, 545);
            this.btn_createfield.Margin = new System.Windows.Forms.Padding(4);
            this.btn_createfield.Name = "btn_createfield";
            this.btn_createfield.Size = new System.Drawing.Size(154, 56);
            this.btn_createfield.TabIndex = 19;
            this.btn_createfield.Text = "Create Field";
            this.btn_createfield.UseVisualStyleBackColor = true;
            this.btn_createfield.Click += new System.EventHandler(this.btn_createfield_Click);
            // 
            // cb_subfolder
            // 
            this.cb_subfolder.AutoSize = true;
            this.cb_subfolder.Location = new System.Drawing.Point(13, 436);
            this.cb_subfolder.Name = "cb_subfolder";
            this.cb_subfolder.Size = new System.Drawing.Size(187, 32);
            this.cb_subfolder.TabIndex = 20;
            this.cb_subfolder.Text = "Search Subfolder";
            this.cb_subfolder.UseVisualStyleBackColor = true;
            // 
            // FileTileExister_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(613, 614);
            this.ControlBox = false;
            this.Controls.Add(this.cb_subfolder);
            this.Controls.Add(this.btn_createfield);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.rb_selected);
            this.Controls.Add(this.rb_all);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_folderpath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_extension);
            this.Controls.Add(this.txb_suffix);
            this.Controls.Add(this.txb_prefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_fieldname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_layers);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_initialize);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileTileExister_Form";
            this.Text = "FileTileExister_Form";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_initialize;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox cbo_layers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_fieldname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_prefix;
        private System.Windows.Forms.TextBox txb_suffix;
        private System.Windows.Forms.ComboBox cbo_extension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_folderpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.RadioButton rb_selected;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_createfield;
        private System.Windows.Forms.CheckBox cb_subfolder;
    }
}