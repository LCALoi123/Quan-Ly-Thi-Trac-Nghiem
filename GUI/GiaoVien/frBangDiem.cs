using BUS;
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

namespace GUI.GiaoVien
{
    public partial class frBangDiem : Form
    {
        public frBangDiem()
        {
            InitializeComponent();
        }
        static string makt = "NULL";
        public frBangDiem(string ma):this()
        {
            makt = ma;
        }
        private void frBangDiem_Load(object sender, EventArgs e)
        {
            
            rpvBangDiem.LocalReport.DataSources.Clear();
            var BangDiemDS = new BindingSource();
            var hsrDs = new ReportDataSource("BangDiem");
            hsrDs.Value = BangDiemDS;
            rpvBangDiem.LocalReport.DataSources.Add(hsrDs);
            if(makt == "NULL")
                BangDiemDS.DataSource = DiemBUS.Instance.LayBangDiem();
            else
                BangDiemDS.DataSource = DiemBUS.Instance.LayBangDiem(makt);

            this.rpvBangDiem.RefreshReport();
        }
    }
}
