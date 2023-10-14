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
using EntityLayer;
using LogicLayer;

namespace HastaneYönetim
{
    public partial class SekreterGirisForm : Form
    {
        public SekreterGirisForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();
        private void BtnGirisYapSekreter_Click(object sender, EventArgs e)
        {
            List<EntitySekreter> SekreterGetir = LogicSekreterler.LLSekreterGiris(maskedTextBox1.Text, textBox1.Text);
            if (SekreterGetir != null && SekreterGetir.Count > 0)
            {
                SekreterDetayForm SekreterDetay = new SekreterDetayForm();
                SekreterDetay.sekreterTc = maskedTextBox1.Text;
                SekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
            SqlCommand giris=new SqlCommand("Select * From Tbl_Sekreter Where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            giris.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            giris.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
               SekreterDetayForm SekreterDetay= new SekreterDetayForm();
                SekreterDetay.sekreterTc = maskedTextBox1.Text;
                SekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.");
            }
            bgl.baglanti().Close();*/
        }
    }
}
