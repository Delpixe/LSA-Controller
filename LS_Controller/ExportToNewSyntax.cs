using System;
using System.Windows.Forms;
using System.Text;

namespace LS_Controller
{

    public partial class ExportToNewSyntax : Form
    {
        Functions functions = new Functions();//prendo la classe functions
        private string OutputStr { get; set; }

        public ExportToNewSyntax()
        {
            InitializeComponent();

            //setta tutti i checkbox della lista a true
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            OutputStr = RunScript(this);
            this.ShowOutput_button.Enabled = true;
        }

        // Bring up a dialog to chose a folder path in which to open or save a file.
        private void NAV_Server_Path_button_Click(object sender, System.EventArgs e)
        {
            NAV_Service_Path_Text.Text = functions.GetFolder(NAV_Service_Path_Text.Text);
        }

        private void BC_Serve_Path_button_Click(object sender, EventArgs e)
        {
            BC_Server_Path_text.Text = functions.GetFolder(BC_Server_Path_text.Text);
        }

        private void AL_Path_button_Click(object sender, EventArgs e)
        {
            AL_Path_text.Text = functions.GetFolder(AL_Path_text.Text);
        }

        private void SingleFile_button_Click(object sender, EventArgs e)
        {
            SingleFile_Text.Text = functions.GetFolder(SingleFile_Text.Text);
        }

        private void Splitted_button_Click(object sender, EventArgs e)
        {
            Splitted_text.Text = functions.GetFolder(Splitted_text.Text);
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
                            functions.RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                        case "Converti in AL":
                            lLaunchType = " -LaunchType TxtToAL ";
                            functions.RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                        case "Dividi per tipo":
                            lLaunchType = " -LaunchType Split ";
                            functions.RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
                            break;
                    }
                }
            }
            else
            {
                lLaunchType = " -LaunchType All ";
                functions.RunPowerShellCommand(lscript + lLaunchType, lsb);//lancio powershell
            }
            return lsb.ToString();
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
            functions.ShowOutput(OutputStr);
        }
    }
}
