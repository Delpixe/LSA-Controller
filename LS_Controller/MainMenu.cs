using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ExportToNewSyntax ExportToNewSyntax = new ExportToNewSyntax();
            // Show the ExportToNewSyntax form
            ExportToNewSyntax.Show();
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
