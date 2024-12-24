using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    [Serializable]


    public partial class frmThucDon : Form
    {
        private DanhMucThucDon dmthucdon = new DanhMucThucDon();
        private ThucDon _thucDon;
        private int selectedRowIndex = -1;

        private string dictionaryBinaryFile = "dictionary.dat";
        
        ThucDon produccurrent = new ThucDon();
        public frmThucDon()
        {
            InitializeComponent();
            dtgvFood.CellClick += dtgvFood_CellClick;
            _thucDon = new ThucDon();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }



        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFoodAdd_Click(object sender, EventArgs e)
        {
            string maMA = txtFoodMa.Text;
            string tenMA = txtFoodTen.Text;
            float giabanMA = float.Parse(txtFoodGiaBan.Text);

            // Ensure that the combo box has a valid selection
            if (cbo_category.SelectedIndex >= 0)
            {
                // Get the selected category key (int) directly
                int loaiMA = (int)cbo_category.SelectedValue;  // Get the selected key (int)

                // Create a new ThucDon object
                ThucDon td = new ThucDon(maMA, tenMA, giabanMA, loaiMA);

                // Add the item to the list
                if (dmthucdon.Them(td))
                {
                    MessageBox.Show("Đã thêm vào danh sách", "Thông Báo !!!", MessageBoxButtons.OK);
                    HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
                }
                else
                {
                    MessageBox.Show("Đã có rồi mời nhập khác", "Thông Báo !!!", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại hợp lệ", "Thông Báo", MessageBoxButtons.OK);
            }
        }


        private void HienThiDanhSachThucDon(List<ThucDon> TD, DataGridView dgv)
        {
            // Unbind the DataGridView to avoid conflicts
            dgv.DataSource = null;

            // Bind the new data
            dgv.DataSource = TD.ToList();

            // Ensure the "LoaiMA" column is hidden
            if (dgv.Columns.Contains("LoaiMonAn") )
            {
                dgv.Columns["LoaiMonAn"].Visible = false;
               
            }
            if(dgv.Columns.Contains("LoaiMA"))
            {
                dgv.Columns["LoaiMA"].Visible = false;
            }

            if (dgv.Columns.Contains("LoaiMA_toString"))
            {
                dgv.Columns["LoaiMA_toString"].HeaderText = "Loại Món Ăn ";
                dgv.Columns["LoaiMA_toString"].DisplayIndex = 1;
            }

            
        }








        private void btnFoodDelete_Click(object sender, EventArgs e)
        {
            DialogResult ketqua = MessageBox.Show("Bạn muốn xóa món ăn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.Yes)
            {
                if (dtgvFood.CurrentCell == null)
                {
                    MessageBox.Show("Vui lòng chọn món ăn để xóa !", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                int vitri = dtgvFood.CurrentCell.RowIndex;
                if (vitri < 0 || vitri >= dmthucdon.DSThucDon.Count)
                {
                    MessageBox.Show("Chỉ số không hợp lệ !", "Thông Báo", MessageBoxButtons.OKCancel);
                    return;
                }
                dmthucdon.Xoa(vitri);
                MessageBox.Show("Đã xóa món ăn này", "Thông Báo");
                HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            }
        }

        private void dtgvFood_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {
            dtgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvFood.AutoResizeColumns();
        }

        private void btnFoodEdit_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Please select an item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the food code (MaMonAn) and food name (TenMonAn)
            if (string.IsNullOrWhiteSpace(txtFoodMa.Text) || string.IsNullOrWhiteSpace(txtFoodTen.Text))
            {
                MessageBox.Show("Please enter both food code and name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a valid category is selected
            if (cbo_category.SelectedValue == null)
            {
                MessageBox.Show("Please select a food category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate GiaBan (price) input
            if (!float.TryParse(txtFoodGiaBan.Text, out float giaBan))
            {
                MessageBox.Show("Invalid price value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the updated ThucDon object
            ThucDon updatedThucDon = new ThucDon
            {
                MaMonAn = txtFoodMa.Text,
                TenMonAn = txtFoodTen.Text,
                LoaiMonAn = (int)cbo_category.SelectedValue,
                GiaBan = giaBan
            };

            // Update the item at the selected index in the list
            bool isUpdated = dmthucdon.Sua(updatedThucDon, selectedRowIndex);

            if (isUpdated)
            {
                // Refresh the DataGridView to reflect the changes
                HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
                MessageBox.Show("Food updated successfully!", "Notification", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Failed to update food. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row index is selected
            if (e.RowIndex != -1)
            {
                selectedRowIndex = e.RowIndex;  // Set the selected index to the clicked row index

                // Debugging output
                MessageBox.Show("Row Index: " + selectedRowIndex);

                // Populate text boxes and combo box with selected row's data
                DataGridViewRow row = dtgvFood.Rows[e.RowIndex];
                txtFoodMa.Text = row.Cells["MaMonAn"].Value.ToString();
                txtFoodTen.Text = row.Cells["TenMonAn"].Value.ToString();
                txtFoodGiaBan.Text = row.Cells["GiaBan"].Value.ToString();

                var categoryIndex = row.Cells["LoaiMonAn"].Value;
                if (categoryIndex != null)
                {
                    cbo_category.SelectedValue = categoryIndex;
                }
            }
        }


        private bool Luu(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath)) { } // Create an empty file
                    dmthucdon.DSThucDon = new List<ThucDon>(); // Initialize with an empty list
                    return true; // Return true to indicate the file was successfully created
                }
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dmthucdon.DSThucDon);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Type: {ex.GetType().Name}\nMessage: {ex.Message}\nStack Trace: {ex.StackTrace}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        private void btnFoodSave_Click(object sender, EventArgs e)
        {
            if (Luu("dmthucdon.DSThucDon.dat") == true)
            {
                MessageBox.Show("Đã Lưu!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Không Lưu Được !!!", "Thông Báo", MessageBoxButtons.OK);
        }
        public bool Doc(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    dmthucdon.DSThucDon = (List<ThucDon>)bf.Deserialize(fs);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Type: {ex.GetType().Name}\nMessage: {ex.Message}\nStack Trace: {ex.StackTrace}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void frmThucDon_Load(object sender, EventArgs e)
        {
            cbo_category.DataSource = new BindingSource(ThucDon.foodCategory, null);
            cbo_category.DisplayMember = "Value";
            cbo_category.ValueMember = "Key";

            dmthucdon = new DanhMucThucDon();
            if (Doc("dmThucDon.DSThucDon.dat") == true)
            {

                HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
                
            }
            else
                MessageBox.Show("Không Đọc Được dữ liệu !!!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btnFoodOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            string input = InputBox.Show("Enter new category:");

            // Check for empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Category cannot be empty");
                return;
            }

            // Check if category already exists
            if (ThucDon.foodCategory.ContainsValue(input))
            {
                MessageBox.Show("Already exist");
                return;
            }

            // Add new category to the dictionary
            ThucDon.foodCategoryAmount++;
            ThucDon.foodCategory.Add(ThucDon.foodCategoryAmount, input);
            

            

            // Save the updated dictionary to file
            ThucDon.SaveDictionary();

            // Reload the dictionary to make sure the new data is reflected
            ThucDon.LoadDictionary();

            // Update the ComboBox data source
            cbo_category.DataSource = new BindingSource(ThucDon.foodCategory, null);
            cbo_category.DisplayMember = "Value";
            cbo_category.ValueMember = "Key";
        }

        private void btn_del_category_Click(object sender, EventArgs e)
        {
            if (ThucDon.foodCategory.Count == 1)
            {
                MessageBox.Show("Can not delete the last item of the catgory", "Category cannot be empty", MessageBoxButtons.OK);
                return;
            }


            var selectedCategory = ListBoxDialog.Show("Choose category", ThucDon.foodCategory);

            if (!selectedCategory.Equals(default(KeyValuePair<int, string>)))
            {
                MessageBox.Show($"{selectedCategory.Value} has been deleted");
                ThucDon.foodCategory.Remove(selectedCategory.Key);
                

                ThucDon.SaveDictionary();
                ThucDon.LoadDictionary();
                cbo_category.DataSource = new BindingSource(ThucDon.foodCategory, null);
                cbo_category.DisplayMember = "Value";
                cbo_category.ValueMember = "Key";
                return;
            }
        }

        private void cbo_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
