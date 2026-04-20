namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class FrmMainAdmin
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
            this.BtnDangXuat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnQLSV = new System.Windows.Forms.Button();
            this.BtnQLS = new System.Windows.Forms.Button();
            this.BtnTkBc = new System.Windows.Forms.Button();
            this.BtnTLS = new System.Windows.Forms.Button();
            this.BtnMuonTraSach = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCDQD = new System.Windows.Forms.Button();
            this.BtnQLTK = new System.Windows.Forms.Button();
            this.BtnQLNV = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Wheat;
            this.panel1.Controls.Add(this.BtnDangXuat);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblQuyen);
            this.panel1.Controls.Add(this.lblHoTen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 167);
            this.panel1.TabIndex = 0;
            // 
            // BtnDangXuat
            // 
            this.BtnDangXuat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDangXuat.Location = new System.Drawing.Point(914, 13);
            this.BtnDangXuat.Name = "BtnDangXuat";
            this.BtnDangXuat.Size = new System.Drawing.Size(110, 23);
            this.BtnDangXuat.TabIndex = 4;
            this.BtnDangXuat.Text = "Đăng Xuất";
            this.BtnDangXuat.UseVisualStyleBackColor = false;
            this.BtnDangXuat.Click += new System.EventHandler(this.BtnDangXuat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 85);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(136, 63);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(104, 16);
            this.lblQuyen.TabIndex = 2;
            this.lblQuyen.Text = "Quyền Truy Cập";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(136, 35);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(73, 16);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ và Tên ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN NKH ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 490);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Yellow;
            this.groupBox2.Controls.Add(this.BtnQLSV);
            this.groupBox2.Controls.Add(this.BtnQLS);
            this.groupBox2.Controls.Add(this.BtnTkBc);
            this.groupBox2.Controls.Add(this.BtnTLS);
            this.groupBox2.Controls.Add(this.BtnMuonTraSach);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thủ Thư";
            // 
            // BtnQLSV
            // 
            this.BtnQLSV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnQLSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLSV.Location = new System.Drawing.Point(6, 56);
            this.BtnQLSV.Name = "BtnQLSV";
            this.BtnQLSV.Size = new System.Drawing.Size(171, 29);
            this.BtnQLSV.TabIndex = 16;
            this.BtnQLSV.Text = "Quản Lý Sinh Viên";
            this.BtnQLSV.UseVisualStyleBackColor = false;
            this.BtnQLSV.Click += new System.EventHandler(this.BtnQLSV_Click);
            // 
            // BtnQLS
            // 
            this.BtnQLS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnQLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLS.Location = new System.Drawing.Point(6, 21);
            this.BtnQLS.Name = "BtnQLS";
            this.BtnQLS.Size = new System.Drawing.Size(171, 29);
            this.BtnQLS.TabIndex = 15;
            this.BtnQLS.Text = "Quản Lý Sách";
            this.BtnQLS.UseVisualStyleBackColor = false;
            // 
            // BtnTkBc
            // 
            this.BtnTkBc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnTkBc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTkBc.Location = new System.Drawing.Point(6, 163);
            this.BtnTkBc.Name = "BtnTkBc";
            this.BtnTkBc.Size = new System.Drawing.Size(171, 31);
            this.BtnTkBc.TabIndex = 13;
            this.BtnTkBc.Text = "Thống Kê - Báo Cáo";
            this.BtnTkBc.UseVisualStyleBackColor = false;
            this.BtnTkBc.Click += new System.EventHandler(this.BtnTkBc_Click);
            // 
            // BtnTLS
            // 
            this.BtnTLS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnTLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTLS.Location = new System.Drawing.Point(6, 128);
            this.BtnTLS.Name = "BtnTLS";
            this.BtnTLS.Size = new System.Drawing.Size(171, 29);
            this.BtnTLS.TabIndex = 12;
            this.BtnTLS.Text = "Thanh Lý Sách";
            this.BtnTLS.UseVisualStyleBackColor = false;
            this.BtnTLS.Click += new System.EventHandler(this.BtnTLS_Click);
            // 
            // BtnMuonTraSach
            // 
            this.BtnMuonTraSach.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnMuonTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMuonTraSach.Location = new System.Drawing.Point(6, 91);
            this.BtnMuonTraSach.Name = "BtnMuonTraSach";
            this.BtnMuonTraSach.Size = new System.Drawing.Size(171, 31);
            this.BtnMuonTraSach.TabIndex = 11;
            this.BtnMuonTraSach.Text = "Mượn - Trả Sách";
            this.BtnMuonTraSach.UseVisualStyleBackColor = false;
            this.BtnMuonTraSach.Click += new System.EventHandler(this.BtnMuonTraSach_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.BtnCDQD);
            this.groupBox1.Controls.Add(this.BtnQLTK);
            this.groupBox1.Controls.Add(this.BtnQLNV);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Trị";
            // 
            // BtnCDQD
            // 
            this.BtnCDQD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCDQD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCDQD.Location = new System.Drawing.Point(6, 92);
            this.BtnCDQD.Name = "BtnCDQD";
            this.BtnCDQD.Size = new System.Drawing.Size(171, 28);
            this.BtnCDQD.TabIndex = 10;
            this.BtnCDQD.Text = "Cài Đặt Quy Định";
            this.BtnCDQD.UseVisualStyleBackColor = false;
            // 
            // BtnQLTK
            // 
            this.BtnQLTK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnQLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLTK.Location = new System.Drawing.Point(6, 59);
            this.BtnQLTK.Name = "BtnQLTK";
            this.BtnQLTK.Size = new System.Drawing.Size(171, 27);
            this.BtnQLTK.TabIndex = 9;
            this.BtnQLTK.Text = "Quản Lý Tài Khoản";
            this.BtnQLTK.UseVisualStyleBackColor = false;
            // 
            // BtnQLNV
            // 
            this.BtnQLNV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLNV.Location = new System.Drawing.Point(6, 21);
            this.BtnQLNV.Name = "BtnQLNV";
            this.BtnQLNV.Size = new System.Drawing.Size(171, 32);
            this.BtnQLNV.TabIndex = 8;
            this.BtnQLNV.Text = "Quản Lý Nhân Viên";
            this.BtnQLNV.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(201, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 490);
            this.panel3.TabIndex = 2;
            // 
            // FrmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 657);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMainAdmin";
            this.Text = "FrmMainAdmin";
            this.Load += new System.EventHandler(this.FrmMainAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnDangXuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnTkBc;
        private System.Windows.Forms.Button BtnTLS;
        private System.Windows.Forms.Button BtnMuonTraSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCDQD;
        private System.Windows.Forms.Button BtnQLTK;
        private System.Windows.Forms.Button BtnQLNV;
        private System.Windows.Forms.Button BtnQLS;
        private System.Windows.Forms.Button BtnQLSV;
    }
}