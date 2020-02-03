using System.Management.Automation;
using System.Text;
using System.Windows.Forms;

namespace LS_Controller
{
    class Functions
    {
        public string GetFolder(string pfolderName)
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

        public void RunPowerShellCommand(string pscript, StringBuilder psb)
        {
            //psb.AppendLine(pscript);//per test
            //return;//per test
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

            /* old
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
        }

        public void ShowOutput(string pOutputStr)
        {
            ShowOutput output = new ShowOutput(); //inizializzo output
            output.txtOutput.Clear();
            output.txtOutput.Text = pOutputStr;
            output.Show();
        }

    }
}
