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
    public class CauHoiBUS
    {
        #region singleton
        private static CauHoiBUS instance;

        public static CauHoiBUS Instance
        {
            get { if (instance == null) instance = new CauHoiBUS(); return CauHoiBUS.instance; }
            private set { CauHoiBUS.instance = value; }
        }
        private CauHoiBUS() { }
        #endregion

        #region method
        public bool Insert_CauHoi(CauHoiDTO cauHoi)
        {
            try
            {
                if (CauHoiDAO.Instance.KiemTraNoiDungCauHoi(cauHoi.CauHoi))
                {
                    CauHoiDAO.Instance.Add_CauHoi(cauHoi);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        public void Insert_DongGopCauHoi(CauHoiDongGopDTO cauHoi)
        {
            try
            {
                CauHoiDAO.Instance.Add_DongGopCauHoi(cauHoi);
            }
            catch
            {

            }
        }

        public DataTable SelectCauHois()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(CauHoiDAO.Instance.Select_CauHois());
            }
            catch
            {
                return null;
            }
        }

        public DataTable SelectCauHois(string MaDe)
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(CauHoiDAO.Instance.Select_CauHois(MaDe));
            }
            catch
            {
                return null;
            }


        }
        public DataTable SelectCauHoiDongGops(int idhs)
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(CauHoiDAO.Instance.Select_CauHoiDongGop(idhs));
            }
            catch
            {
                return null;
            }


        }
        public DataTable SelectCauHoiDongGops()
        {
            try
            {
                return MethodBUS.Instance.ConvertToDataTable(CauHoiDAO.Instance.Select_CauHoiDongGop());
            }
            catch
            {
                return null;
            }

        }

        public CauHoiDTO SelectCauHoi(int idch)
        {
            try
            {
                CauHoi ch = CauHoiDAO.Instance.SelectCauHoi(idch);
                CauHoiDTO cauhoi = new CauHoiDTO();
                cauhoi.IdCH = ch.IDch;
                cauhoi.CauHoi = ch.CauHoi1;
                cauhoi.DapAnA = ch.dapanA;
                cauhoi.DapAnB = ch.dapanB;
                cauhoi.DapAnC = ch.dapanC;
                cauhoi.DapAnD = ch.dapanD;
                cauhoi.DapAnDung = ch.dapandung;
                cauhoi.DoKho = ch.DoKho;
                return cauhoi;

            }
            catch
            {
                return null;
            }

        }

        public void update_CauHoi(CauHoiDTO cauHoi)
        {
            try
            {
                CauHoiDAO.Instance.Update_CauHoi(cauHoi);
            }
            catch
            {

            }

        }
        public void update_CauHoiDongGop(int id)
        {
            try
            {
                CauHoiDAO.Instance.Update_CauHoiDongGop(id);
            }
            catch
            {

            }
        }

        #endregion
    }
}
