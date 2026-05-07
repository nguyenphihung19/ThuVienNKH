namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class ucQuanLySach
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
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.cboTinhTrang = new System.Windows.Forms.GroupBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSua = new System.Windows.Forms.Button();
            this.BtnXoa = new System.Windows.Forms.Button();
            this.BtnThem = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CboTinhTrangSach = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            //this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.cboTinhTrang.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSach
            // 
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 0);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(947, 520);
            this.dgvSach.TabIndex = 2;
            this.dgvSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellContentClick);
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Controls.Add(this.BtnReset);
            this.cboTinhTrang.Controls.Add(this.BtnSua);
            this.cboTinhTrang.Controls.Add(this.BtnXoa);
            this.cboTinhTrang.Controls.Add(this.BtnThem);
            this.cboTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinhTrang.ForeColor = System.Drawing.Color.Gold;
            this.cboTinhTrang.Location = new System.Drawing.Point(8, 38);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(220, 126);
            this.cboTinhTrang.TabIndex = 1;
            this.cboTinhTrang.TabStop = false;
            this.cboTinhTrang.Text = "Công Cụ";
            // 
            // BtnReset
            // 
            this.BtnReset.ForeColor = System.Drawing.Color.Black;
            this.BtnReset.Location = new System.Drawing.Point(121, 78);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(94, 42);
            this.BtnReset.TabIndex = 12;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSua
            // 
            this.BtnSua.ForeColor = System.Drawing.Color.Black;
            this.BtnSua.Location = new System.Drawing.Point(121, 29);
            this.BtnSua.Name = "BtnSua";
            this.BtnSua.Size = new System.Drawing.Size(94, 42);
            this.BtnSua.TabIndex = 2;
            this.BtnSua.Text = "Sửa";
            this.BtnSua.UseVisualStyleBackColor = true;
            this.BtnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // BtnXoa
            // 
            this.BtnXoa.ForeColor = System.Drawing.Color.Black;
            this.BtnXoa.Location = new System.Drawing.Point(7, 78);
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.Size = new System.Drawing.Size(94, 42);
            this.BtnXoa.TabIndex = 1;
            this.BtnXoa.Text = "Xóa";
            this.BtnXoa.UseVisualStyleBackColor = true;
            this.BtnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // BtnThem
            // 
            this.BtnThem.ForeColor = System.Drawing.Color.Black;
            this.BtnThem.Location = new System.Drawing.Point(7, 29);
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(94, 42);
            this.BtnThem.TabIndex = 0;
            this.BtnThem.Text = "Thêm";
            this.BtnThem.UseVisualStyleBackColor = true;
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 28);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Loại sách";
            // 
            // CboTinhTrangSach
            // 
            this.CboTinhTrangSach.FormattingEnabled = true;
            this.CboTinhTrangSach.Items.AddRange(new object[] {
            "Mới",
            "Cũ",
            "Hỏng"});
            this.CboTinhTrangSach.Location = new System.Drawing.Point(486, 61);
            this.CboTinhTrangSach.Name = "CboTinhTrangSach";
            this.CboTinhTrangSach.Size = new System.Drawing.Size(211, 30);
            this.CboTinhTrangSach.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(486, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(211, 28);
            this.textBox4.TabIndex = 10;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 28);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(124, 24);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(188, 28);
            this.txtMaSach.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tình Trạng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã Sách";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboTinhTrang);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 165);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(386, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 29);
            this.label6.TabIndex = 3;
            this.label6.Text = "Quản lý sách ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboTinhTrangSach);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            //this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label3);
            //this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(234, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // 
            //this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.dgvSach);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 165);
            this.panel2.Name = "panel2";
            //this.dateTimePicker1.Size = new System.Drawing.Size(8, 26);
            //this.dateTimePicker1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Bài_TH_Quản_Lý_Thư_Viện.Properties.Resources.Interior_Design_Wutopia_Lab_idx190601_wl02_06_19;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1065, 650);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(434, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 32);
            this.label6.TabIndex = 3;
            this.label6.Text = "Quản lý sách ";
            // 
            // ucQuanLySach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucQuanLySach";
            this.Size = new System.Drawing.Size(947, 685);
            this.Load += new System.EventHandler(this.ucQuanLySach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.cboTinhTrang.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.GroupBox cboTinhTrang;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.ComboBox CboTinhTrangSach;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSua;
        private System.Windows.Forms.Button BtnXoa;
        private System.Windows.Forms.Button BtnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
    }
}
