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

            // Bill ListBox
            ListBox billListBox = new ListBox
            {
                Width = 200,
                Height = 400,
                Top = 25,
                Left = this.ClientSize.Width - 220,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = SelectionMode.MultiExtended
            };
            billListBox.Items.AddRange(new object[] { "1", "2", "3" });
            this.Controls.Add(billListBox);

            // Table Title
            Label tableTitle = new Label
            {
                Text = $"Table {tableNumber}",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };
            this.Controls.Add(tableTitle);

            // Assign incoming data
            _thucDon = thucDon ?? new ThucDon();
            _danhMucThucDon = dmThucDon ?? new DanhMucThucDon();

            // Category Panel
            FlowLayoutPanel categoryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Width = 150,
                WrapContents = false
            };
            this.Controls.Add(categoryPanel);

            // Food Items Panel
            FlowLayoutPanel foodItemsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true
            };
            this.Controls.Add(foodItemsPanel);

            // Generate Category Buttons
            foreach (var category in _thucDon.foodCategory)
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
                    }

                    if (!filteredItems.Any())
                    {
                        MessageBox.Show($"No items found for category: {category.Value}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                
            }
        }



    }
}
