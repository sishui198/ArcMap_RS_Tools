﻿namespace RS_Tools.Tools.EcogUtilites
{
    partial class PrepLASData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrepLASData));
            this.tc_select_type = new System.Windows.Forms.TabControl();
            this.tp_las = new System.Windows.Forms.TabPage();
            this.chb_selected_las_tiles = new System.Windows.Forms.CheckBox();
            this.tp_las_ortho = new System.Windows.Forms.TabPage();
            this.chb_selected_ortho_tiles = new System.Windows.Forms.CheckBox();
            this.cb_field_ortho = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_tile_layout_ortho = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_create_batch = new System.Windows.Forms.Button();
            this.btn_reload_layers = new System.Windows.Forms.Button();
            this.btn_folder_output = new System.Windows.Forms.Button();
            this.btn_folder_las_tools = new System.Windows.Forms.Button();
            this.btn_folder_Las = new System.Windows.Forms.Button();
            this.cb_field_las = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_tile_layout_las = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_erdastools = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_las_folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chb_recursion_las = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_geoexpress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_deleteMergedLAS = new System.Windows.Forms.CheckBox();
            this.tc_select_type.SuspendLayout();
            this.tp_las.SuspendLayout();
            this.tp_las_ortho.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_select_type
            // 
            this.tc_select_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_select_type.Controls.Add(this.tp_las);
            this.tc_select_type.Controls.Add(this.tp_las_ortho);
            this.tc_select_type.Location = new System.Drawing.Point(12, 672);
            this.tc_select_type.Name = "tc_select_type";
            this.tc_select_type.SelectedIndex = 0;
            this.tc_select_type.Size = new System.Drawing.Size(611, 226);
            this.tc_select_type.TabIndex = 0;
            // 
            // tp_las
            // 
            this.tp_las.Controls.Add(this.chb_selected_las_tiles);
            this.tp_las.Location = new System.Drawing.Point(4, 30);
            this.tp_las.Name = "tp_las";
            this.tp_las.Padding = new System.Windows.Forms.Padding(3);
            this.tp_las.Size = new System.Drawing.Size(603, 192);
            this.tp_las.TabIndex = 0;
            this.tp_las.Text = "LAS";
            this.tp_las.UseVisualStyleBackColor = true;
            // 
            // chb_selected_las_tiles
            // 
            this.chb_selected_las_tiles.AutoSize = true;
            this.chb_selected_las_tiles.Location = new System.Drawing.Point(6, 6);
            this.chb_selected_las_tiles.Name = "chb_selected_las_tiles";
            this.chb_selected_las_tiles.Size = new System.Drawing.Size(190, 25);
            this.chb_selected_las_tiles.TabIndex = 12;
            this.chb_selected_las_tiles.Text = "Use Selected LAS Tiles";
            this.chb_selected_las_tiles.UseVisualStyleBackColor = true;
            // 
            // tp_las_ortho
            // 
            this.tp_las_ortho.Controls.Add(this.chb_selected_ortho_tiles);
            this.tp_las_ortho.Controls.Add(this.cb_field_ortho);
            this.tp_las_ortho.Controls.Add(this.label7);
            this.tp_las_ortho.Controls.Add(this.cb_tile_layout_ortho);
            this.tp_las_ortho.Controls.Add(this.label6);
            this.tp_las_ortho.Location = new System.Drawing.Point(4, 30);
            this.tp_las_ortho.Name = "tp_las_ortho";
            this.tp_las_ortho.Padding = new System.Windows.Forms.Padding(3);
            this.tp_las_ortho.Size = new System.Drawing.Size(603, 192);
            this.tp_las_ortho.TabIndex = 1;
            this.tp_las_ortho.Text = "LAS + Ortho";
            this.tp_las_ortho.UseVisualStyleBackColor = true;
            // 
            // chb_selected_ortho_tiles
            // 
            this.chb_selected_ortho_tiles.AutoSize = true;
            this.chb_selected_ortho_tiles.Location = new System.Drawing.Point(6, 143);
            this.chb_selected_ortho_tiles.Name = "chb_selected_ortho_tiles";
            this.chb_selected_ortho_tiles.Size = new System.Drawing.Size(204, 25);
            this.chb_selected_ortho_tiles.TabIndex = 27;
            this.chb_selected_ortho_tiles.Text = "Use Selected Ortho Tiles";
            this.chb_selected_ortho_tiles.UseVisualStyleBackColor = true;
            // 
            // cb_field_ortho
            // 
            this.cb_field_ortho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_field_ortho.FormattingEnabled = true;
            this.cb_field_ortho.Location = new System.Drawing.Point(6, 108);
            this.cb_field_ortho.Name = "cb_field_ortho";
            this.cb_field_ortho.Size = new System.Drawing.Size(591, 29);
            this.cb_field_ortho.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 21);
            this.label7.TabIndex = 25;
            this.label7.Text = "Field That Links to Ortho Data";
            // 
            // cb_tile_layout_ortho
            // 
            this.cb_tile_layout_ortho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tile_layout_ortho.FormattingEnabled = true;
            this.cb_tile_layout_ortho.Location = new System.Drawing.Point(6, 38);
            this.cb_tile_layout_ortho.Name = "cb_tile_layout_ortho";
            this.cb_tile_layout_ortho.Size = new System.Drawing.Size(591, 29);
            this.cb_tile_layout_ortho.TabIndex = 23;
            this.cb_tile_layout_ortho.SelectedIndexChanged += new System.EventHandler(this.cb_tile_layout_ortho_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ortho Tile Layout";
            // 
            // btn_create_batch
            // 
            this.btn_create_batch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_create_batch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_create_batch.Location = new System.Drawing.Point(12, 904);
            this.btn_create_batch.Name = "btn_create_batch";
            this.btn_create_batch.Size = new System.Drawing.Size(611, 50);
            this.btn_create_batch.TabIndex = 11;
            this.btn_create_batch.Text = "Create Batch Files";
            this.btn_create_batch.UseVisualStyleBackColor = true;
            this.btn_create_batch.Click += new System.EventHandler(this.btn_create_batch_Click);
            // 
            // btn_reload_layers
            // 
            this.btn_reload_layers.ForeColor = System.Drawing.Color.Black;
            this.btn_reload_layers.Location = new System.Drawing.Point(12, 12);
            this.btn_reload_layers.Name = "btn_reload_layers";
            this.btn_reload_layers.Size = new System.Drawing.Size(410, 33);
            this.btn_reload_layers.TabIndex = 19;
            this.btn_reload_layers.Text = "Reload Layers";
            this.btn_reload_layers.UseVisualStyleBackColor = true;
            this.btn_reload_layers.Click += new System.EventHandler(this.btn_reload_layers_Click);
            // 
            // btn_folder_output
            // 
            this.btn_folder_output.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_folder_output.BackgroundImage")));
            this.btn_folder_output.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_folder_output.Location = new System.Drawing.Point(591, 552);
            this.btn_folder_output.Name = "btn_folder_output";
            this.btn_folder_output.Size = new System.Drawing.Size(28, 29);
            this.btn_folder_output.TabIndex = 18;
            this.btn_folder_output.UseVisualStyleBackColor = true;
            this.btn_folder_output.Click += new System.EventHandler(this.btn_folder_output_Click);
            // 
            // btn_folder_las_tools
            // 
            this.btn_folder_las_tools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_folder_las_tools.BackgroundImage")));
            this.btn_folder_las_tools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_folder_las_tools.Location = new System.Drawing.Point(591, 369);
            this.btn_folder_las_tools.Name = "btn_folder_las_tools";
            this.btn_folder_las_tools.Size = new System.Drawing.Size(28, 29);
            this.btn_folder_las_tools.TabIndex = 17;
            this.btn_folder_las_tools.UseVisualStyleBackColor = true;
            this.btn_folder_las_tools.Click += new System.EventHandler(this.btn_folder_las_tools_Click);
            // 
            // btn_folder_Las
            // 
            this.btn_folder_Las.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_folder_Las.BackgroundImage")));
            this.btn_folder_Las.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_folder_Las.Location = new System.Drawing.Point(591, 252);
            this.btn_folder_Las.Name = "btn_folder_Las";
            this.btn_folder_Las.Size = new System.Drawing.Size(28, 29);
            this.btn_folder_Las.TabIndex = 16;
            this.btn_folder_Las.UseVisualStyleBackColor = true;
            this.btn_folder_Las.Click += new System.EventHandler(this.btn_folder_Las_Click);
            // 
            // cb_field_las
            // 
            this.cb_field_las.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_field_las.FormattingEnabled = true;
            this.cb_field_las.Location = new System.Drawing.Point(12, 168);
            this.cb_field_las.Name = "cb_field_las";
            this.cb_field_las.Size = new System.Drawing.Size(607, 29);
            this.cb_field_las.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Field That Links To File Name";
            // 
            // cb_tile_layout_las
            // 
            this.cb_tile_layout_las.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tile_layout_las.FormattingEnabled = true;
            this.cb_tile_layout_las.Location = new System.Drawing.Point(12, 96);
            this.cb_tile_layout_las.Name = "cb_tile_layout_las";
            this.cb_tile_layout_las.Size = new System.Drawing.Size(607, 29);
            this.cb_tile_layout_las.TabIndex = 13;
            this.cb_tile_layout_las.SelectedIndexChanged += new System.EventHandler(this.cb_tile_layout_las_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(428, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(191, 33);
            this.btn_close.TabIndex = 12;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Output Folder";
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(12, 553);
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.Size = new System.Drawing.Size(573, 29);
            this.tb_output.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "ERDAS Imagine Tools";
            // 
            // tb_erdastools
            // 
            this.tb_erdastools.Location = new System.Drawing.Point(12, 370);
            this.tb_erdastools.Name = "tb_erdastools";
            this.tb_erdastools.ReadOnly = true;
            this.tb_erdastools.Size = new System.Drawing.Size(573, 29);
            this.tb_erdastools.TabIndex = 7;
            this.tb_erdastools.Text = "C:\\Program Files\\Hexagon\\ERDAS IMAGINE 2018\\bin\\x64URelease";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Folder Containing LAS Data";
            // 
            // tb_las_folder
            // 
            this.tb_las_folder.Location = new System.Drawing.Point(12, 253);
            this.tb_las_folder.Name = "tb_las_folder";
            this.tb_las_folder.ReadOnly = true;
            this.tb_las_folder.Size = new System.Drawing.Size(573, 29);
            this.tb_las_folder.TabIndex = 5;
            this.tb_las_folder.Text = "E:\\ResearchAndDevelopment\\Tools\\EcogUtilities\\LAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "LAS Tile Layout";
            // 
            // chb_recursion_las
            // 
            this.chb_recursion_las.AutoSize = true;
            this.chb_recursion_las.Location = new System.Drawing.Point(12, 288);
            this.chb_recursion_las.Name = "chb_recursion_las";
            this.chb_recursion_las.Size = new System.Drawing.Size(162, 25);
            this.chb_recursion_las.TabIndex = 20;
            this.chb_recursion_las.Text = "Search Subfolders";
            this.chb_recursion_las.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(593, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 29);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tb_geoexpress
            // 
            this.tb_geoexpress.Location = new System.Drawing.Point(14, 462);
            this.tb_geoexpress.Name = "tb_geoexpress";
            this.tb_geoexpress.ReadOnly = true;
            this.tb_geoexpress.Size = new System.Drawing.Size(573, 29);
            this.tb_geoexpress.TabIndex = 21;
            this.tb_geoexpress.Text = "C:\\Program Files\\LizardTech\\GeoExpress\\bin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "GeoExpress Bin Folder";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 601);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 21);
            this.label10.TabIndex = 24;
            this.label10.Text = "Options";
            // 
            // cb_deleteMergedLAS
            // 
            this.cb_deleteMergedLAS.AutoSize = true;
            this.cb_deleteMergedLAS.Checked = true;
            this.cb_deleteMergedLAS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_deleteMergedLAS.Location = new System.Drawing.Point(12, 625);
            this.cb_deleteMergedLAS.Name = "cb_deleteMergedLAS";
            this.cb_deleteMergedLAS.Size = new System.Drawing.Size(450, 25);
            this.cb_deleteMergedLAS.TabIndex = 25;
            this.cb_deleteMergedLAS.Text = "Progressivly Delete Merged LAS Data (Saves Storage Space)\r\n";
            this.cb_deleteMergedLAS.UseVisualStyleBackColor = true;
            // 
            // PrepLASData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(635, 966);
            this.ControlBox = false;
            this.Controls.Add(this.cb_deleteMergedLAS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_geoexpress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chb_recursion_las);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_create_batch);
            this.Controls.Add(this.btn_folder_output);
            this.Controls.Add(this.btn_reload_layers);
            this.Controls.Add(this.btn_folder_las_tools);
            this.Controls.Add(this.tc_select_type);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_folder_Las);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_field_las);
            this.Controls.Add(this.cb_tile_layout_las);
            this.Controls.Add(this.tb_erdastools);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_las_folder);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PrepLASData";
            this.Text = "Prep LAS Data";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PrepLASData_Load);
            this.tc_select_type.ResumeLayout(false);
            this.tp_las.ResumeLayout(false);
            this.tp_las.PerformLayout();
            this.tp_las_ortho.ResumeLayout(false);
            this.tp_las_ortho.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc_select_type;
        private System.Windows.Forms.TabPage tp_las;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_erdastools;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_las_folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tp_las_ortho;
        private System.Windows.Forms.ComboBox cb_field_las;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_tile_layout_las;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_create_batch;
        private System.Windows.Forms.Button btn_reload_layers;
        private System.Windows.Forms.Button btn_folder_output;
        private System.Windows.Forms.Button btn_folder_las_tools;
        private System.Windows.Forms.Button btn_folder_Las;
        private System.Windows.Forms.ComboBox cb_tile_layout_ortho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_field_ortho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chb_selected_las_tiles;
        private System.Windows.Forms.CheckBox chb_selected_ortho_tiles;
        private System.Windows.Forms.CheckBox chb_recursion_las;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_geoexpress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cb_deleteMergedLAS;
    }
}