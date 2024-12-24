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
    public class ListHoaDon
    {
        private List<HoaDon> dsHoaDon;

        public ListHoaDon()
        {
            if (Doc("listHoaDon.dat"))
            {
                MessageBox.Show("Load success");
                MessageBox.Show($"Loaded {DsHoaDon.Count} bills.");
            }
            if(dsHoaDon == null)
            {
                dsHoaDon = new List<HoaDon>();
          
            }
        }

        

        public List<HoaDon> DsHoaDon { get => this.dsHoaDon; set => this.dsHoaDon = value; }

        public bool Them(HoaDon hd)
        {
            this.dsHoaDon.Add(hd);
            return true;
        }

        public bool Doc(string tenFile)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tenFile);

                if (!File.Exists(filePath))
                {
                    this.dsHoaDon = new List<HoaDon>();
                    return true;
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    var deserializedData = bf.Deserialize(fs);

                    if (deserializedData is List<HoaDon> hoaDonList)
                    {
                        this.dsHoaDon = hoaDonList;
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in file. Clearing data.");
                        this.dsHoaDon = new List<HoaDon>();
                    }
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
