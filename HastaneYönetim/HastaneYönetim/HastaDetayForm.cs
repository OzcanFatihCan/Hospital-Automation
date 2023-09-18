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
    public partial class HastaDetayForm : Form
    {
        public HastaDetayForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();
        public string tc;
        private void HastaDetayForm_Load(object sender, EventArgs e)
        {
            LblHastaTc.Text = tc;

            //ad soyad çekme

            SqlCommand komut=new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblHastaTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblHastaAdSoyad.Text = dr[0] + " " + dr[1];
            }

            bgl.baglanti().Close();

            //randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where HastaTC="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //branşları çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();//burada sqldeki veriler okunuyor.
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
