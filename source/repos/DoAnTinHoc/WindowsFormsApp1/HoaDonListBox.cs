using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HoaDonListBox : Form
    {
        
        
        public HoaDonListBox()
        {
            InitializeComponent();
        }

        public void showName (List<string> tenMonAn)
        {
            listBox_HoaDon.DataSource = null;
            listBox_HoaDon.DataSource = tenMonAn;
        }
    }
}
