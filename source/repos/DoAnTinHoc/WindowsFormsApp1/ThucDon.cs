using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class ThucDon
    {
        private string maMA;
        private string tenMA;
        private float giabanMA;
        private string loaiMA;
        

        public ThucDon()
        {
            this.maMA = null;
            this.tenMA = null;
            this.giabanMA = 0;
            this.LoaiMonAn = null;
           
        }


        public ThucDon(string maMA,string tenMA,float giabanMA,string loaiMA )
        {
            this.maMA = maMA;
            this.tenMA = tenMA;
            this.giabanMA = giabanMA;
            this.loaiMA = loaiMA;
        }



        public string MaMonAn
        {
            get { return this.maMA; }
            set { this.maMA = value; }
        }

        public string TenMonAn
        {
            get { return this.tenMA; }
            set { this.tenMA = value; }
        }
        public float GiaBan
        {
            get { return this.giabanMA; }
            set { this.giabanMA = value; }
        }
        public string LoaiMonAn
        {
            get { return this.loaiMA; }
            set { this.loaiMA = value; }
        }

    }
}
