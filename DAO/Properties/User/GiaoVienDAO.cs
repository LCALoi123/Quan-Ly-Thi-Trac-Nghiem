using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Đây là class chứa các hàm truy vấn dữ liệu của bảng GiaoVien
    /// và các hàm thủ tục liên quan đến GiaoVien
    /// </summary>
    public class GiaoVienDAO
    {
        #region singleton
        private static GiaoVienDAO instance;

        public static GiaoVienDAO Instance
        {
            get { if (instance == null) instance = new GiaoVienDAO(); return GiaoVienDAO.instance; }
            private set { GiaoVienDAO.instance = value; }
        }
        private GiaoVienDAO() { }
        #endregion

        #region method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giaoVienDTO"></param>
        public void InsertGiaoVien(GiaoVienDTO giaoVienDTO)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                GiaoVien giaoVien = new GiaoVien();
                giaoVien.TenGV = giaoVienDTO.TenGV;

                giaoVien.IDus = giaoVienDTO.Idus;
                qltn.GiaoViens.InsertOnSubmit(giaoVien);
                qltn.SubmitChanges();
            }
        }
        //Xóa học sinh
        public void DeleteGiaoVien() { }
        /// <summary>
        /// cập nhật thông tin giáo viên
        /// </summary>
        /// <param name="idus">id account của giáo viên</param>
        /// <param name="Hoten">Họ tên mới</param>
        public void UpdateGiaoVien(int idus,string Hoten)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                try
                {
                    GiaoVien gv = qltn.GiaoViens.Single(p => p.IDus == idus);

                    gv.TenGV = Hoten;
                    qltn.SubmitChanges();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// lấy tên của giáo viên
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Họ tên</returns>
        public string Get_Name(int id)
        {
            string name = "";
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var hs = from a in qltn.GiaoViens
                         where a.IDus == id
                         select a.TenGV ;
                name = hs.FirstOrDefault();
            }
            return name;
        }

        public List<GiaoVienDTO> Select_All_GiaoVien()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var gv = qltn.GiaoViens.Select(c => c);
                List<GiaoVien> giaoviens = gv.ToList();
                List<GiaoVienDTO> DTO = new List<GiaoVienDTO>();
                foreach (GiaoVien giaovien in giaoviens)
                {
                    GiaoVienDTO tmp = new GiaoVienDTO();
                    tmp.IdGV = giaovien.IDgv;
                    tmp.TenGV = giaovien.TenGV;
                    DTO.Add(tmp);
                }
                return DTO;
            }
        }
        #endregion
    }
}
