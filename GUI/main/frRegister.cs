using BUS;
using DTO;
using GUI.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// textbox: tbTenDangNhap,tbMatKhau
    /// comboBox:cbbPhanHe
    /// button: btDangKy
    /// </summary>
    public partial class frRegister : Form
    {
        public frRegister()
        {
            InitializeComponent();
            cbbPhanHe.SelectedIndex = 2;
        }
        #region event
        /// <summary>
        /// sự kiện button click cho nút đăng ký
        /// kiểm tra thông tin mà người dùng điền vào 
        /// nếu hợp lệ thì sẽ gọi lại hàm đăng ký
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDangKy_Click(object sender, EventArgs e)
        {
                DangKy();
        }
        /// <summary>
        /// validating control cho textbox tên đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Tên đăng nhập phải > 6 ký tự và" +
                " phải gồm ký tự không có ký tự HOA, bắt đầu bởi ký tự a-z, không khoảng trắng và các ký tự đặc biệt";
            validator(ctrl, msg, RgPattern.Username, e);
        }

        /// <summary>
        /// validating control cho textbox mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMatKhau_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Mật khẩu phải > 6 ký tự và không chứa khoảng trắng";
            validator(ctrl, msg, RgPattern.PassWord, e);
        }

        private void frRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không", "Tìm Thấy Lỗi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    Application.Exit();
                }
            }
        }
        private void PtbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbMatKhau_TextChanged(object sender, EventArgs e)
        {
            tbMatKhau.UseSystemPasswordChar = true;
            if (tbMatKhau.Text == "Nhập mật khẩu ...")
            {
                tbMatKhau.Text = "";
            }
        }

        private void TbMatKhau_Click(object sender, EventArgs e)
        {
            if (tbMatKhau.Text == "Nhập mật khẩu ...")
            {
                tbMatKhau.Text = "";
            }
        }

        private void TbTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "Nhập tên đăng nhập ...")
            {
                tbTenDangNhap.Text = "";
            }

        }

        private void TbTenDangNhap_Click(object sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "Nhập tên đăng nhập ...")
            {
                tbTenDangNhap.Text = "";
            }
        }
        #endregion

        #region method
        /// <summary>
        /// hàm này thực hiện lưu trữ thông tin mà người dùng điền vào
        /// sao đó gữi thông tin sang form đăng ký tương ứng
        /// </summary>
        private void DangKy()
        {
            AccountDTO account = new AccountDTO();
            account.USName = tbTenDangNhap.Text;
            account.PassWord = tbMatKhau.Text;
            account.PhanHe = cbbPhanHe.Text;
            Form fr;
            if (account.PhanHe == "Học Sinh")
            {
                fr = new frRegisterHocSinh(account);
                this.Hide();
                fr.ShowDialog();
                this.Show();
                this.Dispose();

            }
            if (account.PhanHe == "Giáo Viên")
            {
                fr = new frRegisterGiaoVien(account);
                this.Hide();
                fr.ShowDialog();
                this.Show();
                this.Dispose();
            }
            if (account.PhanHe == "Admin")
            {
                fr = new frAdmin(account.USName);
                AccountBUS.Instance.DangKyAccount(account);

                AdminDTO adminDTO = new AdminDTO();
                int IDus = AccountBUS.Instance.get_id_max_in_account();
                adminDTO.IDus = IDus;

                AdminBUS.Instance.DangKyAdmin(adminDTO);
                this.Hide();
                fr.ShowDialog();
                this.Show();
                this.Dispose();
            }
           
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
