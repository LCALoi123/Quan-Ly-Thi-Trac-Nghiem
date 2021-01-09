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
    public class DeBUS
    {
        #region singleton
        private static DeBUS instance;

        public static DeBUS Instance
        {
            get { if (instance == null) instance = new DeBUS(); return DeBUS.instance; }
            private set { DeBUS.instance = value; }
        }
        private DeBUS() { }
        #endregion
        #region method
        public void Insert_DeThi(DeThiDTO de)
        {
            try
            {
                DeDAO.Instance.Add_DeThi(de);
            }
            catch
            {

            }

        }

        
        public void Insert_CT_DeThi(CT_DethiDTO ct)
        {
            try
            {
                DeDAO.Instance.Add_CT_DeThi(ct);
            }
            catch
            {

            }

        }

        public List<int> selectDanhSachIDCH(string MaDe)
        {
            try
            {
                return DeDAO.Instance.select_idch(MaDe);
            }
            catch
            {
                return null;
            }

        }

        public DataTable SelectDethis()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(DeDAO.Instance.Select_DeThi());
            }
            catch
            {
                return null;
            }

        }

        public List<string> SelectDanhSachTenDe(string makt)
        {
            try
            {
                return DeDAO.Instance.select_DS_TenDe(makt);
            }
            catch
            {
                return null;
            }

        }
        public List<string> SelectDanhSachTenDeThiThu(string makt)
        {
            try
            {
                return DeDAO.Instance.select_DS_TenDeThiThu(makt);
            }
            catch
            {
                return null;
            }

        }

        public List<string> LayDSMaDe()
        {
            try
            {
                return DeDAO.Instance.LayDanhSachMaDe();
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
