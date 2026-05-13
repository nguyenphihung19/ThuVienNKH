using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    partial class UCPowerBI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpen;

        private System.Windows.Forms.FlowLayoutPanel flowLeft;

        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.Panel pnlBrowserTop;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Label lblFooterLeft;
        private System.Windows.Forms.Label lblFooterRight;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea29 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend29 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title29 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea30 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend30 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title30 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea31 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend31 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title31 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea32 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend32 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title32 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterLeft = new System.Windows.Forms.Label();
            this.lblFooterRight = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTongSach = new System.Windows.Forms.Panel();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDocGia = new System.Windows.Forms.Panel();
            this.lblTongDocGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMuon = new System.Windows.Forms.Panel();
            this.lblTongMuon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTre = new System.Windows.Forms.Panel();
            this.lblSachTre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartTopSach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTopSach = new System.Windows.Forms.DataGridView();
            this.chartTrangThai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLoaiSach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMuonTheoThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPowerBI = new System.Windows.Forms.Label();
            this.pnlBrowserTop = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flowLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.card1 = new System.Windows.Forms.Panel();
            this.card1Header = new System.Windows.Forms.Panel();
            this.lblCard1 = new System.Windows.Forms.Label();
            this.lblCard1Content = new System.Windows.Forms.Label();
            this.card2 = new System.Windows.Forms.Panel();
            this.card2Header = new System.Windows.Forms.Panel();
            this.lblCard2 = new System.Windows.Forms.Label();
            this.lblCard2Content = new System.Windows.Forms.Label();
            this.card3 = new System.Windows.Forms.Panel();
            this.card3Header = new System.Windows.Forms.Panel();
            this.lblCard3 = new System.Windows.Forms.Label();
            this.lblCard3Content = new System.Windows.Forms.Label();
            this.btnGreen = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBrowser.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTongSach.SuspendLayout();
            this.panelDocGia.SuspendLayout();
            this.panelMuon.SuspendLayout();
            this.panelTre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMuonTheoThang)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.flowLeft.SuspendLayout();
            this.card1.SuspendLayout();
            this.card1Header.SuspendLayout();
            this.card2.SuspendLayout();
            this.card2Header.SuspendLayout();
            this.card3.SuspendLayout();
            this.card3Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(107)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnOpen);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1947, 90);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(519, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHÂN TÍCH & TRIỂN KHAI POWER BI";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubTitle.Location = new System.Drawing.Point(35, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(274, 23);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Hệ thống Quản Lý Thư Viện • NKH";
            this.lblSubTitle.Click += new System.EventHandler(this.lblSubTitle_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(79)))), ((int)(((byte)(127)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(960, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(79)))), ((int)(((byte)(127)))));
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(1080, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(150, 40);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open Power BI";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(107)))));
            this.pnlFooter.Controls.Add(this.lblFooterLeft);
            this.pnlFooter.Controls.Add(this.lblFooterRight);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 1082);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1947, 50);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.AutoSize = true;
            this.lblFooterLeft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFooterLeft.ForeColor = System.Drawing.Color.White;
            this.lblFooterLeft.Location = new System.Drawing.Point(20, 15);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Size = new System.Drawing.Size(197, 23);
            this.lblFooterLeft.TabIndex = 0;
            this.lblFooterLeft.Text = "📄 Quy trình triển khai";
            // 
            // lblFooterRight
            // 
            this.lblFooterRight.AutoSize = true;
            this.lblFooterRight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFooterRight.ForeColor = System.Drawing.Color.White;
            this.lblFooterRight.Location = new System.Drawing.Point(760, 15);
            this.lblFooterRight.Name = "lblFooterRight";
            this.lblFooterRight.Size = new System.Drawing.Size(462, 23);
            this.lblFooterRight.TabIndex = 1;
            this.lblFooterRight.Text = "Power BI Service Connected | Last Updated: 13/05/2026";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 90);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBody.Size = new System.Drawing.Size(1947, 992);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlBrowser);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(315, 15);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1617, 962);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBrowser.Controls.Add(this.pnlContent);
            this.pnlBrowser.Controls.Add(this.pnlBrowserTop);
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(15, 15);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBrowser.Size = new System.Drawing.Size(1587, 932);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.lblPowerBI);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 55);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1557, 862);
            this.pnlContent.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.panelTongSach);
            this.panel1.Controls.Add(this.panelDocGia);
            this.panel1.Controls.Add(this.panelMuon);
            this.panel1.Controls.Add(this.panelTre);
            this.panel1.Controls.Add(this.chartTopSach);
            this.panel1.Controls.Add(this.dgvTopSach);
            this.panel1.Controls.Add(this.chartTrangThai);
            this.panel1.Controls.Add(this.chartLoaiSach);
            this.panel1.Controls.Add(this.chartMuonTheoThang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1557, 862);
            this.panel1.TabIndex = 1;
            // 
            // panelTongSach
            // 
            this.panelTongSach.BackColor = System.Drawing.Color.MediumPurple;
            this.panelTongSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTongSach.Controls.Add(this.lblTongSach);
            this.panelTongSach.Controls.Add(this.label1);
            this.panelTongSach.Location = new System.Drawing.Point(20, 20);
            this.panelTongSach.Name = "panelTongSach";
            this.panelTongSach.Size = new System.Drawing.Size(350, 120);
            this.panelTongSach.TabIndex = 0;
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongSach.ForeColor = System.Drawing.Color.White;
            this.lblTongSach.Location = new System.Drawing.Point(25, 20);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(54, 62);
            this.lblTongSach.TabIndex = 0;
            this.lblTongSach.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng Sách";
            // 
            // panelDocGia
            // 
            this.panelDocGia.BackColor = System.Drawing.Color.MediumPurple;
            this.panelDocGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDocGia.Controls.Add(this.lblTongDocGia);
            this.panelDocGia.Controls.Add(this.label2);
            this.panelDocGia.Location = new System.Drawing.Point(400, 20);
            this.panelDocGia.Name = "panelDocGia";
            this.panelDocGia.Size = new System.Drawing.Size(350, 120);
            this.panelDocGia.TabIndex = 1;
            // 
            // lblTongDocGia
            // 
            this.lblTongDocGia.AutoSize = true;
            this.lblTongDocGia.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongDocGia.ForeColor = System.Drawing.Color.White;
            this.lblTongDocGia.Location = new System.Drawing.Point(25, 20);
            this.lblTongDocGia.Name = "lblTongDocGia";
            this.lblTongDocGia.Size = new System.Drawing.Size(54, 62);
            this.lblTongDocGia.TabIndex = 0;
            this.lblTongDocGia.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng Độc Giả";
            // 
            // panelMuon
            // 
            this.panelMuon.BackColor = System.Drawing.Color.MediumPurple;
            this.panelMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMuon.Controls.Add(this.lblTongMuon);
            this.panelMuon.Controls.Add(this.label3);
            this.panelMuon.Location = new System.Drawing.Point(780, 20);
            this.panelMuon.Name = "panelMuon";
            this.panelMuon.Size = new System.Drawing.Size(350, 120);
            this.panelMuon.TabIndex = 2;
            // 
            // lblTongMuon
            // 
            this.lblTongMuon.AutoSize = true;
            this.lblTongMuon.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongMuon.ForeColor = System.Drawing.Color.White;
            this.lblTongMuon.Location = new System.Drawing.Point(25, 20);
            this.lblTongMuon.Name = "lblTongMuon";
            this.lblTongMuon.Size = new System.Drawing.Size(54, 62);
            this.lblTongMuon.TabIndex = 0;
            this.lblTongMuon.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phiếu Mượn";
            // 
            // panelTre
            // 
            this.panelTre.BackColor = System.Drawing.Color.MediumPurple;
            this.panelTre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTre.Controls.Add(this.lblSachTre);
            this.panelTre.Controls.Add(this.label4);
            this.panelTre.Location = new System.Drawing.Point(1160, 20);
            this.panelTre.Name = "panelTre";
            this.panelTre.Size = new System.Drawing.Size(350, 120);
            this.panelTre.TabIndex = 3;
            // 
            // lblSachTre
            // 
            this.lblSachTre.AutoSize = true;
            this.lblSachTre.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSachTre.ForeColor = System.Drawing.Color.White;
            this.lblSachTre.Location = new System.Drawing.Point(25, 20);
            this.lblSachTre.Name = "lblSachTre";
            this.lblSachTre.Size = new System.Drawing.Size(54, 62);
            this.lblSachTre.TabIndex = 0;
            this.lblSachTre.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sách Quá Hạn";
            // 
            // chartTopSach
            // 
            this.chartTopSach.BorderlineColor = System.Drawing.Color.MediumPurple;
            this.chartTopSach.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartTopSach.BorderlineWidth = 2;
            chartArea29.Name = "ChartArea1";
            this.chartTopSach.ChartAreas.Add(chartArea29);
            legend29.Name = "Legend1";
            this.chartTopSach.Legends.Add(legend29);
            this.chartTopSach.Location = new System.Drawing.Point(20, 170);
            this.chartTopSach.Name = "chartTopSach";
            this.chartTopSach.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartTopSach.Size = new System.Drawing.Size(520, 300);
            this.chartTopSach.TabIndex = 4;
            title29.Name = "Title1";
            title29.Text = "Count of MaSach by TrangThaiThanhLy";
            this.chartTopSach.Titles.Add(title29);
            // 
            // dgvTopSach
            // 
            this.dgvTopSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTopSach.ColumnHeadersHeight = 40;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopSach.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTopSach.EnableHeadersVisualStyles = false;
            this.dgvTopSach.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTopSach.Location = new System.Drawing.Point(555, 170);
            this.dgvTopSach.Name = "dgvTopSach";
            this.dgvTopSach.RowHeadersWidth = 51;
            this.dgvTopSach.RowTemplate.Height = 35;
            this.dgvTopSach.Size = new System.Drawing.Size(540, 300);
            this.dgvTopSach.TabIndex = 5;
            // 
            // chartTrangThai
            // 
            this.chartTrangThai.BorderlineColor = System.Drawing.Color.MediumPurple;
            this.chartTrangThai.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartTrangThai.BorderlineWidth = 2;
            chartArea30.Name = "ChartArea1";
            this.chartTrangThai.ChartAreas.Add(chartArea30);
            legend30.Name = "Legend1";
            this.chartTrangThai.Legends.Add(legend30);
            this.chartTrangThai.Location = new System.Drawing.Point(1120, 170);
            this.chartTrangThai.Name = "chartTrangThai";
            this.chartTrangThai.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chartTrangThai.Size = new System.Drawing.Size(390, 300);
            this.chartTrangThai.TabIndex = 6;
            title30.Name = "Title1";
            title30.Text = "Count of MaSach by TinhTrang";
            this.chartTrangThai.Titles.Add(title30);
            // 
            // chartLoaiSach
            // 
            this.chartLoaiSach.BorderlineColor = System.Drawing.Color.MediumPurple;
            this.chartLoaiSach.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartLoaiSach.BorderlineWidth = 2;
            chartArea31.Name = "ChartArea1";
            this.chartLoaiSach.ChartAreas.Add(chartArea31);
            legend31.Name = "Legend1";
            this.chartLoaiSach.Legends.Add(legend31);
            this.chartLoaiSach.Location = new System.Drawing.Point(20, 500);
            this.chartLoaiSach.Name = "chartLoaiSach";
            this.chartLoaiSach.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            this.chartLoaiSach.Size = new System.Drawing.Size(760, 330);
            this.chartLoaiSach.TabIndex = 7;
            title31.Name = "Title1";
            title31.Text = "Count of MaLoaiSach by SoSachMuon";
            this.chartLoaiSach.Titles.Add(title31);
            // 
            // chartMuonTheoThang
            // 
            this.chartMuonTheoThang.BorderlineColor = System.Drawing.Color.MediumPurple;
            this.chartMuonTheoThang.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartMuonTheoThang.BorderlineWidth = 2;
            chartArea32.Name = "ChartArea1";
            this.chartMuonTheoThang.ChartAreas.Add(chartArea32);
            legend32.Name = "Legend1";
            this.chartMuonTheoThang.Legends.Add(legend32);
            this.chartMuonTheoThang.Location = new System.Drawing.Point(810, 500);
            this.chartMuonTheoThang.Name = "chartMuonTheoThang";
            this.chartMuonTheoThang.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartMuonTheoThang.Size = new System.Drawing.Size(700, 330);
            this.chartMuonTheoThang.TabIndex = 8;
            title32.Name = "Title1";
            title32.Text = "Count of MaDG by SoSachMuon";
            this.chartMuonTheoThang.Titles.Add(title32);
            // 
            // lblPowerBI
            // 
            this.lblPowerBI.AutoSize = true;
            this.lblPowerBI.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPowerBI.ForeColor = System.Drawing.Color.Gray;
            this.lblPowerBI.Location = new System.Drawing.Point(250, 250);
            this.lblPowerBI.Name = "lblPowerBI";
            this.lblPowerBI.Size = new System.Drawing.Size(475, 54);
            this.lblPowerBI.TabIndex = 0;
            this.lblPowerBI.Text = "POWER BI DASHBOARD";
            // 
            // pnlBrowserTop
            // 
            this.pnlBrowserTop.BackColor = System.Drawing.Color.LightGray;
            this.pnlBrowserTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowserTop.Location = new System.Drawing.Point(15, 15);
            this.pnlBrowserTop.Name = "pnlBrowserTop";
            this.pnlBrowserTop.Size = new System.Drawing.Size(1557, 40);
            this.pnlBrowserTop.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flowLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(15, 15);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlLeft.Size = new System.Drawing.Size(300, 962);
            this.pnlLeft.TabIndex = 1;
            // 
            // flowLeft
            // 
            this.flowLeft.AutoScroll = true;
            this.flowLeft.Controls.Add(this.card1);
            this.flowLeft.Controls.Add(this.card2);
            this.flowLeft.Controls.Add(this.card3);
            this.flowLeft.Controls.Add(this.btnGreen);
            this.flowLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLeft.Name = "flowLeft";
            this.flowLeft.Size = new System.Drawing.Size(290, 962);
            this.flowLeft.TabIndex = 0;
            this.flowLeft.WrapContents = false;
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card1.Controls.Add(this.card1Header);
            this.card1.Controls.Add(this.lblCard1Content);
            this.card1.Location = new System.Drawing.Point(10, 10);
            this.card1.Margin = new System.Windows.Forms.Padding(10);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(260, 180);
            this.card1.TabIndex = 0;
            // 
            // card1Header
            // 
            this.card1Header.BackColor = System.Drawing.Color.RoyalBlue;
            this.card1Header.Controls.Add(this.lblCard1);
            this.card1Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.card1Header.Location = new System.Drawing.Point(0, 0);
            this.card1Header.Name = "card1Header";
            this.card1Header.Size = new System.Drawing.Size(258, 40);
            this.card1Header.TabIndex = 0;
            // 
            // lblCard1
            // 
            this.lblCard1.AutoSize = true;
            this.lblCard1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCard1.ForeColor = System.Drawing.Color.White;
            this.lblCard1.Location = new System.Drawing.Point(15, 10);
            this.lblCard1.Name = "lblCard1";
            this.lblCard1.Size = new System.Drawing.Size(183, 25);
            this.lblCard1.TabIndex = 0;
            this.lblCard1.Text = "Giới thiệu hệ thống";
            // 
            // lblCard1Content
            // 
            this.lblCard1Content.AutoSize = true;
            this.lblCard1Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard1Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard1Content.Name = "lblCard1Content";
            this.lblCard1Content.Size = new System.Drawing.Size(179, 115);
            this.lblCard1Content.TabIndex = 1;
            this.lblCard1Content.Text = "• Quản lý thư viện\n• Quản lý sách\n• Quản lý độc giả\n• Quản lý phiếu mượn\n• Quản l" +
    "ý phiếu trả";
            this.lblCard1Content.Click += new System.EventHandler(this.lblCard1Content_Click);
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card2.Controls.Add(this.card2Header);
            this.card2.Controls.Add(this.lblCard2Content);
            this.card2.Location = new System.Drawing.Point(10, 210);
            this.card2.Margin = new System.Windows.Forms.Padding(10);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(260, 185);
            this.card2.TabIndex = 1;
            // 
            // card2Header
            // 
            this.card2Header.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.card2Header.Controls.Add(this.lblCard2);
            this.card2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.card2Header.Location = new System.Drawing.Point(0, 0);
            this.card2Header.Name = "card2Header";
            this.card2Header.Size = new System.Drawing.Size(258, 40);
            this.card2Header.TabIndex = 0;
            // 
            // lblCard2
            // 
            this.lblCard2.AutoSize = true;
            this.lblCard2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCard2.ForeColor = System.Drawing.Color.White;
            this.lblCard2.Location = new System.Drawing.Point(15, 10);
            this.lblCard2.Name = "lblCard2";
            this.lblCard2.Size = new System.Drawing.Size(161, 25);
            this.lblCard2.TabIndex = 0;
            this.lblCard2.Text = "Chức năng chính";
            // 
            // lblCard2Content
            // 
            this.lblCard2Content.AutoSize = true;
            this.lblCard2Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard2Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard2Content.Name = "lblCard2Content";
            this.lblCard2Content.Size = new System.Drawing.Size(157, 115);
            this.lblCard2Content.TabIndex = 1;
            this.lblCard2Content.Text = "• Quản lý sách\n• Lập phiếu mượn\n• Lập phiếu trả\n• Thanh lý sách\n• Quản lý tài kho" +
    "ản";
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card3.Controls.Add(this.card3Header);
            this.card3.Controls.Add(this.lblCard3Content);
            this.card3.Location = new System.Drawing.Point(10, 415);
            this.card3.Margin = new System.Windows.Forms.Padding(10);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(260, 206);
            this.card3.TabIndex = 2;
            // 
            // card3Header
            // 
            this.card3Header.BackColor = System.Drawing.Color.Goldenrod;
            this.card3Header.Controls.Add(this.lblCard3);
            this.card3Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.card3Header.Location = new System.Drawing.Point(0, 0);
            this.card3Header.Name = "card3Header";
            this.card3Header.Size = new System.Drawing.Size(258, 40);
            this.card3Header.TabIndex = 0;
            // 
            // lblCard3
            // 
            this.lblCard3.AutoSize = true;
            this.lblCard3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCard3.ForeColor = System.Drawing.Color.White;
            this.lblCard3.Location = new System.Drawing.Point(15, 10);
            this.lblCard3.Name = "lblCard3";
            this.lblCard3.Size = new System.Drawing.Size(167, 25);
            this.lblCard3.TabIndex = 0;
            this.lblCard3.Text = "Báo cáo thống kê";
            // 
            // lblCard3Content
            // 
            this.lblCard3Content.AutoSize = true;
            this.lblCard3Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard3Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard3Content.Name = "lblCard3Content";
            this.lblCard3Content.Size = new System.Drawing.Size(184, 115);
            this.lblCard3Content.TabIndex = 1;
            this.lblCard3Content.Text = "◉ Số lượng sách\n◉ Sách đang mượn\n◉ Độc giả hoạt động\n◉ Thống kê quá hạn\n◉ Dashboa" +
    "rd Power BI";
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGreen.FlatAppearance.BorderSize = 0;
            this.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGreen.ForeColor = System.Drawing.Color.White;
            this.btnGreen.Location = new System.Drawing.Point(10, 641);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(10);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(260, 50);
            this.btnGreen.TabIndex = 3;
            this.btnGreen.Text = "Tích hợp Dashboard";
            this.btnGreen.UseVisualStyleBackColor = false;
            // 
            // UCPowerBI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCPowerBI";
            this.Size = new System.Drawing.Size(1947, 1132);
            this.Load += new System.EventHandler(this.UCPowerBI_Load_1);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlBrowser.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelTongSach.ResumeLayout(false);
            this.panelTongSach.PerformLayout();
            this.panelDocGia.ResumeLayout(false);
            this.panelDocGia.PerformLayout();
            this.panelMuon.ResumeLayout(false);
            this.panelMuon.PerformLayout();
            this.panelTre.ResumeLayout(false);
            this.panelTre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMuonTheoThang)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.flowLeft.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card1Header.ResumeLayout(false);
            this.card1Header.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card2Header.ResumeLayout(false);
            this.card2Header.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card3Header.ResumeLayout(false);
            this.card3Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblPowerBI;
        private Panel card1;
        private Panel card1Header;
        private Label lblCard1;
        private Label lblCard1Content;
        private Panel card2;
        private Panel card2Header;
        private Label lblCard2;
        private Label lblCard2Content;
        private Panel card3;
        private Panel card3Header;
        private Label lblCard3;
        private Label lblCard3Content;
        private Button btnGreen;
        private Panel panel1;
        private Panel panelTongSach;
        private Label lblTongSach;
        private Label label1;
        private Panel panelDocGia;
        private Label lblTongDocGia;
        private Label label2;
        private Panel panelMuon;
        private Label lblTongMuon;
        private Label label3;
        private Panel panelTre;
        private Label lblSachTre;
        private Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSach;
        private DataGridView dgvTopSach;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrangThai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiSach;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMuonTheoThang;
    }
}