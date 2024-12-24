using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class ListBoxForm : Form
    {
        private ListBox listBox;
        private Button deleteButton;

        public KeyValuePair<int, string> SelectedCategory =>
            (KeyValuePair<int, string>)listBox.SelectedItem;

        public ListBoxForm(string prompt, Dictionary<int, string> foodCategory)
        {
            // Initialize the ListBox and Button
            listBox = new ListBox { Width = 200, Height = 100, SelectionMode = SelectionMode.One };
            deleteButton = new Button { Text = "Xoá", Width = 75 };

            // Populate the ListBox with the values of the dictionary
            foreach (var category in foodCategory)
            {
                listBox.Items.Add(category);
            }

            // Handle the OK button click event
            deleteButton.Click += (sender, e) =>
            {
                // Check if an item is selected
                if (listBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Prevent closing the dialog if no selection is made
                }
                DialogResult = DialogResult.OK;
            };

            // Layout controls
            var label = new Label { Text = prompt, Width = 200 };
            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill };
            layout.Controls.Add(label);
            layout.Controls.Add(listBox);
            layout.Controls.Add(deleteButton);

            // Add layout to form
            Controls.Add(layout);

            // Set window properties
            Width = 250;
            Height = 200;
            StartPosition = FormStartPosition.CenterParent;
        }
    }

    public static class ListBoxDialog
    {
        public static KeyValuePair<int, string> Show(string prompt, Dictionary<int, string> foodCategory)
        {
            using (var form = new ListBoxForm(prompt, foodCategory))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.SelectedCategory;
                }
                return default;
            }
        }
    }


}
