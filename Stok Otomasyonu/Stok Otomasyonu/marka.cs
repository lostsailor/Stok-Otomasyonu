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
    public partial class marka : Form
    {
        public marka()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-B0JL97I;Initial Catalog=stok;Integrated Security=True");
        bool durum;
        void mukerrer()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from marka where marka=@p1", baglanti);
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
                SqlCommand komut = new SqlCommand("insert into marka (marka) values (@p1)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("KAYIT EKLENDİ", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(textBox1.Text + " ZATEN KAYITLI ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
