using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiemDTO
    {
        private string maKyThi;
        private string maDe;
        private int idHS;
        private float diem;
        private int lanThi;
        
        public int IdHS { get => idHS; set => idHS = value; }
        public float Diem { get => diem; set => diem = value; }
        public string MaKyThi { get => maKyThi; set => maKyThi = value; }
        public string MaDe { get => maDe; set => maDe = value; }
        public int LanThi { get => lanThi; set => lanThi = value; }
    }
}
