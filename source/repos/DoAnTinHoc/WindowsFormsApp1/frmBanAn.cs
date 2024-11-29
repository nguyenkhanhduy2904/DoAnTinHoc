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

        public frmBanAn()//load firm bàn ăn
        {
            InitializeComponent();
            LoadTableAmount();
            InitializeTableList();
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

        public void InitializeTableList()//gọi giao diện 
        {
            // xoa flow layer panel cũ nếu đã tồn tại
            var existingPanel = this.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
            if (existingPanel != null)
            {
                this.Controls.Remove(existingPanel);
            }

            // tạo flow layer panel mới
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10, 50, 10, 10), // Padding for spacing
                WrapContents = true // Allow buttons to wrap naturally
            };

            // Add the FlowLayoutPanel to the control
            this.Controls.Add(flowLayoutPanel);

            // Dynamically create buttons for tables
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
                    //_mainForm.LoadControl(new TableDetailsControl(_mainForm, tableNumber));
                };

                flowLayoutPanel.Controls.Add(tableButton);
            }

            // Force layout recalculation
            flowLayoutPanel.PerformLayout();

            // Add a buffer to the scrollable area 
            flowLayoutPanel.AutoScrollMinSize = new Size(
                flowLayoutPanel.ClientSize.Width,
                flowLayoutPanel.DisplayRectangle.Height
            );

            // Ensure the last button is visible
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
