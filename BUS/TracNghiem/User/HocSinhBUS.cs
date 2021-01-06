using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocSinhBUS
    {
        #region singleton
        private static HocSinhBUS instance;

        public static HocSinhBUS Instance
        {
            get { if (instance == null) instance = new HocSinhBUS(); return HocSinhBUS.instance; }
            private set { HocSinhBUS.instance = value; }
        }
        private HocSinhBUS() { }
        #endregion
        #region method
        public int SelectIDhs(int idus)
        {
            try
            {
                return HocSinhDAO.Instance.Get_IDhs(idus);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Thực hiện thêm thông tin cho hocsinh
        /// </summary>
        /// <param name="hocSinhDTO">thông tin của học sinh</param>
        public void DangKyHocSinh(HocSinhDTO hocSinhDTO)
        {
            try
            {
                HocSinhDAO.Instance.InsertHocSinh(hocSinhDTO);
            }
            catch
            {

            }

            /*end*/
        }

        /// <summary>
        /// cập nhật thông tin cho học sinh 
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <param name="hocSinh">thông tin của học sinh</param>
        public void update_hocsinh(string usname, HocSinhDTO hocSinh)
        {
            try
            {
                int idus = AccountDAO.Instance.Get_ID(usname);
                HocSinhDAO.Instance.UpdateHocSinh(idus, hocSinh);
            }
            catch
            {

            }

        }

        /// <summary>
        /// lấy thông tin họ tên của học sinh
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <returns>họ tên</returns>
        public string get_name_hocsinh(string usname)
        {
            try
            {
                int id = AccountDAO.Instance.Get_ID(usname);
                return HocSinhDAO.Instance.Get_Name(id);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// lấy thông tin cá nhân của học sinh
        /// </summary>
        /// <param name="usname">usname</param>
        /// <returns>hocsinh</returns>
        public HocSinhDTO get_HocSinh(string usname)
        {
            try
            {
                HocSinhDTO hocSinh = new HocSinhDTO();
                int Id = AccountDAO.Instance.Get_ID(usname);
                hocSinh = HocSinhDAO.Instance.Get_HocSinh(Id);
                return hocSinh;
            }
            catch
            {
                return null;
            }

        }

        public DataTable selectHocSinhs()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(HocSinhDAO.Instance.Select_All_HocSinh());
            }
            catch
            {
                return null;
            }

        }
        #endregion
    }
}
