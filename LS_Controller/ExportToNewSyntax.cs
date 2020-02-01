using System;
using System.Windows.Forms;
using System.Management.Automation;
using System.Text;

namespace LS_Controller
{
    public partial class ExportToNewSyntax : Form
    {
        public ShowOutput Output { get; set; }

        public ExportToNewSyntax()
        {
            InitializeComponent();

            //setta tutti i checkbox della lista a true
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }

            Output = new ShowOutput(); //inizializzo output
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            Output.txtOutput.Clear();
            Output.txtOutput.Text = RunScript(this);
            this.ShowOutput_button.Enabled = true;
        }

        // Bring up a dialog to chose a folder path in which to open or save a file.
        private void NAV_Server_Path_button_Click(object sender, System.EventArgs e)
        {
            NAV_Service_Path_Text.Text = GetFolder(NAV_Service_Path_Text.Text);
        }

        private void BC_Serve_Path_button_Click(object sender, EventArgs e)
        {
            BC_Server_Path_text.Text = GetFolder(BC_Server_Path_text.Text);
        }

        private void AL_Path_button_Click(object sender, EventArgs e)
        {
            AL_Path_text.Text = GetFolder(AL_Path_text.Text);
        }

        private void SingleFile_button_Click(object sender, EventArgs e)
        {
            SingleFile_Text.Text = GetFolder(SingleFile_Text.Text);
        }

        private void Splitted_button_Click(object sender, EventArgs e)
        {
            Splitted_text.Text = GetFolder(Splitted_text.Text);
        }

        private string GetFolder(string pfolderName)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            
            //se aveva già qualcosa di scritto, riprendo da dove ero
            if (pfolderName != "")
            {
                folderBrowserDialog1.SelectedPath = pfolderName;
            }

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pfolderName = folderBrowserDialog1.SelectedPath;
            }
            return (pfolderName);
        }

        private void Date_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Date_ApplyDate_check.Checked = true;
        }

        private string RunScript(ExportToNewSyntax sender)
        {
                
            string lscript = "& '" + Environment.CurrentDirectory + @"\Scripts\LaunchAll_Scripts.ps1' ",
                    lLaunchType = "",
                    lobjectTypeList = "",
                    lfilter = "";
            
            StringBuilder lsb = new StringBuilder();
            lscript += GetScriptToRun(sender);
            
            foreach (var ObjType in sender.ObjType_listBox.SelectedItems)
            {
                lobjectTypeList = " -objectTypeList {";
                if (!string.IsNullOrEmpty(lfilter))
                {
                    lfilter += ",";
                }
                lfilter += sender.ObjType_listBox.GetItemText(ObjType);
            }
            if (! string.IsNullOrEmpty(lobjectTypeList))
            {
                lobjectTypeList = " -objectTypeList {" + lfilter + "}";
            }

            lscript += lobjectTypeList;

            if (sender.checkedListBox.CheckedItems.Count != sender.checkedListBox.Items.Count) //prendo cosa devo lanciare (exporttonewsyntax etc)
            {
                foreach (var ObjCheckedListBox in sender.checkedListBox.CheckedItems)
                {
                    //da rivedere
                    switch (ObjCheckedListBox.ToString())
                    {
                        case "ExportToNewSyntax":
                            lLaunchType = " -LaunchType ExportToNewSyntax ";
                            RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                        case "Converti in AL":
                            lLaunchType = " -LaunchType TxtToAL ";
                            RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                        case "Dividi per tipo":
                            lLaunchType = " -LaunchType Split ";
                            RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                    }
                }
            }
            else
            {
                lLaunchType = " -LaunchType All ";
                RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
            }
            return lsb.ToString();
        }

        private void RunPowerShellCommand(string pscript, StringBuilder psb)
        {
            //psb.AppendLine(pscript);//per test
            //return;//per test
            /*
             * try { 
                if (pscript != null)
                {
                    Runspace runspace = RunspaceFactory.CreateRunspace();
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript(pscript);
                    pipeline.Commands.Add("Out-String");
                    Collection<PSObject> results = pipeline.Invoke();
                    runspace.Close();
                    foreach (PSObject pSObject in results)
                    {
                        psb.AppendLine(pSObject.ToString());
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                psb.AppendLine(pscript);
            }
            */
            PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(pscript);
            powerShell.AddCommand("Out-String");
            var results = powerShell.Invoke();

            foreach (var result in results)
            {
                psb.AppendLine(result.ToString());
            }

            if (powerShell.Streams.Error.Count > 0)
            {
                psb.AppendLine(powerShell.Streams.Error.Count + " errors");
            }
        }

        private string GetScriptToRun(ExportToNewSyntax sender)
        {
            string  lfilter = GetFiltersToApply(sender); //prendo i filtri
            return lfilter;
        }

        /*
        .\\LaunchAll.ps1 
         -Date  08/01/20  
         -LockedBy "logsys\n"
         -NAV_serverName  "SRVDB01"  
         -NAV_DataBaseName  "MARK"  
         -NAV_service_path  "C:\\Program Files (x86)\\Microsoft Dynamics NAV\\110 CU09\\RoleTailored Client"
         -SourcePath  "C:\\Users\\m.delpapa\\Desktop\\MARK\\2020 01 08\\ALL_txt"
         -DestinationPath  "C:\\Users\\m.delpapa\\Desktop\\MARK\\2020 01 08\\SPLITTED_txt"
         ;
        */
        private string GetFiltersToApply(ExportToNewSyntax sender)
        {
            string lfilterToApply = "";

            lfilterToApply += " -NAV_serverName '" + sender.NAV_ServerName_Text.Text + "'";
            lfilterToApply += " -NAV_DataBaseName '" + sender.NAV_DataBaseName_Text.Text + "'";
            lfilterToApply += " -NAV_service_path '" + sender.NAV_Service_Path_Text.Text + "'";
            lfilterToApply += " -SourcePath '" + sender.SingleFile_Text.Text + "'";
            lfilterToApply += " -DestinationPath '" + sender.Splitted_text.Text + "'";
            lfilterToApply += " -BC_server_path '" + sender.BC_Server_Path_text.Text + "'";
            lfilterToApply += " -AL_path '" + sender.AL_Path_text.Text + "'";

            if (sender.Date_ApplyDate_check.Checked)
                lfilterToApply += " -Date '" + sender.Date_dateTimePicker.Value.Date.ToString("dd/MM/yy") + "'";

            if (sender.LockedBy_text.TextLength > 0)
                lfilterToApply += " -LockedBy '" + sender.LockedBy_text.Text + "'";

            if (sender.VersionList_text.TextLength > 0)
                lfilterToApply += " -VersionList '" + sender.VersionList_text.Text + "'";

            if (sender.DeleteAllTxtFiles.Checked)
                lfilterToApply += " -DeleteAllTxt " + 1;

            if (sender.Extension_start_id_textBox.Text != "")
                lfilterToApply += " -extensionStartId " + sender.Extension_start_id_textBox.Text;

            lfilterToApply += " -OtherScriptsPath '" + Environment.CurrentDirectory + "\\Scripts'";

            return lfilterToApply;
        }

        private void ShowOutput_button_Click(object sender, EventArgs e)
        {
            Output.Show();
        }

    }
}
