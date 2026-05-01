namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class frmMainReader
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDangXuat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuyenReader = new System.Windows.Forms.Label();
            this.lblHoTenReader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GbNoiQuy = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDoiMatKhau = new System.Windows.Forms.Button();
            this.BtnCaNhan = new System.Windows.Forms.Button();
            this.BtnTraCuu = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblNoiQuy = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.GbNoiQuy.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BtnDangXuat);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblQuyenReader);
            this.panel1.Controls.Add(this.lblHoTenReader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 100);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(535, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "THƯ VIỆN NKH";
            // 
            // BtnDangXuat
            // 
            this.BtnDangXuat.Location = new System.Drawing.Point(925, 12);
            this.BtnDangXuat.Name = "BtnDangXuat";
            this.BtnDangXuat.Size = new System.Drawing.Size(105, 23);
            this.BtnDangXuat.TabIndex = 4;
            this.BtnDangXuat.Text = "Đăng Xuất";
            this.BtnDangXuat.UseVisualStyleBackColor = true;
            this.BtnDangXuat.Click += new System.EventHandler(this.BtnDangXuat_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 85);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(144, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 2;
            // 
            // lblQuyenReader
            // 
            this.lblQuyenReader.AutoSize = true;
            this.lblQuyenReader.ForeColor = System.Drawing.Color.White;
            this.lblQuyenReader.Location = new System.Drawing.Point(144, 65);
            this.lblQuyenReader.Name = "lblQuyenReader";
            this.lblQuyenReader.Size = new System.Drawing.Size(46, 16);
            this.lblQuyenReader.TabIndex = 1;
            this.lblQuyenReader.Text = "Quyền";
            // 
            // lblHoTenReader
            // 
            this.lblHoTenReader.AutoSize = true;
            this.lblHoTenReader.ForeColor = System.Drawing.Color.White;
            this.lblHoTenReader.Location = new System.Drawing.Point(144, 19);
            this.lblHoTenReader.Name = "lblHoTenReader";
            this.lblHoTenReader.Size = new System.Drawing.Size(70, 16);
            this.lblHoTenReader.TabIndex = 0;
            this.lblHoTenReader.Text = "Họ và Tên";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 575);
            this.panel2.TabIndex = 1;
            // 
            // GbNoiQuy
            // 
            this.GbNoiQuy.Controls.Add(this.lblNoiQuy);
            this.GbNoiQuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbNoiQuy.ForeColor = System.Drawing.Color.White;
            this.GbNoiQuy.Location = new System.Drawing.Point(0, 0);
            this.GbNoiQuy.Name = "GbNoiQuy";
            this.GbNoiQuy.Size = new System.Drawing.Size(200, 406);
            this.GbNoiQuy.TabIndex = 1;
            this.GbNoiQuy.TabStop = false;
            this.GbNoiQuy.Text = "Nội Quy";
            this.GbNoiQuy.Enter += new System.EventHandler(this.GbNoiQuy_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDoiMatKhau);
            this.groupBox1.Controls.Add(this.BtnCaNhan);
            this.groupBox1.Controls.Add(this.BtnTraCuu);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // BtnDoiMatKhau
            // 
            this.BtnDoiMatKhau.ForeColor = System.Drawing.Color.Black;
            this.BtnDoiMatKhau.Location = new System.Drawing.Point(6, 88);
            this.BtnDoiMatKhau.Name = "BtnDoiMatKhau";
            this.BtnDoiMatKhau.Size = new System.Drawing.Size(179, 27);
            this.BtnDoiMatKhau.TabIndex = 2;
            this.BtnDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.BtnDoiMatKhau.UseVisualStyleBackColor = true;
            this.BtnDoiMatKhau.Click += new System.EventHandler(this.BtnDoiMatKhau_Click);
            // 
            // BtnCaNhan
            // 
            this.BtnCaNhan.ForeColor = System.Drawing.Color.Black;
            this.BtnCaNhan.Location = new System.Drawing.Point(6, 55);
            this.BtnCaNhan.Name = "BtnCaNhan";
            this.BtnCaNhan.Size = new System.Drawing.Size(179, 27);
            this.BtnCaNhan.TabIndex = 1;
            this.BtnCaNhan.Text = "Theo Dõi Cá Nhân";
            this.BtnCaNhan.UseVisualStyleBackColor = true;
            this.BtnCaNhan.Click += new System.EventHandler(this.BtnCaNhan_Click);
            // 
            // BtnTraCuu
            // 
            this.BtnTraCuu.ForeColor = System.Drawing.Color.Black;
            this.BtnTraCuu.Location = new System.Drawing.Point(6, 22);
            this.BtnTraCuu.Name = "BtnTraCuu";
            this.BtnTraCuu.Size = new System.Drawing.Size(179, 27);
            this.BtnTraCuu.TabIndex = 0;
            this.BtnTraCuu.Text = "Tìm Kiếm Sách";
            this.BtnTraCuu.UseVisualStyleBackColor = true;
            this.BtnTraCuu.Click += new System.EventHandler(this.BtnTraCuu_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 100);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(842, 575);
            this.pnlContent.TabIndex = 2;
            // 
            // lblNoiQuy
            // 
            this.lblNoiQuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoiQuy.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiQuy.Location = new System.Drawing.Point(3, 18);
            this.lblNoiQuy.Name = "lblNoiQuy";
            this.lblNoiQuy.Size = new System.Drawing.Size(194, 385);
            this.lblNoiQuy.TabIndex = 0;
            this.lblNoiQuy.Text = "label1";
            this.lblNoiQuy.Click += new System.EventHandler(this.lblNoiQuy_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 169);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.GbNoiQuy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 169);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 406);
            this.panel4.TabIndex = 1;
            // 
            // frmMainReader
            // 
            this.ClientSize = new System.Drawing.Size(1042, 675);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMainReader";
            this.Text = "Hệ Thống Quản Lý Thư Viện";
            this.Load += new System.EventHandler(this.frmMainReader_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.GbNoiQuy.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQuyenReader;
        private System.Windows.Forms.Label lblHoTenReader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnDoiMatKhau;
        private System.Windows.Forms.Button BtnCaNhan;
        private System.Windows.Forms.Button BtnTraCuu;
        private System.Windows.Forms.Button BtnDangXuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox GbNoiQuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNoiQuy;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}