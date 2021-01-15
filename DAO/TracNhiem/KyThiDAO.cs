using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KyThiDAO
    {
        #region singelton
        private static KyThiDAO instance;

        public static KyThiDAO Instance
        {
            get { if (instance == null) instance = new KyThiDAO(); return KyThiDAO.instance; }
            private set { KyThiDAO.instance = value; }
        }
        private KyThiDAO() { }
        #endregion

        #region method
        public void Insert_KyThi(KyThiDTO kyThi)
        {
            
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                KyThi insert = new KyThi();
                insert.MaKyThi = kyThi.MaKyThi;
                insert.TenKyThi = kyThi.TenKyThi;
                insert.NgayThi = DateTime.Parse(kyThi.NgayThi);
                qltn.KyThis.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public void Insert_CT_KyThi(CT_KyThiDTO cT_KyThi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CT_KyThi insert = new CT_KyThi();
                insert.MaKyThi = cT_KyThi.MaKyThi;
                insert.MaDe = cT_KyThi.MaDe;
                qltn.CT_KyThis.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public void Insert_CT_HocSinh_kyThi(CT_HocSinh_kyThiDTO ct)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CT_HOCSINH_KYTHI insert = new CT_HOCSINH_KYTHI();
                insert.MaKyThi = ct.MaKyThi;
                insert.IDhs = ct.IDhs;
                qltn.CT_HOCSINH_KYTHIs.InsertOnSubmit(insert);
                qltn.SubmitChanges();

            }
        }
        public List<KyThi> Select_KyThi()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                return qltn.KyThis.Select(a => a).ToList();
            }
        }
        public List<KyThi> Select_KyThi(int idus)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var kt = from ct in qltn.CT_HOCSINH_KYTHIs
                         from kts in qltn.KyThis
                         where ct.MaKyThi == kts.MaKyThi && ct.IDhs == idus
                         select kts;
                return kt.ToList();
            }
        }
        public void Update_KyThi(KyThiDTO kyThi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                KyThi Update = qltn.KyThis.Single(a => a.MaKyThi == kyThi.MaKyThi);
                Update.MaKyThi = kyThi.MaKyThi;
                Update.TenKyThi = kyThi.TenKyThi;
                Update.NgayThi = DateTime.Parse(kyThi.NgayThi);
                qltn.SubmitChanges();
            }
        }
        public void Delete_KyThi(string makt)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                KyThi delete = qltn.KyThis.Single(a => a.MaKyThi == makt);
                var ctkt = qltn.CT_KyThis.Where(a => a.MaKyThi == makt);
                var cths = qltn.CT_HOCSINH_KYTHIs.Where(a => a.MaKyThi == makt);
                
                foreach(CT_KyThi ct in ctkt.ToList())
                {
                    qltn.CT_KyThis.DeleteOnSubmit(ct);
                }
                qltn.SubmitChanges();

                foreach (CT_HOCSINH_KYTHI ct in cths.ToList())
                {
                    qltn.CT_HOCSINH_KYTHIs.DeleteOnSubmit(ct);
                }
                qltn.SubmitChanges();

                qltn.KyThis.DeleteOnSubmit(delete);
                qltn.SubmitChanges();
            }
        }
        #endregion
    }
}
