using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountBUS
    {
        #region singleton
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return AccountBUS.instance; }
            private set { AccountBUS.instance = value; }
        }
        private AccountBUS() { }
        #endregion
        #region method
        /// <summary DangKyAccount DangKyAdmin DangKyHocSinh DangKyGiaoVien >
        /// thực hiện đăng ký gọi lại hàm từ lớp DAO
        /// </summary>
        /// <param name="accountDTO">thông tin usname và passwword của account</param>
        public void DangKyAccount(AccountDTO accountDTO)
        {
            try
            {
                AccountDAO.Instance.InsertAccount(accountDTO);
            }
            catch
            {

            }

            /*end*/
        }

        /// <summary>
        /// thay đổi password 
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <param name="password">password mới</param>
        public void update_password(string usname, string password)
        {
            try
            {
                AccountDAO.Instance.UpdateAccount(usname, password);
            }
            catch
            {

            }


        }

        /// <summary>
        /// hàm đăng nhập tài khoảng
        /// </summary>
        /// <param name="username">tên đăng nhập </param>
        /// <param name="password">mật khẩu </param>
        /// <returns>Trả về PhanHe nếu đăng nhập thành công, "" nếu tài khoảng không tồn tại </returns>
        public string DangNhap(string username, string password)
        {
            try
            {
                string PhanHe = "";
                if (AccountDAO.Instance.isUsername(username))
                {
                    if (AccountDAO.Instance.isPassword(username, password))
                    {
                        PhanHe = AccountDAO.Instance.get_PhanHe(username);
                    }
                }
                return PhanHe;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// gọi lại hàm lấy giá trị id max tron class AccountDAO ở project DAO
        /// </summary>
        /// <returns> trả về giá trị id lớn nhất của account </returns>
        public int get_id_max_in_account()
        {
            try
            {
                return AccountDAO.Instance.IDmax();
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// lấy thông tin ID của account
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <returns>ID</returns>
        public int get_ID_account(string usname)
        {
            try
            {
                return AccountDAO.Instance.Get_ID(usname);
            }
            catch
            {
                return 0;
            }

        }


        #endregion
    }
}
