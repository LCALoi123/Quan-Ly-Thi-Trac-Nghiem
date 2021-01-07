namespace GUI.HocSinh
{
    partial class frInBangDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvBangDiem = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BangDiemDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HocSinhDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BangDiemDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HocSinhDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvBangDiem
            // 
            this.rpvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BangDiem";
            reportDataSource1.Value = this.BangDiemDTOBindingSource;
            reportDataSource2.Name = "ThongTinHocSinh";
            reportDataSource2.Value = this.HocSinhDTOBindingSource;
            this.rpvBangDiem.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBangDiem.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvBangDiem.LocalReport.ReportEmbeddedResource = "GUI.Report.reportKetQuaHocSinh.rdlc";
            this.rpvBangDiem.Location = new System.Drawing.Point(0, 0);
            this.rpvBangDiem.Name = "rpvBangDiem";
            this.rpvBangDiem.ServerReport.BearerToken = null;
            this.rpvBangDiem.Size = new System.Drawing.Size(482, 558);
            this.rpvBangDiem.TabIndex = 0;
            // 
            // BangDiemDTOBindingSource
            // 
            this.BangDiemDTOBindingSource.DataSource = typeof(DTO.BangDiemDTO);
            // 
            // HocSinhDTOBindingSource
            // 
            this.HocSinhDTOBindingSource.DataSource = typeof(DTO.HocSinhDTO);
            // 
            // frInBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 558);
            this.Controls.Add(this.rpvBangDiem);
            this.Name = "frInBangDiem";
            this.Text = "frInBangDiem";
            this.Load += new System.EventHandler(this.frInBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangDiemDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HocSinhDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBangDiem;
        private System.Windows.Forms.BindingSource BangDiemDTOBindingSource;
        private System.Windows.Forms.BindingSource HocSinhDTOBindingSource;
    }
}