namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class ucTraCuuSach
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
            this.cboTheLoaiSach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridviewTraCuu = new System.Windows.Forms.DataGridView();
            this.MaDauSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDauSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTraCuu)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTheLoaiSach
            // 
            this.cboTheLoaiSach.FormattingEnabled = true;
            this.cboTheLoaiSach.Items.AddRange(new object[] {
            "CNTT",
            "Kinh doanh",
            "Y Học",
            "Kinh tế học"});
            this.cboTheLoaiSach.Location = new System.Drawing.Point(147, 39);
            this.cboTheLoaiSach.Name = "cboTheLoaiSach";
            this.cboTheLoaiSach.Size = new System.Drawing.Size(181, 24);
            this.cboTheLoaiSach.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thể loại sách";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 75);
            this.panel1.TabIndex = 5;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(779, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(103, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(687, 22);
            this.txtSearch.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboTheLoaiSach);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 79);
            this.panel2.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(782, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 34);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Đặt Lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridviewTraCuu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(957, 454);
            this.panel3.TabIndex = 6;
            // 
            // gridviewTraCuu
            // 
            this.gridviewTraCuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewTraCuu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDauSach,
            this.TenDauSach,
            this.TenLoaiSach,
            this.TinhTrang});
            this.gridviewTraCuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridviewTraCuu.Location = new System.Drawing.Point(0, 0);
            this.gridviewTraCuu.Name = "gridviewTraCuu";
            this.gridviewTraCuu.RowHeadersWidth = 51;
            this.gridviewTraCuu.RowTemplate.Height = 24;
            this.gridviewTraCuu.Size = new System.Drawing.Size(957, 454);
            this.gridviewTraCuu.TabIndex = 0;
            // 
            // MaDauSach
            // 
            this.MaDauSach.DataPropertyName = "MaDauSach";
            this.MaDauSach.HeaderText = "Ma Sach";
            this.MaDauSach.MinimumWidth = 6;
            this.MaDauSach.Name = "MaDauSach";
            this.MaDauSach.Width = 125;
            // 
            // TenDauSach
            // 
            this.TenDauSach.DataPropertyName = "TenDauSach";
            this.TenDauSach.HeaderText = "Ten Sach";
            this.TenDauSach.MinimumWidth = 6;
            this.TenDauSach.Name = "TenDauSach";
            this.TenDauSach.Width = 125;
            // 
            // TenLoaiSach
            // 
            this.TenLoaiSach.DataPropertyName = "TenLoaiSach";
            this.TenLoaiSach.HeaderText = "Loai Sach";
            this.TenLoaiSach.MinimumWidth = 6;
            this.TenLoaiSach.Name = "TenLoaiSach";
            this.TenLoaiSach.Width = 125;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tinh Trang";
            this.TinhTrang.MinimumWidth = 6;
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 125;
            // 
            // ucTraCuuSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucTraCuuSach";
            this.Size = new System.Drawing.Size(957, 608);
            this.Load += new System.EventHandler(this.ucTraCuuSach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTraCuu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboTheLoaiSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView gridviewTraCuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDauSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDauSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
    }
}
