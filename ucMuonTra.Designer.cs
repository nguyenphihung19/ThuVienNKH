namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class ucMuonTra
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboTinhTrang = new System.Windows.Forms.GroupBox();
            this.btnLocQuaHan = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChoMuon = new System.Windows.Forms.Button();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.btnXemDs = new System.Windows.Forms.Button();
            this.DgvMuonTra = new System.Windows.Forms.DataGridView();
            this.cboTinhTrang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMuonTra)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Controls.Add(this.btnXemDs);
            this.cboTinhTrang.Controls.Add(this.btnLocQuaHan);
            this.cboTinhTrang.Controls.Add(this.btnInPhieu);
            this.cboTinhTrang.Location = new System.Drawing.Point(15, 26);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(144, 120);
            this.cboTinhTrang.TabIndex = 1;
            this.cboTinhTrang.TabStop = false;
            this.cboTinhTrang.Text = "Công Cụ";
            // 
            // btnLocQuaHan
            // 
            this.btnLocQuaHan.Location = new System.Drawing.Point(7, 51);
            this.btnLocQuaHan.Name = "btnLocQuaHan";
            this.btnLocQuaHan.Size = new System.Drawing.Size(122, 23);
            this.btnLocQuaHan.TabIndex = 1;
            this.btnLocQuaHan.Text = "Lọc Quá Hạn";
            this.btnLocQuaHan.UseVisualStyleBackColor = true;
            this.btnLocQuaHan.Visible = false;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(7, 22);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(122, 23);
            this.btnInPhieu.TabIndex = 0;
            this.btnInPhieu.Text = "In Phiếu Mượn";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMaPhieuMuon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.btnChoMuon);
            this.groupBox1.Controls.Add(this.btnXacNhanTra);
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.dtpNgayMuon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.txtMaDG);
            this.groupBox1.Location = new System.Drawing.Point(165, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khu Vực Mượn";
            // 
            // btnChoMuon
            // 
            this.btnChoMuon.Location = new System.Drawing.Point(700, 15);
            this.btnChoMuon.Name = "btnChoMuon";
            this.btnChoMuon.Size = new System.Drawing.Size(92, 23);
            this.btnChoMuon.TabIndex = 19;
            this.btnChoMuon.Text = "Mượn Sách";
            this.btnChoMuon.UseVisualStyleBackColor = true;
            this.btnChoMuon.Click += new System.EventHandler(this.btnChoMuon_Click);
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.Location = new System.Drawing.Point(700, 51);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(92, 23);
            this.btnXacNhanTra.TabIndex = 24;
            this.btnXacNhanTra.Text = "Trả Sách";
            this.btnXacNhanTra.UseVisualStyleBackColor = true;
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Location = new System.Drawing.Point(469, 50);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(212, 22);
            this.dtpNgayTra.TabIndex = 25;
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Location = new System.Drawing.Point(469, 16);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(208, 22);
            this.dtpNgayMuon.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Độc Giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày Mượn";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(98, 56);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(87, 22);
            this.txtMaSach.TabIndex = 17;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(98, 18);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(87, 22);
            this.txtMaDG.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboTinhTrang);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 162);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DgvMuonTra);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 162);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1014, 548);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mã NV";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(286, 19);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(87, 22);
            this.txtMaNV.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mã PM";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(286, 55);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(87, 22);
            this.txtMaPhieuMuon.TabIndex = 29;
            // 
            // btnXemDs
            // 
            this.btnXemDs.Location = new System.Drawing.Point(6, 80);
            this.btnXemDs.Name = "btnXemDs";
            this.btnXemDs.Size = new System.Drawing.Size(122, 23);
            this.btnXemDs.TabIndex = 2;
            this.btnXemDs.Text = "Xem Danh Sách";
            this.btnXemDs.UseVisualStyleBackColor = true;
            this.btnXemDs.Click += new System.EventHandler(this.btnXemDs_Click);
            // 
            // DgvMuonTra
            // 
            this.DgvMuonTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMuonTra.Location = new System.Drawing.Point(0, 0);
            this.DgvMuonTra.Name = "DgvMuonTra";
            this.DgvMuonTra.RowHeadersWidth = 51;
            this.DgvMuonTra.RowTemplate.Height = 24;
            this.DgvMuonTra.Size = new System.Drawing.Size(1014, 548);
            this.DgvMuonTra.TabIndex = 0;
            // 
            // ucMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ucMuonTra";
            this.Size = new System.Drawing.Size(1014, 710);
            this.cboTinhTrang.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMuonTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox cboTinhTrang;
        private System.Windows.Forms.Button btnLocQuaHan;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Button btnChoMuon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Button btnXacNhanTra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Button btnXemDs;
        private System.Windows.Forms.DataGridView DgvMuonTra;
    }
}
