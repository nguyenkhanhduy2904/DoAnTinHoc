using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTaiKhoanKhach : Form
    {
       
        private DanhMucTaiKhoanKhach dmtk =new DanhMucTaiKhoanKhach();
        TaiKhoanKhach produccurrent = new TaiKhoanKhach();
        
        public frmTaiKhoanKhach()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            string MaTK = txtMaKH.Text;
            string TenTK = txtTenKH.Text;
            string DiaChiTK = txtDiaChiKH.Text;
            string SDTTK = msksdtKH.Text;
            DateTime NgaySinhTK = DateTime.Now;
            string GioiTinhTK = ckbGioiTinh.Checked == true ? "Nam" : "Nữ ";
            TaiKhoanKhach TK = new TaiKhoanKhach(MaTK,TenTK,DiaChiTK,SDTTK,NgaySinhTK,GioiTinhTK);
            if (dmtk.Them(TK) == true)
            {
                MessageBox.Show("Đã thêm tài khoản vào danh sách", "Thông Báo !!!", MessageBoxButtons.OK);
                HienThiDanhSachTaiKhoanKhachHang(dmtk.DSTaiKhoanKhach, dtgvAccount);
            }
            else
                MessageBox.Show("Tài khoản có rồi mời nhập khác", " Thông Báo !!!", MessageBoxButtons.OK);
        }
        private void HienThiDanhSachTaiKhoanKhachHang(List<TaiKhoanKhach> TK, DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = TK.ToList();

        }
        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            DialogResult ketqua = MessageBox.Show("Bạn muốn xóa món ăn này ?", "thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.Yes)
            {
                if (dtgvAccount.CurrentCell == null)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để xóa !", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                int vitri = dtgvAccount.CurrentCell.RowIndex;
                if (vitri < 0 || vitri >= dmtk.DSTaiKhoanKhach.Count)
                {
                    MessageBox.Show("Chỉ số không hợp lệ !", "Thông Báo", MessageBoxButtons.OKCancel);
                    return;
                }
               dmtk.Xoa(vitri);
                MessageBox.Show("Đã xóa món ăn này", "Thông Báo");
                HienThiDanhSachTaiKhoanKhachHang(dmtk.DSTaiKhoanKhach, dtgvAccount);
            }
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            
            if (produccurrent == null || string.IsNullOrWhiteSpace(produccurrent.MaTK))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Mã tài khoản không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiKH.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(msksdtKH.Text) || msksdtKH.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            produccurrent.TenTK = txtTenKH.Text;
            produccurrent.DiaChiTK = txtDiaChiKH.Text;
            produccurrent.SDTTK = msksdtKH.Text;
            produccurrent.NgaySinhTK = dtpkNgaySinhTK.Value;
            produccurrent.GioiTinhTK = ckbGioiTinh.Checked ? "Nam" : "Nữ";

           
            var account = dmtk.DSTaiKhoanKhach.FirstOrDefault(x => x.MaTK == produccurrent.MaTK);
            if (account != null)
            {
                account.TenTK = produccurrent.TenTK;
                account.DiaChiTK = produccurrent.DiaChiTK;
                account.SDTTK = produccurrent.SDTTK;
                account.NgaySinhTK = produccurrent.NgaySinhTK;
                account.GioiTinhTK = produccurrent.GioiTinhTK;

                
                HienThiDanhSachTaiKhoanKhachHang(dmtk.DSTaiKhoanKhach, dtgvAccount);

                
                MessageBox.Show("Tài khoản đã được cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản để cập nhật!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LuuFile(string tenFile)
        {
            try
            {
                
                using (FileStream fs = new FileStream(tenFile, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dmtk.DSTaiKhoanKhach); 
                }

                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
                return false; 
            }
        }



        private bool Doc(string tenFile)
        {
            try
            {
             
                if (!File.Exists(tenFile))
                {
                    using (FileStream fs = new FileStream(tenFile, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, new List<TaiKhoanKhach>()); 
                    }
                }

              
                using (FileStream fs = new FileStream(tenFile, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    dmtk.DSTaiKhoanKhach = (List<TaiKhoanKhach>)bf.Deserialize(fs);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
                return false;
            }
        }

        private void btnAccountSave_Click(object sender, EventArgs e)
        {
            if (LuuFile("TKK.dat") == true)
            {
                MessageBox.Show("Đã Lưu!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Không Lưu Được !!!", "Thông Báo", MessageBoxButtons.OK);
        }
        private void frmTaiKhoanKhach_Load(object sender, EventArgs e)
        {
            dmtk = new DanhMucTaiKhoanKhach();
            
        }
        private void btnAccountExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dtgvAccount.Rows[e.RowIndex];
                produccurrent = (TaiKhoanKhach)row.DataBoundItem;


                txtMaKH.Text = produccurrent.MaTK;
                txtTenKH.Text = produccurrent.TenTK;
                txtDiaChiKH.Text = produccurrent.DiaChiTK;
                msksdtKH.Text = produccurrent.SDTTK;
                dtpkNgaySinhTK.Value = produccurrent.NgaySinhTK;
                ckbGioiTinh.Checked = produccurrent.GioiTinhTK == "Nam";
            }

        }
    }
}
