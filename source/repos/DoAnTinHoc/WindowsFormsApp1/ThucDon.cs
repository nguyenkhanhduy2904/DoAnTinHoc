using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]


    public class ThucDon
    {
        public Dictionary<int, string> foodCategory = new Dictionary<int, string>()
        {
            
            {0, "Extra" },
            {1, "Dessert" },
            {2, "Soft Drink"},
            {3, "Coffee" },
            {4, "Alcohol" },
            {5, "Snack" },
            {6, "Rice" },
            {7,"Noodle" },
            {8, "Beef" },
            {9, "Pork" },
            {10,"Chicken" },
            {11,"Vegan" },
            {12, "Pie" }



        };




        private string maMA;
        private string tenMA;
        private float giabanMA;
        private int loaiMA;


        public ThucDon()
        {
            this.maMA = null;
            this.tenMA = null;
            this.giabanMA = 0;
            this.LoaiMonAn = 0;

        }


        public ThucDon(string maMA, string tenMA, float giabanMA, int loaiMA)
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
        public int LoaiMonAn
        {
            get { return this.loaiMA; }
            set 
            {
                if (foodCategory.ContainsKey(value))
                {
                    loaiMA = value;
                }
                else
                {
                    throw new ArgumentException("Invalid food category key.");
                }
            }
        }

    }
}
