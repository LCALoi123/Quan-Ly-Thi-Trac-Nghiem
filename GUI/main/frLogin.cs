using BUS;
using DTO;
using GUI.Admin;
using GUI.HocSinh;
using GUI.GiaoVien;
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
    public partial class frLogin : Form
    {
        /// <summary>
        /// textbox: tbTenDanhNhap, tbMatKhau
        /// button: btDangNhap, btDangKy
        /// </summary>
        public frLogin()
        {
            InitializeComponent();
        }
        #region event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
            
        }

        private void TbTenDangNhap_Click(object sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "Nhập tên đăng nhập...")
            {
                tbTenDangNhap.Text = "";
            }
        }

        private void TbMatKhau_Click(object sender, EventArgs e)
        {
            if (tbMatKhau.Text == "Nhập mật khẩu ...")
            {
                tbMatKhau.Text = "";

            }

        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TbMatKhau_TextChanged(object sender, EventArgs e)
        {
            tbMatKhau.UseSystemPasswordChar = true;
        }

        private void LlbDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frRegister register = new frRegister();
            register.ShowDialog();
            this.Show();
        }
        private void PtbExit_MouseHover(object sender, EventArgs e)
        {
            ptbExit.BackColor = Color.Red;
        }

        private void PtbExit_MouseLeave(object sender, EventArgs e)
        {
            ptbExit.BackColor = Color.Transparent;
        }
        /// <summary>
        /// sự kiện click cho nút đăng ký
        /// hàm này sẽ chuyển người dùng đến from đăng ký
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDangKy_Click(object sender, EventArgs e)
        {
           

            this.Hide();
            frRegister register = new frRegister();
            register.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// validating control cho textbox tên tài khoảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Tên tài khoảng phải > 6 ký tự và" +
                " phải gồm ký tự không có ký tự HOA, bắt đầu bởi ký tự a-z, không khoảng trắng và các ký tự đặc biệt";
            validator(ctrl, msg, RgPattern.Username, e);
        }

        /// <summary>
        /// validating control cho textbox Mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbMatKhau_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            string msg = "Mật khẩu phải > 6 ký tự và không chứa khoảng trắng";
            validator(ctrl, msg, RgPattern.PassWord, e);
        }
        /// <summary>
        /// sự kiện khi form đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrLogin_FormClosing(object sender, FormClosingEventArgs e)
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
        #endregion

        #region method
        /// <summary>
        /// thực hiện validate chon control tương ứng và thông báo (message) nếu sai điều kiên (pattern) của chuỗi
        /// </summary>
        /// <param name="ctrl">Control in sender</param>
        /// <param name="msg">một Message thông báo lỗi cho validate</param>
        /// <param name="pattern">chuỗi điều kiện của validate</param>
        /// <param name="e">e in CancelEventArgs</param>
        private void validator(Control ctrl,string msg,string pattern, CancelEventArgs e)
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
        private void DangNhap()
        {
            string phanhe = AccountBUS.Instance.DangNhap(tbTenDangNhap.Text, tbMatKhau.Text);
            if (phanhe != "")
            {
                Form fr = new Form();
                if (phanhe == "Học Sinh") fr = new frHocSinh(tbTenDangNhap.Text);

                if (phanhe == "Giáo Viên") fr = new frGiaoVien(tbTenDangNhap.Text);

                if (phanhe == "Admin") fr = new frAdmin(tbTenDangNhap.Text);

                this.Hide();
                fr.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Sai Tên đăng nhập hoặc mật khẩu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
