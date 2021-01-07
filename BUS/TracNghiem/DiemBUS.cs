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
    public class DiemBUS
    {
        #region singleton
        private static DiemBUS instance;

        public static DiemBUS Instance
        {
            get { if (instance == null) instance = new DiemBUS(); return DiemBUS.instance; }
            private set { DiemBUS.instance = value; }
        }
        private DiemBUS() { }
        #endregion
        #region method
        public bool Insert_DiemThi(DiemDTO diem)
        {
            try
            {
                DiemDAO.Instance.Insert_Diem(diem);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public DataTable SelectBangDiem(int idus)
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(DiemDAO.Instance.LayDSKetQua(idus));
            }
            catch
            {
                return null;
            }
        }
        public DataTable LayBangDiem()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(DiemDAO.Instance.LayBangDiem());
            }
            catch
            {
                return null;
            }
        }
        public DataTable LayBangDiem(string makt)
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(DiemDAO.Instance.LayBangDiem(makt));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
