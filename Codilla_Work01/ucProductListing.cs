using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codilla
{
    public partial class ucProductListing : UserControl
    {
        public ucProductListing()
        {
            InitializeComponent();
        }

        // Each row in the grid is one ShoppingItem
        private class ShoppingItem
        {
            public string Description { get; set; }
            public double Amount { get; set; }
            public string Unit { get; set; }
        }

        string[] units = { "Piece", "Box", "Kilograms", "Liter" };

        // BindingList updates the grid automatically when items are added/removed
        BindingList<ShoppingItem> shoppingList = new BindingList<ShoppingItem>();

        private void ucProductListing_Load(object sender, EventArgs e)
        {
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;

            dgvItems.DataSource = shoppingList;

            // Grid setup
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.ReadOnly = true;
            dgvItems.MultiSelect = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.RowHeadersVisible = false;
        }

        // Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                string item = txtDescription.Text.Trim();
                string unit = cmbUnit.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(item) || string.IsNullOrEmpty(unit) ||
                    !double.TryParse(txtAmount.Text, out double amount))
                {
                    MessageBox.Show("Please enter a description and a valid amount.");
                    return;
                }

                shoppingList.Add(new ShoppingItem
                {
                    Description = item,
                    Amount = amount,
                    Unit = unit
                });

                MessageBox.Show("Item Added.");
                txtAmount.Clear();
                txtDescription.Clear();
                cmbUnit.SelectedIndex = 0;
                txtDescription.Focus();
            }
        }

        // Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null || dgvItems.SelectedRows.Count == 0)
            {
                lblPrompt.Text = "Please select an item to delete.";
                lblPrompt.Visible = true;
                return;
            }

            int index = dgvItems.SelectedRows[0].Index;

            DialogResult result = MessageBox.Show("Are you sure you want to delete?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string description = shoppingList[index].Description;
                shoppingList.RemoveAt(index);
                MessageBox.Show(description + " deleted.");
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            lblPrompt.Text = "";
            lblPrompt.Visible = false;
        }
    }
}
