using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.HocSinh
{
    public partial class frHocSinh : Form
    {
        public frHocSinh()
        {
            InitializeComponent();
            
        }

        private string usname;
        public frHocSinh(string username) : this()
        {
            usname = username;
        }
        #region event
        private void FrHocSinh_Load(object sender, EventArgs e)
        {
            SttLbusName.Text ="Xin chào: "+ HocSinhBUS.Instance.get_name_hocsinh(usname);
            load_thongtinhocsinh();
            Load_KyThi();
            Load_kyThiThu();
            Load_KetQua();
            LoadCauHoiDaDongGop();
        }
        /// <summary>
        /// cập nhật thông tin cá nhân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSuaThongTin_Click(object sender, EventArgs e)
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
                SttLbusName.Text = "Xin chào: " + HocSinhBUS.Instance.get_name_hocsinh(usname);
                Non_Enabled_lable();
            }
        }
        /// <summary>
        /// đăng cuất account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// đổi mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCapNhat_Click(object sender, EventArgs e)
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

        CT_KyThiDTO ctSender = new CT_KyThiDTO();
        string tenKyThi = "";
        string tende = "";
        private void dgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                KyThiDTO kt = new KyThiDTO();

                    kt = selected_row_kythi(dgvKyThi, e.RowIndex);
                    lbTenKyThi.Text = kt.TenKyThi;
                    tenKyThi = kt.TenKyThi;
                    cbbTenDe.DataSource = DeBUS.Instance.SelectDanhSachTenDe(kt.MaKyThi);

                    ctSender.MaKyThi = kt.MaKyThi;

                btLamBaiThi.Enabled = true;

            }
            catch
            {
                btLamBaiThi.Enabled = false;
            }
        }

        
        private void btLamBaiThi_Click(object sender, EventArgs e)
        {
            if (lbTenKyThi.Text != "__________________")
            {
                string[] dethi = cbbTenDe.Text.Split('|');
                ctSender.MaDe = dethi[0];
                tende = dethi[1];
                HocSinhDTO hs = HocSinhBUS.Instance.get_HocSinh(usname);
                (new frLamBaiTracNghiem(ctSender,hs.IdHS, SttLbusName.Text,tende,tenKyThi)).ShowDialog();
                Load_KetQua();
            }
            else
            {
                MessageBox.Show("Chưa chọn kỳ thi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvKyThiThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbtenkythithu.Text = dgvKyThiThu.Rows[e.RowIndex].Cells[1].Value.ToString();
                string makt = dgvKyThiThu.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbdethithu.DataSource = DeBUS.Instance.SelectDanhSachTenDeThiThu(makt);
                string[] dethi = cbbdethithu.Text.Split('|');
                kttsender.MaDe = dethi[0];
                kttsender.MaKyThi = makt;
                btThiThu.Enabled = true;
            }
            catch
            {
                btThiThu.Enabled = false;
            }
        }
        CT_KyThiThu kttsender = new CT_KyThiThu();
        private void btThiThu_Click(object sender, EventArgs e)
        {
            if(lbtenkythithu.Text != "__________________")
            {
                
                HocSinhDTO hs = HocSinhBUS.Instance.get_HocSinh(usname);
                string[] dethi = cbbdethithu.Text.Split('|');
                kttsender.MaDe = dethi[0];
                (new frOnThiTuLuyen(kttsender, hs.IdHS, SttLbusName.Text, dethi[1], lbtenkythithu.Text)).ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn kỳ thi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btDongGop_Click(object sender, EventArgs e)
        {
            DongGopCauHoi();
        }
        #endregion

        #region method
        /// <summary>
        /// load thông tin cá nhân
        /// </summary>
        private void load_thongtinhocsinh()
        {
            lbthongbao.Text = "";

            HocSinhDTO hs = HocSinhBUS.Instance.get_HocSinh(usname);
            tbHoTen.Text = hs.TenHS;
            tbLop.Text = hs.LopHoc;
            tbKhoi.Text = hs.KhoiLop;
            tbNgaySinh.Text = hs.NgaySinh;
            Non_Enabled_lable();
        }
        /// <summary>
        /// không cho phép nhập dữ liệu vào các lable thông tin cá nhân
        /// </summary>
        private void Non_Enabled_lable()
        {
            tbHoTen.Enabled = false;
            tbLop.Enabled = false;
            tbKhoi.Enabled = false;
            tbNgaySinh.Enabled = false;
        }
        /// <summary>
        /// cho phép nhập dữ liệu vào các lable thông tin cá nhân
        /// </summary>
        private void Enabled_lable()
        {
            tbHoTen.Enabled = true;
            tbLop.Enabled = true;
            tbKhoi.Enabled = true;
            tbNgaySinh.Enabled = true;
        }
        /// <summary>
        /// cập nhật thông tin cá nhân
        /// </summary>
        private void Update_thongtin()
        {
            HocSinhDTO hocSinhDTO = new HocSinhDTO();
            hocSinhDTO.TenHS = tbHoTen.Text;
            hocSinhDTO.LopHoc = tbLop.Text;
            hocSinhDTO.KhoiLop = tbKhoi.Text;
            hocSinhDTO.NgaySinh = tbNgaySinh.Text;

            HocSinhBUS.Instance.update_hocsinh(usname, hocSinhDTO);
        }
        private void Load_KyThi()
        {
            int idus = AccountBUS.Instance.get_ID_account(usname);
            int idhs = HocSinhBUS.Instance.SelectIDhs(idus);
            dgvKyThi.DataSource = KyThiBUS.Instance.SelectKyThis(idhs);

        }
        private void Load_kyThiThu()
        {
            int idus = AccountBUS.Instance.get_ID_account(usname);
            int idhs = HocSinhBUS.Instance.SelectIDhs(idus);
            dgvKyThiThu.DataSource = KyThiThuBUS.Instance.SelectKyThiThus(idhs);
        }
        private void Load_KetQua()
        {
            int idus = AccountBUS.Instance.get_ID_account(usname);
            dgvKetQua.DataSource = DiemBUS.Instance.SelectBangDiem(HocSinhBUS.Instance.SelectIDhs(idus));
        }
        private KyThiDTO selected_row_kythi(DataGridView dgvKyThi,int n)
        {
            try
            {
                KyThiDTO kyThi = new KyThiDTO();

                kyThi.MaKyThi = dgvKyThi.Rows[n].Cells[0].Value.ToString();
                kyThi.TenKyThi = dgvKyThi.Rows[n].Cells[1].Value.ToString();
                kyThi.NgayThi = dgvKyThi.Rows[n].Cells[2].Value.ToString();

                return kyThi;
            }
            catch
            {
                return null;
            }
        }

        private void DongGopCauHoi()
        {
            int idus = AccountBUS.Instance.get_ID_account(usname);

            CauHoiDongGopDTO cauHoi = new CauHoiDongGopDTO();
            cauHoi.IDhs = HocSinhBUS.Instance.SelectIDhs(idus);
            cauHoi.CauHoi = rtbCauHoi.Text;
            cauHoi.DapAnA = rtbDapAnA.Text;
            cauHoi.DapAnB = rtbDapAnB.Text;
            cauHoi.DapAnC = rtbDapAnC.Text;
            cauHoi.DapAnD = rtbDapAnD.Text;

            if (string.IsNullOrEmpty(cauHoi.CauHoi) || string.IsNullOrEmpty(cauHoi.DapAnA) || string.IsNullOrEmpty(cauHoi.DapAnB)
                || string.IsNullOrEmpty(cauHoi.DapAnC) || string.IsNullOrEmpty(cauHoi.DapAnD))
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin dữ liệu !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (RadioButton button in gbDapAn.Controls)
                {
                    if (button != null)
                        if (button.Checked)
                        {
                            cauHoi.DapAnDung = button.Text;
                            break;
                        }
                }
                try
                {
                    cauHoi.DoKho = int.Parse(cbbDoKho.Text);
                }
                catch
                {
                    MessageBox.Show("bạn chưa chọn độ khó", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CauHoiBUS.Instance.Insert_DongGopCauHoi(cauHoi);
                LoadCauHoiDaDongGop();
            }
        }
        private void LoadCauHoiDaDongGop()
        {
            int idus = AccountBUS.Instance.get_ID_account(usname);

            dgvCauHoiDongGop.DataSource = CauHoiBUS.Instance.SelectCauHoiDongGops(HocSinhBUS.Instance.SelectIDhs(idus));
        }



        #endregion

        private void btInBangDiem_Click(object sender, EventArgs e)
        {
            (new frInBangDiem(usname)).ShowDialog();
        }
    }
}
