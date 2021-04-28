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

namespace KarGes
{
    public partial class frm_KarGes : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-V5NIP1E\\SQLEXPRESS;Initial Catalog=Kale_Tugla;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public frm_KarGes()
        {
            InitializeComponent();
        }

        string sorgu, id, Kayit_Durum = "Giris Islemi";
        bool durum;

        private void frm_KarGes_Load(object sender, EventArgs e)
        {
            lbl_Bugun.Text = "Bugünün Tarihi\n" + "   " + DateTime.Today.ToShortDateString().ToString();
            tmr_Kontrol.Start();
        }

        private void btn_Detay_Click(object sender, EventArgs e)
        {
            frm_KarGes_Yetki_Kontrol kontrol = new frm_KarGes_Yetki_Kontrol();
            kontrol.ShowDialog();
            txt_ID.Focus();
        }

        private void tmr_Kontrol_Tick(object sender, EventArgs e)
        {
            try
            {
                if (txt_ID.Text.Length == 10)
                {
                    Sicil_No_Kontrol();
                    if (durum != true)
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        sorgu = "SELECT * FROM KarGes_Test_Personel WHERE Sicil_No = " + id;
                        SqlDataAdapter bilgiler = new SqlDataAdapter(sorgu, baglanti);
                        baglanti.Close();
                        DataTable tablo = new DataTable();
                        bilgiler.Fill(tablo);
                        foreach (DataRow satir in tablo.Rows)
                        {
                            lbl_Sicil_No.Text = satir[0].ToString();
                            lbl_Ad.Text = satir[1].ToString();
                            lbl_Soyad.Text = satir[2].ToString();
                            lbl_Departman.Text = satir[5].ToString();
                            lbl_Gorev.Text = satir[6].ToString();
                        }
                        Kayit_Durum_Kontrol();
                        Log_Kayit();
                    }
                    txt_ID.Clear();
                    if (lbl_Sicil_No.Text != "")
                    {
                        tmr_Temizle.Start();
                    }
                }
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void Sicil_No_Kontrol()
        {
            int i = 0;
            baglanti.Open();
            sorgu = "SELECT COUNT(Sicil_No) FROM KarGes_Test_Personel";
            komut = new SqlCommand(sorgu, baglanti);
            int adet = Convert.ToInt32(komut.ExecuteScalar());

            sorgu = "SELECT Sicil_No FROM KarGes_Test_Personel";
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() != id)
                {
                    txt_ID.Clear();
                    i++;
                }
            }
            if (i == adet)
            {
                MessageBox.Show(id + " nolu sicil numarası bulunmamaktadır.");
                durum = true;
            }
            else
            {
                durum = false;
            }
            oku.Close();
            baglanti.Close();
        }

        private void Kayit_Durum_Kontrol()
        {
            try
            {
                baglanti.Open();
                sorgu = "SELECT Kayit_Durum FROM KarGes_Test_Log WHERE Sicil_No = " + id + " ORDER BY Kayit_Tarih DESC, Kayit_Saat DESC";
                komut = new SqlCommand(sorgu, baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (oku[0].ToString() == "Giris Islemi")
                    {
                        Kayit_Durum = "Cikis Islemi";
                        lbl_Kayit_Durum.Text = Kayit_Durum;
                        lbl_Kayit_Durum.ForeColor = Color.Red;
                        lbl_Kayit_Saat.Text = DateTime.Now.ToShortTimeString();
                        break;
                    }
                    else if (oku[0].ToString() == "Cikis Islemi")
                    {
                        Kayit_Durum = "Giris Islemi";
                        lbl_Kayit_Durum.Text = Kayit_Durum;
                        lbl_Kayit_Durum.ForeColor = Color.Green;
                        lbl_Kayit_Saat.Text = DateTime.Now.ToShortTimeString();
                        break;
                    }
                }
                oku.Close();
                baglanti.Close();
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void tmr_Temizle_Tick(object sender, EventArgs e)
        {
            if (lbl_Sicil_No.Text != "")
            {
                lbl_Sicil_No.Text = "";
                lbl_Ad.Text = "";
                lbl_Soyad.Text = "";
                lbl_Departman.Text = "";
                lbl_Gorev.Text = "";
                lbl_Kayit_Durum.Text = "";
                lbl_Kayit_Saat.Text = "";
                tmr_Temizle.Stop();
            }
        }

        private void Log_Kayit()
        {
            try
            {
                baglanti.Open();
                sorgu = "INSERT INTO KarGes_Test_Log (Sicil_No, Ad, Soyad, Departman, Gorev, Kayit_Durum, Kayit_Saat, Kayit_Tarih) VALUES (@Sicil_No, @Ad, @Soyad, @Departman, @Gorev, @Kayit_Durum, @Kayit_Saat, @Kayit_Tarih)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Sicil_No", lbl_Sicil_No.Text);
                komut.Parameters.AddWithValue("@Ad", lbl_Ad.Text);
                komut.Parameters.AddWithValue("@Soyad", lbl_Soyad.Text);
                komut.Parameters.AddWithValue("@Departman", lbl_Departman.Text);
                komut.Parameters.AddWithValue("@Gorev", lbl_Gorev.Text);
                komut.Parameters.AddWithValue("@Kayit_Durum", Kayit_Durum);
                lbl_Kayit_Durum.Text = Kayit_Durum;
                lbl_Kayit_Saat.Text = DateTime.Now.ToShortTimeString();
                komut.Parameters.AddWithValue("@Kayit_Saat", DateTime.Now.ToLongTimeString());
                komut.Parameters.AddWithValue("@Kayit_Tarih", DateTime.Today.ToString("yyyy-MM-dd"));
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            id = txt_ID.Text;
        }
    }
}
