using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1//TO DO: Fix the layoout 
{
    public partial class UCTableDetails : UserControl
    {

        private ThucDon _thucDon;
        private DanhMucThucDon _danhMucThucDon = new DanhMucThucDon();
        
        private ListHoaDon _listHoaDon=new ListHoaDon();

        public event EventHandler goBack;
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

            // Create the ListBox for selected items
            System.Windows.Forms.ListBox billListBox = new System.Windows.Forms.ListBox
            {
                Width = 200,
                Height = 400,
                Top = 25,
                Left = this.ClientSize.Width - 220,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = SelectionMode.MultiExtended
            };

            // Set the DisplayMember to "TenMonAn" to display only the name of the food item
            billListBox.DisplayMember = "TenMonAn"; // This will make ListBox show only the name of the food item
            this.Controls.Add(billListBox);

            Button goBackButton = new Button
            {
                Text = "Back and save",
                Font = new Font("Arial", 6, FontStyle.Bold),
                Top = 430,
                Left = this.ClientSize.Width - 100,
            };
            this.Controls.Add(goBackButton);

            goBackButton.Click += (sender, e) =>
            {
               SaveBill(tableNumber, billListBox);
               goBack?.Invoke(this, EventArgs.Empty);



            };
            foreach (var hoaDon in _listHoaDon.DsHoaDon)//load ban chua tinh tien
            {
                if (hoaDon.TenBan == tableNumber && hoaDon.DaThanhToan == false)
                {
                    var dsMonAnThisTable = hoaDon.CacMonAn;
                    foreach(var item in dsMonAnThisTable)
                    {
                        billListBox.Items.Add(item);
                    }

                }
            }

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
                    // Clear any previous items in foodItemsPanel
                    foodItemsPanel.Controls.Clear();
                    string categoryName = category.Value;

                    // Filter the items based on the selected category
                    List<ThucDon> preLoad = new List<ThucDon>();
                    foreach (var i in _danhMucThucDon.DSThucDon)
                    {
                        if (i.LoaiMA_toString == category.Value)
                        {
                            preLoad.Add(i);
                        }
                    }

                    // If no items are found, show a message and return
                    if (!preLoad.Any())
                    {
                        MessageBox.Show("There are no items in this category.");
                        return;
                    }

                    // Iterate through the filtered items and create buttons for each
                    foreach (var item in preLoad)
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

                        var currentItem = item; // Capture the current item in a separate variable
                        itemButton.Click += (sender1, e1) => billListBox.Items.Add(currentItem); // Add item to bill list
                    }
                };
            }
        }

        private void SaveBill(int tableNumber, ListBox billListBox)
        {
            var selectedItems = billListBox.Items.OfType<ThucDon>().ToList();

            if (!selectedItems.Any())
            {
                MessageBox.Show("No items to save.");
                return;
            } 

            bool flag = false;

            foreach(var _hoaDon in _listHoaDon.DsHoaDon)
            {
                if (_hoaDon.TenBan == tableNumber && _hoaDon.DaThanhToan == false)
                {
                    _hoaDon.CacMonAn = selectedItems;
                    _hoaDon.ThoiGian = DateTime.Now;
                    _hoaDon.SoLuongMon = selectedItems.Count;
                    _hoaDon.TongTien = CalculateTotal(selectedItems);
                    MessageBox.Show("success edit");
                    flag = true;
                    break;
                }
                
            }
            if(flag == false)
            {
                HoaDon hoaDon = new HoaDon(
                    maHD: HoaDon.GenerateMA(),
                    tenBan: tableNumber,
                    tongTien: CalculateTotal(selectedItems),
                    soLuongMon: selectedItems.Count,
                    cacMonAn: selectedItems,
                    tkKhach: null,
                    thoiGian: DateTime.Now,
                    daThanhToan: false
            );
            
            _listHoaDon.Them(hoaDon);
                MessageBox.Show("success add list<ThucDon>");
            }

            // Save the updated list to file
            if (Luu("listHoaDon.dat"))
            {
                MessageBox.Show("Bill saved to file.");
            }
        }



        private bool Luu(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);

                // Ensure the list is initialized before saving
                if (_listHoaDon.DsHoaDon == null)
                {
                    _listHoaDon.DsHoaDon = new List<HoaDon>();
                }

                // Always write to the file, whether it exists or not
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, _listHoaDon.DsHoaDon);
                }

                MessageBox.Show($"File '{tenFile}' saved successfully at {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Type: {ex.GetType().Name}\nMessage: {ex.Message}\nStack Trace: {ex.StackTrace}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public float CalculateTotal(List<ThucDon> items)
        {
            float total = 0;
            foreach (var item in items)
            {
                total += item.GiaBan; 
            }
            return total;
        }

        // Update the method that loads HoaDon items into the ListBox
        public void LoadUnpaidHoaDonToListBox(List<HoaDon> hoaDonList, ListBox billListBox)
        {
            billListBox.Items.Clear(); // Clear the ListBox first

            foreach (var hoaDon in hoaDonList)
            {
                if (!hoaDon.DaThanhToan) // Only show unpaid HoaDon items
                {
                    // Format each item in cacMonAn (ThucDon list) to display
                    foreach (var monAn in hoaDon.CacMonAn)
                    {
                        string itemText = $"{monAn.TenMonAn} ";
                        billListBox.Items.Add(itemText);
                    }
                }
            }
        }



    }






}

