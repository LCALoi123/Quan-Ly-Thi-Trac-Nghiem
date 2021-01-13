using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KyThiThuBUS
    {
        #region singleton
        private static KyThiThuBUS instance;

        public static KyThiThuBUS Instance
        {
            get { if (instance == null) instance = new KyThiThuBUS(); return KyThiThuBUS.instance; }
            private set { KyThiThuBUS.instance = value; }
        }
        private KyThiThuBUS() { }
        #endregion
        #region method
        public void Insert_KyThiThu(KyThiThu kyThi)
        {
            try
            {
                KyThiThuDAO.Instance.Insert_KyThiThu(kyThi);
            }
            catch
            {

            }
            
            

        }
        public void Insert_CT_KyThiThu(CT_KyThiThu ct)
        {
            try
            {
                KyThiThuDAO.Instance.Insert_CT_KyThiThu(ct);
            }
            catch
            {

            }

        }
        
        
        public void Insert_CT_HocSinh_KyThiThu(CT_HOCSINH_KyThiThu ct)
        {
            try
            {
                KyThiThuDAO.Instance.Insert_CT_HocSinh_kyThiThu(ct);
            }
            catch
            {

            }

        }

      
        #endregion
    }
}
