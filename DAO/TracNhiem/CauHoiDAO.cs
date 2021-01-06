using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CauHoiDAO
    {
        #region singelton
        private static CauHoiDAO instance;

        public static CauHoiDAO Instance
        {
            get { if (instance == null) instance = new CauHoiDAO(); return CauHoiDAO.instance; }
            private set { CauHoiDAO.instance = value; }
        }
        private CauHoiDAO() { }
        #endregion

        #region method
        public List<CauHoi> Select_CauHois()
        {
            
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = qltn.CauHois.Select(c=>c);
                return ch.ToList();
            }
        }

        public CauHoi SelectCauHoi(int idch)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CauHoi ch = qltn.CauHois.Single(c => c.IDch == idch);
                return ch;
            }
        }

        public void Add_CauHoi(CauHoiDTO cauHoi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CauHoi insert = new CauHoi();
                insert.CauHoi1 = cauHoi.CauHoi;
                insert.dapanA = cauHoi.DapAnA;
                insert.dapanB = cauHoi.DapAnB;
                insert.dapanC = cauHoi.DapAnC;
                insert.dapanD = cauHoi.DapAnD;
                insert.dapandung = cauHoi.DapAnDung;
                insert.DoKho = cauHoi.DoKho;
                qltn.CauHois.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public void Add_DongGopCauHoi(CauHoiDongGopDTO cauHoi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CauHoiDongGop insert = new CauHoiDongGop();
                insert.IDhs = cauHoi.IDhs;
                insert.CauHoi = cauHoi.CauHoi;
                insert.dapanA = cauHoi.DapAnA;
                insert.dapanB = cauHoi.DapAnB;
                insert.dapanC = cauHoi.DapAnC;
                insert.dapanD = cauHoi.DapAnD;
                insert.dapandung = cauHoi.DapAnDung;
                insert.DoKho = cauHoi.DoKho;
                insert.duyet = false;
                qltn.CauHoiDongGops.InsertOnSubmit(insert);
                qltn.SubmitChanges();
            }
        }
        public void Update_CauHoi(CauHoiDTO cauHoi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CauHoi update = qltn.CauHois.Single(p => p.IDch == cauHoi.IdCH);
                update.CauHoi1 = cauHoi.CauHoi;
                update.dapanA = cauHoi.DapAnA;
                update.dapanB = cauHoi.DapAnB;
                update.dapanC = cauHoi.DapAnC;
                update.dapanD = cauHoi.DapAnD;
                update.dapandung = cauHoi.DapAnDung;
                update.DoKho = cauHoi.DoKho;
                qltn.SubmitChanges();
            }
        }
        public void Update_CauHoiDongGop(int id)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                CauHoiDongGop update = qltn.CauHoiDongGops.Single(p => p.IDch == id);
                update.duyet = true;
                qltn.SubmitChanges();
            }
        }

        public string Select_DapAn(int idch)
        {
            string DA = "";
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var da = from d in qltn.CauHois
                         where d.IDch == idch
                         select d.dapandung;
                DA = da.First();
                return DA;                
            }
        }

        public List<CauHoi> Select_CauHois(string MaDe)
        {

            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = from ctd in qltn.CT_DeThis
                         from cau in qltn.CauHois
                         where ctd.MaDe == MaDe && cau.IDch == ctd.IDch
                         select cau;

                return ch.ToList();
            }
        }
        public List<CauHoiDongGop> Select_CauHoiDongGop(int idhs)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = qltn.CauHoiDongGops.Where(a => a.IDhs == idhs);

                return ch.ToList();
            }
        }
        public List<CauHoiDongGop> Select_CauHoiDongGop()
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = qltn.CauHoiDongGops.Select(a => a);
                return ch.ToList();
            }
        }
        public bool KiemTraNoiDungCauHoi(string cauhoi)
        {
            using (qltnDAODataContext qltn = new qltnDAODataContext())
            {
                var ch = qltn.CauHois.Select(a => a);
                foreach(var i in ch.ToList())
                {
                    if (cauhoi == i.CauHoi1)
                        return false;
                }
            }

            return true;
        }
        #endregion
    }
}
