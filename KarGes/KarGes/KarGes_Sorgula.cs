using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace KarGes
{
    public partial class frm_KarGes_Sorgula : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-V5NIP1E\\SQLEXPRESS;Initial Catalog=Kale_Tugla;Integrated Security=True");
        SqlCommand komut;
        DateTime zaman;
        int giris, Gec_Kalinan_Dakika;

        public frm_KarGes_Sorgula()
        {
            InitializeComponent();
        }

        string sorgu;
        int i = 0;


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Karges_Detay detay = new frm_Karges_Detay();
            detay.Show();
        }

        private void cmb_Aylar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_Yazdir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult karar = MessageBox.Show("Raporu PDF olarak kaydetmek ister misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (karar == DialogResult.Yes)
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\hak_e\source\repos\KarGes\kale.png");
                    img.ScaleToFit(350, 90);
                    iTextSharp.text.Paragraph baslik = new iTextSharp.text.Paragraph("KALE TUGLA " + cmb_Aylar.Text.ToUpper() + " AYI KAYIT BILGILERI");
                    baslik.Alignment = Convert.ToInt32(HorizontalAlignment.Right);

                    iTextSharp.text.Paragraph bilgiler = new iTextSharp.text.Paragraph(frm_Karges_Detay.Sicil_No + "\n" + frm_Karges_Detay.Ad + " " + frm_Karges_Detay.Soyad);
                    bilgiler.Alignment = Convert.ToInt32(HorizontalAlignment.Right);

                    PdfPTable tablo = new PdfPTable(dgv_Sorgula.ColumnCount);

                    foreach (DataGridViewColumn sutun in dgv_Sorgula.Columns)
                    {
                        PdfPCell hucre = new PdfPCell(new Phrase(sutun.HeaderText));
                        hucre.HorizontalAlignment = Convert.ToInt32(HorizontalAlignment.Right);
                        tablo.AddCell(hucre);
                    }

                    int satir = dgv_Sorgula.Rows.Count, Hucre_Sayisi = dgv_Sorgula.Rows[1].Cells.Count;
                    for (i = 0; i < satir - 1; i++)
                    {
                        for (int j = 0; j < Hucre_Sayisi; j++)
                        {
                            /*if (dgv_Sorgula.Rows[i].Cells[j].Value == null)
                            {
                                dgv_Sorgula.Rows[i].Cells[j].Value = "null";
                            }*/
                            tablo.AddCell(dgv_Sorgula.Rows[i].Cells[j].Value.ToString());
                        }
                    }

                    string Dosya_Yolu = "C:\\Users\\hak_e\\Desktop\\" + txt_Sicil_No.Text + "\\";
                    if (!Directory.Exists(Dosya_Yolu))
                    {
                        Directory.CreateDirectory(Dosya_Yolu);
                    }

                    string Dosya_Adi = Dosya_Yolu + txt_Sicil_No.Text + "_" + DateTime.Today.ToShortDateString() + ".pdf";
                    if (File.Exists(Dosya_Adi))
                    {
                        i = 1;
                        while (File.Exists(Dosya_Adi))
                        {
                            Dosya_Adi = Dosya_Yolu + txt_Sicil_No.Text + "_" + DateTime.Today.ToShortDateString() + " (" + i + ')' + ".pdf";
                            if (File.Exists(Dosya_Adi))
                            {
                                i++;
                            }
                        }

                        Dosya_Adi = txt_Sicil_No.Text + "_" + DateTime.Today.ToShortDateString() + " (" + i + ')' + ".pdf";
                        using (FileStream akis = new FileStream(Dosya_Yolu + Dosya_Adi, FileMode.Create))
                        {
                            Document belge = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            PdfWriter.GetInstance(belge, akis);
                            belge.Open();
                            belge.Add(img);
                            belge.Add(baslik);
                            belge.Add(new Chunk("\n"));
                            belge.Add(bilgiler);
                            belge.Add(new Chunk("\n"));
                            belge.Add(tablo);
                            belge.Close();
                            akis.Close();
                            MessageBox.Show("Dosya " + Dosya_Adi + " ismiyle kaydedilmiştir.");
                        }
                    }
                    else
                    {
                        Dosya_Adi = txt_Sicil_No.Text + "_" + DateTime.Today.ToShortDateString() + ".pdf";
                        using (FileStream akis = new FileStream(Dosya_Yolu + Dosya_Adi, FileMode.Create))
                        {
                            Document belge = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            PdfWriter.GetInstance(belge, akis);
                            belge.Open();
                            belge.Add(img);
                            belge.Add(baslik);
                            belge.Add(new Chunk("\n"));
                            belge.Add(bilgiler);
                            belge.Add(new Chunk("\n"));
                            belge.Add(tablo);
                            belge.Close();
                            akis.Close();
                            MessageBox.Show("Dosya " + Dosya_Adi + " ismiyle kaydedilmiştir.");
                        }
                    }
                }

                karar = prntDi_Belge.ShowDialog();
                if (karar == DialogResult.OK)
                {
                    prdc_Belge.Print();
                }
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("YAZDIRILABİLECEK VEYA KAYDEDİLEBİLECEK BİR VERİ BULUNAMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frm_KarGes_Sorgula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                btn_Yazdir_Click(sender, e);
            }
        }

        private void btn_Sorgula_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Sicil_No.Text.Length == 10 && cmb_Yil.Text != "" && cmb_Aylar.Text != "")
                {
                    Gec_Kalinan_Dakika = 0;
                    lbl_Ad_Soyad.Text = frm_Karges_Detay.Ad + " " + frm_Karges_Detay.Soyad;
                    baglanti.Open();
                    sorgu = "SELECT Kayit_Durum, Kayit_Saat, Kayit_Tarih FROM KarGes_Test_Log WHERE YEAR(Kayit_Tarih) = " + cmb_Yil.Text + " AND MONTH(Kayit_Tarih) = " + (cmb_Aylar.SelectedIndex + 1) + " AND Sicil_No = " + txt_Sicil_No.Text + " ORDER BY Kayit_Tarih ASC, Kayit_Saat ASC";
                    //baglanti.Close();
                    SqlDataAdapter bilgiler = new SqlDataAdapter(sorgu, baglanti);
                    DataTable BilgiTablosu = new DataTable();
                    bilgiler.Fill(BilgiTablosu);
                    dgv_Sorgula.DataSource = BilgiTablosu;

                    //baglanti.Open();
                    sorgu = "SELECT Kayit_Durum, Kayit_Saat FROM KarGes_Test_Log WHERE Sicil_No = " + txt_Sicil_No.Text + " ORDER BY Kayit_Tarih ASC, Kayit_Saat ASC";
                    komut = new SqlCommand(sorgu, baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    int i = 0;
                    while (oku.Read())
                    {
                        try
                        {
                            if (oku[0].ToString() == "Giris Islemi" && Convert.ToDateTime(oku[1].ToString()) <= Convert.ToDateTime("8:30:00"))
                            {
                                dgv_Sorgula.Rows[i].Cells[0].Style.ForeColor = Color.Green;
                            }
                            else if (oku[0].ToString() == "Cikis Islemi" && Convert.ToDateTime(oku[1].ToString()) >= Convert.ToDateTime("17:30:00"))
                            {
                                dgv_Sorgula.Rows[i].Cells[0].Style.ForeColor = Color.Green;
                            }
                            else
                            {
                                dgv_Sorgula.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            }
                            i++;

                            if (oku[0].ToString() == "Giris Islemi")
                            {
                                zaman = Convert.ToDateTime(oku[1].ToString());
                                giris = (zaman.Hour * 60) + zaman.Minute + (zaman.Second / 60);
                            }
                            else if (oku[0].ToString() == "Cikis Islemi")
                            {
                                zaman = Convert.ToDateTime(oku[1].ToString());
                                int cikis = ((zaman.Hour * 60) + zaman.Minute + (zaman.Second / 60)) - giris;
                                if (cikis < 540)
                                {
                                    Gec_Kalinan_Dakika += cikis;
                                    lbl_Dakika.Text = Gec_Kalinan_Dakika.ToString();
                                }
                            }
                        }
                        catch{}
                    }
                    oku.Close();
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("LÜTFEN TÜM BİLGİLERİ GİRİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void txt_Sicil_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void prdc_Belge_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dgv_Sorgula.Width = 800;
            dgv_Sorgula.Height = 2200;

            Bitmap olcu = new Bitmap(this.dgv_Sorgula.Width, this.dgv_Sorgula.Height);
            dgv_Sorgula.DrawToBitmap(olcu, new System.Drawing.Rectangle(0, 0, this.dgv_Sorgula.Width, this.dgv_Sorgula.Height));
            e.Graphics.DrawImage(olcu, 0, 0);

            dgv_Sorgula.Width = 348;
            dgv_Sorgula.Height = 420;
        }

        private void cmb_Yil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frm_KarGes_Sorgula_Load(object sender, EventArgs e)
        {
            cmb_Yil.Focus();
            baglanti.Open();
            sorgu = "SELECT DISTINCT YEAR(Kayit_Tarih) FROM KarGes_Test_Log";
            komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmb_Yil.Items.Add(oku[0].ToString());
            }
            oku.Close();
            baglanti.Close();
            txt_Sicil_No.Text = frm_Karges_Detay.Sicil_No;
        }
    }
}
