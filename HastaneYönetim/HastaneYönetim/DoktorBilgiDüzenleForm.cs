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
    public partial class DoktorBilgiDüzenleForm : Form
    {
        public DoktorBilgiDüzenleForm()
        {
            InitializeComponent();
        }
        
        public string TC;

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {         
            EntityDoktorlar ent = new EntityDoktorlar();
            ent.DoktorTC = MskDoktorTc.Text;
            ent.DoktorAd = TxtDoktorAd.Text;
            ent.DoktorSoyad = TxtDoktorSoyad.Text;
            ent.DoktorBrans = CmbDoktorBrans.Text;
            ent.DoktorSifre = TxtDoktorSifre.Text;
            bool result= LogicDoktorlar.LLDoktorGuncelle(ent);
            if(result == true)
            {
                MessageBox.Show("Başarıyla güncelleme yapıldı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen boş hücre bırakmayınız", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DoktorBilgiDüzenleForm_Load(object sender, EventArgs e)
        {       
           List<EntityDoktorlar> Doktorgetir = LogicDoktorlar.LLDoktorListesi(TC);
          
                foreach (var item in Doktorgetir)
                {
                MskDoktorTc.Text = TC;
                TxtDoktorAd.Text = item.DoktorAd;
                TxtDoktorSoyad.Text = item.DoktorSoyad;
                TxtDoktorSifre.Text = item.DoktorSifre;
                CmbDoktorBrans.SelectedValue = item.DoktorBrans;
                }
              
            //Hazır Branş getir
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbDoktorBrans.DataSource = bransAdListesi;
        }
    }
}
