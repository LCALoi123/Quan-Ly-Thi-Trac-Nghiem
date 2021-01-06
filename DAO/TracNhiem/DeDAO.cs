using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DeDAO
    {
        #region singelton
        private static DeDAO instance;

        public static DeDAO Instance
        {
            get { if (instance == null) instance = new DeDAO(); return DeDAO.instance; }
            private set { DeDAO.instance = value; }
        }
        private DeDAO() { }
        #endregion
        #region method
        public void Add_DeThi(DeThiDTO de)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                DeThi insert = new DeThi();
                insert.MaDe = de.MaDe;
                insert.TenDe = de.TenDe;
                qltn.DeThis.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public void Add_CT_DeThi(CT_DethiDTO ct)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CT_DeThi insert = new CT_DeThi();
                insert.MaDe = ct.MaDe;
                insert.IDch = ct.IDch;
                qltn.CT_DeThis.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        
        public List<DeThi> Select_DeThi()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var dt = qltn.DeThis.Select(c => c);
                return dt.ToList();
            }
        }
        public List<string> select_DS_TenDe(string makt)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var k = from a in qltn.DeThis
                        from ct in qltn.CT_KyThis
                        where a.MaDe == ct.MaDe && ct.MaKyThi == makt
                        select a.MaDe + "|" + a.TenDe;
                return k.ToList();
            }
        }
        public List<string> select_DS_TenDeThiThu(string makt)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var k = from a in qltn.DeThis
                        from ct in qltn.CT_KyThiThus
                        where a.MaDe == ct.MaDe && ct.MaKyThi == makt
                        select a.MaDe + "|" + a.TenDe;
                return k.ToList();
            }
        }
        public List<string> LayDanhSachMaDe()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var made = qltn.DeThis.Select(a => a.MaDe);
                return made.ToList();
            }
        }
        public List<int> select_idch(string madethi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var k = from ctdt in qltn.CT_DeThis
                        where ctdt.MaDe == madethi
                        select ctdt.IDch;
                return k.ToList();
            }
        }
        #endregion
    }
}
