using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DanhMucTaiKhoanKhach
    {
        private List<TaiKhoanKhach> dsTaiKhoanKhach;
        public DanhMucTaiKhoanKhach()
        {
            if (Doc("TKK.dat"))
            {
                MessageBox.Show($"Read success with {dsTaiKhoanKhach.Count} item");
            }
            if(dsTaiKhoanKhach == null)
            {
                dsTaiKhoanKhach = new List<TaiKhoanKhach>();
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
                    this.DSTaiKhoanKhach = (List<TaiKhoanKhach>)bf.Deserialize(fs);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
                return false;
            }
        }


        public DanhMucTaiKhoanKhach(List<TaiKhoanKhach> dsTaiKhoanKhach)
        {
            this.dsTaiKhoanKhach = dsTaiKhoanKhach;
        }

        public List<TaiKhoanKhach> DSTaiKhoanKhach
        { 
            get { return dsTaiKhoanKhach; }
            set { dsTaiKhoanKhach = value; }
        }

        public bool Them(TaiKhoanKhach tk)
        {
            if (KiemTraMa(tk.MaTK))
            {
                return false;
            }
            else
            {
                this.dsTaiKhoanKhach.Add(tk);
                return true;
            }

        }
        public bool Xoa(int viTri)
        {
            this.dsTaiKhoanKhach.RemoveAt(viTri);
            return true;
        }

        public bool Sua(TaiKhoanKhach tk, int viTri)
        {
            this.dsTaiKhoanKhach[viTri] = tk;
            return true;
        }
        public bool KiemTraMa(string ma)
        {
            foreach (TaiKhoanKhach tk in this.dsTaiKhoanKhach)
            {
                if (tk.MaTK.Equals(ma))
                    return true;
            }
            return false;
        }
    }
}
