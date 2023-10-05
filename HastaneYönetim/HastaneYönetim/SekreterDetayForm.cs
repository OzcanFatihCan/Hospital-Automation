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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneYönetim
{
    public partial class SekreterDetayForm : Form
    {
        public SekreterDetayForm()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();
        public string sekreterTc;
        private void SekreterDetayForm_Load(object sender, EventArgs e)
        {
            LblSekreterTc.Text = sekreterTc;
            //ad soyad çekme

            SqlCommand AdSoyadCek = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            AdSoyadCek.Parameters.AddWithValue("@p1", LblSekreterTc.Text);
            SqlDataReader dr1 = AdSoyadCek.ExecuteReader();
            while (dr1.Read())
            {
                LblSekreterAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branşları datagride çek

            /*
            DataTable dt1=new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select BransAd From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource= dt1;*/

            //branşları datagride çek
            List<EntityBranslar> BransListesi = LogicBranslar.LLBransListesi();
            dataGridView1.DataSource = BransListesi;

            //doktorları datagridviewe çek
            /*
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+' '+DoktorSoyad) as 'Doktorlar',DoktorBrans,DoktorTC From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;*/

            //doktorları datagridviewe çek
            List<EntityDoktorlarS> Doktorlar = LogicDoktorlar.LLDokorCek();
            dataGridView2.DataSource = Doktorlar;




            //branşları comboboxa çekme
            /*
            SqlCommand BransCek = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = BransCek.ExecuteReader();//burada sqldeki veriler okunuyor.
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();*/

            //branşları comboboxa çekme
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbBrans.DataSource = bransAdListesi;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
          

            if (MskTarih.Text!=""&& MskTarih.MaskCompleted && MskSaat.Text!="" && MskSaat.MaskCompleted && CmbBrans.Text!="" && CmbDoktor.Text!="")
            {
                SqlCommand kaydetkomut = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@a1,@a2,@a3,@a4)", bgl.baglanti());
                kaydetkomut.Parameters.AddWithValue("@a1", MskTarih.Text);
                kaydetkomut.Parameters.AddWithValue("@a2", MskSaat.Text);
                kaydetkomut.Parameters.AddWithValue("@a3", CmbBrans.Text);
                kaydetkomut.Parameters.AddWithValue("@a4", CmbDoktor.Text);
                kaydetkomut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevu oluşturuldu","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Randevu için boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktorları comboboxa çekme
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            //seçilen branşa göre doktor çekme
            /*
            SqlCommand DoktorCek = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());
            DoktorCek.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr3 = DoktorCek.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();*/
            List<EntityDoktorlar> BransliDoktorGetir = LogicDoktorlar.LLBransliDoktor(CmbBrans.Text);
            foreach (var item in BransliDoktorGetir)
            {
                CmbDoktor.Items.Add(item.DoktorAd + " " + item.DoktorSoyad);
            }

        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            /*
            if (RchDuyuru.Text!="")
            {
                SqlCommand duyuruEkle = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
                duyuruEkle.Parameters.AddWithValue("@d1", RchDuyuru.Text);
                duyuruEkle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Duyuru oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Duyuru için metin girdisi yapınız");
            }*/

            EntityDuyurular ent = new EntityDuyurular();
            ent.Duyuru = RchDuyuru.Text;
            int result=LogicDuyurular.LLDuyuruEkle(ent);
            if (result > 0)
            {
                MessageBox.Show("Ekleme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else if (result == 0)
            {
                MessageBox.Show("Ekleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Boş duyuru eklenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            SekreterDoktorAyarForm SekreterDoktorPanel = new SekreterDoktorAyarForm();
            SekreterDoktorPanel.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            SekreterBransAyarForm SekreterBransPanel = new SekreterBransAyarForm();
            SekreterBransPanel.Show();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            SekreterRandevuAyarForm SekreterRandevuPanel=new SekreterRandevuAyarForm();
            SekreterRandevuPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuyurularForm Duyurular=new DuyurularForm();
            Duyurular.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CmbBrans.Text = "";
            CmbDoktor.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
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
