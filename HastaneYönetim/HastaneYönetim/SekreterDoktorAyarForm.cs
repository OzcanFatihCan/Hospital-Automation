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
    public partial class SekreterDoktorAyarForm : Form
    {
        public SekreterDoktorAyarForm()
        {
            InitializeComponent();
        }

        //tcsiz doktor çekme işlemi hazırlanacak
        void DoktorCek()
        {
            List<EntityDoktorlar> DoktorListesi = LogicDoktorlar.LLDoktorGetir();
            dataGridView1.DataSource = DoktorListesi;
        }

        private void SekreterDoktorAyarForm_Load(object sender, EventArgs e)
        {
            //doktorları datagridviewe çek
            DoktorCek();
            
            //branşları comboboxa çekme
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbBrans.DataSource = bransAdListesi;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {           
            EntityDoktorlar ent = new EntityDoktorlar();
            ent.DoktorAd = TxtAd.Text;
            ent.DoktorSoyad = TxtSoyad.Text;
            ent.DoktorSifre = TxtSifre.Text;
            ent.DoktorTC=MskTc.Text;
            ent.DoktorBrans = CmbBrans.Text;
            int result = LogicDoktorlar.LLDoktorEkle(ent);

            if (result > 0)
            {
                MessageBox.Show("Ekleme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoktorCek();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int secilen = dataGridView1.SelectedCells[0].RowIndex;//seçilen hücrelerin içerisindeki sıfırıncı indexe göre satır indexi al
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            MskTc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {           
            EntityDoktorlar ent = new EntityDoktorlar();
            ent.DoktorTC = MskTc.Text;
            ent.DoktorAd = TxtAd.Text;
            ent.DoktorSoyad = TxtSoyad.Text;
            ent.DoktorBrans = CmbBrans.Text;
            ent.DoktorSifre = TxtSifre.Text;
            bool result = LogicDoktorlar.LLDoktorGuncelle(ent);
            if (result == true)
            {
                MessageBox.Show("Başarıyla güncelleme yapıldı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoktorCek();
            }
            else
            {
                MessageBox.Show("Lütfen boş hücre bırakmayınız", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {                      
            if (MskTc.Text != "")
            {
                EntityDoktorlar ent = new EntityDoktorlar();
                ent.DoktorTC = MskTc.Text;
                bool result = LogicDoktorlar.LLDoktorSil(ent);
                if (result == true)
                {
                    MessageBox.Show("Silme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DoktorCek();
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz doktoru seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz doktoru seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtSifre.Text = "";
            TxtSoyad.Text = "";
            MskTc.Text = "";
            CmbBrans.Text = "";
        }
    }
}
