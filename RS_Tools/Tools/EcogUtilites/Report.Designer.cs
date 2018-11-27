namespace RS_Tools.Tools.EcogUtilites
{
    partial class Report
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
            this.rtb_report = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_report
            // 
            this.rtb_report.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_report.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_report.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_report.Location = new System.Drawing.Point(0, 0);
            this.rtb_report.Name = "rtb_report";
            this.rtb_report.ReadOnly = true;
            this.rtb_report.Size = new System.Drawing.Size(484, 362);
            this.rtb_report.TabIndex = 1;
            this.rtb_report.Text = "";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.rtb_report);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 162);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_report;
    }
}