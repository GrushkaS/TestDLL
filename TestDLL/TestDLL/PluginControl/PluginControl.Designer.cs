namespace TestDLL
{
    partial class PluginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LayerButton = new System.Windows.Forms.Button();
            this.Coordinates1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.DescriptLabel = new System.Windows.Forms.Label();
            this.LayerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 9;
            // 
            // LayerButton
            // 
            this.LayerButton.Location = new System.Drawing.Point(349, 15);
            this.LayerButton.Name = "LayerButton";
            this.LayerButton.Size = new System.Drawing.Size(75, 35);
            this.LayerButton.TabIndex = 2;
            this.LayerButton.Text = "Update active layer";
            this.LayerButton.UseVisualStyleBackColor = true;
            this.LayerButton.Click += new System.EventHandler(this.LayerButton_Click);
            // 
            // Coordinates1
            // 
            this.Coordinates1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Coordinates1.Location = new System.Drawing.Point(6, 91);
            this.Coordinates1.Name = "Coordinates1";
            this.Coordinates1.Size = new System.Drawing.Size(418, 20);
            this.Coordinates1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "WGS84";
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(349, 164);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 8;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // DescriptLabel
            // 
            this.DescriptLabel.AutoSize = true;
            this.DescriptLabel.Location = new System.Drawing.Point(3, 123);
            this.DescriptLabel.Name = "DescriptLabel";
            this.DescriptLabel.Size = new System.Drawing.Size(247, 26);
            this.DescriptLabel.TabIndex = 11;
            this.DescriptLabel.Text = "Input format: Xcoord1 Ycoord1 Xcoord2 Ycoord2...\nRecomended fill in clockwise";
            // 
            // LayerTextBox
            // 
            this.LayerTextBox.Location = new System.Drawing.Point(6, 15);
            this.LayerTextBox.Name = "LayerTextBox";
            this.LayerTextBox.ReadOnly = true;
            this.LayerTextBox.Size = new System.Drawing.Size(312, 20);
            this.LayerTextBox.TabIndex = 12;
            this.LayerTextBox.Text = "Empty";
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayerTextBox);
            this.Controls.Add(this.DescriptLabel);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Coordinates1);
            this.Controls.Add(this.LayerButton);
            this.Controls.Add(this.label1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(440, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LayerButton;
        private System.Windows.Forms.TextBox Coordinates1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Label DescriptLabel;
        private System.Windows.Forms.TextBox LayerTextBox;
    }
}
