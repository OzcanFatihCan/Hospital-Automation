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

        public string sekreterTc;
        private void SekreterDetayForm_Load(object sender, EventArgs e)
        {
            LblSekreterTc.Text = sekreterTc;
            //ad soyad çekme

            List<EntitySekreter> SekreterGetir = LogicSekreterler.LLSekreterGetir(LblSekreterTc.Text);
            foreach (var item in SekreterGetir)
            {
                LblSekreterAdSoyad.Text = item.SekreterAdSoyad;
            }
         
            //branşları datagride çek
            List<EntityBranslar> BransListesi = LogicBranslar.LLBransListesi();
            dataGridView1.DataSource = BransListesi;


            //doktorları datagridviewe çek
            List<EntityDoktorlarS> Doktorlar = LogicDoktorlar.LLDokorCek();
            dataGridView2.DataSource = Doktorlar;


            //branşları comboboxa çekme
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbBrans.DataSource = bransAdListesi;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {  
            EntityRandevular ent = new EntityRandevular();
            ent.RandevuTarih = MskTarih.Text;
            ent.RandevuSaat = MskSaat.Text;
            ent.RandevuBrans = CmbBrans.Text;
            ent.RandevuDoktor=CmbDoktor.Text;
            int result = LogicRandevular.LLRandevuEkle(ent);
            if (result>0)
            {
                MessageBox.Show("Ekleme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (result == 0)
            {
                MessageBox.Show("Ekleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Hücreleri boş bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktorları comboboxa çekme
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            //seçilen branşa göre doktor çekme
            List<EntityDoktorlar> BransliDoktorGetir = LogicDoktorlar.LLBransliDoktor(CmbBrans.Text);
            foreach (var item in BransliDoktorGetir)
            {
                CmbDoktor.Items.Add(item.DoktorAd + " " + item.DoktorSoyad);
            }

        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
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
