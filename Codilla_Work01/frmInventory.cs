using Codilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codilla_Work01
{
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        private void ShowPage(UserControl page)
        {
            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {

        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new ucProductListing());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult userResponse = MessageBox.Show("Are you sure you want to exit?", "Exit confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userResponse == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
