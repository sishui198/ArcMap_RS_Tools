namespace RS_Tools.DockWins
{
    partial class HydroTrackerUpdate_Dock
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
            this.cboTileLayout = new System.Windows.Forms.ComboBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.seperate_label01 = new System.Windows.Forms.Label();
            this.lblTileLayout = new System.Windows.Forms.Label();
            this.lblCreatorName = new System.Windows.Forms.Label();
            this.lblDrawingOrQC = new System.Windows.Forms.Label();
            this.cboDrawingOrQC = new System.Windows.Forms.ComboBox();
            this.cboCreatorName = new System.Windows.Forms.ComboBox();
            this.seperate_label02 = new System.Windows.Forms.Label();
            this.btnUpdateTracker = new System.Windows.Forms.Button();
            this.lblheader = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.cboTileLayout.TabIndex = 0;
            this.cboTileLayout.SelectedIndexChanged += new System.EventHandler(this.cboTileLayout_SelectedIndexChanged);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitialize.ForeColor = System.Drawing.Color.Orange;
            this.btnInitialize.Location = new System.Drawing.Point(3, 50);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(140, 21);
            this.btnInitialize.TabIndex = 1;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // seperate_label01
            // 
            this.seperate_label01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperate_label01.Location = new System.Drawing.Point(3, 76);
            this.seperate_label01.Name = "seperate_label01";
            this.seperate_label01.Size = new System.Drawing.Size(143, 2);
            this.seperate_label01.TabIndex = 2;
            // 
            // lblTileLayout
            // 
            this.lblTileLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileLayout.Location = new System.Drawing.Point(3, 78);
            this.lblTileLayout.Name = "lblTileLayout";
            this.lblTileLayout.Size = new System.Drawing.Size(143, 16);
            this.lblTileLayout.TabIndex = 3;
            this.lblTileLayout.Text = "Tile Layout";
            this.lblTileLayout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCreatorName
            // 
            this.lblCreatorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatorName.Location = new System.Drawing.Point(3, 164);
            this.lblCreatorName.Name = "lblCreatorName";
            this.lblCreatorName.Size = new System.Drawing.Size(143, 16);
            this.lblCreatorName.TabIndex = 4;
            this.lblCreatorName.Text = "Creator Name";
            this.lblCreatorName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDrawingOrQC
            // 
            this.lblDrawingOrQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawingOrQC.Location = new System.Drawing.Point(3, 121);
            this.lblDrawingOrQC.Name = "lblDrawingOrQC";
            this.lblDrawingOrQC.Size = new System.Drawing.Size(143, 16);
            this.lblDrawingOrQC.TabIndex = 5;
            this.lblDrawingOrQC.Text = "Drawing or QC?";
            this.lblDrawingOrQC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboDrawingOrQC
            // 
            this.cboDrawingOrQC.DropDownHeight = 100;
            this.cboDrawingOrQC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawingOrQC.DropDownWidth = 200;
            this.cboDrawingOrQC.FormattingEnabled = true;
            this.cboDrawingOrQC.IntegralHeight = false;
            this.cboDrawingOrQC.Items.AddRange(new object[] {
            "",
            "Drawing",
            "Quality Check"});
            this.cboDrawingOrQC.Location = new System.Drawing.Point(3, 140);
            this.cboDrawingOrQC.Name = "cboDrawingOrQC";
            this.cboDrawingOrQC.Size = new System.Drawing.Size(140, 21);
            this.cboDrawingOrQC.TabIndex = 6;
            this.cboDrawingOrQC.SelectedIndexChanged += new System.EventHandler(this.cboDrawingOrQC_SelectedIndexChanged);
            // 
            // cboCreatorName
            // 
            this.cboCreatorName.DropDownHeight = 100;
            this.cboCreatorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreatorName.DropDownWidth = 200;
            this.cboCreatorName.FormattingEnabled = true;
            this.cboCreatorName.IntegralHeight = false;
            this.cboCreatorName.Location = new System.Drawing.Point(3, 183);
            this.cboCreatorName.Name = "cboCreatorName";
            this.cboCreatorName.Size = new System.Drawing.Size(140, 21);
            this.cboCreatorName.TabIndex = 7;
            // 
            // seperate_label02
            // 
            this.seperate_label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperate_label02.Location = new System.Drawing.Point(3, 228);
            this.seperate_label02.Name = "seperate_label02";
            this.seperate_label02.Size = new System.Drawing.Size(143, 2);
            this.seperate_label02.TabIndex = 8;
            // 
            // btnUpdateTracker
            // 
            this.btnUpdateTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTracker.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnUpdateTracker.Location = new System.Drawing.Point(3, 233);
            this.btnUpdateTracker.Name = "btnUpdateTracker";
            this.btnUpdateTracker.Size = new System.Drawing.Size(142, 50);
            this.btnUpdateTracker.TabIndex = 9;
            this.btnUpdateTracker.Text = "Update Tracker";
            this.btnUpdateTracker.UseVisualStyleBackColor = true;
            this.btnUpdateTracker.Click += new System.EventHandler(this.btnUpdateTracker_Click);
            // 
            // lblheader
            // 
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(7, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(140, 47);
            this.lblheader.TabIndex = 10;
            this.lblheader.Text = "Hydro";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HydroTrackerUpdateDock
            // 
            this.Controls.Add(this.lblheader);
            this.Controls.Add(this.btnUpdateTracker);
            this.Controls.Add(this.seperate_label02);
            this.Controls.Add(this.cboCreatorName);
            this.Controls.Add(this.cboDrawingOrQC);
            this.Controls.Add(this.lblDrawingOrQC);
            this.Controls.Add(this.lblCreatorName);
            this.Controls.Add(this.lblTileLayout);
            this.Controls.Add(this.seperate_label01);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.cboTileLayout);
            this.Name = "HydroTrackerUpdateDock";
            this.Size = new System.Drawing.Size(150, 300);
            this.Load += new System.EventHandler(this.HydroTrackerUpdateDock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTileLayout;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Label seperate_label01;
        private System.Windows.Forms.Label lblTileLayout;
        private System.Windows.Forms.Label lblCreatorName;
        private System.Windows.Forms.Label lblDrawingOrQC;
        private System.Windows.Forms.ComboBox cboDrawingOrQC;
        private System.Windows.Forms.ComboBox cboCreatorName;
        private System.Windows.Forms.Label seperate_label02;
        private System.Windows.Forms.Button btnUpdateTracker;
        private System.Windows.Forms.Label lblheader;

    }
}
