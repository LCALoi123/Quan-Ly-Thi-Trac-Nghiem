using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KyThiThuDAO
    {
        #region singelton
        private static KyThiThuDAO instance;

        public static KyThiThuDAO Instance
        {
            get { if (instance == null) instance = new KyThiThuDAO(); return KyThiThuDAO.instance; }
            private set { KyThiThuDAO.instance = value; }
        }
        private KyThiThuDAO() { }
        #endregion

        #region method
        public void Insert_KyThiThu(KyThiThu kyThi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                qltn.KyThiThus.InsertOnSubmit(kyThi);
                qltn.SubmitChanges();
            }
        }
        public void Insert_CT_KyThiThu(CT_KyThiThu cT_KyThi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                qltn.CT_KyThiThus.InsertOnSubmit(cT_KyThi);
                qltn.SubmitChanges();
            }
        }
        public void Insert_CT_HocSinh_kyThiThu(CT_HOCSINH_KyThiThu cthsKythiThu)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                qltn.CT_HOCSINH_KyThiThus.InsertOnSubmit(cthsKythiThu);
                qltn.SubmitChanges();
            }
        }
        
        public List<KyThiThu> Select_KyThiThu()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                return qltn.KyThiThus.Select(a => a).ToList();
            }
        }
        public List<KyThiThu> Select_KyThiThu(int idus)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {

                var kt = from ct in qltn.CT_HOCSINH_KyThiThus
                         from kts in qltn.KyThiThus
                         where ct.MaKyThi == kts.MaKyThi && ct.IDhs == idus
                         select kts;
                return kt.ToList();
            }
        }
        public void Delete_KyThiThu(string makt)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                KyThiThu delete = qltn.KyThiThus.Single(a => a.MaKyThi == makt);
                var ctkt = qltn.CT_KyThiThus.Where(a => a.MaKyThi == makt);
                var cths = qltn.CT_HOCSINH_KyThiThus.Where(a => a.MaKyThi == makt);

                foreach (CT_KyThiThu ct in ctkt.ToList())
                {
                    qltn.CT_KyThiThus.DeleteOnSubmit(ct);
                }
                qltn.SubmitChanges();

                foreach (CT_HOCSINH_KyThiThu ct in cths.ToList())
                {
                    qltn.CT_HOCSINH_KyThiThus.DeleteOnSubmit(ct);
                }
                qltn.SubmitChanges();

                qltn.KyThiThus.DeleteOnSubmit(delete);
                qltn.SubmitChanges();
            }
        }
        #endregion
    }
}
