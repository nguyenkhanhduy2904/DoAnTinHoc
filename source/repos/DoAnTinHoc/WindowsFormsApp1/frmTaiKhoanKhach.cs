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
        //private int vitri = -1;
        private int selectedIndex = -1;
        public frmTaiKhoanKhach()
        {
            InitializeComponent();
            dtgvAccount.CellClick +=  DtgvAccount_CellClick;
            HienThiDanhSachTaiKhoanKhachHang(dmtk.DSTaiKhoanKhach, dtgvAccount);
        }

        private void DtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString());
            if (e.RowIndex != -1)
            {
                selectedIndex = e.RowIndex;
                produccurrent = (TaiKhoanKhach)dtgvAccount.Rows[e.RowIndex].DataBoundItem;
                txtTenKH.Text = produccurrent.TenTK.ToString();
                txtMaKH.Text = produccurrent.MaTK.ToString();
                msksdtKH.Text = produccurrent.SDTTK.ToString();
                txtDiaChiKH.Text = produccurrent.DiaChiTK.ToString();
                dtpkNgaySinhTK.Value = produccurrent.NgaySinhTK;



            }
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
            if(TK!= null)
            {
                dgv.DataSource = TK.ToList();
            }
            
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

        }
        private bool LuuFile(string tenFile)
        {
            try
            {
                // Use 'using' statement for automatic resource management
                using (FileStream fs = new FileStream(tenFile, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dmtk.DSTaiKhoanKhach); // Serialize the list to the file
                }

                return true; // Return true if saving is successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
                return false; // Return false if an exception occurs
            }
        }



        private bool Doc(string tenFile)
        {
            try
            {
                // Check if the file exists; if not, create an empty file
                if (!File.Exists(tenFile))
                {
                    using (FileStream fs = new FileStream(tenFile, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, new List<TaiKhoanKhach>()); // Serialize an empty list
                    }
                }

                // Open the file and deserialize its content
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
            
           
        }
    }
}
