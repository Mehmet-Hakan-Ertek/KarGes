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
    public partial class frm_Karges_Detay : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-V5NIP1E\\SQLEXPRESS;Initial Catalog=Kale_Tugla;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public frm_Karges_Detay()
        {
            InitializeComponent();
        }

        string sorgu;
        bool durum;
        public static string Sicil_No, Ad, Soyad;

        private void frm_Karges_Detay_Load(object sender, EventArgs e)
        {
            Verileri_Goster();
            Departman_Getir();
        }

        private void Verileri_Goster()
        {
            try
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM KarGes_Test_Personel";
                SqlDataAdapter bilgiler = new SqlDataAdapter(sorgu, baglanti);
                baglanti.Close();
                DataTable BilgiTablosu = new DataTable();
                bilgiler.Fill(BilgiTablosu);
                dgv_KarGes_Personel.DataSource = BilgiTablosu;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void Arama(string sorgu)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter bilgiler = new SqlDataAdapter(sorgu, baglanti);
                baglanti.Close();
                DataTable tablo = new DataTable();
                bilgiler.Fill(tablo);
                dgv_KarGes_Personel.DataSource = tablo;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        #region Arama
        private void cmb_Arama_Departman_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arama("SELECT * FROM KarGes_Test_Personel WHERE Departman LIKE '%" + cmb_Arama_Departman.Text + "%'");
        }

        private void txt_Arama_Ad_TextChanged(object sender, EventArgs e)
        {
            Arama("SELECT * FROM KarGes_Test_Personel WHERE Ad LIKE '%" + txt_Arama_Ad.Text + "%'");
        }

        private void txt_Arama_Sicil_No_TextChanged(object sender, EventArgs e)
        {
            Arama("SELECT * FROM KarGes_Test_Personel WHERE Sicil_No LIKE '%" + txt_Arama_Sicil_No.Text + "%'");
        }
        #endregion

        private void dgv_KarGes_Personel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Sicil_No.Text = dgv_KarGes_Personel.CurrentRow.Cells[0].Value.ToString();
            txt_Ad.Text = dgv_KarGes_Personel.CurrentRow.Cells[1].Value.ToString();
            txt_Soyad.Text = dgv_KarGes_Personel.CurrentRow.Cells[2].Value.ToString();
            mtxt_Telefon.Text = dgv_KarGes_Personel.CurrentRow.Cells[3].Value.ToString();
            rtxt_Adres.Text = dgv_KarGes_Personel.CurrentRow.Cells[4].Value.ToString();
            cmb_Departman.Text = dgv_KarGes_Personel.CurrentRow.Cells[5].Value.ToString();
            cmb_Gorev.Text = dgv_KarGes_Personel.CurrentRow.Cells[6].Value.ToString();
            txt_Maas.Text = dgv_KarGes_Personel.CurrentRow.Cells[7].Value.ToString();
            txt_Izin_Gunu_Sayisi.Text = dgv_KarGes_Personel.CurrentRow.Cells[8].Value.ToString();
            Sicil_No = txt_Sicil_No.Text;
            Ad = txt_Ad.Text;
            Soyad = txt_Soyad.Text;

            baglanti.Open();
            sorgu = "SELECT * FROM KarGes_Test_Yetki";
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == txt_Sicil_No.Text)
                {
                    cbox_Yetki.Checked = true;
                    break;
                }
                else
                {
                    cbox_Yetki.Checked = false;
                }
            }
            oku.Close();
            baglanti.Close();
        }

        private void Sicil_No_Kontrol()
        {
            baglanti.Open();
            sorgu = "SELECT Sicil_No FROM KarGes_Test_Personel";
            komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == txt_Sicil_No.Text)
                {
                    durum = true;
                }
            }
            oku.Close();
            baglanti.Close();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                Sicil_No_Kontrol();
                if (durum == false)
                {
                    baglanti.Open();
                    sorgu = "INSERT INTO KarGes_Test_Personel (Sicil_No, Ad, Soyad, Telefon, Adres, Departman, Gorev, Maas, Izin_Gunu_Sayisi) VALUES (@Sicil_No, @Ad, @Soyad, @Telefon, @Adres, @Departman, @Gorev, @Maas, @Izin_Gunu_Sayisi)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Sicil_No", txt_Sicil_No.Text);
                    komut.Parameters.AddWithValue("@Ad", txt_Ad.Text);
                    komut.Parameters.AddWithValue("@Soyad", txt_Soyad.Text);
                    komut.Parameters.AddWithValue("@Telefon", mtxt_Telefon.Text);
                    komut.Parameters.AddWithValue("@Adres", rtxt_Adres.Text);
                    komut.Parameters.AddWithValue("@Departman", cmb_Departman.Text);
                    komut.Parameters.AddWithValue("@Gorev", cmb_Gorev.Text);
                    komut.Parameters.AddWithValue("@Maas", txt_Maas.Text);
                    komut.Parameters.AddWithValue("@Izin_Gunu_Sayisi", txt_Izin_Gunu_Sayisi.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    if (cbox_Yetki.Checked)
                    {
                        Yetkilendir();
                    }
                    Verileri_Goster();
                    Temizle();
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    MessageBox.Show(txt_Sicil_No.Text + " nolu sicil numarası bulunmaktadır.");
                }
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void Yetkilendir()
        {
            int i = 0;
            baglanti.Open();
            sorgu = "SELECT * FROM KarGes_Test_Yetki";
            komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == txt_Sicil_No.Text)
                {
                    i++;
                }
            }
            oku.Close();

            if (i == 0)
            {
                sorgu = "INSERT INTO KarGes_Test_Yetki (Sicil_No) VALUES (@Sicil_No)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Sicil_No", txt_Sicil_No.Text);
                komut.ExecuteNonQuery();
            }
            baglanti.Close();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                sorgu = "UPDATE KarGes_Test_Personel SET Sicil_No = @Sicil_No, Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, Adres = @Adres, Departman = @Departman, Gorev = @Gorev, Maas = @Maas, Izin_Gunu_Sayisi = @Izin_Gunu_Sayisi WHERE Sicil_No = " + txt_Sicil_No.Text;
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Sicil_No", txt_Sicil_No.Text);
                komut.Parameters.AddWithValue("@Ad", txt_Ad.Text);
                komut.Parameters.AddWithValue("@Soyad", txt_Soyad.Text);
                komut.Parameters.AddWithValue("@Telefon", mtxt_Telefon.Text);
                komut.Parameters.AddWithValue("@Adres", rtxt_Adres.Text);
                komut.Parameters.AddWithValue("@Departman", cmb_Departman.Text);
                komut.Parameters.AddWithValue("@Gorev", cmb_Gorev.Text);
                komut.Parameters.AddWithValue("@Maas", txt_Maas.Text);
                komut.Parameters.AddWithValue("@Izin_Gunu_Sayisi", txt_Izin_Gunu_Sayisi.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();

                if (cbox_Yetki.Checked)
                {
                    Yetkilendir();
                }
                else
                {
                    baglanti.Open();
                    sorgu = "DELETE FROM KarGes_Test_Yetki WHERE Sicil_No = " + txt_Sicil_No.Text;
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                Verileri_Goster();
                Temizle();
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult karar = MessageBox.Show("Seçili kaydı silmek istiyor musunuz?", "Uyarı: Kayıt Silinecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (karar == DialogResult.OK)
                {
                    baglanti.Open();
                    sorgu = "DELETE FROM KarGes_Test_Personel WHERE Sicil_No = " + txt_Sicil_No.Text;
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    if (cbox_Yetki.Checked)
                    {
                        sorgu = "DELETE FROM KarGes_Test_Yetki WHERE Sicil_No = " + txt_Sicil_No.Text;
                        komut = new SqlCommand(sorgu, baglanti);
                        komut.ExecuteNonQuery();
                    }
                    baglanti.Close();
                    MessageBox.Show("Kayıt Silindi");
                    Verileri_Goster();
                    Temizle();
                }
            }
            catch (SqlException hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void Temizle()
        {
            txt_Sicil_No.Clear();
            txt_Ad.Clear();
            txt_Soyad.Clear();
            mtxt_Telefon.Clear();
            cmb_Departman.Text = "";
            cmb_Gorev.Text = "";
            txt_Izin_Gunu_Sayisi.Clear();
            txt_Maas.Clear();
            rtxt_Adres.Clear();
            txt_Sicil_No.Focus();
            cbox_Yetki.Checked = false;
        }

        #region Kontrol
        private void txt_Maas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Izin_Gunu_Sayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Sicil_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mtxt_Telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Departman_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Gorev_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        private void btn_Sorgula_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_KarGes_Sorgula sorgula = new frm_KarGes_Sorgula();
            sorgula.Show();
        }

        private void btn_Departman_Ekle_Click(object sender, EventArgs e)
        {
            int i = 0;
            baglanti.Open();
            sorgu = "SELECT * FROM KarGes_Departman";
            komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == cmb_Departman.Text)
                {
                    i++;
                }
            }
            oku.Close();

            if (i == 0)
            {
                sorgu = "INSERT INTO KarGes_Departman(Departman) VALUES (@Departman)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Departman", cmb_Departman.Text);
                komut.ExecuteNonQuery();
                Temizle();
                MessageBox.Show("Departman Eklenmiştir");
            }
            else
            {
                MessageBox.Show("Bu departman kayıtlıdır.");
            }
            baglanti.Close();
            Departman_Getir();
        }

        private void frm_Karges_Detay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btn_Ekle_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                btn_Guncelle_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                btn_Sil_Click(sender, e);
            }
        }

        private void Departman_Getir()
        {
            cmb_Departman.Items.Clear();
            baglanti.Open();
            sorgu = "SELECT Departman FROM KarGes_Departman";
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmb_Departman.Items.Add(oku[0].ToString());
            }
            oku.Close();
            baglanti.Close();
        }

        private void btn_Gorev_Ekle_Click(object sender, EventArgs e)
        {
            int i = 0;
            baglanti.Open();
            sorgu = "SELECT * FROM KarGes_Gorev";
            komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == cmb_Gorev.Text)
                {
                    i++;
                }
            }
            oku.Close();

            if (i == 0)
            {
                sorgu = "INSERT INTO KarGes_Gorev(Gorev, Gorev_ID) VALUES (@Gorev, (SELECT Departman_ID FROM KarGes_Departman WHERE Departman = '" + cmb_Departman.Text + "'))";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Gorev", cmb_Gorev.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Görev Eklenmiştir");
            }
            else
            {
                MessageBox.Show("Bu görev kayıtlıdır.");
            }
            baglanti.Close();
            Gorev_Getir();
            Temizle();
        }

        private void Gorev_Getir()
        {
            cmb_Gorev.Items.Clear();
            baglanti.Open();
            sorgu = "SELECT Gorev FROM KarGes_Gorev WHERE Gorev_ID = (SELECT Departman_ID FROM KarGes_Departman WHERE Departman = '" + cmb_Departman.Text + "')";
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmb_Gorev.Items.Add(oku[0].ToString());
            }
            oku.Close();
            baglanti.Close();
        }

        private void cmb_Departman_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gorev_Getir();
        }
    }
}