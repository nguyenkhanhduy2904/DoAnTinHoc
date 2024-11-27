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
        
        ThucDon produccurrent = new ThucDon();
        public frmThucDon()
        {
            InitializeComponent();
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
            string loaiMA = txtLoai.Text;
            ThucDon td = new ThucDon(maMA,tenMA,giabanMA,loaiMA);
            if (dmthucdon.Them(td) == true)
            {
                MessageBox.Show("Đã thêm vào danh sách", "Thông Báo !!!", MessageBoxButtons.OK);
                HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            }
            else
                MessageBox.Show("Đã có rồi mời nhập khác", "Thông Báo !!!", MessageBoxButtons.OK);
        }
        private void HienThiDanhSachThucDon(List<ThucDon> TD, DataGridView dgv)
        {

            dgv.DataSource = TD.ToList();
        }

        private void btnFoodDelete_Click(object sender, EventArgs e)
        {
            DialogResult ketqua = MessageBox.Show("Bạn muốn xóa món ăn này ?", "thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            produccurrent.LoaiMonAn = txtLoai.Text.ToString();
            produccurrent.GiaBan = float.Parse(txtFoodGiaBan.Text.ToString());
            HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            MessageBox.Show("Đã Cập Nhật", "Thông báo", MessageBoxButtons.OK);
        }

        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            
        }
        private bool Luu(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dmthucdon.DSThucDon);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
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
            dmthucdon = new DanhMucThucDon();
            if (Doc("dmThucDon.DSThucDon.dat") == true)
            {
                HienThiDanhSachThucDon(dmthucdon.DSThucDon, dtgvFood);
            }
            else
                MessageBox.Show("Không Đọc Được dữ liệu  !!!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btnFoodOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgvFood_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                produccurrent = (ThucDon)dtgvFood.Rows[e.RowIndex].DataBoundItem;
                txtFoodMa.Text = produccurrent.MaMonAn.ToString();
                txtFoodTen.Text = produccurrent.TenMonAn.ToString();
                txtLoai.Text = produccurrent.LoaiMonAn.ToString();
                txtFoodGiaBan.Text = produccurrent.GiaBan.ToString();


            }
        }
    }
}
