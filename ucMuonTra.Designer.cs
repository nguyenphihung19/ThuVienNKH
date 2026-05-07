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
            this.btnXemDs = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.btnChoMuon = new System.Windows.Forms.Button();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSSDM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTensach = new System.Windows.Forms.TextBox();
            this.txtTenDocGIa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DgvMuonTra = new System.Windows.Forms.DataGridView();
            this.btnXemSachDaMuon = new System.Windows.Forms.Button();
            this.cboTinhTrang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMuonTra)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.BackColor = System.Drawing.Color.PowderBlue;
            this.cboTinhTrang.Controls.Add(this.btnXemDs);
            this.cboTinhTrang.Controls.Add(this.btnInPhieu);
            this.cboTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinhTrang.Location = new System.Drawing.Point(12, 57);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(144, 142);
            this.cboTinhTrang.TabIndex = 1;
            this.cboTinhTrang.TabStop = false;
            this.cboTinhTrang.Text = "Công Cụ";
            // 
            // btnXemDs
            // 
            this.btnXemDs.Location = new System.Drawing.Point(6, 58);
            this.btnXemDs.Name = "btnXemDs";
            this.btnXemDs.Size = new System.Drawing.Size(122, 30);
            this.btnXemDs.TabIndex = 2;
            this.btnXemDs.Text = "Xem Danh Sách";
            this.btnXemDs.UseVisualStyleBackColor = true;
            this.btnXemDs.Click += new System.EventHandler(this.btnXemDs_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(7, 22);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(122, 30);
            this.btnInPhieu.TabIndex = 0;
            this.btnInPhieu.Text = "In Phiếu Mượn";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMaPhieuMuon);
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.dtpNgayMuon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.txtMaDG);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(162, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khu Vực Mượn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mã PM";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(304, 40);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(87, 28);
            this.txtMaPhieuMuon.TabIndex = 29;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Location = new System.Drawing.Point(534, 22);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(280, 28);
            this.dtpNgayTra.TabIndex = 25;
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Location = new System.Drawing.Point(534, 75);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(280, 28);
            this.dtpNgayMuon.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Độc Giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày Mượn";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(131, 76);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(87, 28);
            this.txtMaSach.TabIndex = 17;
            this.txtMaSach.TextChanged += new System.EventHandler(this.txtMaSach_TextChanged);
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(131, 35);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(87, 28);
            this.txtMaDG.TabIndex = 16;
            this.txtMaDG.TextChanged += new System.EventHandler(this.txtMaDG_TextChanged);
            // 
            // btnChoMuon
            // 
            this.btnChoMuon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnChoMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoMuon.ForeColor = System.Drawing.Color.White;
            this.btnChoMuon.Location = new System.Drawing.Point(18, 219);
            this.btnChoMuon.Name = "btnChoMuon";
            this.btnChoMuon.Size = new System.Drawing.Size(137, 32);
            this.btnChoMuon.TabIndex = 19;
            this.btnChoMuon.Text = "Mượn Sách";
            this.btnChoMuon.UseVisualStyleBackColor = false;
            this.btnChoMuon.Click += new System.EventHandler(this.btnChoMuon_Click);
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnXacNhanTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanTra.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanTra.Location = new System.Drawing.Point(18, 257);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(135, 32);
            this.btnXacNhanTra.TabIndex = 24;
            this.btnXacNhanTra.Text = "Trả Sách";
            this.btnXacNhanTra.UseVisualStyleBackColor = false;
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnXemSachDaMuon);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboTinhTrang);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnChoMuon);
            this.panel2.Controls.Add(this.btnXacNhanTra);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 360);
            this.panel2.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSSDM);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTensach);
            this.groupBox2.Controls.Add(this.txtTenDocGIa);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(162, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 142);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khu vực thông tin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Số sách đã mượn";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtSSDM
            // 
            this.txtSSDM.Location = new System.Drawing.Point(546, 35);
            this.txtSSDM.Name = "txtSSDM";
            this.txtSSDM.Size = new System.Drawing.Size(63, 28);
            this.txtSSDM.TabIndex = 27;
            this.txtSSDM.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "Tên Sách";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "Tên Đôc Giả";
            // 
            // txtTensach
            // 
            this.txtTensach.Location = new System.Drawing.Point(131, 76);
            this.txtTensach.Name = "txtTensach";
            this.txtTensach.Size = new System.Drawing.Size(233, 28);
            this.txtTensach.TabIndex = 17;
            // 
            // txtTenDocGIa
            // 
            this.txtTenDocGIa.Location = new System.Drawing.Point(131, 35);
            this.txtTenDocGIa.Name = "txtTenDocGIa";
            this.txtTenDocGIa.Size = new System.Drawing.Size(233, 28);
            this.txtTenDocGIa.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(381, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 42);
            this.label7.TabIndex = 25;
            this.label7.Text = "Mượn và trả";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DgvMuonTra);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 360);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1014, 350);
            this.panel3.TabIndex = 6;
            // 
            // DgvMuonTra
            // 
            this.DgvMuonTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMuonTra.Location = new System.Drawing.Point(0, 0);
            this.DgvMuonTra.Name = "DgvMuonTra";
            this.DgvMuonTra.RowHeadersWidth = 51;
            this.DgvMuonTra.RowTemplate.Height = 24;
            this.DgvMuonTra.Size = new System.Drawing.Size(1014, 350);
            this.DgvMuonTra.TabIndex = 0;
            this.DgvMuonTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMuonTra_CellContentClick);
            // 
            // btnXemSachDaMuon
            // 
            this.btnXemSachDaMuon.BackColor = System.Drawing.Color.BlueViolet;
            this.btnXemSachDaMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemSachDaMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemSachDaMuon.ForeColor = System.Drawing.Color.White;
            this.btnXemSachDaMuon.Location = new System.Drawing.Point(19, 295);
            this.btnXemSachDaMuon.Name = "btnXemSachDaMuon";
            this.btnXemSachDaMuon.Size = new System.Drawing.Size(137, 32);
            this.btnXemSachDaMuon.TabIndex = 31;
            this.btnXemSachDaMuon.Text = "Ds Sách";
            this.btnXemSachDaMuon.UseVisualStyleBackColor = false;
            this.btnXemSachDaMuon.Click += new System.EventHandler(this.btnXemSachDaMuon_Click_1);
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
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMuonTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox cboTinhTrang;
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
        private System.Windows.Forms.Button btnXemDs;
        private System.Windows.Forms.DataGridView DgvMuonTra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTensach;
        private System.Windows.Forms.TextBox txtTenDocGIa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSSDM;
        private System.Windows.Forms.Button btnXemSachDaMuon;
    }
}
