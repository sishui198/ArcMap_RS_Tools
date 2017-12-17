namespace RS_Tools.Tools.DomainAppointer
{
    partial class DomainAppointer
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
            this.lblField = new System.Windows.Forms.Label();
            this.lblFeatureLayer = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.cboFeatureLayer = new System.Windows.Forms.ComboBox();
            this.btn_Initialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(14, 119);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(29, 13);
            this.lblField.TabIndex = 9;
            this.lblField.Text = "Field";
            // 
            // lblFeatureLayer
            // 
            this.lblFeatureLayer.AutoSize = true;
            this.lblFeatureLayer.Location = new System.Drawing.Point(17, 58);
            this.lblFeatureLayer.Name = "lblFeatureLayer";
            this.lblFeatureLayer.Size = new System.Drawing.Size(72, 13);
            this.lblFeatureLayer.TabIndex = 8;
            this.lblFeatureLayer.Text = "Feature Layer";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.DropDownWidth = 130;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(17, 149);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 21);
            this.cboField.TabIndex = 7;
            // 
            // cboFeatureLayer
            // 
            this.cboFeatureLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeatureLayer.DropDownWidth = 130;
            this.cboFeatureLayer.FormattingEnabled = true;
            this.cboFeatureLayer.Location = new System.Drawing.Point(17, 83);
            this.cboFeatureLayer.Name = "cboFeatureLayer";
            this.cboFeatureLayer.Size = new System.Drawing.Size(121, 21);
            this.cboFeatureLayer.TabIndex = 6;
            this.cboFeatureLayer.SelectedIndexChanged += new System.EventHandler(this.cboFeatureLayer_SelectedIndexChanged);
            // 
            // btn_Initialize
            // 
            this.btn_Initialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Initialize.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_Initialize.Location = new System.Drawing.Point(17, 18);
            this.btn_Initialize.Name = "btn_Initialize";
            this.btn_Initialize.Size = new System.Drawing.Size(121, 23);
            this.btn_Initialize.TabIndex = 5;
            this.btn_Initialize.Text = "Initialize";
            this.btn_Initialize.UseVisualStyleBackColor = true;
            this.btn_Initialize.Click += new System.EventHandler(this.btn_Initialize_Click);
            // 
            // DomainAppointer
            // 
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblFeatureLayer);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.cboFeatureLayer);
            this.Controls.Add(this.btn_Initialize);
            this.Name = "DomainAppointer";
            this.Size = new System.Drawing.Size(152, 189);
            this.Load += new System.EventHandler(this.DomainAppointer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblFeatureLayer;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.ComboBox cboFeatureLayer;
        private System.Windows.Forms.Button btn_Initialize;
    }
}
