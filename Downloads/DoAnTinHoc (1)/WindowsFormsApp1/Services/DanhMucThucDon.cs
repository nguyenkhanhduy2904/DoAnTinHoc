using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DanhMucThucDon
    {
        private List<ThucDon> dsThucDon;
        

        public DanhMucThucDon()
        {
            if (Doc("dmThucDon.DSThucDon.dat"))
            {
                MessageBox.Show($"Loaded {DSThucDon.Count} items successfully.");

            }
            else
            {
                dsThucDon = new List<ThucDon>()
                {
                  new ThucDon{ MaMonAn = "00", TenMonAn = "00", GiaBan = 0, LoaiMonAn = 0},
                };
            }
        }
        public List<ThucDon> DSThucDon
        {
            get { return this.dsThucDon; }
            set { dsThucDon = value; }
        }
        public bool Them(ThucDon td)
        {
            if (KiemTraMa(td.MaMonAn))
            {
                return false;
            }
            else
            {
                this.dsThucDon.Add(td);
                return true;
            }
        }
        public bool Xoa(int vitri)
        {
            
                this.dsThucDon.RemoveAt(vitri);
                return true;
         
           
        }
        public bool Sua(ThucDon td, int vitri)
        {
            this.dsThucDon[vitri] = td;
            return true;
        }
        private bool KiemTraMa(string ma)
        {
            foreach (ThucDon td in this.dsThucDon)
            {
                if (td.MaMonAn.Equals(ma))
                    return true;
            }
            return false;
        }

        private ThucDon TimtheoMa(string maCanTim)
        {
            foreach (ThucDon td in this.dsThucDon)
            {
                if (td.Equals(maCanTim))
                    return td;
            }
            return null;
        }
        public bool Doc(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    this.DSThucDon = (List<ThucDon>)bf.Deserialize(fs);
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

    }
}
