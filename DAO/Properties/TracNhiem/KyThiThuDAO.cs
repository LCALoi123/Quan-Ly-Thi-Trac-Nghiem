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
      
        #endregion
    }
}
