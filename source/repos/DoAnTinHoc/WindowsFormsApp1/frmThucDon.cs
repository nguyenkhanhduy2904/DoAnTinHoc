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


    public partial class frmThucDon : Form
    {
        private DanhMucThucDon dmthucdon = new DanhMucThucDon();
        private ThucDon _thucDon;
        
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
            
            // Bind the data source to the DataGridView
            dgv.DataSource = TD.ToList();
            dgv.Columns["LoaiMA"].Visible = false;


            // Add a new column for the category name
            if (!dgv.Columns.Contains("CategoryName"))
            {
                DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
                categoryColumn.HeaderText = "Category Name";
                categoryColumn.Name = "CategoryName";
                dgv.Columns.Add(categoryColumn);
                categoryColumn.DisplayIndex = 1;
            }

            // Populate the new column with category names based on the LoaiMA key
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                // Get the LoaiMA value from the corresponding column
                if (row.Cells["LoaiMA"] != null && row.Cells["LoaiMA"].Value != null)
                {
                    int loaiMAKey;
                    if (int.TryParse(row.Cells["LoaiMA"].Value.ToString(), out loaiMAKey))
                    {
                        // Map the key to the category name
                        if (_thucDon.foodCategory.ContainsKey(loaiMAKey))
                        {
                            row.Cells["CategoryName"].Value = _thucDon.foodCategory[loaiMAKey];
                        }
                        else
                        {
                            row.Cells["CategoryName"].Value = "Unknown Category"; // Fallback for invalid keys
                        }
                    }
                    else
                    {
                        row.Cells["CategoryName"].Value = "Invalid Key"; // Handle non-integer keys gracefully
                    }
                }
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
            produccurrent.MaMonAn = txtFoodMa.Text.ToString();
            produccurrent.TenMonAn = txtFoodTen.Text.ToString();
            if (cbo_category.SelectedIndex >= 0) 
            {
                produccurrent.LoaiMonAn = cbo_category.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Hay chon loai mon an!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            produccurrent.GiaBan = float.Parse(txtFoodGiaBan.Text.ToString());
            HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            MessageBox.Show("Đã Cập Nhật", "Thông báo", MessageBoxButtons.OK);
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
                using (FileStream fs = new FileStream(tenFile, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dmthucdon.DSThucDon);

                    return true;
                }
               

            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"Error Type: {ex.GetType().Name}\nMessage: {ex.Message}",
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
        private bool Doc(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                dmthucdon.DSThucDon = (List<ThucDon>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frmThucDon_Load(object sender, EventArgs e)
        {
            cbo_category.DataSource = new BindingSource(_thucDon.foodCategory, null);
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

       
    }
}
