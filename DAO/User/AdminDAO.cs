using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Đây là class chứa các hàm truy vấn dữ liệu của bảng admin 
    /// và các hàm thủ tục liên quan đến admin
    /// </summary>
    public class AdminDAO
    {
        #region singleton
        private static AdminDAO instance;

        public static AdminDAO Instance
        {
            get { if (instance == null) instance = new AdminDAO(); return AdminDAO.instance; }
            private set { AdminDAO.instance = value; }
        }
        private AdminDAO() {}
        #endregion

        #region method
        /// <summary>
        /// thêm thông tin admin
        /// </summary>
        /// <param name="adminDTO">giá trị truyền vào là thông tin tài khoảng của admin </param>
        public void InsertAdmin(AdminDTO adminDTO)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                Admin admin = new Admin();
                admin.IDus = adminDTO.IDus;
                qltn.Admins.InsertOnSubmit(admin);
                qltn.SubmitChanges();
            }
        }
        //sửa admin
        public void UpdateAdmin(int idus, AdminDTO adminDTO) {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                try
                {
                    Admin admin = qltn.Admins.Single(p => p.IDus == idus);
                    admin.HoTen = adminDTO.Hoten;
                    admin.UsName = adminDTO.Username;
                    admin.NgaySinh = DateTime.Parse(adminDTO.Ngaysinh);

                    qltn.SubmitChanges();
                }
                catch
                {

                }
            }
        }

     
        #endregion
    }
}
