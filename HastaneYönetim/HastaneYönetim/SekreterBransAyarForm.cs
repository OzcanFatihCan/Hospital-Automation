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
using DataAccessLayer;
using LogicLayer;
namespace HastaneYönetim
{
    public partial class SekreterBransAyarForm : Form
    {
        public SekreterBransAyarForm()
        {
            InitializeComponent();
        }
     
        void BransCek()
        {
            List<EntityBranslar> BransListesi = LogicBranslar.LLBransListesi();
            dataGridView1.DataSource= BransListesi;
        }
        private void SekreterBransAyarForm_Load(object sender, EventArgs e)
        {
            //bransları datagride çekme
            BransCek();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityBranslar ent =new EntityBranslar();
            ent.BransAd = TxtBransAd.Text;
            int result= LogicBranslar.LLBransEkle(ent);
            if (result > 0)
            {
                MessageBox.Show("Ekleme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BransCek();
            }
            else if (result == 0)
            {
                MessageBox.Show("Ekleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Branş adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;//seçilen hücrelerin içerisindeki sıfırıncı indexe göre satır indexi al
            TxtBransid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();   
            TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {   
            if (TxtBransid.Text != "")
            {
                EntityBranslar ent = new EntityBranslar();
                ent.Bransid = byte.Parse(TxtBransid.Text);
                ent.BransAd = TxtBransAd.Text;
                bool result = LogicBranslar.LLBransGuncelle(ent);
                if (result == true)
                {
                    MessageBox.Show("Güncelleme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BransCek();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz branşı seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz branşı seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
          
            if (TxtBransid.Text!="")
            {
                EntityBranslar ent = new EntityBranslar();
                ent.Bransid = byte.Parse(TxtBransid.Text);
                bool result = LogicBranslar.LLBransSil(ent);
                if (result == true)
                {
                    MessageBox.Show("Silme başarıyla gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BransCek();
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz branşı seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz branşı seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtBransAd.Text = "";
            TxtBransid.Text = "";
        }
    }
}
