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

        }
        private bool LuuFile(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                dmtk.DSTaiKhoanKhach = (List<TaiKhoanKhach>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool Doc(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                dmtk.DSTaiKhoanKhach = (List<TaiKhoanKhach>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void btnAccountSave_Click(object sender, EventArgs e)
        {
            if (LuuFile("dmthucdon.DSThucDon.dat") == true)
            {
                MessageBox.Show("Đã Lưu!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Không Lưu Được !!!", "Thông Báo", MessageBoxButtons.OK);
        }
        private void frmTaiKhoanKhach_Load(object sender, EventArgs e)
        {
            dmtk = new DanhMucTaiKhoanKhach();
            if (Doc("dmThucDon.DSThucDon.dat") == true)
            {
               HienThiDanhSachTaiKhoanKhachHang(dmtk.DSTaiKhoanKhach,dtgvAccount);
            }
            else
                MessageBox.Show("Không Đọc Được dữ liệu  !!!", "Thông Báo", MessageBoxButtons.OK);
        }
        private void btnAccountExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                produccurrent = (TaiKhoanKhach)dtgvAccount.Rows[e.RowIndex].DataBoundItem;
                txtTenKH.Text = produccurrent.TenTK.ToString();
                txtMaKH.Text = produccurrent.MaTK.ToString();
                txtDiaChiKH.Text = produccurrent.DiaChiTK.ToString();
                dtpkNgaySinhTK.Value = produccurrent.NgaySinhTK;
                
               
            }
        }
    }
}
