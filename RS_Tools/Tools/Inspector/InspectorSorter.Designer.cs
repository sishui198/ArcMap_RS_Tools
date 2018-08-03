namespace RS_Tools.Tools.Inspector
{
    partial class InspectorSorter
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
            this.btn_GenerateIndex = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_FeatureLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_TopLeft = new System.Windows.Forms.RadioButton();
            this.rb_TopRight = new System.Windows.Forms.RadioButton();
            this.rb_BottomLeft = new System.Windows.Forms.RadioButton();
            this.rb_BottomRight = new System.Windows.Forms.RadioButton();
            this.rb_Column = new System.Windows.Forms.RadioButton();
            this.rb_Row = new System.Windows.Forms.RadioButton();
            this.groupCorner = new System.Windows.Forms.GroupBox();
            this.groupDirection = new System.Windows.Forms.GroupBox();
            this.groupCorner.SuspendLayout();
            this.groupDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GenerateIndex
            // 
            this.btn_GenerateIndex.Location = new System.Drawing.Point(202, 412);
            this.btn_GenerateIndex.Name = "btn_GenerateIndex";
            this.btn_GenerateIndex.Size = new System.Drawing.Size(115, 35);
            this.btn_GenerateIndex.TabIndex = 0;
            this.btn_GenerateIndex.Text = "Generate Index";
            this.btn_GenerateIndex.UseVisualStyleBackColor = true;
            this.btn_GenerateIndex.Click += new System.EventHandler(this.btn_GenerateIndex_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Feature Layer";
            // 
            // cbo_FeatureLayers
            // 
            this.cbo_FeatureLayers.FormattingEnabled = true;
            this.cbo_FeatureLayers.Location = new System.Drawing.Point(12, 367);
            this.cbo_FeatureLayers.Name = "cbo_FeatureLayers";
            this.cbo_FeatureLayers.Size = new System.Drawing.Size(305, 27);
            this.cbo_FeatureLayers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 95);
            this.label2.TabIndex = 4;
            this.label2.Text = "This tool will reorder how the inspector \r\ngoes through data. You choose a corner" +
    "\r\n to start from and then if you want to go\r\n in columns or rows. Add \'rsi_index" +
    "\' to the \r\ntable as an \'integer\' field.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rb_TopLeft
            // 
            this.rb_TopLeft.AutoSize = true;
            this.rb_TopLeft.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_TopLeft.Location = new System.Drawing.Point(13, 35);
            this.rb_TopLeft.Name = "rb_TopLeft";
            this.rb_TopLeft.Size = new System.Drawing.Size(79, 23);
            this.rb_TopLeft.TabIndex = 5;
            this.rb_TopLeft.TabStop = true;
            this.rb_TopLeft.Text = "Top Left";
            this.rb_TopLeft.UseVisualStyleBackColor = true;
            // 
            // rb_TopRight
            // 
            this.rb_TopRight.AutoSize = true;
            this.rb_TopRight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_TopRight.Location = new System.Drawing.Point(122, 35);
            this.rb_TopRight.Name = "rb_TopRight";
            this.rb_TopRight.Size = new System.Drawing.Size(88, 23);
            this.rb_TopRight.TabIndex = 6;
            this.rb_TopRight.TabStop = true;
            this.rb_TopRight.Text = "Top Right";
            this.rb_TopRight.UseVisualStyleBackColor = true;
            // 
            // rb_BottomLeft
            // 
            this.rb_BottomLeft.AutoSize = true;
            this.rb_BottomLeft.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_BottomLeft.Location = new System.Drawing.Point(13, 70);
            this.rb_BottomLeft.Name = "rb_BottomLeft";
            this.rb_BottomLeft.Size = new System.Drawing.Size(103, 23);
            this.rb_BottomLeft.TabIndex = 7;
            this.rb_BottomLeft.TabStop = true;
            this.rb_BottomLeft.Text = "Bottom Left";
            this.rb_BottomLeft.UseVisualStyleBackColor = true;
            // 
            // rb_BottomRight
            // 
            this.rb_BottomRight.AutoSize = true;
            this.rb_BottomRight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_BottomRight.Location = new System.Drawing.Point(122, 70);
            this.rb_BottomRight.Name = "rb_BottomRight";
            this.rb_BottomRight.Size = new System.Drawing.Size(112, 23);
            this.rb_BottomRight.TabIndex = 8;
            this.rb_BottomRight.TabStop = true;
            this.rb_BottomRight.Text = "Bottom Right";
            this.rb_BottomRight.UseVisualStyleBackColor = true;
            // 
            // rb_Column
            // 
            this.rb_Column.AutoSize = true;
            this.rb_Column.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Column.Location = new System.Drawing.Point(6, 21);
            this.rb_Column.Name = "rb_Column";
            this.rb_Column.Size = new System.Drawing.Size(78, 23);
            this.rb_Column.TabIndex = 9;
            this.rb_Column.TabStop = true;
            this.rb_Column.Text = "Column";
            this.rb_Column.UseVisualStyleBackColor = true;
            // 
            // rb_Row
            // 
            this.rb_Row.AutoSize = true;
            this.rb_Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Row.Location = new System.Drawing.Point(122, 21);
            this.rb_Row.Name = "rb_Row";
            this.rb_Row.Size = new System.Drawing.Size(56, 23);
            this.rb_Row.TabIndex = 10;
            this.rb_Row.TabStop = true;
            this.rb_Row.Text = "Row";
            this.rb_Row.UseVisualStyleBackColor = true;
            // 
            // groupCorner
            // 
            this.groupCorner.Controls.Add(this.rb_TopLeft);
            this.groupCorner.Controls.Add(this.rb_BottomLeft);
            this.groupCorner.Controls.Add(this.rb_TopRight);
            this.groupCorner.Controls.Add(this.rb_BottomRight);
            this.groupCorner.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCorner.Location = new System.Drawing.Point(16, 124);
            this.groupCorner.Name = "groupCorner";
            this.groupCorner.Size = new System.Drawing.Size(268, 131);
            this.groupCorner.TabIndex = 13;
            this.groupCorner.TabStop = false;
            this.groupCorner.Text = "Starting Corner";
            // 
            // groupDirection
            // 
            this.groupDirection.Controls.Add(this.rb_Column);
            this.groupDirection.Controls.Add(this.rb_Row);
            this.groupDirection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDirection.Location = new System.Drawing.Point(29, 261);
            this.groupDirection.Name = "groupDirection";
            this.groupDirection.Size = new System.Drawing.Size(244, 65);
            this.groupDirection.TabIndex = 14;
            this.groupDirection.TabStop = false;
            this.groupDirection.Text = "Direction";
            // 
            // InspectorSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 459);
            this.Controls.Add(this.groupDirection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_FeatureLayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_GenerateIndex);
            this.Controls.Add(this.groupCorner);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InspectorSorter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inspector Sorter";
            this.Load += new System.EventHandler(this.InspectorSorter_Load);
            this.groupCorner.ResumeLayout(false);
            this.groupCorner.PerformLayout();
            this.groupDirection.ResumeLayout(false);
            this.groupDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerateIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_FeatureLayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_TopLeft;
        private System.Windows.Forms.RadioButton rb_TopRight;
        private System.Windows.Forms.RadioButton rb_BottomLeft;
        private System.Windows.Forms.RadioButton rb_BottomRight;
        private System.Windows.Forms.RadioButton rb_Column;
        private System.Windows.Forms.RadioButton rb_Row;
        private System.Windows.Forms.GroupBox groupCorner;
        private System.Windows.Forms.GroupBox groupDirection;
    }
}