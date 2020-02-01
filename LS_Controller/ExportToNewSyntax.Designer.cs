namespace LS_Controller
{
    partial class ExportToNewSyntax
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportToNewSyntax));
            this.Launch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nav_Service_Path_Label = new System.Windows.Forms.Label();
            this.Nav_Service_Path = new System.Windows.Forms.FolderBrowserDialog();
            this.NAV_Service_Path_Text = new System.Windows.Forms.TextBox();
            this.NAV_Service_Path_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SingleFile_button = new System.Windows.Forms.Button();
            this.SingleFile_Text = new System.Windows.Forms.TextBox();
            this.SingleFile_Label = new System.Windows.Forms.Label();
            this.BC_Server_Path_button = new System.Windows.Forms.Button();
            this.BC_Server_Path_text = new System.Windows.Forms.TextBox();
            this.BC_Server_Path_label = new System.Windows.Forms.Label();
            this.AL_Path_button = new System.Windows.Forms.Button();
            this.AL_Path_text = new System.Windows.Forms.TextBox();
            this.AL_Path_label = new System.Windows.Forms.Label();
            this.Splitted_button = new System.Windows.Forms.Button();
            this.Splitted_text = new System.Windows.Forms.TextBox();
            this.Splitted_label = new System.Windows.Forms.Label();
            this.DeleteAllTxtFiles = new System.Windows.Forms.CheckBox();
            this.LockedBy_text = new System.Windows.Forms.TextBox();
            this.LockedBy_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Date_label = new System.Windows.Forms.Label();
            this.VersionList_text = new System.Windows.Forms.TextBox();
            this.VersionList_label = new System.Windows.Forms.Label();
            this.NAV_ServerName_Text = new System.Windows.Forms.TextBox();
            this.NAV_DataBaseName_Text = new System.Windows.Forms.TextBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.Date_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Date_ApplyDate_check = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.ObjectType_label = new System.Windows.Forms.Label();
            this.ObjType_listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Launch
            // 
            this.Launch.BackColor = System.Drawing.SystemColors.Window;
            this.Launch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Launch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Launch.Location = new System.Drawing.Point(554, 549);
            this.Launch.Name = "Launch";
            this.Launch.Size = new System.Drawing.Size(158, 37);
            this.Launch.TabIndex = 0;
            this.Launch.Text = "Lancia";
            this.Launch.UseVisualStyleBackColor = false;
            this.Launch.Click += new System.EventHandler(this.Launch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "NAV";
            // 
            // Nav_Service_Path_Label
            // 
            this.Nav_Service_Path_Label.AutoSize = true;
            this.Nav_Service_Path_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_Service_Path_Label.Location = new System.Drawing.Point(17, 94);
            this.Nav_Service_Path_Label.Name = "Nav_Service_Path_Label";
            this.Nav_Service_Path_Label.Size = new System.Drawing.Size(88, 17);
            this.Nav_Service_Path_Label.TabIndex = 2;
            this.Nav_Service_Path_Label.Text = "Service Path";
            // 
            // Nav_Service_Path
            // 
            this.Nav_Service_Path.RootFolder = System.Environment.SpecialFolder.ProgramFilesX86;
            // 
            // NAV_Service_Path_Text
            // 
            this.NAV_Service_Path_Text.Location = new System.Drawing.Point(180, 93);
            this.NAV_Service_Path_Text.Name = "NAV_Service_Path_Text";
            this.NAV_Service_Path_Text.Size = new System.Drawing.Size(461, 20);
            this.NAV_Service_Path_Text.TabIndex = 3;
            // 
            // NAV_Service_Path_button
            // 
            this.NAV_Service_Path_button.Location = new System.Drawing.Point(649, 90);
            this.NAV_Service_Path_button.Name = "NAV_Service_Path_button";
            this.NAV_Service_Path_button.Size = new System.Drawing.Size(63, 21);
            this.NAV_Service_Path_button.TabIndex = 4;
            this.NAV_Service_Path_button.Text = "Scegli";
            this.NAV_Service_Path_button.UseVisualStyleBackColor = true;
            this.NAV_Service_Path_button.Click += new System.EventHandler(this.NAV_Server_Path_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "DataBase Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Business Central";
            // 
            // SingleFile_button
            // 
            this.SingleFile_button.Location = new System.Drawing.Point(649, 116);
            this.SingleFile_button.Name = "SingleFile_button";
            this.SingleFile_button.Size = new System.Drawing.Size(63, 21);
            this.SingleFile_button.TabIndex = 14;
            this.SingleFile_button.Text = "Scegli";
            this.SingleFile_button.UseVisualStyleBackColor = true;
            this.SingleFile_button.Click += new System.EventHandler(this.SingleFile_button_Click);
            // 
            // SingleFile_Text
            // 
            this.SingleFile_Text.Location = new System.Drawing.Point(180, 119);
            this.SingleFile_Text.Name = "SingleFile_Text";
            this.SingleFile_Text.Size = new System.Drawing.Size(461, 20);
            this.SingleFile_Text.TabIndex = 13;
            // 
            // SingleFile_Label
            // 
            this.SingleFile_Label.AutoSize = true;
            this.SingleFile_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleFile_Label.Location = new System.Drawing.Point(17, 120);
            this.SingleFile_Label.Name = "SingleFile_Label";
            this.SingleFile_Label.Size = new System.Drawing.Size(102, 17);
            this.SingleFile_Label.TabIndex = 12;
            this.SingleFile_Label.Text = "SingleFile Path";
            // 
            // BC_Server_Path_button
            // 
            this.BC_Server_Path_button.Location = new System.Drawing.Point(649, 439);
            this.BC_Server_Path_button.Name = "BC_Server_Path_button";
            this.BC_Server_Path_button.Size = new System.Drawing.Size(63, 21);
            this.BC_Server_Path_button.TabIndex = 17;
            this.BC_Server_Path_button.Text = "Scegli";
            this.BC_Server_Path_button.UseVisualStyleBackColor = true;
            this.BC_Server_Path_button.Click += new System.EventHandler(this.BC_Serve_Path_button_Click);
            // 
            // BC_Server_Path_text
            // 
            this.BC_Server_Path_text.Location = new System.Drawing.Point(180, 438);
            this.BC_Server_Path_text.Name = "BC_Server_Path_text";
            this.BC_Server_Path_text.Size = new System.Drawing.Size(461, 20);
            this.BC_Server_Path_text.TabIndex = 16;
            // 
            // BC_Server_Path_label
            // 
            this.BC_Server_Path_label.AutoSize = true;
            this.BC_Server_Path_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BC_Server_Path_label.Location = new System.Drawing.Point(17, 439);
            this.BC_Server_Path_label.Name = "BC_Server_Path_label";
            this.BC_Server_Path_label.Size = new System.Drawing.Size(79, 17);
            this.BC_Server_Path_label.TabIndex = 15;
            this.BC_Server_Path_label.Text = "Txt2al Path";
            // 
            // AL_Path_button
            // 
            this.AL_Path_button.Location = new System.Drawing.Point(649, 466);
            this.AL_Path_button.Name = "AL_Path_button";
            this.AL_Path_button.Size = new System.Drawing.Size(63, 21);
            this.AL_Path_button.TabIndex = 20;
            this.AL_Path_button.Text = "Scegli";
            this.AL_Path_button.UseVisualStyleBackColor = true;
            this.AL_Path_button.Click += new System.EventHandler(this.AL_Path_button_Click);
            // 
            // AL_Path_text
            // 
            this.AL_Path_text.Location = new System.Drawing.Point(180, 465);
            this.AL_Path_text.Name = "AL_Path_text";
            this.AL_Path_text.Size = new System.Drawing.Size(461, 20);
            this.AL_Path_text.TabIndex = 19;
            // 
            // AL_Path_label
            // 
            this.AL_Path_label.AutoSize = true;
            this.AL_Path_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AL_Path_label.Location = new System.Drawing.Point(17, 466);
            this.AL_Path_label.Name = "AL_Path_label";
            this.AL_Path_label.Size = new System.Drawing.Size(58, 17);
            this.AL_Path_label.TabIndex = 18;
            this.AL_Path_label.Text = "AL Path";
            // 
            // Splitted_button
            // 
            this.Splitted_button.Location = new System.Drawing.Point(649, 143);
            this.Splitted_button.Name = "Splitted_button";
            this.Splitted_button.Size = new System.Drawing.Size(63, 21);
            this.Splitted_button.TabIndex = 23;
            this.Splitted_button.Text = "Scegli";
            this.Splitted_button.UseVisualStyleBackColor = true;
            this.Splitted_button.Click += new System.EventHandler(this.Splitted_button_Click);
            // 
            // Splitted_text
            // 
            this.Splitted_text.Location = new System.Drawing.Point(180, 146);
            this.Splitted_text.Name = "Splitted_text";
            this.Splitted_text.Size = new System.Drawing.Size(461, 20);
            this.Splitted_text.TabIndex = 22;
            // 
            // Splitted_label
            // 
            this.Splitted_label.AutoSize = true;
            this.Splitted_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Splitted_label.Location = new System.Drawing.Point(17, 147);
            this.Splitted_label.Name = "Splitted_label";
            this.Splitted_label.Size = new System.Drawing.Size(88, 17);
            this.Splitted_label.TabIndex = 21;
            this.Splitted_label.Text = "Splitted Path";
            // 
            // DeleteAllTxtFiles
            // 
            this.DeleteAllTxtFiles.AutoSize = true;
            this.DeleteAllTxtFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAllTxtFiles.Location = new System.Drawing.Point(20, 534);
            this.DeleteAllTxtFiles.Name = "DeleteAllTxtFiles";
            this.DeleteAllTxtFiles.Size = new System.Drawing.Size(163, 21);
            this.DeleteAllTxtFiles.TabIndex = 24;
            this.DeleteAllTxtFiles.Text = "Delete All Txt Files";
            this.DeleteAllTxtFiles.UseVisualStyleBackColor = true;
            // 
            // LockedBy_text
            // 
            this.LockedBy_text.Location = new System.Drawing.Point(180, 226);
            this.LockedBy_text.Name = "LockedBy_text";
            this.LockedBy_text.Size = new System.Drawing.Size(461, 20);
            this.LockedBy_text.TabIndex = 26;
            // 
            // LockedBy_label
            // 
            this.LockedBy_label.AutoSize = true;
            this.LockedBy_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockedBy_label.Location = new System.Drawing.Point(17, 227);
            this.LockedBy_label.Name = "LockedBy_label";
            this.LockedBy_label.Size = new System.Drawing.Size(74, 17);
            this.LockedBy_label.TabIndex = 25;
            this.LockedBy_label.Text = "Locked By";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 24);
            this.label5.TabIndex = 27;
            this.label5.Text = "Filters";
            // 
            // Date_label
            // 
            this.Date_label.AutoSize = true;
            this.Date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_label.Location = new System.Drawing.Point(17, 204);
            this.Date_label.Name = "Date_label";
            this.Date_label.Size = new System.Drawing.Size(38, 17);
            this.Date_label.TabIndex = 28;
            this.Date_label.Text = "Data";
            // 
            // VersionList_text
            // 
            this.VersionList_text.Location = new System.Drawing.Point(180, 252);
            this.VersionList_text.Name = "VersionList_text";
            this.VersionList_text.Size = new System.Drawing.Size(461, 20);
            this.VersionList_text.TabIndex = 31;
            // 
            // VersionList_label
            // 
            this.VersionList_label.AutoSize = true;
            this.VersionList_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionList_label.Location = new System.Drawing.Point(17, 253);
            this.VersionList_label.Name = "VersionList_label";
            this.VersionList_label.Size = new System.Drawing.Size(82, 17);
            this.VersionList_label.TabIndex = 30;
            this.VersionList_label.Text = "Version List";
            // 
            // NAV_ServerName_Text
            // 
            this.NAV_ServerName_Text.Location = new System.Drawing.Point(180, 42);
            this.NAV_ServerName_Text.Name = "NAV_ServerName_Text";
            this.NAV_ServerName_Text.Size = new System.Drawing.Size(461, 20);
            this.NAV_ServerName_Text.TabIndex = 6;
            // 
            // NAV_DataBaseName_Text
            // 
            this.NAV_DataBaseName_Text.Location = new System.Drawing.Point(180, 67);
            this.NAV_DataBaseName_Text.Name = "NAV_DataBaseName_Text";
            this.NAV_DataBaseName_Text.Size = new System.Drawing.Size(461, 20);
            this.NAV_DataBaseName_Text.TabIndex = 9;
            // 
            // checkedListBox
            // 
            this.checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Converti in AL",
            "Dividi per tipo",
            "ExportToNewSyntax"});
            this.checkedListBox.Location = new System.Drawing.Point(274, 517);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(201, 54);
            this.checkedListBox.Sorted = true;
            this.checkedListBox.TabIndex = 32;
            // 
            // Date_dateTimePicker
            // 
            this.Date_dateTimePicker.Location = new System.Drawing.Point(180, 200);
            this.Date_dateTimePicker.Name = "Date_dateTimePicker";
            this.Date_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.Date_dateTimePicker.TabIndex = 33;
            this.Date_dateTimePicker.ValueChanged += new System.EventHandler(this.Date_dateTimePicker_ValueChanged);
            // 
            // Date_ApplyDate_check
            // 
            this.Date_ApplyDate_check.AutoSize = true;
            this.Date_ApplyDate_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_ApplyDate_check.Location = new System.Drawing.Point(547, 200);
            this.Date_ApplyDate_check.Name = "Date_ApplyDate_check";
            this.Date_ApplyDate_check.Size = new System.Drawing.Size(94, 20);
            this.Date_ApplyDate_check.TabIndex = 34;
            this.Date_ApplyDate_check.Text = "Apply Date";
            this.Date_ApplyDate_check.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtOutput.CausesValidation = false;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(733, 15);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(900, 571);
            this.txtOutput.TabIndex = 35;
            // 
            // ObjectType_label
            // 
            this.ObjectType_label.AutoSize = true;
            this.ObjectType_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectType_label.Location = new System.Drawing.Point(17, 278);
            this.ObjectType_label.Name = "ObjectType_label";
            this.ObjectType_label.Size = new System.Drawing.Size(85, 17);
            this.ObjectType_label.TabIndex = 36;
            this.ObjectType_label.Text = "Object Type";
            // 
            // ObjType_listBox
            // 
            this.ObjType_listBox.FormattingEnabled = true;
            this.ObjType_listBox.Items.AddRange(new object[] {
            "Codeunit",
            "MenuSuite",
            "Page",
            "Query",
            "Report",
            "Table",
            "XMLport"});
            this.ObjType_listBox.Location = new System.Drawing.Point(180, 278);
            this.ObjType_listBox.Name = "ObjType_listBox";
            this.ObjType_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ObjType_listBox.Size = new System.Drawing.Size(168, 108);
            this.ObjType_listBox.TabIndex = 37;
            // 
            // ExportToNewSyntax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1638, 598);
            this.Controls.Add(this.ObjType_listBox);
            this.Controls.Add(this.ObjectType_label);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.Date_ApplyDate_check);
            this.Controls.Add(this.Date_dateTimePicker);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.VersionList_text);
            this.Controls.Add(this.VersionList_label);
            this.Controls.Add(this.Date_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LockedBy_text);
            this.Controls.Add(this.LockedBy_label);
            this.Controls.Add(this.DeleteAllTxtFiles);
            this.Controls.Add(this.Splitted_button);
            this.Controls.Add(this.Splitted_text);
            this.Controls.Add(this.Splitted_label);
            this.Controls.Add(this.AL_Path_button);
            this.Controls.Add(this.AL_Path_text);
            this.Controls.Add(this.AL_Path_label);
            this.Controls.Add(this.BC_Server_Path_button);
            this.Controls.Add(this.BC_Server_Path_text);
            this.Controls.Add(this.BC_Server_Path_label);
            this.Controls.Add(this.SingleFile_button);
            this.Controls.Add(this.SingleFile_Text);
            this.Controls.Add(this.SingleFile_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NAV_DataBaseName_Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NAV_ServerName_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NAV_Service_Path_button);
            this.Controls.Add(this.NAV_Service_Path_Text);
            this.Controls.Add(this.Nav_Service_Path_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Launch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportToNewSyntax";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LS Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Launch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Nav_Service_Path_Label;
        private System.Windows.Forms.FolderBrowserDialog Nav_Service_Path;
        private System.Windows.Forms.TextBox NAV_Service_Path_Text;
        private System.Windows.Forms.Button NAV_Service_Path_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SingleFile_button;
        private System.Windows.Forms.TextBox SingleFile_Text;
        private System.Windows.Forms.Label SingleFile_Label;
        private System.Windows.Forms.Button BC_Server_Path_button;
        private System.Windows.Forms.TextBox BC_Server_Path_text;
        private System.Windows.Forms.Label BC_Server_Path_label;
        private System.Windows.Forms.Button AL_Path_button;
        private System.Windows.Forms.TextBox AL_Path_text;
        private System.Windows.Forms.Label AL_Path_label;
        private System.Windows.Forms.Button Splitted_button;
        private System.Windows.Forms.TextBox Splitted_text;
        private System.Windows.Forms.Label Splitted_label;
        private System.Windows.Forms.CheckBox DeleteAllTxtFiles;
        private System.Windows.Forms.TextBox LockedBy_text;
        private System.Windows.Forms.Label LockedBy_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Date_label;
        private System.Windows.Forms.TextBox VersionList_text;
        private System.Windows.Forms.Label VersionList_label;
        private System.Windows.Forms.TextBox NAV_ServerName_Text;
        private System.Windows.Forms.TextBox NAV_DataBaseName_Text;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.DateTimePicker Date_dateTimePicker;
        private System.Windows.Forms.CheckBox Date_ApplyDate_check;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label ObjectType_label;
        private System.Windows.Forms.ListBox ObjType_listBox;
    }
}

