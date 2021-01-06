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

namespace GUI.GiaoVien
{
    public partial class frGiaoVien : Form
    {
        public frGiaoVien()
        {
            InitializeComponent();
        }
        private string usname;
        public frGiaoVien(string username) : this()
        {
            usname = username;
        }

        #region Load
        private void FrGiaoVien_Load(object sender, EventArgs e)
        {
            sttLbName.Text = "Xin chào: " + GiaoVienBUS.Instance.get_name_giaovien(usname);
            Load_thongtingiaovien();
            Load_CauHoi();
            Load_DeThi();
            Load_HocSinh();
            Load_KyThi();
            Load_cbbMaDe();
            Loadnoidungthemkythithu();
            Load_KyThiThu();

        }
        #endregion
        #region trang chủ

        #region event
        KyThi kiThiselected = new KyThi();
        private void dgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                kiThiselected.MaKyThi = dgvKyThi.Rows[e.RowIndex].Cells["MaKyThi"].Value.ToString();
                btXoaKyThi.Enabled = true;
                btSuaKyThi.Enabled = true;
            }
            catch
            {
                btXoaKyThi.Enabled = false;
                btSuaKyThi.Enabled = false;
            }
            
        }
        private void btXoaKyThi_Click(object sender, EventArgs e)
        {
            if (KyThiBUS.Instance.Delete_KyThi(kiThiselected.MaKyThi))
            {
                MessageBox.Show("Xóa kỳ thi " + kiThiselected.MaKyThi + "Thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Xóa kỳ thi " + kiThiselected.MaKyThi + "Thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            Load_KyThi();
            btXoaKyThi.Enabled = false;
            btSuaKyThi.Enabled = false;
        }
        KyThiThu KyThiThuSelected = new KyThiThu();
        private void dgvKyThiThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                KyThiThuSelected.MaKyThi = dgvKyThiThu.Rows[e.RowIndex].Cells[0].Value.ToString();
                btXoaKyThiThu.Enabled = true;
                btSuaKyThiThu.Enabled = true;
            }
            catch
            {
                btXoaKyThiThu.Enabled = false;
                btSuaKyThiThu.Enabled = false;
            }

        }
        private void btXoaKyThiThu_Click(object sender, EventArgs e)
        {
            if(KyThiThuBUS.Instance.Delete_kyThiThu(KyThiThuSelected.MaKyThi))
            {
                MessageBox.Show("Xóa kỳ thi thử " + KyThiThuSelected.MaKyThi + "Thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Xóa kỳ thi thử" + KyThiThuSelected.MaKyThi + "Thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            Load_KyThiThu();
            btXoaKyThiThu.Enabled = false;
            btSuaKyThiThu.Enabled = false;
        }
        #endregion
        #region method

        #endregion

        #endregion
        /* */
        #region CaNhan
        /** ===================================================================== **/
        #region event
        /// <summary>
        /// đăng xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                tbHoTen.Enabled = true;

            }
            else
            {
                btSuaThongTin.Text = "Sửa thông tin";
                Update_thongtin();
                sttLbName.Text = "Xin chào: " + GiaoVienBUS.Instance.get_name_giaovien(usname);
                tbHoTen.Enabled = false;

            }
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
        #endregion
        /** ===================================================================== **/
        #region method
        /// <summary>
        /// cập nhật thông tin cá nhân
        /// </summary>
        private void Update_thongtin()
        {
            GiaoVienBUS.Instance.update_giaovien(usname, tbHoTen.Text);
        }
        /// <summary>
        /// load thông tin cá nhân
        /// </summary>
        private void Load_thongtingiaovien()
        {
            lbthongbao.Text = "";


            tbHoTen.Text = GiaoVienBUS.Instance.get_name_giaovien(usname);
            tbHoTen.Enabled = false;
        }
        #endregion

        #endregion

        /* */
        #region CauHoi
        /** ===================================================================== **/
        #region event
        /// <summary>
        /// sự kiện thêm một câu hỏi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtThemCauHoi_Click(object sender, EventArgs e)
        {
            (new frThemCauHoi()).ShowDialog();
            Load_CauHoi();

        }
        /// <summary>
        /// sự kiện thêm danh sách câu hỏi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtThemDanhSachCauHoi_Click(object sender, EventArgs e)
        {
            (new frThemDsCauHoi()).ShowDialog();
            Load_CauHoi();
        }
        /// <summary>
        /// sửa thông tin câu hỏi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSuaCuaHoi_Click(object sender, EventArgs e)
        {
            (new frSuaCauHoi(cauHoiRowSelect)).ShowDialog();
            Load_CauHoi();
        }
        private void DgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                select_Row_CauHoi(dgvCauHoi, e.RowIndex);
        }
        private void cbbMaDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCauHoi.DataSource = CauHoiBUS.Instance.SelectCauHois(cbbMaDe.Text);
        }
        private void btCauHoiDongGop_Click(object sender, EventArgs e)
        {
            (new frCauHoiDongGop()).ShowDialog();
            Load_CauHoi();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            (new frEPCauHoi()).ShowDialog();
        }
        #endregion
        /** ===================================================================== **/
        #region method

        /// <summary>
        /// Load thông tin câu hỏi lên datagridview
        /// </summary>
        private void Load_CauHoi()
        {
            dgvCauHoi.DataSource = CauHoiBUS.Instance.SelectCauHois();
            dgvCauHoiThem.DataSource = CauHoiBUS.Instance.SelectCauHois();
            try
            {
                select_Row_CauHoi(dgvCauHoi, 0);
            }
            catch
            {

            }
        }
        private void Load_cbbMaDe()
        {
            cbbMaDe.DataSource = DeBUS.Instance.LayDSMaDe();
            cbbMaDe.Text = " ";

        }
        #endregion

        #endregion

        /*  */
        #region DeThi
        /** ===================================================================== **/
        #region event
        int rowCauHoithem = -1;
        private void DgvCauHoiThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            select_Row_CauHoi(dgvCauHoiThem, e.RowIndex);
            rowCauHoithem = e.RowIndex;
            btThemCHDe.Enabled = true;

        }

        private void BtThemCHDe_Click(object sender, EventArgs e)
        {
            btThemDeThi.Enabled = true;
            if (rowCauHoithem >= 0)
            {
                dgvCauHoiDuocThem.Rows.Add(cauHoiRowSelect.IdCH, cauHoiRowSelect.CauHoi, cauHoiRowSelect.DapAnA
                    , cauHoiRowSelect.DapAnB, cauHoiRowSelect.DapAnC, cauHoiRowSelect.DapAnD, cauHoiRowSelect.DapAnDung, cauHoiRowSelect.DoKho);
                dgvCauHoiThem.Rows.RemoveAt(rowCauHoithem);
                rowCauHoithem = -1;
            }
            btThemCHDe.Enabled = false;
        }

        private void BtThemDeThi_Click(object sender, EventArgs e)
        {
            if (tbMaDe.Text == "" || tbTenDe.Text == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin mã đề và tên đề!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DeThiDTO de = new DeThiDTO();
                de.MaDe = tbMaDe.Text;
                de.TenDe = tbTenDe.Text;
                DeBUS.Instance.Insert_DeThi(de);
                for (int i = 0; i < dgvCauHoiDuocThem.Rows.Count; i++)
                {
                    CT_DethiDTO ct = new CT_DethiDTO();
                    ct.MaDe = de.MaDe;
                    ct.IDch = int.Parse(dgvCauHoiDuocThem.Rows[i].Cells[0].Value.ToString());
                    DeBUS.Instance.Insert_CT_DeThi(ct);
                }
                MessageBox.Show("Đã thêm đề thi " + de.TenDe, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                dgvCauHoiThem.DataSource = CauHoiBUS.Instance.SelectCauHois();
                dgvCauHoiDuocThem.Rows.Clear();
                tbMaDe.Text = "";
                tbTenDe.Text = "";
                Load_DeThi();
            }
        }
        private void btHuyDeThi_Click(object sender, EventArgs e)
        {
            dgvCauHoiDuocThem.Rows.Clear();
            tbMaDe.Text = "";
            tbTenDe.Text = "";
            dgvCauHoiThem.DataSource = CauHoiBUS.Instance.SelectCauHois();
        }
        #endregion
        /** ===================================================================== **/
        #region method
        private void Load_DeThi()
        {
            dgvDeThi.DataSource = null;
            dgvDeThi.DataSource = DeBUS.Instance.SelectDethis();
        }

        #endregion
        #endregion

        /* */
        #region KyThi
        /** ===================================================================== **/
        #region event
      
        DeThiDTO DethiRowSelected = new DeThiDTO();
        int RowDeThiThem = -1;
        private void dgvDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowDeThiThem = e.RowIndex;
            DethiRowSelected = select_Row_DeThi(dgvDeThi, RowDeThiThem);
            btThemVaoDsDeThi.Enabled = true;
            
        }
        private void btThemVaoDsDeThi_Click(object sender, EventArgs e)
        {
            btAddKyThi.Enabled = true;
            if (RowDeThiThem >= 0)
            {
                dgvDeThiThem.Rows.Add(DethiRowSelected.MaDe, DethiRowSelected.TenDe);
                dgvDeThi.Rows.RemoveAt(RowDeThiThem);
                RowDeThiThem = -1;
            }
            btThemVaoDsDeThi.Enabled = false;
        }
        private void dgvDanhSachHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                dgvDanhSachHocSinhThem.Rows.Add(dgvDanhSachHocSinh.Rows[row].Cells[0].Value,
                                                dgvDanhSachHocSinh.Rows[row].Cells[1].Value,
                                                dgvDanhSachHocSinh.Rows[row].Cells[2].Value,
                                                dgvDanhSachHocSinh.Rows[row].Cells[3].Value);
                dgvDanhSachHocSinh.Rows.RemoveAt(row);
            }
        }
        private void dgvDanhSachHocSinhThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                dgvDanhSachHocSinh.Rows.Add(dgvDanhSachHocSinhThem.Rows[row].Cells[0].Value,
                                            dgvDanhSachHocSinhThem.Rows[row].Cells[1].Value,
                                            dgvDanhSachHocSinhThem.Rows[row].Cells[2].Value,
                                            dgvDanhSachHocSinhThem.Rows[row].Cells[3].Value);
                dgvDanhSachHocSinhThem.Rows.RemoveAt(row);
            }
        }
        private void btAddKyThi_Click(object sender, EventArgs e)
        {
            if(tbMaKyThi.Text == "" || tbTenKyThi.Text == "" )
            {
                MessageBox.Show("Điền đầy đủ thông tin mã đề và tên đề!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //thêm kỳ thi
                KyThiDTO kyThi = new KyThiDTO();
                kyThi.MaKyThi = tbMaKyThi.Text;
                kyThi.TenKyThi = tbTenKyThi.Text;
                kyThi.NgayThi = dtNgayThi.Value.ToString();
                KyThiBUS.Instance.Insert_KyThi(kyThi);
                //thêm chi tiết kỳ thi
                CT_KyThiDTO ctKT = new CT_KyThiDTO();
                ctKT.MaKyThi = kyThi.MaKyThi;
                for (int i = 0; i < dgvDeThiThem.Rows.Count; i++)
                {
                    ctKT.MaDe = dgvDeThiThem.Rows[i].Cells[0].Value.ToString();
                    KyThiBUS.Instance.Insert_CT_KyThi(ctKT);
                }
                //Thêm chi tiết học sinh kỳ thi
                CT_HocSinh_kyThiDTO ctHS = new CT_HocSinh_kyThiDTO();
                ctHS.MaKyThi = kyThi.MaKyThi;
                for (int i = 0; i < dgvDanhSachHocSinhThem.Rows.Count; i++)
                {
                    ctHS.IDhs = int.Parse(dgvDanhSachHocSinhThem.Rows[i].Cells[0].Value.ToString());
                    KyThiBUS.Instance.Insert_CT_HocSinh_KyThi(ctHS);
                }
                //load về trạng thái ban đầu
                ClearAdd_KyThi();
                MessageBox.Show("Đã thêm kỳ thì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Load_KyThi();
        }
        private void btHuyKyThi_Click(object sender, EventArgs e)
        {
            ClearAdd_KyThi();
        }
        #endregion
        /** ===================================================================== **/
        #region method
        private void Load_HocSinh()
        {
            //dgvDanhSachHocSinh.DataSource = selectBUS.Instance.selectHocSinhs();
            dgvDanhSachHocSinh.Rows.Clear();
            DataTable data = HocSinhBUS.Instance.selectHocSinhs();
            foreach(DataRow row in data.Rows)
            {
                dgvDanhSachHocSinh.Rows.Add(row[0], row[1], row[5], row[2]);
            }
        }
        private void Load_KyThi()
        {
            dgvKyThi.DataSource = KyThiBUS.Instance.SelectKyThis();
            try
            {
                lbMaKyThi.DataBindings.Add("Text", dgvKyThi.DataSource, "MaKyThi");
            }
            catch
            {

            }
            
        }
        private void ClearAdd_KyThi()
        {
            tbMaKyThi.Text = "";
            tbTenKyThi.Text = "";
            Load_DeThi();
            Load_HocSinh();
            dgvDeThiThem.Rows.Clear();
            dgvDanhSachHocSinhThem.Rows.Clear();
        }
        #endregion
        #endregion

        #region KyThiThu

        #region event
        private void btTaoKyThiThu_Click(object sender, EventArgs e)
        {
            if(tbMaKyThiThu.Text != "" && tbTenKyThiThu.Text != "")
            {
                ThemKyThiThu();
                MessageBox.Show("Đã thêm kỳ thi thử " + tbTenKyThiThu.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("thêm kỳ thi thử " + tbTenKyThiThu.Text+" thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void dgvDeThiThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDeThithuThem.Rows.Add(dgvDeThiThu.Rows[e.RowIndex].Cells[0].Value,
                                        dgvDeThiThu.Rows[e.RowIndex].Cells[1].Value);
                dgvDeThiThu.Rows.RemoveAt(e.RowIndex);
            }
            catch
            {
                
            }
        }
        private void dgvDeThithuThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                try
                {
                    dgvDeThiThu.Rows.Add(dgvDeThithuThem.Rows[e.RowIndex].Cells[0].Value,
                                           dgvDeThithuThem.Rows[e.RowIndex].Cells[1].Value);
                    dgvDeThithuThem.Rows.RemoveAt(e.RowIndex);
                }
                catch 
                {

                }
            }
        }
        private void dgvHocSinhThiThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btTaoKyThiThu.Enabled = true;
            try
            {
                dgvHocSinhThiThuThem.Rows.Add(dgvHocSinhThiThu.Rows[e.RowIndex].Cells[0].Value,
                                dgvHocSinhThiThu.Rows[e.RowIndex].Cells[1].Value,
                                dgvHocSinhThiThu.Rows[e.RowIndex].Cells[2].Value,
                                dgvHocSinhThiThu.Rows[e.RowIndex].Cells[3].Value);
                dgvHocSinhThiThu.Rows.RemoveAt(e.RowIndex);
            }
            catch { }

        }

        private void dgvHocSinhThiThuThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvHocSinhThiThu.Rows.Add(dgvHocSinhThiThuThem.Rows[e.RowIndex].Cells[0].Value,
                                          dgvHocSinhThiThuThem.Rows[e.RowIndex].Cells[1].Value,
                                          dgvHocSinhThiThuThem.Rows[e.RowIndex].Cells[2].Value,
                                          dgvHocSinhThiThuThem.Rows[e.RowIndex].Cells[3].Value);
                dgvHocSinhThiThuThem.Rows.RemoveAt(e.RowIndex);
            }
            catch { }

        }
        #endregion

        #region method

        private void ThemKyThiThu()
        {
            KyThiThu ktt = new KyThiThu();
            ktt.MaKyThi = tbMaKyThiThu.Text;
            ktt.TenKyThi = tbTenKyThiThu.Text;
            ktt.NgayBD = dtNgayBD.Value;
            ktt.NgayKT = dtNgayKT.Value;

            KyThiThuBUS.Instance.Insert_KyThiThu(ktt);

            //thêm chi tiết kỳ thi thử
            CT_KyThiThu ctKT = new CT_KyThiThu();
            ctKT.MaKyThi = ktt.MaKyThi;
            for (int i = 0; i < dgvDeThithuThem.Rows.Count; i++)
            {
                ctKT.MaDe = dgvDeThithuThem.Rows[i].Cells[0].Value.ToString();
                KyThiThuBUS.Instance.Insert_CT_KyThiThu(ctKT);
            }
            //Thêm chi tiết học sinh kỳ thi
            CT_HOCSINH_KyThiThu ctHS = new CT_HOCSINH_KyThiThu();
            ctHS.MaKyThi = ktt.MaKyThi;
            for (int i = 0; i < dgvHocSinhThiThuThem.Rows.Count; i++)
            {
                ctHS.IDhs = int.Parse(dgvHocSinhThiThuThem.Rows[i].Cells[0].Value.ToString());
                KyThiThuBUS.Instance.Insert_CT_HocSinh_KyThiThu(ctHS);
            }
            Loadnoidungthemkythithu();
            Load_KyThiThu();

        }
        private void Loadnoidungthemkythithu()
        {
            dgvDeThiThu.DataSource = DeBUS.Instance.SelectDethis();
            dgvHocSinhThiThu.DataSource = HocSinhBUS.Instance.selectHocSinhs();
            dgvHocSinhThiThuThem.Rows.Clear();
            dgvDeThithuThem.Rows.Clear();
            tbMaKyThiThu.Text = "";
            tbTenKyThiThu.Text = "";
        }
        private void Load_KyThiThu()
        {
            dgvKyThiThu.DataSource = KyThiThuBUS.Instance.SelectKyThiThus();
        }

        #endregion

        #endregion


        #region method
        CauHoiDTO cauHoiRowSelect = new CauHoiDTO();
        private void select_Row_CauHoi(DataGridView gridView,int n)
        {
            try
            {
                cauHoiRowSelect.IdCH = int.Parse(gridView.Rows[n].Cells[0].Value.ToString());
                cauHoiRowSelect.CauHoi = gridView.Rows[n].Cells[1].Value.ToString();
                cauHoiRowSelect.DapAnA = gridView.Rows[n].Cells[2].Value.ToString();
                cauHoiRowSelect.DapAnB = gridView.Rows[n].Cells[3].Value.ToString();
                cauHoiRowSelect.DapAnC = gridView.Rows[n].Cells[4].Value.ToString();
                cauHoiRowSelect.DapAnD = gridView.Rows[n].Cells[5].Value.ToString();
                cauHoiRowSelect.DapAnDung = gridView.Rows[n].Cells[6].Value.ToString();
                cauHoiRowSelect.DoKho = int.Parse(gridView.Rows[n].Cells[7].Value.ToString());
            }
            catch { }
        }
        private DeThiDTO select_Row_DeThi(DataGridView gridView, int n)
        {
            try { 
                DeThiDTO deThiRowSelect = new DeThiDTO();
                deThiRowSelect.MaDe = gridView.Rows[n].Cells[0].Value.ToString();
                deThiRowSelect.TenDe = gridView.Rows[n].Cells[1].Value.ToString();
                return deThiRowSelect;
            }
            catch { return null; }
        }

















        #endregion

        private void btKetQua_Click(object sender, EventArgs e)
        {
            (new frBangDiem()).ShowDialog();
        }

        private void btThiSinh_Click(object sender, EventArgs e)
        {
            string makt = lbMaKyThi.Text;
            (new frBangDiem(makt)).ShowDialog();
        }

        private void dgvKyThiThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbkt_Click(object sender, EventArgs e)
        {

        }
    }
}
