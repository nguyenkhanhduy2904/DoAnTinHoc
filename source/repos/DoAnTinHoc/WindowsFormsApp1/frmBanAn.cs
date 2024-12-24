using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmBanAn : Form
    {
        private int tableAmount = 10; // Default value
        private const string binaryFile = "tableData.bin";
        
        private ThucDon _thucDon;
        private DanhMucThucDon _danhMucThucDon;
        private Panel _panel;

        public frmBanAn()//load firm bàn ăn
        {
            InitializeComponent();
            LoadTableAmount();
            createMainPanel();
            ShowMainLayout();
        }
         public void createMainPanel()
        {
            _panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),

            };
            this.Controls.Add(_panel);
        }
        
        //load tableAmount từ file binary nếu đã có file
        private void LoadTableAmount()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, binaryFile); //lấy file path
            if (File.Exists(filePath))
            {
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        tableAmount = reader.ReadInt32(); // đọc file
                        MessageBox.Show("read file successfully");//for debug, will delete later
                    }
                }
                catch
                {
                    tableAmount = 10; // gắn =10 nếu đọc lỗi
                }
            }
            else
            {
                tableAmount = 10; // set giá trị bằng 10 nếu ko đọc đc file(file ko tồn tại)
            }
        }

        // lưu tableAmount vào file binary
        private void SaveTableAmount()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, binaryFile); // lấy file path
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    writer.Write(tableAmount);// viết tableAmount vào file
                    MessageBox.Show("saved");//debug, will delete later:))
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving table amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTable(int newTableAmount)//cập nhật tableAmount
        {
            tableAmount = newTableAmount;
            InitializeTableList();
        }

        public void UC_goBack(object sender, EventArgs e)
        {
            
            InitializeComponent();
            ShowMainLayout();
        }

        public void ShowMainLayout()
        {
            _panel.Controls.Clear(); // Clear current controls from the panel
            InitializeTableList();   // Populate the panel with table buttons
        }

        public void InitializeTableList()
        {
            // Check if the FlowLayoutPanel exists, if yes, remove it.
            var existingPanel = _panel.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
            if (existingPanel != null)
            {
                _panel.Controls.Remove(existingPanel);  // Removing the previous FlowLayoutPanel
            }

            // Create a new FlowLayoutPanel to display buttons for tables
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10, 50, 10, 10), // Padding for spacing
                WrapContents = true // Allow buttons to wrap naturally
            };

            // Clear the current contents of _panel before adding the new flowLayoutPanel
            _panel.Controls.Clear();
            _panel.Controls.Add(flowLayoutPanel);  // Add the new flowLayoutPanel to the panel

            // Dynamically create buttons for each table
            for (int i = 1; i <= tableAmount; i++)
            {
                int tableNumber = i; // Capture the current table number
                Button tableButton = new Button
                {
                    Text = $"Table {i}",
                    Width = 100,
                    Height = 50,
                    Margin = new Padding(10)
                };

                // Add click event to load table details
                tableButton.Click += (s, e) =>
                {
                    _panel.Controls.Clear();  // Clear the current content (table buttons)

                    // Create a new TableDetailsControl
                    var tableDetailControl = new UCTableDetails();
                    tableDetailControl.goBack += UC_goBack;
                    tableDetailControl.InitializeTableDetails(tableNumber, _thucDon, _danhMucThucDon);

                    // Add the TableDetailsControl to the FlowLayoutPanel
                   _panel.Controls.Add(tableDetailControl);
                    tableDetailControl.Dock = DockStyle.Fill;

                    // Perform layout to ensure TableDetailsControl is correctly sized and laid out
                    _panel.PerformLayout();
                };

                flowLayoutPanel.Controls.Add(tableButton);  // Add table button to the flowLayoutPanel
            }

            // Force layout recalculation (for FlowLayoutPanel)
            flowLayoutPanel.PerformLayout();

            // Optional: Adjust the AutoScrollMinSize for the FlowLayoutPanel
            flowLayoutPanel.AutoScrollMinSize = new Size(
                flowLayoutPanel.ClientSize.Width,
                flowLayoutPanel.DisplayRectangle.Height
            );

            // Ensure the last button is visible by scrolling into view
            flowLayoutPanel.ScrollControlIntoView(flowLayoutPanel.Controls[flowLayoutPanel.Controls.Count - 1]);
        }


        private void btn_editTableLayout_Click(object sender, EventArgs e)
        {
            string result = InputBox.Show("Enter Value:");

            if (int.TryParse(result, out int newTableAmount))
            {
                if (newTableAmount <= 0)
                {
                    MessageBox.Show("Number of table must be an unsigned integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                tableAmount = newTableAmount;
                SaveTableAmount(); // Save the new table amount to the binary file
                MessageBox.Show($"Table Amount is now {tableAmount} ", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InitializeTableList();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Override the form's FormClosing event to save data before closing
        private void frmBanAn_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTableAmount(); // Ensure the tableAmount is saved when the form is closed
        }

        // Add the event handler for FormClosing
        private void frmBanAn_Load(object sender, EventArgs e)
        {
            this.FormClosing += frmBanAn_FormClosing;
        }
    }

}
