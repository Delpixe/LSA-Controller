namespace LS_Controller
{
    partial class Upgrade
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
            this.OldBaseVersion_label = new System.Windows.Forms.Label();
            this.DatabaseServer_label = new System.Windows.Forms.Label();
            this.DatabaseName_label = new System.Windows.Forms.Label();
            this.OldBasePath_label = new System.Windows.Forms.Label();
            this.OldBaseFilter_label = new System.Windows.Forms.Label();
            this.OldBaseServer_textBox = new System.Windows.Forms.TextBox();
            this.OldBaseName_textBox = new System.Windows.Forms.TextBox();
            this.OldBasePath_textBox = new System.Windows.Forms.TextBox();
            this.OldBaseFilter_textBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OldBasePath_button = new System.Windows.Forms.Button();
            this.ShowOutput_button = new System.Windows.Forms.Button();
            this.Launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OldBaseVersion_label
            // 
            this.OldBaseVersion_label.AutoSize = true;
            this.OldBaseVersion_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldBaseVersion_label.Location = new System.Drawing.Point(12, 9);
            this.OldBaseVersion_label.Name = "OldBaseVersion_label";
            this.OldBaseVersion_label.Size = new System.Drawing.Size(129, 16);
            this.OldBaseVersion_label.TabIndex = 0;
            this.OldBaseVersion_label.Text = "Old Base Version";
            // 
            // DatabaseServer_label
            // 
            this.DatabaseServer_label.AutoSize = true;
            this.DatabaseServer_label.Location = new System.Drawing.Point(12, 36);
            this.DatabaseServer_label.Name = "DatabaseServer_label";
            this.DatabaseServer_label.Size = new System.Drawing.Size(87, 13);
            this.DatabaseServer_label.TabIndex = 1;
            this.DatabaseServer_label.Text = "Database Server";
            // 
            // DatabaseName_label
            // 
            this.DatabaseName_label.AutoSize = true;
            this.DatabaseName_label.Location = new System.Drawing.Point(12, 65);
            this.DatabaseName_label.Name = "DatabaseName_label";
            this.DatabaseName_label.Size = new System.Drawing.Size(84, 13);
            this.DatabaseName_label.TabIndex = 2;
            this.DatabaseName_label.Text = "Database Name";
            // 
            // OldBasePath_label
            // 
            this.OldBasePath_label.AutoSize = true;
            this.OldBasePath_label.Location = new System.Drawing.Point(12, 91);
            this.OldBasePath_label.Name = "OldBasePath_label";
            this.OldBasePath_label.Size = new System.Drawing.Size(75, 13);
            this.OldBasePath_label.TabIndex = 3;
            this.OldBasePath_label.Text = "Old Base Path";
            // 
            // OldBaseFilter_label
            // 
            this.OldBaseFilter_label.AutoSize = true;
            this.OldBaseFilter_label.Location = new System.Drawing.Point(12, 117);
            this.OldBaseFilter_label.Name = "OldBaseFilter_label";
            this.OldBaseFilter_label.Size = new System.Drawing.Size(29, 13);
            this.OldBaseFilter_label.TabIndex = 4;
            this.OldBaseFilter_label.Text = "Filter";
            // 
            // OldBaseServer_textBox
            // 
            this.OldBaseServer_textBox.Location = new System.Drawing.Point(105, 36);
            this.OldBaseServer_textBox.Name = "OldBaseServer_textBox";
            this.OldBaseServer_textBox.Size = new System.Drawing.Size(394, 20);
            this.OldBaseServer_textBox.TabIndex = 1;
            // 
            // OldBaseName_textBox
            // 
            this.OldBaseName_textBox.Location = new System.Drawing.Point(105, 62);
            this.OldBaseName_textBox.Name = "OldBaseName_textBox";
            this.OldBaseName_textBox.Size = new System.Drawing.Size(394, 20);
            this.OldBaseName_textBox.TabIndex = 2;
            // 
            // OldBasePath_textBox
            // 
            this.OldBasePath_textBox.Location = new System.Drawing.Point(105, 88);
            this.OldBasePath_textBox.Name = "OldBasePath_textBox";
            this.OldBasePath_textBox.Size = new System.Drawing.Size(394, 20);
            this.OldBasePath_textBox.TabIndex = 3;
            // 
            // OldBaseFilter_textBox
            // 
            this.OldBaseFilter_textBox.Location = new System.Drawing.Point(105, 114);
            this.OldBaseFilter_textBox.Name = "OldBaseFilter_textBox";
            this.OldBaseFilter_textBox.Size = new System.Drawing.Size(394, 20);
            this.OldBaseFilter_textBox.TabIndex = 5;
            // 
            // OldBasePath_button
            // 
            this.OldBasePath_button.Location = new System.Drawing.Point(505, 88);
            this.OldBasePath_button.Name = "OldBasePath_button";
            this.OldBasePath_button.Size = new System.Drawing.Size(63, 21);
            this.OldBasePath_button.TabIndex = 6;
            this.OldBasePath_button.Text = "Scegli";
            this.OldBasePath_button.UseVisualStyleBackColor = true;
            this.OldBasePath_button.Click += new System.EventHandler(this.OldBasePath_button_Click);
            // 
            // ShowOutput_button
            // 
            this.ShowOutput_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowOutput_button.BackColor = System.Drawing.SystemColors.Window;
            this.ShowOutput_button.Enabled = false;
            this.ShowOutput_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowOutput_button.Location = new System.Drawing.Point(322, 401);
            this.ShowOutput_button.Name = "ShowOutput_button";
            this.ShowOutput_button.Size = new System.Drawing.Size(57, 37);
            this.ShowOutput_button.TabIndex = 24;
            this.ShowOutput_button.Text = "Show output";
            this.ShowOutput_button.UseVisualStyleBackColor = false;
            this.ShowOutput_button.Click += new System.EventHandler(this.ShowOutput_button_Click);
            // 
            // Launch
            // 
            this.Launch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Launch.BackColor = System.Drawing.SystemColors.Window;
            this.Launch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Launch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Launch.Location = new System.Drawing.Point(410, 401);
            this.Launch.Name = "Launch";
            this.Launch.Size = new System.Drawing.Size(158, 37);
            this.Launch.TabIndex = 23;
            this.Launch.Text = "Lancia";
            this.Launch.UseVisualStyleBackColor = false;
            this.Launch.Click += new System.EventHandler(this.Launch_Click);
            // 
            // Upgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 450);
            this.Controls.Add(this.ShowOutput_button);
            this.Controls.Add(this.Launch);
            this.Controls.Add(this.OldBasePath_button);
            this.Controls.Add(this.OldBaseFilter_textBox);
            this.Controls.Add(this.OldBasePath_textBox);
            this.Controls.Add(this.OldBaseName_textBox);
            this.Controls.Add(this.OldBaseServer_textBox);
            this.Controls.Add(this.OldBaseFilter_label);
            this.Controls.Add(this.OldBasePath_label);
            this.Controls.Add(this.DatabaseName_label);
            this.Controls.Add(this.DatabaseServer_label);
            this.Controls.Add(this.OldBaseVersion_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Upgrade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upgrade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OldBaseVersion_label;
        private System.Windows.Forms.Label DatabaseServer_label;
        private System.Windows.Forms.Label DatabaseName_label;
        private System.Windows.Forms.Label OldBasePath_label;
        private System.Windows.Forms.Label OldBaseFilter_label;
        private System.Windows.Forms.TextBox OldBaseServer_textBox;
        private System.Windows.Forms.TextBox OldBaseName_textBox;
        private System.Windows.Forms.TextBox OldBasePath_textBox;
        private System.Windows.Forms.TextBox OldBaseFilter_textBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button OldBasePath_button;
        private System.Windows.Forms.Button ShowOutput_button;
        private System.Windows.Forms.Button Launch;
    }
}