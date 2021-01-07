using BUS;
using DAO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.HocSinh
{
    public partial class frInBangDiem : Form
    {
        public frInBangDiem()
        {
            InitializeComponent();
        }
        static string name = "";
        public frInBangDiem(string usname):this()
        {
            name = usname;
        }
        private void frInBangDiem_Load(object sender, EventArgs e)
        {

            load();
        }
        private void load()
        {
            rpvBangDiem.LocalReport.DataSources.Clear();
            var DiemBS = new BindingSource();
            var rDS = new ReportDataSource("BangDiem");
            rDS.Value = DiemBS;
            rpvBangDiem.LocalReport.DataSources.Add(rDS);
            
            int idus = AccountBUS.Instance.get_ID_account(name);

            DiemBS.DataSource = DiemDAO.Instance.LayDSKetQua(HocSinhBUS.Instance.SelectIDhs(idus));

            var HocSinhBS = new BindingSource();
            var hsrDs = new ReportDataSource("ThongTinHocSinh");
            hsrDs.Value = HocSinhBS;
            rpvBangDiem.LocalReport.DataSources.Add(hsrDs);
            HocSinhBS.DataSource = HocSinhBUS.Instance.get_HocSinh(name);



            this.rpvBangDiem.RefreshReport();


        }
    }
}
