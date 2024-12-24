using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmHoaDon : Form
    {
        private ListHoaDon dsHoaDon = new ListHoaDon();
        private DanhMucTaiKhoanKhach dsKhach = new DanhMucTaiKhoanKhach();

        public frmHoaDon()
        {
            InitializeComponent();
            HienThiDGV_allData(dsHoaDon.DsHoaDon, dgv_hoaDon);
            dgv_hoaDon.SelectionChanged += dgv_hoaDon_SelectionChanged;
            if(dsHoaDon.DsHoaDon != null)
            MessageBox.Show($" {dsHoaDon.DsHoaDon.Count}");
            cbo_customer.DataSource = new BindingSource(dsKhach.DSTaiKhoanKhach, null);
            cbo_customer.DisplayMember = "tenKH";
        }

        public void HienThiDGV_allData(List<HoaDon> listHD, DataGridView dgv)
        {
            dgv.DataSource = null;
            if(listHD !=null)
            {
                dgv.DataSource = listHD.ToList();
            }  
        }

        public void HienThiDGV_daThanhToan(List<HoaDon> listHD, DataGridView dgv)
        {
            dgv.DataSource = null;
            if (listHD != null)
            {
                List<HoaDon> filterHoaDon = new List<HoaDon>();
                foreach(var hoaDon in listHD)
                {
                    if(hoaDon.DaThanhToan == true)
                    {
                        filterHoaDon.Add(hoaDon);
                    }
                }

                if(filterHoaDon.Count > 0)
                {
                    dgv_hoaDon.DataSource = filterHoaDon;
                }
                else
                {
                    MessageBox.Show("Cant find any HoaDon");
                }
            }
            else
            {
                MessageBox.Show("List<HoaDon> is empty");
            }
        }


        public void HienThiDGV_chuaThanhToan(List<HoaDon> listHD, DataGridView dgv)
        {
            dgv.DataSource = null;
            if (listHD != null)
            {
                List<HoaDon> filterHoaDon = new List<HoaDon>();
                foreach (var hoaDon in listHD)
                {
                    if (hoaDon.DaThanhToan == false)
                    {
                        filterHoaDon.Add(hoaDon);
                    }
                }

                if (filterHoaDon.Count > 0)
                {
                    dgv_hoaDon.DataSource = filterHoaDon;
                }
                else
                {
                    MessageBox.Show("Cant find any HoaDon");
                }
            }
            else
            {
                MessageBox.Show("List<HoaDon> is empty");
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ClearBinaryFile("listHoaDon.dat");
            
        }

        public static void ClearBinaryFile(string fileName)
        {
            try
            {
                // Prepare an empty list to serialize
                var emptyList = new List<HoaDon>();

                // Determine the file path
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                // Overwrite the file with the empty list
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, emptyList);
                }

                Console.WriteLine("File cleared successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing file: {ex.Message}");
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            if(chBox_daThanhToan_false.Checked && chBox_daThanhToan_true.Checked)
            {
                HienThiDGV_allData(dsHoaDon.DsHoaDon, dgv_hoaDon);
            }
            else if (chBox_daThanhToan_false.Checked)
            {
                HienThiDGV_chuaThanhToan(dsHoaDon.DsHoaDon, dgv_hoaDon);
            }
            else if (chBox_daThanhToan_true.Checked)
            {
                HienThiDGV_daThanhToan(dsHoaDon.DsHoaDon, dgv_hoaDon);
            }
        }

        private void dgv_hoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_hoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_hoaDon.SelectedRows[0];
                // Access row data:
                var hoaDon = selectedRow.DataBoundItem as HoaDon;
                MessageBox.Show($"Selected Bill ID: {hoaDon.MaHD}");
            }
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (dgv_hoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_hoaDon.SelectedRows[0];
                var hoaDon = selectedRow.DataBoundItem as HoaDon;

                if (hoaDon != null)
                {
                    hoaDon.DaThanhToan = true;
                    hoaDon.TkKhach = (TaiKhoanKhach)cbo_customer.SelectedItem;
                    if (Luu("listHoaDon.dat"))
                    {
                        MessageBox.Show($"Bill {hoaDon.MaHD} has been marked as paid.");
                    }
                    
                    

                    // Refresh DataGridView
                   if(chBox_daThanhToan_false.Checked && chBox_daThanhToan_true.Checked)
                    {
                        HienThiDGV_allData(dsHoaDon.DsHoaDon, dgv_hoaDon);
                    }
                   else if (chBox_daThanhToan_false.Checked)
                    {
                        HienThiDGV_chuaThanhToan(dsHoaDon.DsHoaDon, dgv_hoaDon);
                    }
                   else if (chBox_daThanhToan_true.Checked)
                    {
                        HienThiDGV_daThanhToan(dsHoaDon.DsHoaDon, dgv_hoaDon);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a bill to mark as paid.");
            }
        }

        private bool Luu(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);

                // Ensure the list is initialized before saving
                if (dsHoaDon.DsHoaDon == null)
                {
                    dsHoaDon.DsHoaDon = new List<HoaDon>();
                }

                // Always write to the file, whether it exists or not
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dsHoaDon.DsHoaDon);
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

        private void btn_show_DSmon_Click(object sender, EventArgs e)
        {
            if (dgv_hoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_hoaDon.SelectedRows[0];
                HoaDon selectedHoaDon = (HoaDon)selectedRow.DataBoundItem;
                if (selectedHoaDon != null)
                {
                    // Extract the list of MonAn
                    List<ThucDon> danhSachMonAn = selectedHoaDon.CacMonAn;

                    // Display the list of MonAn names
                    using (HoaDonListBox hoaDonListBox = new HoaDonListBox())
                    {
                        List<string> monAn = danhSachMonAn.Select(ma => ma.TenMonAn).ToList();
                        hoaDonListBox.showName(monAn);
                        hoaDonListBox.ShowDialog();
                    }
                }
            }
        }
    }
}
