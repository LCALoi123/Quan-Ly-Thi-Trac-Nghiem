using BUS;
using DTO;
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
    public partial class frRegisterGiaoVien : Form
    {
        /// <summary>
        /// Họ tên: tbHoTen
        /// button đăng ký: btDangKy
        /// </summary>
        public frRegisterGiaoVien()
        {
            InitializeComponent();
        }
        private AccountDTO account;
        public frRegisterGiaoVien(AccountDTO accountDTO): this()
        {
            account = accountDTO;
        }

        #region event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDangKy_Click(object sender, EventArgs e)
        {
            if (tbHoTen.Text != "")
            {
                DangKy();
                frGiaoVien frGiaoVien = new frGiaoVien(account.USName);
                this.Hide();
                frGiaoVien.ShowDialog();
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
            string msg = "Họ và tên phải > 6 ký tự và không được có ký tự đặc biệt hay số " +
                " ";
            validator(ctrl, msg, RgPattern.Name, e);
        }

        /// <summary>
        /// sự kiện khi form đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frRegisterGiaoVien_FormClosing(object sender, FormClosingEventArgs e)
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



        private void DangKy()
        {
            AccountBUS.Instance.DangKyAccount(account);

            GiaoVienDTO giaoVienDTO = new GiaoVienDTO();

            giaoVienDTO.TenGV = tbHoTen.Text;
            int IDus = AccountBUS.Instance.get_id_max_in_account();
            giaoVienDTO.Idus = IDus;

            GiaoVienBUS.Instance.DangKyGiaoVien(giaoVienDTO);
        }
        #endregion

    }
}
