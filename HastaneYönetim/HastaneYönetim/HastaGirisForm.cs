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
    public partial class HastaGirisForm : Form
    {
        public HastaGirisForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void LinkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıtForm HastaKayitGiris = new HastaKayıtForm();
            HastaKayitGiris.Show();
        }

        private void BtnGirisYapHasta_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                HastaDetayForm HastaDetay=new HastaDetayForm();//geçiş sırasında tc ve ad soyad taşınacak
                HastaDetay.tc = maskedTextBox1.Text;
                HastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.");
            }
            bgl.baglanti().Close();

        }

        private void HastaGirisForm_Load(object sender, EventArgs e)
        {

        }
    }
}
