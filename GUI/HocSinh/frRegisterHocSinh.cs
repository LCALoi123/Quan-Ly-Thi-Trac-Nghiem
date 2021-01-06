using DTO;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.HocSinh;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class frRegisterHocSinh : Form
    {
        /// <summary>
        /// Họ tên: tbHoTen
        /// Lớp: tbLopHoc
        /// Khối: cbbKhoi
        /// Ngày sinh: dtpNgaySinh
        /// button đăng ký : btDangKy
        /// </summary>
        public frRegisterHocSinh()
        {
            
            InitializeComponent();
        }
        /// <summary>
        /// khởi tạo một class account để lưu trữ thông tin accout của người dùng đã đăng ký từ form account
        /// </summary>
        private AccountDTO account;

        /// <summary>
        /// xây dựng hàm tạo để lấy thôn tin account từ form đăng ký account
        /// </summary>
        /// <param name="accountDTO">class account </param>
        public frRegisterHocSinh(AccountDTO accountDTO) : this()
        {
            account = accountDTO;
        }

        #region event
        /// <summary>
        /// tạo sự kiện cho nút nút đăng ký
        /// kiểm tra xem dữ liệu có rỗng hay không
        /// nếu không rỗng thì gọi lại hàm đăng ký đồng thời chuyển sang form chính ở phân quyền Hoc Sinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDangKy_Click(object sender, EventArgs e)
        {
            if(tbHoTen.Text != "" && cbbKhoi.Text != "" && tbLopHoc.Text != "")
            {
                DangKy();
                frHocSinh frHocSinh = new frHocSinh(account.USName);
                this.Hide();
                frHocSinh.ShowDialog();
                this.Show();
                this.Dispose();
            }

        }


        /// <summary>
        /// validating control cho textbox họ tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbHoTen_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Họ Tên phải > 3 ký tự và không chứa chữ số" ;
            validator(ctrl, msg, RgPattern.Name, e);
        }

        /// <summary>
        /// validating control cho textbox lớp học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLopHoc_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Lớp phải > 2 ký tự và không chứa khoảng trắng ";
            validator(ctrl, msg, RgPattern.Lop, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrRegisterHocSinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không", "Thông Báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    Application.Exit();
                }
            }
        }
        #endregion

        #region method

        /// <summary>
        /// cài đặt thủ tục đăng ký một account cho 
        /// insert tất cả dữ liệu có được của account và hocsinh vào database
        /// sử dụng lại các hàm trong lớp BUS 
        /// </summary>
        private void DangKy()
        {
            AccountBUS.Instance.DangKyAccount(account);

            HocSinhDTO hocSinhDTO = new HocSinhDTO();
            hocSinhDTO.TenHS = tbHoTen.Text;
            hocSinhDTO.LopHoc = tbLopHoc.Text;
            hocSinhDTO.KhoiLop = cbbKhoi.Text;
            hocSinhDTO.NgaySinh = dtpNgaySinh.Value.ToString();
            int IDus = AccountBUS.Instance.get_id_max_in_account();
            hocSinhDTO.IDus = IDus;

            HocSinhBUS.Instance.DangKyHocSinh(hocSinhDTO);
        }
        /// <summary>
        /// thực hiện validate chon control tương ứng và thông báo (message) nếu sai điều kiên (pattern) của chuỗi
        /// </summary>
        /// <param name="ctrl">Control in sender</param>
        /// <param name="msg">một Message thông báo lỗi cho validate</param>
        /// <param name="pattern">chuỗi điều kiện của validate</param>
        /// <param name="e">e in CancelEventArgs</param>
        private void validator(Control ctrl, string msg, string pattern, CancelEventArgs e)
        {
            var re = new Regex(pattern);
            if (!re.IsMatch(ctrl.Text))
            {
                //errorProviderMain được add bên form thực thi
                errorProviderMain.SetError(ctrl, msg);
                e.Cancel = true;
            }
            else
            {
                errorProviderMain.SetError(ctrl, "");
            }
        }
        #endregion
    }
}
