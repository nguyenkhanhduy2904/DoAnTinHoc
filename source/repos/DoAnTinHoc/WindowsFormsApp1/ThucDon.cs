using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsFormsApp1
{
    [Serializable]
    public class ThucDon
    {
        // Dictionary will be initialized only if file does not exist
        public static Dictionary<int, string> foodCategory;

        public static int foodCategoryAmount;

        private string maMA;
        private string tenMA;
        private float giabanMA;
        private int loaiMA;
        private string loaiMA_toString;

        public ThucDon()
        {
            this.maMA = null;
            this.tenMA = null;
            this.giabanMA = 0;
            this.LoaiMonAn = 0;
            this.loaiMA_toString = null;
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
                if(foodCategory ==null)
                {
                    InitializeDictionary();
                }
                

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

        public string LoaiMA_toString
        {
            get
            {
                return foodCategory.ContainsKey(loaiMA) ? foodCategory[loaiMA] : "Unknown";
            }
        }

        // Method to initialize dictionary
        public static void InitializeDictionary()
        {
            if (foodCategory != null && foodCategory.Count > 0)
            {
                
                return;
            }

            string fileName = "foodCategory.dat"; // File name
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string filePath = Path.Combine(directory, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    // Attempt to load from file
                    LoadDictionary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading dictionary. Default values will be used.\n{ex.Message}");
                    foodCategory = new Dictionary<int, string>() { { 0, "Extra" } };
                }
            }
            else
            {
                // If no file exists, initialize with default values
                foodCategory = new Dictionary<int, string>() { { 0, "Extra" } };
            }

            // Update the foodCategoryAmount
            foodCategoryAmount = foodCategory.Keys.Any() ? foodCategory.Keys.Max() + 1 : 1;
        }


        // Save the dictionary to a relative path
        public static void SaveDictionary()
        {
            string fileName = "foodCategory.dat";
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string filePath = Path.Combine(directory, fileName);

            // Ensure the directory exists
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                // Serialize the dictionary to the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, foodCategory);
                }
                MessageBox.Show("Dictionary saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving dictionary: {ex.Message}");
            }
        }

        // Load the dictionary from a relative path (no parameters)
        public static void LoadDictionary()
        {
            string fileName = "foodCategory.dat";
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string filePath = Path.Combine(directory, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        var formatter = new BinaryFormatter();
                        foodCategory = (Dictionary<int, string>)formatter.Deserialize(stream);
                    }
                    MessageBox.Show($"Dictionary loaded successfully with {foodCategory.Count}");
                }
                else
                {
                    MessageBox.Show("No existing dictionary found. Using default.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dictionary: {ex.Message}");
            }
        }
    }
}
