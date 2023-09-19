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
    public partial class HastaBilgiDüzenleForm : Form
    {
        public HastaBilgiDüzenleForm()
        {
            InitializeComponent();
        }
        public string hastatc;
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void HastaBilgiDüzenleForm_Load(object sender, EventArgs e)
        {
            MskHastaTc.Text = hastatc;
            //yukarıdaki çekilen tc değerine göre diğer verileri getirme
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskHastaTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtHastaAd.Text = dr[1].ToString();
                TxtHastaSoyad.Text = dr[2].ToString();
                MskHastaTel.Text = dr[4].ToString();
                TxtHastaSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text= dr[6].ToString(); 

            }

            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGüncelle = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bgl.baglanti());//update sorgularında mutlaka where yani şart kullan yoksa tüm kayıt güncellenir.!!!!!
            komutGüncelle.Parameters.AddWithValue("@p1", TxtHastaAd.Text);
            komutGüncelle.Parameters.AddWithValue("@p2", TxtHastaSoyad.Text);
            komutGüncelle.Parameters.AddWithValue("@p3", MskHastaTel.Text);
            komutGüncelle.Parameters.AddWithValue("@p4", TxtHastaSifre.Text);
            komutGüncelle.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komutGüncelle.Parameters.AddWithValue("@p6", MskHastaTc.Text);
            komutGüncelle.ExecuteNonQuery();//insert, delete update komutlarında sqle işlenmesi için muhakkak kullan!
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz başarıyla güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
