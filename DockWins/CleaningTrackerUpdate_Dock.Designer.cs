namespace EsriTools.DockWins
{
    partial class CleaningTrackerUpdate_Dock
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
            this.lblheader = new System.Windows.Forms.Label();
            this.btnIntialize = new System.Windows.Forms.Button();
            this.seperate_label02 = new System.Windows.Forms.Label();
            this.lblTileLayout = new System.Windows.Forms.Label();
            this.cboTileLayout = new System.Windows.Forms.ComboBox();
            this.btnUpdateTracker = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCleanerName = new System.Windows.Forms.ComboBox();
            this.cboCleaningOrQC = new System.Windows.Forms.ComboBox();
            this.lblCleaningOrQC = new System.Windows.Forms.Label();
            this.lblCleanerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblheader
            // 
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblheader.Location = new System.Drawing.Point(7, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(140, 47);
            this.lblheader.TabIndex = 0;
            this.lblheader.Text = "Cleaning";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIntialize
            // 
            this.btnIntialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntialize.ForeColor = System.Drawing.Color.Orange;
            this.btnIntialize.Location = new System.Drawing.Point(3, 50);
            this.btnIntialize.Name = "btnIntialize";
            this.btnIntialize.Size = new System.Drawing.Size(140, 23);
            this.btnIntialize.TabIndex = 1;
            this.btnIntialize.Text = "Initialize";
            this.btnIntialize.UseVisualStyleBackColor = true;
            this.btnIntialize.Click += new System.EventHandler(this.btnIntialize_Click);
            // 
            // seperate_label02
            // 
            this.seperate_label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperate_label02.Location = new System.Drawing.Point(3, 76);
            this.seperate_label02.Name = "seperate_label02";
            this.seperate_label02.Size = new System.Drawing.Size(143, 2);
            this.seperate_label02.TabIndex = 9;
            // 
            // lblTileLayout
            // 
            this.lblTileLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileLayout.Location = new System.Drawing.Point(4, 78);
            this.lblTileLayout.Name = "lblTileLayout";
            this.lblTileLayout.Size = new System.Drawing.Size(143, 16);
            this.lblTileLayout.TabIndex = 11;
            this.lblTileLayout.Text = "Tile Layout";
            this.lblTileLayout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboTileLayout
            // 
            this.cboTileLayout.DropDownHeight = 100;
            this.cboTileLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileLayout.DropDownWidth = 200;
            this.cboTileLayout.FormattingEnabled = true;
            this.cboTileLayout.IntegralHeight = false;
            this.cboTileLayout.ItemHeight = 13;
            this.cboTileLayout.Location = new System.Drawing.Point(3, 97);
            this.cboTileLayout.Name = "cboTileLayout";
            this.cboTileLayout.Size = new System.Drawing.Size(140, 21);
            this.cboTileLayout.TabIndex = 10;
            this.cboTileLayout.SelectedIndexChanged += new System.EventHandler(this.cboTileLayout_SelectedIndexChanged);
            // 
            // btnUpdateTracker
            // 
            this.btnUpdateTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTracker.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnUpdateTracker.Location = new System.Drawing.Point(3, 233);
            this.btnUpdateTracker.Name = "btnUpdateTracker";
            this.btnUpdateTracker.Size = new System.Drawing.Size(142, 50);
            this.btnUpdateTracker.TabIndex = 17;
            this.btnUpdateTracker.Text = "Update Tracker";
            this.btnUpdateTracker.UseVisualStyleBackColor = true;
            this.btnUpdateTracker.Click += new System.EventHandler(this.btnUpdateTracker_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 2);
            this.label1.TabIndex = 16;
            // 
            // cboCleanerName
            // 
            this.cboCleanerName.DropDownHeight = 100;
            this.cboCleanerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCleanerName.DropDownWidth = 200;
            this.cboCleanerName.FormattingEnabled = true;
            this.cboCleanerName.IntegralHeight = false;
            this.cboCleanerName.Location = new System.Drawing.Point(3, 183);
            this.cboCleanerName.Name = "cboCleanerName";
            this.cboCleanerName.Size = new System.Drawing.Size(140, 21);
            this.cboCleanerName.TabIndex = 15;
            // 
            // cboCleaningOrQC
            // 
            this.cboCleaningOrQC.DropDownHeight = 100;
            this.cboCleaningOrQC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCleaningOrQC.DropDownWidth = 200;
            this.cboCleaningOrQC.FormattingEnabled = true;
            this.cboCleaningOrQC.IntegralHeight = false;
            this.cboCleaningOrQC.Items.AddRange(new object[] {
            "",
            "Cleaning",
            "Quality Check"});
            this.cboCleaningOrQC.Location = new System.Drawing.Point(3, 140);
            this.cboCleaningOrQC.Name = "cboCleaningOrQC";
            this.cboCleaningOrQC.Size = new System.Drawing.Size(140, 21);
            this.cboCleaningOrQC.TabIndex = 14;
            this.cboCleaningOrQC.SelectedIndexChanged += new System.EventHandler(this.cboCleaningOrQC_SelectedIndexChanged);
            // 
            // lblCleaningOrQC
            // 
            this.lblCleaningOrQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleaningOrQC.Location = new System.Drawing.Point(3, 121);
            this.lblCleaningOrQC.Name = "lblCleaningOrQC";
            this.lblCleaningOrQC.Size = new System.Drawing.Size(143, 16);
            this.lblCleaningOrQC.TabIndex = 13;
            this.lblCleaningOrQC.Text = "Cleaning or QC?";
            this.lblCleaningOrQC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCleanerName
            // 
            this.lblCleanerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleanerName.Location = new System.Drawing.Point(3, 164);
            this.lblCleanerName.Name = "lblCleanerName";
            this.lblCleanerName.Size = new System.Drawing.Size(143, 16);
            this.lblCleanerName.TabIndex = 12;
            this.lblCleanerName.Text = "Cleaner Name";
            this.lblCleanerName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CleaningTrackerUpdateDock
            // 
            this.Controls.Add(this.btnUpdateTracker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCleanerName);
            this.Controls.Add(this.cboCleaningOrQC);
            this.Controls.Add(this.lblCleaningOrQC);
            this.Controls.Add(this.lblCleanerName);
            this.Controls.Add(this.lblTileLayout);
            this.Controls.Add(this.cboTileLayout);
            this.Controls.Add(this.seperate_label02);
            this.Controls.Add(this.btnIntialize);
            this.Controls.Add(this.lblheader);
            this.Name = "CleaningTrackerUpdateDock";
            this.Size = new System.Drawing.Size(150, 300);
            this.Load += new System.EventHandler(this.CleaningTrackerUpdateDock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Button btnIntialize;
        private System.Windows.Forms.Label seperate_label02;
        private System.Windows.Forms.Label lblTileLayout;
        private System.Windows.Forms.ComboBox cboTileLayout;
        private System.Windows.Forms.Button btnUpdateTracker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCleanerName;
        private System.Windows.Forms.ComboBox cboCleaningOrQC;
        private System.Windows.Forms.Label lblCleaningOrQC;
        private System.Windows.Forms.Label lblCleanerName;

    }
}
