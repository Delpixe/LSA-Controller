using System;
using System.Windows.Forms;

namespace LS_Controller
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NewSyntax_Click(object sender, EventArgs e)
        {
            // Create a new instance of the ExportToNewSyntax class
            ExportToNewSyntax exportToNewSyntax = new ExportToNewSyntax();
            // Show the ExportToNewSyntax form
            exportToNewSyntax.Show();
            //exportToNewSyntax.Dispose();
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            // Create a new instance of the ExportToNewSyntax class
            Upgrade upgrade = new Upgrade();
            // Show the ExportToNewSyntax form
            upgrade.Show();
            //upgrade.Dispose();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
