using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI.Admin
{
    public partial class frAdmin : Form
    {
        public frAdmin()
        {
            InitializeComponent();
        }
        private string usname;
        public frAdmin(string username) : this()
        {
            usname = username;
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (tbmatkhaumoi.Text == tbnhaplai.Text)
            {
                AccountBUS.Instance.update_password(usname, tbmatkhaumoi.Text);
                lbthongbao.Text = "Đổi mật khẩu thành công";
            }
            else
                lbthongbao.Text = "Nhập lại mật khẩu không chính xác ";
            tbmatkhaumoi.Text = "";
            tbnhaplai.Text = "";
        }

        private void btSuaThongTin_Click(object sender, EventArgs e)
        {
            if (btSuaThongTin.Text == "Sửa thông tin")
            {
                btSuaThongTin.Text = "Cập nhật";
                Enabled_lable();
            }
            else
            {
                btSuaThongTin.Text = "Sửa thông tin";
                Update_thongtin();
                Non_Enabled_lable();
            }
        }
        #region method
        /// <summary>
        /// cập nhật thông tin cá nhân
        /// </summary>
        private void Non_Enabled_lable()
        {
            tbHoTen.Enabled = false;
            tbUserName.Enabled = false;
            tbNgaySinh.Enabled = false;
        }
        private void Enabled_lable()
        {
            tbHoTen.Enabled = true;
            tbUserName.Enabled = true;
            tbNgaySinh.Enabled = true;
        }
        private void Update_thongtin()
        {
            AdminDTO adminDTO = new AdminDTO();
            adminDTO.Hoten = tbHoTen.Text;
            adminDTO.Ngaysinh = tbNgaySinh.Text;
            adminDTO.Username = tbUserName.Text;
            AdminBUS.Instance.update_admin(usname, adminDTO);
        }
        #endregion

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #region method
        public void LoadData()
        {
            try
            {
                DataTable dt = GiaoVienBUS.Instance.selectGiaoViens();
                DataTable dtv = HocSinhBUS.Instance.selectHocSinhs();
                dgvGiaoVien.DataSource = dt;
                dgvHocSinh.DataSource = dtv;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void dgvGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                dgvGiaoVien.Rows.Add(dgvGiaoVien.Rows[row].Cells[0].Value,
                                                dgvGiaoVien.Rows[row].Cells[1].Value,
                                                dgvGiaoVien.Rows[row].Cells[2].Value);
                dgvGiaoVien.Rows.RemoveAt(row);
            }
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                dgvHocSinh.Rows.Add(dgvHocSinh.Rows[row].Cells[0].Value,
                                                dgvHocSinh.Rows[row].Cells[1].Value,
                                                dgvHocSinh.Rows[row].Cells[2].Value,
                                                dgvHocSinh.Rows[row].Cells[3].Value,
                                                dgvHocSinh.Rows[row].Cells[4].Value);
                dgvHocSinh.Rows.RemoveAt(row);
            }
        }
    }
}
