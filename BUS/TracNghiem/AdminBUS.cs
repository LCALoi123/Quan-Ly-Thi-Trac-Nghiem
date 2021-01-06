using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AdminBUS
    {
        #region singleton
        private static AdminBUS instance;

        public static AdminBUS Instance
        {
            get { if (instance == null) instance = new AdminBUS(); return AdminBUS.instance; }
            private set { AdminBUS.instance = value; }
        }
        private AdminBUS() { }
        #endregion
        #region method
        /// <summary>
        /// Thực hiện thêm thông tin cho admin
        /// </summary>
        /// <param name="adminDTO">thông tin của admin</param>
        public void DangKyAdmin(AdminDTO adminDTO)
        {
            try
            {
                AdminDAO.Instance.InsertAdmin(adminDTO);
            }
            catch
            {

            }
        }
        public void update_admin(string usname, AdminDTO admin)
        {
            try
            {
                int idus = AccountDAO.Instance.Get_ID(usname);
                AdminDAO.Instance.UpdateAdmin(idus, admin);
            }
            catch
            {

            }

        }
        #endregion
    }
}
