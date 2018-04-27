namespace RS_Tools.Tools.Homesite
{
    partial class Homesite
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
            this.btn_intialize = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_okay = new System.Windows.Forms.Button();
            this.cbo_featureclass = new System.Windows.Forms.ComboBox();
            this.lbl_featureclass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_intialize
            // 
            this.btn_intialize.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_intialize.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_intialize.Location = new System.Drawing.Point(12, 26);
            this.btn_intialize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_intialize.Name = "btn_intialize";
            this.btn_intialize.Size = new System.Drawing.Size(135, 45);
            this.btn_intialize.TabIndex = 0;
            this.btn_intialize.Text = "Initalize";
            this.btn_intialize.UseVisualStyleBackColor = true;
            this.btn_intialize.Click += new System.EventHandler(this.btn_intialize_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(288, 131);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(84, 33);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_okay
            // 
            this.btn_okay.Location = new System.Drawing.Point(387, 131);
            this.btn_okay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_okay.Name = "btn_okay";
            this.btn_okay.Size = new System.Drawing.Size(84, 33);
            this.btn_okay.TabIndex = 2;
            this.btn_okay.Text = "Okay";
            this.btn_okay.UseVisualStyleBackColor = true;
            this.btn_okay.Click += new System.EventHandler(this.btn_okay_Click);
            // 
            // cbo_featureclass
            // 
            this.cbo_featureclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_featureclass.FormattingEnabled = true;
            this.cbo_featureclass.Location = new System.Drawing.Point(173, 40);
            this.cbo_featureclass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_featureclass.Name = "cbo_featureclass";
            this.cbo_featureclass.Size = new System.Drawing.Size(298, 31);
            this.cbo_featureclass.TabIndex = 3;
            // 
            // lbl_featureclass
            // 
            this.lbl_featureclass.AutoSize = true;
            this.lbl_featureclass.Location = new System.Drawing.Point(169, 9);
            this.lbl_featureclass.Name = "lbl_featureclass";
            this.lbl_featureclass.Size = new System.Drawing.Size(110, 23);
            this.lbl_featureclass.TabIndex = 4;
            this.lbl_featureclass.Text = "Feature Class";
            // 
            // Homesite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(483, 181);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_featureclass);
            this.Controls.Add(this.cbo_featureclass);
            this.Controls.Add(this.btn_okay);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_intialize);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(501, 228);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(501, 228);
            this.Name = "Homesite";
            this.Text = "Homesite Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_intialize;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_okay;
        private System.Windows.Forms.ComboBox cbo_featureclass;
        private System.Windows.Forms.Label lbl_featureclass;
    }
}