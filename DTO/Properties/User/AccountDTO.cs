using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        /// <summary>
        /// id dùng để phân biệt các account với nhau
        /// usName là tên đăng nhập của người dùng
        /// PassWord là pass đănh nhaapk vào hệ thông
        /// phanHe dùng để phân hệ các người dùng là Học Sinh, Giáo Viên hay admin
        /// *** Lưu ý: admin không thể được tạo bằng cách đăng ký thông thường
        /// </summary>
        private int id;
        private string uSName;       
        private string passWord;
        private string phanHe;

        // --------------------------------------------------------------------------//

        public string USName { get => uSName; set => uSName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string PhanHe { get => phanHe; set => phanHe = value; }

    }
}
