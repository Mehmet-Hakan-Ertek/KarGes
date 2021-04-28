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
    public partial class frm_KarGes_Yetki_Kontrol : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-V5NIP1E\\SQLEXPRESS;Initial Catalog=Kale_Tugla;Integrated Security=True");
        SqlCommand komut;

        public frm_KarGes_Yetki_Kontrol()
        {
            InitializeComponent();
        }

        string sorgu;

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                baglanti.Open();
                sorgu = "SELECT COUNT(*) FROM KarGes_Test_Yetki";
                komut = new SqlCommand(sorgu, baglanti);
                int adet = Convert.ToInt32(komut.ExecuteScalar());

                sorgu = "SELECT * FROM KarGes_Test_Yetki";
                komut = new SqlCommand(sorgu, baglanti);
                SqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    if (read[0].ToString() == txt_Sicil_No.Text)
                    {
                        this.Close();
                        frm_Karges_Detay detay = new frm_Karges_Detay();
                        detay.Show();
                    }
                    else if (read[0].ToString() != txt_Sicil_No.Text)
                    {
                        i++;
                    }
                }
                if (i == adet)
                {
                    MessageBox.Show(txt_Sicil_No.Text + " nolu sicil numarasını yetkisi bulunmamaktadır");
                    txt_Sicil_No.Clear();
                    txt_Sicil_No.Focus();
                }
                read.Close();
                baglanti.Close();
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
    }
}
