using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DanhMucThucDon
    {
        private List<ThucDon> dsThucDon;
        public DanhMucThucDon()
        {
            this.dsThucDon = new List<ThucDon>();

            dsThucDon.Add(new ThucDon("001", "Pizza", 100000, 12));
            dsThucDon.Add(new ThucDon("002", "Cappuccino", 50000, 3));
            dsThucDon.Add(new ThucDon("003", "Sushi", 100000, 6));
            dsThucDon.Add(new ThucDon("004", "Coca Cola", 30000, 2));
            dsThucDon.Add(new ThucDon("005", "KFC", 100000, 10));
            dsThucDon.Add(new ThucDon("006", "Pho Bo", 100000, 8));
            dsThucDon.Add(new ThucDon("007", "Beef Steak", 100000, 8));
            dsThucDon.Add(new ThucDon("008", "Tai Loc Qua Lon", 1.50f, 2));  // Soft Drink
            dsThucDon.Add(new ThucDon("009", "Espresso", 2.50f, 3));   // Coffee
            dsThucDon.Add(new ThucDon("010", "Red Wine", 8.99f, 4));   // Alcohol
            dsThucDon.Add(new ThucDon("011", "Potato Chips", 1.99f, 5)); // Snack
            dsThucDon.Add(new ThucDon("012", "Chicken Fried Rice", 6.99f, 6)); // Rice
            dsThucDon.Add(new ThucDon("013", "Beef Pho", 7.99f, 7));   // Noodle
            dsThucDon.Add(new ThucDon("014", "Steak", 14.99f, 8));     // Beef
            dsThucDon.Add(new ThucDon("015", "Pork Chop", 12.99f, 9)); // Pork
            dsThucDon.Add(new ThucDon("016", "Grilled Chicken", 10.99f, 10)); // Chicken
            dsThucDon.Add(new ThucDon("017", "Tofu Stir-Fry", 5.50f, 11)); // Vegan
            dsThucDon.Add(new ThucDon("018", "Fruit Salad", 4.99f, 1)); // Dessert
            dsThucDon.Add(new ThucDon("019", "Green Tea", 1.99f, 2));  // Soft Drink
            dsThucDon.Add(new ThucDon("020", "Mocha", 3.75f, 3));      // Coffee
            dsThucDon.Add(new ThucDon("021", "White Wine", 7.99f, 4)); // Alcohol
            dsThucDon.Add(new ThucDon("022", "Trail Mix", 2.50f, 5));  // Snack

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
