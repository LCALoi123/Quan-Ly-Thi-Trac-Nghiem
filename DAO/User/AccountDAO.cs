using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Đây là class chứa các hàm truy vấn dữ liệu của bảng Account 
    /// và các hàm thủ tục liên quan đến account
    /// </summary>
    public class AccountDAO
    {
        #region singleton
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value;}
        }
        private AccountDAO() { }
        #endregion

        /// <summary Thêm một account>
        /// thực hiện câu truy vấn để thêm dữ liệu vào bảng account
        /// </summary>
        /// <param name="accountDTO"> giá trị truyền vào là dữ liệu cần thêm</param>
        public void InsertAccount(AccountDTO accountDTO)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                Account account = new Account();
                account.usName = accountDTO.USName;
                account.PassWord = accountDTO.PassWord;
                account.PhanHe = accountDTO.PhanHe;
                qltn.Accounts.InsertOnSubmit(account);
                qltn.SubmitChanges();
            }
           
            
        }
        /// <summary Xóa account>
        /// 
        /// </summary>
        public void DeleteAccount() { }
        /// <summary>
        /// cập nhật password cho account
        /// </summary>
        /// <param name="usname">tên tài khoảng</param>
        /// <param name="password">password mới</param>
        public void UpdateAccount(string usname,string password)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                try
                {
                    Account ac = qltn.Accounts.Single(p => p.usName == usname);
                    ac.PassWord = password;
                    qltn.SubmitChanges();
                }
                catch
                {

                }
            }
        }
        
        /// <summary lấy giá trị ID lớn nhất trong bảng account >
        /// hàm này thực hiện truy vấn dữ liệu từ database để lấy ID của bảng account
        /// </summary>
        /// <returns name = IDmax > Trả về giá trị lớn nhất của ID </returns>
        public int IDmax()
        {
            int IDmax = 0;
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                IDmax = qltn.Accounts.Max(a => a.ID);
            }
            return IDmax;
        }

        /// <summary>
        /// kiểm tra tài khoản có tồn tại không
        /// </summary>
        /// <param name="username">tên đăng nhập</param>
        /// <returns>trả về true nếu tài khoảng tồn tại ngược lại trả về false</returns>
        public bool isUsername(string username)
        {
            int num = 0;
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ac = from a in qltn.Accounts
                            where a.usName == username
                            select a;
                num = ac.Count();

            }
            if (num > 0)
                return true;
            return false;
        }

        /// <summary>
        /// kiểm tra mật khẩu có đúng cho tài khoản không
        /// </summary>
        /// <param name="username"> tên đăng nhập </param>
        /// <param name="pass"> mật khẩu </param>
        /// <returns>true nếu pass đúng false nếu pass sai</returns>
        public bool isPassword(string username,string pass)
        {
            int num = 0;
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ac = from a in qltn.Accounts
                         where a.usName == username && a.PassWord == pass
                         select a;
                num = ac.Count();

            }
            if (num > 0)
                return true;
            return false;
        }
        /// <summary>
        /// lấy phân hệ của tài khoảng đó
        /// </summary>
        /// <param name="username">tên đăng nhập</param>
        /// <returns>trả về phân hệ</returns>
        public string get_PhanHe(string username)
        {
            string PhanHe = "";
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ac = from a in qltn.Accounts
                         where a.usName == username 
                         select a.PhanHe;
                foreach(var n in ac)
                {
                    PhanHe = n;
                }
            }
            return PhanHe;
        }
        /// <summary>
        /// lấy id của account
        /// </summary>
        /// <param name="username">tên tài khoảng</param>
        /// <returns>ID</returns>
        public int Get_ID(string username)
        {
            int id = -1;
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ac = from a in qltn.Accounts
                         where a.usName == username
                         select a.ID;
                id = ac.First();
            }
            return id;
        }
    }
}
