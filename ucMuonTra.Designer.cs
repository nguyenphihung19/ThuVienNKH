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
            this.btnLocQuaHan = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
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
            this.DgvMuonTra = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTinhTrang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMuonTra)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.BackColor = System.Drawing.Color.PowderBlue;
            this.cboTinhTrang.Controls.Add(this.btnXemDs);
            this.cboTinhTrang.Controls.Add(this.btnLocQuaHan);
            this.cboTinhTrang.Controls.Add(this.btnInPhieu);
            this.cboTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinhTrang.Location = new System.Drawing.Point(13, 71);
            this.cboTinhTrang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTinhTrang.Size = new System.Drawing.Size(162, 177);
            this.cboTinhTrang.TabIndex = 1;
            this.cboTinhTrang.TabStop = false;
            this.cboTinhTrang.Text = "Công Cụ";
            // 
            // btnXemDs
            // 
            this.btnXemDs.Location = new System.Drawing.Point(8, 120);
            this.btnXemDs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXemDs.Name = "btnXemDs";
            this.btnXemDs.Size = new System.Drawing.Size(137, 37);
            this.btnXemDs.TabIndex = 2;
            this.btnXemDs.Text = "Xem Danh Sách";
            this.btnXemDs.UseVisualStyleBackColor = true;
            this.btnXemDs.Click += new System.EventHandler(this.btnXemDs_Click);
            // 
            // btnLocQuaHan
            // 
            this.btnLocQuaHan.Location = new System.Drawing.Point(8, 73);
            this.btnLocQuaHan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLocQuaHan.Name = "btnLocQuaHan";
            this.btnLocQuaHan.Size = new System.Drawing.Size(137, 37);
            this.btnLocQuaHan.TabIndex = 1;
            this.btnLocQuaHan.Text = "Quá hạn";
            this.btnLocQuaHan.UseVisualStyleBackColor = true;
            this.btnLocQuaHan.Visible = false;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(8, 28);
            this.btnInPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(137, 37);
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
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.dtpNgayMuon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.txtMaDG);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(182, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(923, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khu Vực Mượn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 26);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mã PM";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(347, 93);
            this.txtMaPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(97, 32);
            this.txtMaPhieuMuon.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 26);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mã NV";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(347, 45);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(97, 32);
            this.txtMaNV.TabIndex = 27;
            // 
            // btnChoMuon
            // 
            this.btnChoMuon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnChoMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoMuon.ForeColor = System.Drawing.Color.White;
            this.btnChoMuon.Location = new System.Drawing.Point(650, 253);
            this.btnChoMuon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoMuon.Name = "btnChoMuon";
            this.btnChoMuon.Size = new System.Drawing.Size(154, 40);
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
            this.btnXacNhanTra.Location = new System.Drawing.Point(823, 253);
            this.btnXacNhanTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(152, 40);
            this.btnXacNhanTra.TabIndex = 24;
            this.btnXacNhanTra.Text = "Trả Sách";
            this.btnXacNhanTra.UseVisualStyleBackColor = false;
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Location = new System.Drawing.Point(601, 27);
            this.dtpNgayTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(238, 32);
            this.dtpNgayTra.TabIndex = 25;
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Location = new System.Drawing.Point(601, 94);
            this.dtpNgayMuon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(234, 32);
            this.dtpNgayMuon.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Độc Giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày Mượn";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(147, 95);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(97, 32);
            this.txtMaSach.TabIndex = 17;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(147, 44);
            this.txtMaDG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(97, 32);
            this.txtMaDG.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboTinhTrang);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnChoMuon);
            this.panel2.Controls.Add(this.btnXacNhanTra);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 308);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DgvMuonTra);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 308);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1141, 580);
            this.panel3.TabIndex = 6;
            // 
            // DgvMuonTra
            // 
            this.DgvMuonTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMuonTra.Location = new System.Drawing.Point(0, 0);
            this.DgvMuonTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvMuonTra.Name = "DgvMuonTra";
            this.DgvMuonTra.RowHeadersWidth = 51;
            this.DgvMuonTra.RowTemplate.Height = 24;
            this.DgvMuonTra.Size = new System.Drawing.Size(1141, 580);
            this.DgvMuonTra.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(429, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 52);
            this.label7.TabIndex = 25;
            this.label7.Text = "Mượn và trả";
            // 
            // ucMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucMuonTra";
            this.Size = new System.Drawing.Size(1141, 888);
            this.cboTinhTrang.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label label7;
    }
}
