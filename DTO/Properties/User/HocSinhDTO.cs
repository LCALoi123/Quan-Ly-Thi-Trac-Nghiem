using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhDTO
    {
        /// <summary>
        /// idHS là id của học sinh để phân biệt các học sinh với nhau
        /// tenHS là tên của học sinh đó
        /// LopHoc là lớp học hiện tại mà học sinh đó đang học
        /// KhoiLop là Khối lớp học của lớp hiện tại
        /// ngaySinh là ngày sinh của học sinh đó
        /// </summary>
        private int idHS;
        private string tenHS;
        private string lopHoc;
        private string khoiLop;
        private string ngaySinh;
        private int iDus;

        /***----------------------------------------------------------------------***/
        public int IdHS { get => idHS; set => idHS = value; }
        public string TenHS { get => tenHS; set => tenHS = value; }
        public string KhoiLop { get => khoiLop; set => khoiLop = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int IDus { get => iDus; set => iDus = value; }
        public string LopHoc { get => lopHoc; set => lopHoc = value; }
    }
}
