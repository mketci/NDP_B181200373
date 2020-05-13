namespace MixApp
{
    partial class MainPage
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnStokDurum = new System.Windows.Forms.Button();
            this.btnUc = new System.Windows.Forms.Button();
            this.BtnIki = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.btnStokGiris = new System.Windows.Forms.Button();
            this.btnMarkaGiris = new System.Windows.Forms.Button();
            this.btnKategoriGiris = new System.Windows.Forms.Button();
            this.btnUrunGiris = new System.Windows.Forms.Button();
            this.btnFirmaGiris = new System.Windows.Forms.Button();
            this.grb3 = new System.Windows.Forms.GroupBox();
            this.btnSiparisAl = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grb2.SuspendLayout();
            this.grb3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Orange;
            this.pnlTop.Controls.Add(this.btnStokDurum);
            this.pnlTop.Controls.Add(this.btnUc);
            this.pnlTop.Controls.Add(this.BtnIki);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(799, 53);
            this.pnlTop.TabIndex = 0;
            // 
            // btnStokDurum
            // 
            this.btnStokDurum.Location = new System.Drawing.Point(236, 10);
            this.btnStokDurum.Name = "btnStokDurum";
            this.btnStokDurum.Size = new System.Drawing.Size(95, 28);
            this.btnStokDurum.TabIndex = 1;
            this.btnStokDurum.Text = "Stok Durum";
            this.btnStokDurum.UseVisualStyleBackColor = true;
            this.btnStokDurum.Click += new System.EventHandler(this.btnStokDurum_Click);
            // 
            // btnUc
            // 
            this.btnUc.Location = new System.Drawing.Point(130, 11);
            this.btnUc.Margin = new System.Windows.Forms.Padding(2);
            this.btnUc.Name = "btnUc";
            this.btnUc.Size = new System.Drawing.Size(94, 28);
            this.btnUc.TabIndex = 0;
            this.btnUc.Text = "Sipariş Takip";
            this.btnUc.UseVisualStyleBackColor = true;
            this.btnUc.Click += new System.EventHandler(this.btnUc_Click);
            // 
            // BtnIki
            // 
            this.BtnIki.Location = new System.Drawing.Point(18, 10);
            this.BtnIki.Margin = new System.Windows.Forms.Padding(2);
            this.BtnIki.Name = "BtnIki";
            this.BtnIki.Size = new System.Drawing.Size(94, 28);
            this.BtnIki.TabIndex = 0;
            this.BtnIki.Text = "Bilgi Giriş";
            this.BtnIki.UseVisualStyleBackColor = true;
            this.BtnIki.Click += new System.EventHandler(this.BtnIki_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlLeft.Controls.Add(this.grb3);
            this.pnlLeft.Controls.Add(this.grb2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 53);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(151, 428);
            this.pnlLeft.TabIndex = 1;
            // 
            // grb2
            // 
            this.grb2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.grb2.Controls.Add(this.btnStokGiris);
            this.grb2.Controls.Add(this.btnMarkaGiris);
            this.grb2.Controls.Add(this.btnKategoriGiris);
            this.grb2.Controls.Add(this.btnUrunGiris);
            this.grb2.Controls.Add(this.btnFirmaGiris);
            this.grb2.Dock = System.Windows.Forms.DockStyle.Left;
            this.grb2.Location = new System.Drawing.Point(0, 0);
            this.grb2.Margin = new System.Windows.Forms.Padding(2);
            this.grb2.Name = "grb2";
            this.grb2.Padding = new System.Windows.Forms.Padding(2);
            this.grb2.Size = new System.Drawing.Size(150, 428);
            this.grb2.TabIndex = 0;
            this.grb2.TabStop = false;
            this.grb2.Text = "groupBox1";
            this.grb2.Visible = false;
            // 
            // btnStokGiris
            // 
            this.btnStokGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokGiris.Location = new System.Drawing.Point(5, 170);
            this.btnStokGiris.Name = "btnStokGiris";
            this.btnStokGiris.Size = new System.Drawing.Size(140, 32);
            this.btnStokGiris.TabIndex = 1;
            this.btnStokGiris.Text = "Stok Giriş";
            this.btnStokGiris.UseVisualStyleBackColor = true;
            this.btnStokGiris.Click += new System.EventHandler(this.btnStokGiris_Click);
            // 
            // btnMarkaGiris
            // 
            this.btnMarkaGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMarkaGiris.Location = new System.Drawing.Point(5, 132);
            this.btnMarkaGiris.Name = "btnMarkaGiris";
            this.btnMarkaGiris.Size = new System.Drawing.Size(140, 32);
            this.btnMarkaGiris.TabIndex = 1;
            this.btnMarkaGiris.Text = "Marka Giriş";
            this.btnMarkaGiris.UseVisualStyleBackColor = true;
            this.btnMarkaGiris.Click += new System.EventHandler(this.btnMarkaGiris_Click);
            // 
            // btnKategoriGiris
            // 
            this.btnKategoriGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategoriGiris.Location = new System.Drawing.Point(5, 94);
            this.btnKategoriGiris.Name = "btnKategoriGiris";
            this.btnKategoriGiris.Size = new System.Drawing.Size(140, 32);
            this.btnKategoriGiris.TabIndex = 1;
            this.btnKategoriGiris.Text = "Kategori Giriş";
            this.btnKategoriGiris.UseVisualStyleBackColor = true;
            this.btnKategoriGiris.Click += new System.EventHandler(this.btnKategoriGiris_Click);
            // 
            // btnUrunGiris
            // 
            this.btnUrunGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunGiris.Location = new System.Drawing.Point(5, 56);
            this.btnUrunGiris.Name = "btnUrunGiris";
            this.btnUrunGiris.Size = new System.Drawing.Size(140, 32);
            this.btnUrunGiris.TabIndex = 1;
            this.btnUrunGiris.Text = "Ürün Giriş";
            this.btnUrunGiris.UseVisualStyleBackColor = true;
            this.btnUrunGiris.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnFirmaGiris
            // 
            this.btnFirmaGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFirmaGiris.Location = new System.Drawing.Point(5, 18);
            this.btnFirmaGiris.Name = "btnFirmaGiris";
            this.btnFirmaGiris.Size = new System.Drawing.Size(140, 32);
            this.btnFirmaGiris.TabIndex = 0;
            this.btnFirmaGiris.Text = "Firma Giriş";
            this.btnFirmaGiris.UseVisualStyleBackColor = true;
            this.btnFirmaGiris.Click += new System.EventHandler(this.btnFirma_Click);
            // 
            // grb3
            // 
            this.grb3.BackColor = System.Drawing.Color.SeaGreen;
            this.grb3.Controls.Add(this.btnSiparisAl);
            this.grb3.Dock = System.Windows.Forms.DockStyle.Left;
            this.grb3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grb3.Location = new System.Drawing.Point(150, 0);
            this.grb3.Margin = new System.Windows.Forms.Padding(2);
            this.grb3.Name = "grb3";
            this.grb3.Padding = new System.Windows.Forms.Padding(2);
            this.grb3.Size = new System.Drawing.Size(150, 428);
            this.grb3.TabIndex = 0;
            this.grb3.TabStop = false;
            this.grb3.Text = "groupBox1";
            this.grb3.Visible = false;
            // 
            // btnSiparisAl
            // 
            this.btnSiparisAl.Location = new System.Drawing.Point(5, 18);
            this.btnSiparisAl.Name = "btnSiparisAl";
            this.btnSiparisAl.Size = new System.Drawing.Size(140, 32);
            this.btnSiparisAl.TabIndex = 0;
            this.btnSiparisAl.Text = "Sipariş Al";
            this.btnSiparisAl.UseVisualStyleBackColor = true;
            this.btnSiparisAl.Click += new System.EventHandler(this.btnSiparisAl_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 481);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grb2.ResumeLayout(false);
            this.grb3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnUc;
        private System.Windows.Forms.Button BtnIki;
        private System.Windows.Forms.GroupBox grb3;
        private System.Windows.Forms.GroupBox grb2;
        private System.Windows.Forms.Button btnFirmaGiris;
        private System.Windows.Forms.Button btnUrunGiris;
        private System.Windows.Forms.Button btnKategoriGiris;
        private System.Windows.Forms.Button btnMarkaGiris;
        private System.Windows.Forms.Button btnSiparisAl;
        private System.Windows.Forms.Button btnStokDurum;
        private System.Windows.Forms.Button btnStokGiris;
    }
}