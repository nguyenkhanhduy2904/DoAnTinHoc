using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1//TO DO: Fix the layoout 
{
    public partial class UCTableDetails : UserControl
    {

        private ThucDon _thucDon;
        private DanhMucThucDon _danhMucThucDon;
        public UCTableDetails()
        {
            InitializeComponent();
        }





        public void InitializeTableDetails(int tableNumber, ThucDon thucDon, DanhMucThucDon dmThucDon)
        {
            this.Controls.Clear();

            // Assign incoming data
            _thucDon = thucDon ?? new ThucDon();
            _danhMucThucDon = dmThucDon ?? new DanhMucThucDon();
            System.Windows.Forms.ListBox billListBox = new System.Windows.Forms.ListBox
            {
                Width = 200,
                Height = 400,
                Top = 25,
                Left = this.ClientSize.Width - 220,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = SelectionMode.MultiExtended
            };

            this.Controls.Add(billListBox);

            // Main TableLayoutPanel for organizing controls
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // For the table title
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // For category and food panels
            this.Controls.Add(mainLayout);

            // Table Title
            Label tableTitle = new Label
            {
                Text = $"Table {tableNumber}",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };
            mainLayout.Controls.Add(tableTitle, 0, 0);
            mainLayout.SetColumnSpan(tableTitle, 2); // Span across both columns

            // Category Panel
            FlowLayoutPanel categoryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false
            };
            mainLayout.Controls.Add(categoryPanel, 0, 1);

            // Food Items Panel
            FlowLayoutPanel foodItemsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown
            };
            mainLayout.Controls.Add(foodItemsPanel, 1, 1);

            // Generate Category Buttons
            foreach (var category in ThucDon.foodCategory)
            {
                Button categoryButton = new Button
                {
                    Text = category.Value,
                    AutoSize = true,
                    Margin = new Padding(10),
                    Width = 100
                };
                categoryPanel.Controls.Add(categoryButton);

                categoryButton.Click += (sender, e) =>
                {
                    foodItemsPanel.Controls.Clear();
                    var filteredItems = _danhMucThucDon.DSThucDon.Where(item => item.LoaiMonAn == category.Key).ToList();

                    foreach (var item in filteredItems)
                    {
                        Button itemButton = new Button
                        {
                            Text = item.TenMonAn,
                            AutoSize = true,
                            Margin = new Padding(10),
                            Width = 150,
                            Height = 100
                        };
                        foodItemsPanel.Controls.Add(itemButton);
                        var currentItem = item;
                        itemButton.Click += (sender1, e1) => billListBox.Items.Add(item.TenMonAn);

                    }

                    if (!filteredItems.Any())
                    {
                        MessageBox.Show($"No items found for category: {category.Value}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
            }

            // Optional: Bill ListBox
            
        }




    }
}
