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

        private System.Windows.Forms.Button btnDashboard;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterLeft = new System.Windows.Forms.Label();
            this.lblFooterRight = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
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
            this.pnlHeader.Controls.Add(this.btnDashboard);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnOpen);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 90);
            this.pnlHeader.TabIndex = 2;
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
            this.lblSubTitle.Size = new System.Drawing.Size(314, 23);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Hệ thống Quản Lý Thư Viện • Chương 3";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(79)))), ((int)(((byte)(127)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(760, 25);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(190, 40);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard Tổng Quan";
            this.btnDashboard.UseVisualStyleBackColor = false;
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
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(107)))));
            this.pnlFooter.Controls.Add(this.lblFooterLeft);
            this.pnlFooter.Controls.Add(this.lblFooterRight);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 700);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1300, 50);
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
            this.lblFooterRight.Text = "Power BI Service Connected | Last Updated: 09/05/2026";
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
            this.pnlBody.Size = new System.Drawing.Size(1300, 610);
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
            this.pnlMain.Size = new System.Drawing.Size(970, 580);
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
            this.pnlBrowser.Size = new System.Drawing.Size(940, 550);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblPowerBI);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 55);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(910, 480);
            this.pnlContent.TabIndex = 0;
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
            this.pnlBrowserTop.Size = new System.Drawing.Size(910, 40);
            this.pnlBrowserTop.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flowLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(15, 15);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlLeft.Size = new System.Drawing.Size(300, 580);
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
            this.flowLeft.Size = new System.Drawing.Size(290, 580);
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
            this.lblCard1.Size = new System.Drawing.Size(142, 25);
            this.lblCard1.TabIndex = 0;
            this.lblCard1.Text = "Nguồn dữ liệu";
            // 
            // lblCard1Content
            // 
            this.lblCard1Content.AutoSize = true;
            this.lblCard1Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard1Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard1Content.Name = "lblCard1Content";
            this.lblCard1Content.Size = new System.Drawing.Size(168, 115);
            this.lblCard1Content.TabIndex = 1;
            this.lblCard1Content.Text = "• Visual Studio 2022\r\n• SQL Server\r\n• Power BI Desktop\r\n• .NET Framework\r\n• Windo" +
    "ws Forms C#";
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
            this.card2.Size = new System.Drawing.Size(260, 164);
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
            this.lblCard2.Size = new System.Drawing.Size(110, 25);
            this.lblCard2.TabIndex = 0;
            this.lblCard2.Text = "Công nghệ";
            // 
            // lblCard2Content
            // 
            this.lblCard2Content.AutoSize = true;
            this.lblCard2Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard2Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard2Content.Name = "lblCard2Content";
            this.lblCard2Content.Size = new System.Drawing.Size(160, 92);
            this.lblCard2Content.TabIndex = 1;
            this.lblCard2Content.Text = "• C#\r\n• SQL Server\r\n• Power BI Service\r\n• REST / Embed API";
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card3.Controls.Add(this.card3Header);
            this.card3.Controls.Add(this.lblCard3Content);
            this.card3.Location = new System.Drawing.Point(10, 394);
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
            this.lblCard3.Size = new System.Drawing.Size(185, 25);
            this.lblCard3.TabIndex = 0;
            this.lblCard3.Text = "Quy trình triển khai";
            // 
            // lblCard3Content
            // 
            this.lblCard3Content.AutoSize = true;
            this.lblCard3Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard3Content.Location = new System.Drawing.Point(20, 55);
            this.lblCard3Content.Name = "lblCard3Content";
            this.lblCard3Content.Size = new System.Drawing.Size(204, 115);
            this.lblCard3Content.TabIndex = 1;
            this.lblCard3Content.Text = "🟢 Tạo dữ liệu SQL\r\n🟢 Kết nối Power BI\r\n🟢 Publish lên Service\r\n🟢 Lấy Embed Lin" +
    "k\r\n🟢 Nhúng vào WinForms";
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGreen.FlatAppearance.BorderSize = 0;
            this.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGreen.ForeColor = System.Drawing.Color.White;
            this.btnGreen.Location = new System.Drawing.Point(10, 620);
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
            this.Size = new System.Drawing.Size(1300, 750);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlBrowser.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
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
    }
}