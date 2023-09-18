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

namespace HastaneYönetim
{
    public partial class HastaKayıtForm : Form
    {
        public HastaKayıtForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut =new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtHastaAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtHastaSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskHastaTc.Text);
            komut.Parameters.AddWithValue("@p4", MskHastaTel.Text);
            komut.Parameters.AddWithValue("@p5", TxtHastaSifre.Text);
            komut.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz: " + TxtHastaSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
