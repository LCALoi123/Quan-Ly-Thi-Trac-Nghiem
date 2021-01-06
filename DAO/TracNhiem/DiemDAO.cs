using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DiemDAO
    {
        #region singleton
        private static DiemDAO instance;

        public static DiemDAO Instance
        {
            get { if (instance == null) instance = new DiemDAO(); return DiemDAO.instance; }
            private set { DiemDAO.instance = value; }
        }
        private DiemDAO() { }
        #endregion

        #region method
        public void Insert_Diem(DiemDTO diem)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                DiemThi insert = new DiemThi();
                insert.MaKyThi = diem.MaKyThi;
                insert.MaDe = diem.MaDe;
                insert.IDhs = diem.IdHS;
                insert.Diem = diem.Diem;
                qltn.DiemThis.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public List<BangDiemDTO> LayDSKetQua(int idhs)
        {
            List<BangDiemDTO> bd = new List<BangDiemDTO>();
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = from dt in qltn.DiemThis
                         from kt in qltn.KyThis
                         from det in qltn.DeThis
                         where dt.IDhs == idhs && kt.MaKyThi == dt.MaKyThi && det.MaDe == dt.MaDe
                         select new { kt.TenKyThi, det.TenDe, dt.Diem };
                foreach (var item in ch.ToList())
                {
                    BangDiemDTO tmp = new BangDiemDTO();
                    tmp.KyThi = item.TenKyThi;
                    tmp.DeThi = item.TenDe;
                    tmp.Diem = (float)item.Diem;
                    bd.Add(tmp);
                }
                return bd;
            }

        }
        public List<BangDiemThongKe> LayBangDiem()
        {
            List<BangDiemThongKe> bd = new List<BangDiemThongKe>();
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = from hs in qltn.HocSinhs
                         from dt in qltn.DiemThis
                         from kt in qltn.KyThis
                         from det in qltn.DeThis
                         where dt.IDhs == hs.IDhs && kt.MaKyThi == dt.MaKyThi && det.MaDe == dt.MaDe && kt.NgayThi < DateTime.Now
                         select new { hs.IDhs, hs.TenHS, hs.KhoiLop, hs.Lop, hs.NgaySinh, kt.TenKyThi, det.TenDe, dt.Diem };

                foreach (var item in ch.ToList())
                {
                    BangDiemThongKe tmp = new BangDiemThongKe();
                    tmp.IdHS = item.IDhs;
                    tmp.TenHS = item.TenHS;
                    tmp.KhoiLop = item.KhoiLop;
                    tmp.LopHoc = item.Lop;
                    tmp.NgaySinh = item.NgaySinh;
                    tmp.KyThi = item.TenKyThi;
                    tmp.DeThi = item.TenDe;
                    tmp.Diem = (float)item.Diem;
                    bd.Add(tmp);
                }

                return bd;
            }
        }
        public List<BangDiemThongKe> LayBangDiem(string makt)
        {
            List<BangDiemThongKe> bd = new List<BangDiemThongKe>();
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = from hs in qltn.HocSinhs
                         from dt in qltn.DiemThis
                         from kt in qltn.KyThis
                         from det in qltn.DeThis
                         where dt.IDhs == hs.IDhs && kt.MaKyThi == dt.MaKyThi && det.MaDe == dt.MaDe && kt.MaKyThi == makt && kt.NgayThi < DateTime.Now
                         select new { hs.IDhs, hs.TenHS, hs.KhoiLop, hs.Lop, hs.NgaySinh, kt.TenKyThi, det.TenDe, dt.Diem };

                foreach (var item in ch.ToList())
                {
                    BangDiemThongKe tmp = new BangDiemThongKe();
                    tmp.IdHS = item.IDhs;
                    tmp.TenHS = item.TenHS;
                    tmp.KhoiLop = item.KhoiLop;
                    tmp.LopHoc = item.Lop;
                    tmp.NgaySinh = item.NgaySinh;
                    tmp.KyThi = item.TenKyThi;
                    tmp.DeThi = item.TenDe;
                    tmp.Diem = (float)item.Diem;
                    bd.Add(tmp);
                }

                return bd;
            }
        }
        #endregion
    }
}
