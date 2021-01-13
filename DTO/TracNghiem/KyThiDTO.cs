using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KyThiDTO
    {
        private string maKyThi;
        private string tenKyThi;
        private string ngayThi;

        public string MaKyThi { get => maKyThi; set => maKyThi = value; }
        public string TenKyThi { get => tenKyThi; set => tenKyThi = value; }
        public string NgayThi { get => ngayThi; set => ngayThi = value; }
    }
}
