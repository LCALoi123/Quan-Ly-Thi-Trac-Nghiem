using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class GiaoVienBUS
    {
        #region singleton
        private static GiaoVienBUS instance;

        public static GiaoVienBUS Instance
        {
            get { if (instance == null) instance = new GiaoVienBUS(); return GiaoVienBUS.instance; }
            private set { GiaoVienBUS.instance = value; }
        }
        private GiaoVienBUS() { }
        #endregion
        #region method
        /// <summary>
        /// thực hiện thêm thông tin cho giáo viên
        /// </summary>
        /// <param name="giaoVienDTO">thông tin giáo viên</param>
        public void DangKyGiaoVien(GiaoVienDTO giaoVienDTO)
        {
            
            try
            {
                GiaoVienDAO.Instance.InsertGiaoVien(giaoVienDTO);
            }
            catch
            {

            }

            /*end*/
        }

        /// <summary>
        /// cập nhật thông tin cho giáo viên
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <param name="HoTen">họ tên giáo viên</param>
        public void update_giaovien(string usname, string HoTen)
        {
            try
            {
                int idus = AccountDAO.Instance.Get_ID(usname);
                GiaoVienDAO.Instance.UpdateGiaoVien(idus, HoTen);
            }
            catch
            {

            }

        }


        /// <summary>
        /// lấy thông tin họ tên giáo viên
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <returns>họ tên</returns>
        public string get_name_giaovien(string usname)
        {
            try
            {
                int id = AccountDAO.Instance.Get_ID(usname);
                return GiaoVienDAO.Instance.Get_Name(id);
            }
            catch
            {
                return null;
            }

        }

        public DataTable selectGiaoViens()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(GiaoVienDAO.Instance.Select_All_GiaoVien());
            }
            catch
            {
                return null;
            }

        }

        #endregion
    }
}
