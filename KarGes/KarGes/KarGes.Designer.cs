namespace KarGes
{
    partial class frm_KarGes
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KarGes));
            this.lbl_Sicil_No = new System.Windows.Forms.Label();
            this.lbl_Ad = new System.Windows.Forms.Label();
            this.lbl_Soyad = new System.Windows.Forms.Label();
            this.lbl_Departman = new System.Windows.Forms.Label();
            this.lbl_Gorev = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.tmr_Kontrol = new System.Windows.Forms.Timer(this.components);
            this.lbl_Kayit_Durum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            this.btn_Detay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Bugun = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Kayit_Saat = new System.Windows.Forms.Label();
            this.tmr_Temizle = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Sicil_No
            // 
            this.lbl_Sicil_No.AutoSize = true;
            this.lbl_Sicil_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Sicil_No.Location = new System.Drawing.Point(329, 70);
            this.lbl_Sicil_No.Name = "lbl_Sicil_No";
            this.lbl_Sicil_No.Size = new System.Drawing.Size(0, 25);
            this.lbl_Sicil_No.TabIndex = 0;
            // 
            // lbl_Ad
            // 
            this.lbl_Ad.AutoSize = true;
            this.lbl_Ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Ad.Location = new System.Drawing.Point(329, 110);
            this.lbl_Ad.Name = "lbl_Ad";
            this.lbl_Ad.Size = new System.Drawing.Size(0, 25);
            this.lbl_Ad.TabIndex = 1;
            // 
            // lbl_Soyad
            // 
            this.lbl_Soyad.AutoSize = true;
            this.lbl_Soyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Soyad.Location = new System.Drawing.Point(329, 149);
            this.lbl_Soyad.Name = "lbl_Soyad";
            this.lbl_Soyad.Size = new System.Drawing.Size(0, 25);
            this.lbl_Soyad.TabIndex = 2;
            // 
            // lbl_Departman
            // 
            this.lbl_Departman.AutoSize = true;
            this.lbl_Departman.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Departman.Location = new System.Drawing.Point(329, 190);
            this.lbl_Departman.Name = "lbl_Departman";
            this.lbl_Departman.Size = new System.Drawing.Size(0, 25);
            this.lbl_Departman.TabIndex = 3;
            // 
            // lbl_Gorev
            // 
            this.lbl_Gorev.AutoSize = true;
            this.lbl_Gorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Gorev.Location = new System.Drawing.Point(329, 234);
            this.lbl_Gorev.Name = "lbl_Gorev";
            this.lbl_Gorev.Size = new System.Drawing.Size(0, 25);
            this.lbl_Gorev.TabIndex = 4;
            // 
            // txt_ID
            // 
            this.txt_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ID.Location = new System.Drawing.Point(578, 107);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(123, 30);
            this.txt_ID.TabIndex = 0;
            this.txt_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ID_KeyPress);
            // 
            // tmr_Kontrol
            // 
            this.tmr_Kontrol.Tick += new System.EventHandler(this.tmr_Kontrol_Tick);
            // 
            // lbl_Kayit_Durum
            // 
            this.lbl_Kayit_Durum.AutoSize = true;
            this.lbl_Kayit_Durum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Kayit_Durum.ForeColor = System.Drawing.Color.Green;
            this.lbl_Kayit_Durum.Location = new System.Drawing.Point(325, 282);
            this.lbl_Kayit_Durum.Name = "lbl_Kayit_Durum";
            this.lbl_Kayit_Durum.Size = new System.Drawing.Size(0, 24);
            this.lbl_Kayit_Durum.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(224, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sicil No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(266, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(231, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Soyadı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(188, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Departmanı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(235, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Görevi:";
            // 
            // pb_Logo
            // 
            this.pb_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_Logo.Image")));
            this.pb_Logo.Location = new System.Drawing.Point(12, 59);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(149, 109);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_Logo.TabIndex = 12;
            this.pb_Logo.TabStop = false;
            // 
            // btn_Detay
            // 
            this.btn_Detay.BackColor = System.Drawing.Color.White;
            this.btn_Detay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Detay.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Detay.Location = new System.Drawing.Point(578, 162);
            this.btn_Detay.Name = "btn_Detay";
            this.btn_Detay.Size = new System.Drawing.Size(123, 36);
            this.btn_Detay.TabIndex = 13;
            this.btn_Detay.Text = "DETAY";
            this.btn_Detay.UseVisualStyleBackColor = false;
            this.btn_Detay.Click += new System.EventHandler(this.btn_Detay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(307, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "KARTINIZI OKUTUNUZ";
            // 
            // lbl_Bugun
            // 
            this.lbl_Bugun.AutoSize = true;
            this.lbl_Bugun.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Bugun.Location = new System.Drawing.Point(12, 281);
            this.lbl_Bugun.Name = "lbl_Bugun";
            this.lbl_Bugun.Size = new System.Drawing.Size(0, 25);
            this.lbl_Bugun.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 16;
            // 
            // lbl_Kayit_Saat
            // 
            this.lbl_Kayit_Saat.AutoSize = true;
            this.lbl_Kayit_Saat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Kayit_Saat.Location = new System.Drawing.Point(357, 313);
            this.lbl_Kayit_Saat.Name = "lbl_Kayit_Saat";
            this.lbl_Kayit_Saat.Size = new System.Drawing.Size(0, 24);
            this.lbl_Kayit_Saat.TabIndex = 17;
            // 
            // tmr_Temizle
            // 
            this.tmr_Temizle.Interval = 5000;
            this.tmr_Temizle.Tick += new System.EventHandler(this.tmr_Temizle_Tick);
            // 
            // frm_KarGes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(713, 346);
            this.Controls.Add(this.lbl_Kayit_Saat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_Bugun);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Detay);
            this.Controls.Add(this.pb_Logo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Kayit_Durum);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.lbl_Gorev);
            this.Controls.Add(this.lbl_Departman);
            this.Controls.Add(this.lbl_Soyad);
            this.Controls.Add(this.lbl_Ad);
            this.Controls.Add(this.lbl_Sicil_No);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(729, 385);
            this.MinimumSize = new System.Drawing.Size(729, 385);
            this.Name = "frm_KarGes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KarGes";
            this.Load += new System.EventHandler(this.frm_KarGes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Sicil_No;
        private System.Windows.Forms.Label lbl_Ad;
        private System.Windows.Forms.Label lbl_Soyad;
        private System.Windows.Forms.Label lbl_Departman;
        private System.Windows.Forms.Label lbl_Gorev;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Timer tmr_Kontrol;
        private System.Windows.Forms.Label lbl_Kayit_Durum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pb_Logo;
        private System.Windows.Forms.Button btn_Detay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_Bugun;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Kayit_Saat;
        private System.Windows.Forms.Timer tmr_Temizle;
    }
}

