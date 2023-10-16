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
    public partial class HastaKayıtForm : Form
    {
        public HastaKayıtForm()
        {
            InitializeComponent();
        }
        
        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            EntityHastalar ent = new EntityHastalar();

            ent.HastaAd = TxtHastaAd.Text;
            ent.HastaSoyad = TxtHastaSoyad.Text;
            ent.HastaTC = MskHastaTc.Text;
            ent.HastaCinsiyet = CmbCinsiyet.Text;
            ent.HastaTelefon = MskHastaTel.Text;
            ent.HastaSifre = TxtHastaSifre.Text;
            int result = LogicHastalar.LLHastaEkle(ent);
            if (result > 0)
            {
                MessageBox.Show("Kayıt başarıyla gerçekleştirildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == 0)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Hücreleri boş bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
