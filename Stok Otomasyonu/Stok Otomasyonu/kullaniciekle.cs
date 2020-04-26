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


namespace Stok_Otomasyonu
{
    public partial class kullaniciekle : Form
    {
        public kullaniciekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-B0JL97I;Initial Catalog=stok;Integrated Security=True");

        bool durum;
        void mukerrer()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where tc_no=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;

            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mukerrer();
            if (durum == true)
            {
                baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kullanici (tc_no,ad,soyisim,email,telefon,sirket,bolum,gorev,sifre) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.Parameters.AddWithValue("@p5", textBox5.Text);
            komut.Parameters.AddWithValue("@p6", textBox6.Text);
            komut.Parameters.AddWithValue("@p7", textBox7.Text);
            komut.Parameters.AddWithValue("@p8", textBox8.Text);
            komut.Parameters.AddWithValue("@p9", textBox9.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("KAYIT EKLENDİ", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(textBox1.Text + " BARKOD ZATEN KAYITLI ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
