using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace WindowsFormsApp1
{
    public class InputBoxForm : Form
    {
        private TextBox textBox;
        private Button okButton;

        public string InputText => textBox.Text;

        public InputBoxForm(string prompt)
        {
            textBox = new TextBox { Width = 200 };
            okButton = new Button { Text = "OK", Width = 75 };

            okButton.Click += (sender, e) => DialogResult = DialogResult.OK;

            var label = new Label { Text = prompt, Width = 200 };
            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill };
            layout.Controls.Add(label);
            layout.Controls.Add(textBox);
            layout.Controls.Add(okButton);

            Controls.Add(layout);
            Width = 250;
            Height = 150;
            StartPosition = FormStartPosition.CenterParent;
        }
    }

    public static class InputBox
    {
        public static string Show(string prompt)
        {
            using (var form = new InputBoxForm(prompt))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.InputText;
                }
                return null;
            }
        }
    }
}
