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
            List<EntityHastalar> HastaIslem = LogicHastalar.LLHastaGuncelle(MskHastaTc.Text);
            foreach (var item in HastaIslem)
            {
                TxtHastaAd.Text = item.HastaAd;
                TxtHastaSoyad.Text = item.HastaSoyad;
                MskHastaTel.Text = item.HastaTelefon;
                TxtHastaSifre.Text = item.HastaSifre;
                CmbCinsiyet.Text = item.HastaCinsiyet;
            }
        }
        
        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            EntityHastalar ent = new EntityHastalar();
            ent.HastaAd = TxtHastaAd.Text;
            ent.HastaSoyad = TxtHastaSoyad.Text;
            ent.HastaTelefon = MskHastaTel.Text;
            ent.HastaSifre = TxtHastaSifre.Text;
            ent.HastaCinsiyet = CmbCinsiyet.Text;
            ent.HastaTC = MskHastaTc.Text;
            bool result = LogicHastalar.LLHastaIslem(ent);
            if (result)
            {
                MessageBox.Show("Bilgileriniz başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen boş hücre bırakmayınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
