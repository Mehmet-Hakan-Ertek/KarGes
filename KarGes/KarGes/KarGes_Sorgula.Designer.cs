namespace KarGes
{
    partial class frm_KarGes_Sorgula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KarGes_Sorgula));
            this.btn_Geri = new System.Windows.Forms.Button();
            this.btn_Yazdir = new System.Windows.Forms.Button();
            this.prdc_Belge = new System.Drawing.Printing.PrintDocument();
            this.dgv_Sorgula = new System.Windows.Forms.DataGridView();
            this.txt_Sicil_No = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Aylar = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Sorgula = new System.Windows.Forms.Button();
            this.prntDi_Belge = new System.Windows.Forms.PrintDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Yil = new System.Windows.Forms.ComboBox();
            this.lbl_Ad_Soyad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Dakika = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sorgula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Geri
            // 
            this.btn_Geri.BackColor = System.Drawing.Color.White;
            this.btn_Geri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Geri.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Geri.Location = new System.Drawing.Point(12, 384);
            this.btn_Geri.Name = "btn_Geri";
            this.btn_Geri.Size = new System.Drawing.Size(70, 30);
            this.btn_Geri.TabIndex = 5;
            this.btn_Geri.Text = "<< GERİ";
            this.btn_Geri.UseVisualStyleBackColor = false;
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_Yazdir
            // 
            this.btn_Yazdir.BackColor = System.Drawing.Color.White;
            this.btn_Yazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Yazdir.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Yazdir.Location = new System.Drawing.Point(91, 384);
            this.btn_Yazdir.Name = "btn_Yazdir";
            this.btn_Yazdir.Size = new System.Drawing.Size(70, 30);
            this.btn_Yazdir.TabIndex = 6;
            this.btn_Yazdir.Text = "YAZDIR";
            this.btn_Yazdir.UseVisualStyleBackColor = false;
            this.btn_Yazdir.Click += new System.EventHandler(this.btn_Yazdir_Click);
            // 
            // prdc_Belge
            // 
            this.prdc_Belge.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdc_Belge_PrintPage);
            // 
            // dgv_Sorgula
            // 
            this.dgv_Sorgula.BackgroundColor = System.Drawing.Color.Linen;
            this.dgv_Sorgula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Sorgula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sorgula.Location = new System.Drawing.Point(178, 4);
            this.dgv_Sorgula.Name = "dgv_Sorgula";
            this.dgv_Sorgula.Size = new System.Drawing.Size(348, 420);
            this.dgv_Sorgula.TabIndex = 3;
            // 
            // txt_Sicil_No
            // 
            this.txt_Sicil_No.Location = new System.Drawing.Point(12, 164);
            this.txt_Sicil_No.MaxLength = 10;
            this.txt_Sicil_No.Name = "txt_Sicil_No";
            this.txt_Sicil_No.Size = new System.Drawing.Size(149, 20);
            this.txt_Sicil_No.TabIndex = 0;
            this.txt_Sicil_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Sicil_No_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(61, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sicil No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(76, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ay";
            // 
            // cmb_Aylar
            // 
            this.cmb_Aylar.FormattingEnabled = true;
            this.cmb_Aylar.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.cmb_Aylar.Location = new System.Drawing.Point(12, 243);
            this.cmb_Aylar.Name = "cmb_Aylar";
            this.cmb_Aylar.Size = new System.Drawing.Size(149, 21);
            this.cmb_Aylar.TabIndex = 3;
            this.cmb_Aylar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Aylar_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Sorgula
            // 
            this.btn_Sorgula.BackColor = System.Drawing.Color.White;
            this.btn_Sorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Sorgula.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Sorgula.Location = new System.Drawing.Point(45, 338);
            this.btn_Sorgula.Name = "btn_Sorgula";
            this.btn_Sorgula.Size = new System.Drawing.Size(90, 40);
            this.btn_Sorgula.TabIndex = 4;
            this.btn_Sorgula.Text = "SORGULA";
            this.btn_Sorgula.UseVisualStyleBackColor = false;
            this.btn_Sorgula.Click += new System.EventHandler(this.btn_Sorgula_Click);
            // 
            // prntDi_Belge
            // 
            this.prntDi_Belge.UseEXDialog = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(76, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Yıl";
            // 
            // cmb_Yil
            // 
            this.cmb_Yil.FormattingEnabled = true;
            this.cmb_Yil.Location = new System.Drawing.Point(12, 203);
            this.cmb_Yil.Name = "cmb_Yil";
            this.cmb_Yil.Size = new System.Drawing.Size(149, 21);
            this.cmb_Yil.TabIndex = 1;
            this.cmb_Yil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Yil_KeyPress);
            // 
            // lbl_Ad_Soyad
            // 
            this.lbl_Ad_Soyad.AutoSize = true;
            this.lbl_Ad_Soyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Ad_Soyad.Location = new System.Drawing.Point(33, 120);
            this.lbl_Ad_Soyad.Name = "lbl_Ad_Soyad";
            this.lbl_Ad_Soyad.Size = new System.Drawing.Size(0, 20);
            this.lbl_Ad_Soyad.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Aylık Geç Kalınan Dakika: ";
            // 
            // lbl_Dakika
            // 
            this.lbl_Dakika.AutoSize = true;
            this.lbl_Dakika.Location = new System.Drawing.Point(142, 298);
            this.lbl_Dakika.Name = "lbl_Dakika";
            this.lbl_Dakika.Size = new System.Drawing.Size(0, 13);
            this.lbl_Dakika.TabIndex = 13;
            // 
            // frm_KarGes_Sorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(542, 436);
            this.Controls.Add(this.lbl_Dakika);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Ad_Soyad);
            this.Controls.Add(this.cmb_Yil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Sorgula);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmb_Aylar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Sicil_No);
            this.Controls.Add(this.dgv_Sorgula);
            this.Controls.Add(this.btn_Yazdir);
            this.Controls.Add(this.btn_Geri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(558, 475);
            this.MinimumSize = new System.Drawing.Size(558, 475);
            this.Name = "frm_KarGes_Sorgula";
            this.Text = "KarGes Sorgula";
            this.Load += new System.EventHandler(this.frm_KarGes_Sorgula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KarGes_Sorgula_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sorgula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Geri;
        private System.Windows.Forms.Button btn_Yazdir;
        private System.Drawing.Printing.PrintDocument prdc_Belge;
        private System.Windows.Forms.DataGridView dgv_Sorgula;
        private System.Windows.Forms.TextBox txt_Sicil_No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Aylar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Sorgula;
        private System.Windows.Forms.PrintDialog prntDi_Belge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Yil;
        private System.Windows.Forms.Label lbl_Ad_Soyad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Dakika;
    }
}