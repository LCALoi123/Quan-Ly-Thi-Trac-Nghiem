using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangDiemThongKe
    {
        private string kyThi;
        private string deThi;
        private float diem;
        private int idHS;
        private string tenHS;
        private string lopHoc;
        private string khoiLop;
        private DateTime ngaySinh;
        public string KyThi { get => kyThi; set => kyThi = value; }
        public string DeThi { get => deThi; set => deThi = value; }
        public float Diem { get => diem; set => diem = value; }
        public int IdHS { get => idHS; set => idHS = value; }
        public string TenHS { get => tenHS; set => tenHS = value; }
        public string LopHoc { get => lopHoc; set => lopHoc = value; }
        public string KhoiLop { get => khoiLop; set => khoiLop = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}
