namespace GUI
{
    partial class frRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frRegister));
            this.btDangKy = new System.Windows.Forms.Button();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.tbTenDangNhap = new System.Windows.Forms.TextBox();
            this.errorProviderMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbPhanHe = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDangKy
            // 
            this.btDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btDangKy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDangKy.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.btDangKy.ForeColor = System.Drawing.Color.White;
            this.btDangKy.Location = new System.Drawing.Point(79, 150);
            this.btDangKy.Name = "btDangKy";
            this.btDangKy.Size = new System.Drawing.Size(203, 39);
            this.btDangKy.TabIndex = 16;
            this.btDangKy.Text = "Đăng ký";
            this.btDangKy.UseVisualStyleBackColor = false;
            this.btDangKy.Click += new System.EventHandler(this.BtDangKy_Click);
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatKhau.Location = new System.Drawing.Point(46, 66);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.Size = new System.Drawing.Size(265, 29);
            this.tbMatKhau.TabIndex = 14;
            this.tbMatKhau.Text = "Nhập mật khẩu ...";
            this.tbMatKhau.Click += new System.EventHandler(this.TbMatKhau_Click);
            this.tbMatKhau.TextChanged += new System.EventHandler(this.TbMatKhau_TextChanged);
            this.tbMatKhau.Validating += new System.ComponentModel.CancelEventHandler(this.tbMatKhau_Validating);
            // 
            // tbTenDangNhap
            // 
            this.tbTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDangNhap.Location = new System.Drawing.Point(46, 7);
            this.tbTenDangNhap.Name = "tbTenDangNhap";
            this.tbTenDangNhap.Size = new System.Drawing.Size(265, 29);
            this.tbTenDangNhap.TabIndex = 13;
            this.tbTenDangNhap.Text = "Nhập tên đăng nhập ...";
            this.tbTenDangNhap.Click += new System.EventHandler(this.TbTenDangNhap_Click);
            this.tbTenDangNhap.TextChanged += new System.EventHandler(this.TbTenDangNhap_TextChanged);
            this.tbTenDangNhap.Validating += new System.ComponentModel.CancelEventHandler(this.tbTenDangNhap_Validating);
            // 
            // errorProviderMain
            // 
            this.errorProviderMain.ContainerControl = this;
            this.errorProviderMain.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderMain.Icon")));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(102, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 178);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "1";
            // 
            // ptbExit
            // 
            this.ptbExit.BackColor = System.Drawing.Color.Transparent;
            this.ptbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbExit.BackgroundImage")));
            this.ptbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbExit.Location = new System.Drawing.Point(346, 2);
            this.ptbExit.Name = "ptbExit";
            this.ptbExit.Size = new System.Drawing.Size(25, 24);
            this.ptbExit.TabIndex = 22;
            this.ptbExit.TabStop = false;
            this.ptbExit.Click += new System.EventHandler(this.PtbExit_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(9, 66);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 29);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(9, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 29);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cbbPhanHe);
            this.panel1.Controls.Add(this.tbTenDangNhap);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.tbMatKhau);
            this.panel1.Controls.Add(this.btDangKy);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(23, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 217);
            this.panel1.TabIndex = 25;
            // 
            // cbbPhanHe
            // 
            this.cbbPhanHe.AutoCompleteCustomSource.AddRange(new string[] {
            "Học Sinh"});
            this.cbbPhanHe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPhanHe.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cbbPhanHe.Items.AddRange(new object[] {
            "Admin",
            "Giáo Viên",
            "Học Sinh"});
            this.cbbPhanHe.Location = new System.Drawing.Point(46, 101);
            this.cbbPhanHe.Name = "cbbPhanHe";
            this.cbbPhanHe.Size = new System.Drawing.Size(135, 29);
            this.cbbPhanHe.TabIndex = 25;
            // 
            // frRegister
            // 
            this.AcceptButton = this.btDangKy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(376, 424);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbExit);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frRegister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frRegister_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btDangKy;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.TextBox tbTenDangNhap;
        private System.Windows.Forms.ErrorProvider errorProviderMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptbExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbbPhanHe;
    }
}