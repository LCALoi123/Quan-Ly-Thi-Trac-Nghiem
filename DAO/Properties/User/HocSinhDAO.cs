using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Đây là class chứa các hàm truy vấn dữ liệu của bảng HocSinh
    /// và các hàm thủ tục liên quan đến HocSinh
    /// </summary>
    public class HocSinhDAO
    {
        #region singleton
        private static HocSinhDAO instance;

        public static HocSinhDAO Instance
        {
            get { if (instance == null) instance = new HocSinhDAO(); return HocSinhDAO.instance; }
            private set{HocSinhDAO.instance = value;}
        }
        private HocSinhDAO() { }
        #endregion

        #region method
        /// <summary thêm một học sinh>
        /// thực hiện câu truy vấn thêm dữ liệu vào bảng HocSinh
        /// </summary>
        /// <param name="hocSinhDTO">giá trị truyền vào là dữ liệu cần thêm</param>
        public void InsertHocSinh(HocSinhDTO hocSinhDTO)
        {
            using(qltnDAODataContext qltn = new qltnDAODataContext())
            {
                HocSinh hocSinh = new HocSinh();
                hocSinh.TenHS = hocSinhDTO.TenHS;
                hocSinh.Lop = hocSinhDTO.LopHoc;
                hocSinh.KhoiLop = hocSinhDTO.KhoiLop;
                hocSinh.NgaySinh = DateTime.Parse(hocSinhDTO.NgaySinh);
                hocSinh.IDus = hocSinhDTO.IDus;
                qltn.HocSinhs.InsertOnSubmit(hocSinh);
                qltn.SubmitChanges();
            }
        }
        /// <summary xóa học sinh>
        /// 
        /// </summary>
        public void DeleteHocSinh() { }

        /// <summary>
        /// cập nhật thông tin cá nhân của học sinh
        /// </summary>
        /// <param name="idus">id</param>
        /// <param name="hocSinhDTO">thông tin cập nhật của học sinh</param>
        public void UpdateHocSinh(int idus, HocSinhDTO hocSinhDTO)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                try
                {
                    HocSinh hocSinh = qltn.HocSinhs.Single(p => p.IDus == idus);

                    hocSinh.TenHS = hocSinhDTO.TenHS;
                    hocSinh.Lop = hocSinhDTO.LopHoc;
                    hocSinh.KhoiLop = hocSinhDTO.KhoiLop;
                    hocSinh.NgaySinh = DateTime.Parse(hocSinhDTO.NgaySinh);

                    qltn.SubmitChanges();
                }
                catch
                {
                    
                }
            }
        }
        /// <summary>
        /// lấy tên của học sinh
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>họ tên</returns>
        public string Get_Name(int id)
        {
            string name = "";
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var hs = from a in qltn.HocSinhs
                         where a.IDus == id
                         select a.TenHS;
                name = hs.FirstOrDefault();
            }
            return name;
        }
        /// <summary>
        /// lấy thông tin cá nhân của học sinh
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>thông tin cá nhân</returns>
        public HocSinhDTO Get_HocSinh(int id)
        {
            HocSinhDTO hocSinh = new HocSinhDTO();
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var h = from a in qltn.HocSinhs
                        where a.IDus == id
                        select a;
                var hs = h.First();

                hocSinh.IdHS = hs.IDhs;
                hocSinh.TenHS = hs.TenHS;
                hocSinh.LopHoc = hs.Lop;
                hocSinh.KhoiLop = hs.KhoiLop;

                CultureInfo viVN = new CultureInfo("vi-VN");
                hocSinh.NgaySinh = hs.NgaySinh.ToString("d",viVN);

            }
            return hocSinh;
                 
        }
        public int Get_IDhs(int idus)
        {
            int id = 0;
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var hs = from a in qltn.HocSinhs
                         where a.IDus == idus
                         select a.IDhs;
                id = hs.FirstOrDefault();
            }
            return id;
        }
        public List<HocSinhDTO> Select_All_HocSinh()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var hs = qltn.HocSinhs.Select(c => c);
                List<HocSinh> hocSinhs = hs.ToList();
                List<HocSinhDTO> DTO = new List<HocSinhDTO>();
                foreach (HocSinh hocSinh in hocSinhs)
                {
                    HocSinhDTO tmp = new HocSinhDTO();
                    tmp.IdHS = hocSinh.IDhs;
                    tmp.TenHS = hocSinh.TenHS;
                    tmp.LopHoc = hocSinh.Lop;
                    tmp.KhoiLop = hocSinh.KhoiLop;
                    DTO.Add(tmp);
                }
                return DTO;
            }
        }
        #endregion
    }
}
