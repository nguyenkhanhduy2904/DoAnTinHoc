using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DanhMucTaiKhoanKhach
    {
        private List<TaiKhoanKhach> dsTaiKhoanKhach;
        public DanhMucTaiKhoanKhach()
        {
            this.dsTaiKhoanKhach = new List<TaiKhoanKhach>();   
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
