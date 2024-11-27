using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DanhMucThucDon
    {
        private List<ThucDon> dsThucDon;
        public DanhMucThucDon()
        {
            this.dsThucDon = new List<ThucDon>(); 
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
      
    }
}
