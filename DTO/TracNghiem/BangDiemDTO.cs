using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangDiemDTO
    {
        private string kyThi;
        private string deThi;
        private float diem;

        public string KyThi { get => kyThi; set => kyThi = value; }
        public string DeThi { get => deThi; set => deThi = value; }
        public float Diem { get => diem; set => diem = value; }
    }
}
