using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class HoaDon
    {
        private static int countHD = 0;
        private int maHD;
        private int tenBan;
        private float tongTien;
        private int soLuongMon;
        private List<ThucDon> cacMonAn;
        private TaiKhoanKhach tkKhach;
        private DateTime thoiGian;
        private bool daThanhToan;

        public HoaDon(int maHD, int tenBan, float tongTien, int soLuongMon, List<ThucDon> cacMonAn, TaiKhoanKhach tkKhach, DateTime thoiGian, bool daThanhToan)
        {
            this.MaHD = maHD;
            this.TenBan = tenBan;
            this.TongTien = tongTien;
            this.SoLuongMon = soLuongMon;
            this.CacMonAn = cacMonAn;
            this.TkKhach = tkKhach;
            this.ThoiGian = thoiGian;
            this.DaThanhToan = daThanhToan;
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public int TenBan { get => tenBan; set => tenBan = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int SoLuongMon { get => soLuongMon; set => soLuongMon = value; }
        public List<ThucDon> CacMonAn { get => cacMonAn; set => cacMonAn = value; }
        public TaiKhoanKhach TkKhach { get => tkKhach; set => tkKhach = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public bool DaThanhToan { get => daThanhToan; set => daThanhToan = value; }



        public static int GenerateMA()
        {
            return ++countHD;
        }

    }

    


}

