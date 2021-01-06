using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KyThiBUS
    {
        #region singleton
        private static KyThiBUS instance;

        public static KyThiBUS Instance
        {
            get { if (instance == null) instance = new KyThiBUS(); return KyThiBUS.instance; }
            private set { KyThiBUS.instance = value; }
        }
        private KyThiBUS() { }
        #endregion
        #region method
        public void Insert_KyThi(KyThiDTO kyThi)
        {
            try
            {
                KyThiDAO.Instance.Insert_KyThi(kyThi);
            }
            catch
            {

            }

        }
        public void Insert_CT_KyThi(CT_KyThiDTO ct)
        {
            try
            {
                KyThiDAO.Instance.Insert_CT_KyThi(ct);
            }
            catch
            {

            }

        }
        public void Insert_CT_HocSinh_KyThi(CT_HocSinh_kyThiDTO ct)
        {
            try
            {
                KyThiDAO.Instance.Insert_CT_HocSinh_kyThi(ct);
            }
            catch
            {

            }

        }

        public DataTable SelectKyThis()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(KyThiDAO.Instance.Select_KyThi());
            }
            catch
            {
                return null;
            }

        }
        public DataTable SelectKyThis(int idus)
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(KyThiDAO.Instance.Select_KyThi(idus));
            }
            catch
            {
                return null;
            }

        }
        public bool Delete_KyThi(string makt)
        {
            try
            {
                KyThiDAO.Instance.Delete_KyThi(makt);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
