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
using LogicLayer;
using EntityLayer;

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

        void RandevuListele()
        {
            /*
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            List<EntityRandevular> HastaRandevu = LogicRandevular.LLHastaRandevu(tc);
            dataGridView1.DataSource = HastaRandevu;
        }

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
            RandevuListele();

            //branşları Comboboxa çekme
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbBrans.DataSource = bransAdListesi;
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            Txtid.Text = "";
            //seçilen branşa göre doktor çekme
            /*
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",CmbBrans.Text);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();*/

            List<EntityDoktorlar> BransliDoktorGetir = LogicDoktorlar.LLBransliDoktor(CmbBrans.Text);
            foreach (var item in BransliDoktorGetir)
            {
                CmbDoktor.Items.Add(item.DoktorAd + " " + item.DoktorSoyad);
            }
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {   /*   
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans='" + CmbBrans.Text+"'"+"and RandevuDoktor='"+CmbDoktor.Text+"' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource= dt;*/
            List<EntityRandevular> RandevuM = LogicRandevular.LLRandevuM(CmbBrans.Text, CmbDoktor.Text);
            dataGridView2.DataSource = RandevuM;
        }

        private void LnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDüzenleForm BilgiDüzenle=new HastaBilgiDüzenleForm();
            BilgiDüzenle.hastatc = LblHastaTc.Text;
            BilgiDüzenle.Show();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            /*
            SqlCommand RandevuAl= new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3",bgl.baglanti());
            RandevuAl.Parameters.AddWithValue("@p1", LblHastaTc.Text);
            RandevuAl.Parameters.AddWithValue("@p2", RchHastaSikayet.Text);
            RandevuAl.Parameters.AddWithValue("@p3", Txtid.Text);
            RandevuAl.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);*/

            EntityRandevular ent = new EntityRandevular();

            // Txtid.Text'in sayıya dönüştürülüp dönüştürülemediğini kontrol et
            if (int.TryParse(Txtid.Text, out int randevuId))
            {
                ent.Randevuid = randevuId;
                ent.HastaTC = LblHastaTc.Text;
                ent.HastaSikayet = RchHastaSikayet.Text;

                bool result = LogicRandevular.LLRandevuAl(ent);

                if (result && !string.IsNullOrEmpty(Txtid.Text))
                {
                    MessageBox.Show("Randevu alma işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Randevu geçmişi yenile
                    RandevuListele();
                }
                else
                {
                    MessageBox.Show("Lütfen boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Geçersiz Randevu ID", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
    }
}
