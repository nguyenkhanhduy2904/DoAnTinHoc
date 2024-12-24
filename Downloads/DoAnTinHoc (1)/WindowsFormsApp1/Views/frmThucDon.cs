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
        

        private string dictionaryBinaryFile = "dictionary.dat";
        
        ThucDon produccurrent = new ThucDon();
        public frmThucDon()
        {
            InitializeComponent();
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
            //produccurrent.MaMonAn = txtFoodMa.Text;
            //produccurrent.TenMonAn = txtFoodTen.Text;
            //if (cbo_category.SelectedValue != null)
            //{
            //    int selectKey = (int)cbo_category.SelectedValue;
            //    produccurrent.LoaiMonAn = selectKey;
            //}
            //else
            //{
            //    MessageBox.Show("Hay chon loai mon an!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //produccurrent.GiaBan = float.Parse(txtFoodGiaBan.Text.ToString());
            //HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            //MessageBox.Show("Đã Cập Nhật", "Thông báo", MessageBoxButtons.OK);

            // Kiểm tra mã món ăn hợp lệ
         
        
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtFoodMa.Text))
            {
                MessageBox.Show("Mã món ăn không được để trống!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFoodTen.Text))
            {
                MessageBox.Show("Tên món ăn không được để trống!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(txtFoodGiaBan.Text, out float giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbo_category.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn loại món ăn!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận chỉnh sửa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn chỉnh sửa món ăn này?", "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            // Tìm món ăn trong danh sách
            var item = dmthucdon.DSThucDon.FirstOrDefault(x => x.MaMonAn == txtFoodMa.Text);
            if (item != null)
            {
                // Cập nhật thông tin
                item.TenMonAn = txtFoodTen.Text;
                item.LoaiMonAn = (int)cbo_category.SelectedValue;
                item.GiaBan = giaBan;

                // Làm mới DataGridView
                dtgvFood.DataSource = null;
                dtgvFood.DataSource = dmthucdon.DSThucDon;

                // Thông báo thành công
                MessageBox.Show("Món ăn đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy món ăn cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    produccurrent = (ThucDon)dtgvFood.Rows[e.RowIndex].DataBoundItem;
            //    txtFoodMa.Text = produccurrent.MaMonAn.ToString();
            //    txtFoodTen.Text = produccurrent.TenMonAn.ToString();
            //    cbo_category.SelectedItem = produccurrent.LoaiMonAn.ToString();  // This should be set to the category name, not the integer
            //    txtFoodGiaBan.Text = produccurrent.GiaBan.ToString();
            //}

            // Ensure a valid row index is selected
            if (e.RowIndex != -1)
            {
                // Loop through all columns and output their names to check
                foreach (DataGridViewColumn column in dtgvFood.Columns)
                {
                    MessageBox.Show($"Column Name: {column.Name}");
                }

                // Now, you can attempt to access the value
                var categoryIndexCell = dtgvFood.Rows[e.RowIndex].Cells["LoaiMonAn"];
                if (categoryIndexCell != null)
                {
                    // This will show the actual value in the "LoaiMonAn" column for the clicked row
                    var categoryIndex = categoryIndexCell.Value;
                    MessageBox.Show($"Category Index: {categoryIndex}");
                }
                else
                {
                    MessageBox.Show("Column 'LoaiMonAn' not found.");
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
            
        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvFood.Rows[e.RowIndex];

            
                txtFoodMa.Text = row.Cells["MaMonAn"].Value?.ToString();
                txtFoodTen.Text = row.Cells["TenMonAn"].Value?.ToString();
                txtFoodGiaBan.Text = row.Cells["GiaBan"].Value?.ToString();
                cbo_category.SelectedValue = row.Cells["LoaiMonAn"].Value;
            }
        }

    }
}
