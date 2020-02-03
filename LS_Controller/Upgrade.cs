using System;
using System.Text;
using System.Windows.Forms;

namespace LS_Controller
{
    public partial class Upgrade : Form
    {
        Functions functions = new Functions();
        private string OutputStr { get; set; }

        public Upgrade()
        {
            InitializeComponent();

            OldBaseFilter_textBox.Text = "Id=1..1999999999"; //poi va trasformato in "'Id=1..1999999999'"
        }

        private void OldBasePath_button_Click(object sender, EventArgs e)
        {
            OldBasePath_textBox.Text = functions.GetFolder(OldBasePath_textBox.Text);
        }

        private void ShowOutput_button_Click(object sender, EventArgs e)
        {
            functions.ShowOutput(OutputStr);
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            string script = "Export-NAVApplicationObject –DatabaseServer " + OldBaseServer_textBox.Text + "–DatabaseName " + OldBaseName_textBox.Text + " –Path " + OldBasePath_textBox.Text + " -Filter " + OldBaseFilter_textBox.Text;
            StringBuilder lsb = new StringBuilder();
            functions.RunPowerShellCommand(script, lsb);
        }


    }
}
