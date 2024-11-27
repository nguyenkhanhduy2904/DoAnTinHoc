using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class TaiKhoanKhach
    {
        private string maTK;
        private string tenTK;
        private string diachiTK;
        private string sdtTK;
        private DateTime ngaysinhTK;
        private string gioitinhTK;

        public TaiKhoanKhach()
        {
            this.maTK = null;
            this.tenTK = null;
            this.diachiTK = null;
            this.sdtTK = null;
            this.ngaysinhTK = DateTime.Now;
            this.gioitinhTK = null;
        }

        public TaiKhoanKhach(string maTK, string tenTK, string diaChiTK, DateTime ngaySinhTK, string gioiTinhTK)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            diachiTK = diaChiTK;
            ngaysinhTK = ngaySinhTK;
            gioitinhTK = gioiTinhTK;
        }

        public TaiKhoanKhach(string maTK, string tenTK, string diachiTK, string sdtTK, DateTime ngaysinhTK, string gioitinhTK)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.diachiTK = diachiTK;
            this.ngaysinhTK = ngaysinhTK;
            this.sdtTK = sdtTK;
            this.gioitinhTK = gioitinhTK;
        }
        public string MaTK
        {
            get { return this.maTK; }
            set { this.maTK = value; }
        }
        public string TenTK
        {
            get { return this.tenTK; }
            set { this.tenTK = value; }
        }
        public string DiaChiTK
        {
            get { return this.diachiTK; }
            set { this.diachiTK = value; }
        }
        public string SDTTK
        {
            get { return this.sdtTK; }
            set { this.sdtTK = value; }
        }
        public DateTime NgaySinhTK
        {
            get { return this.ngaysinhTK; }
            set { this.ngaysinhTK = value; }
        }
        public string GioiTinhTK
        {
            get { return this.gioitinhTK; }
            set { this.gioitinhTK = value; }
        } 
    }
}

