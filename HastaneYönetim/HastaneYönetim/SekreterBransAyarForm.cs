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

        SqlBaglantisi bgl = new SqlBaglantisi();
        /*
        void BransCek()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }*/
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
           
            if (TxtBransAd.Text!="")
            {
                SqlCommand BransEkle = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)", bgl.baglanti());
                BransEkle.Parameters.AddWithValue("@b1", TxtBransAd.Text);
                BransEkle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //branşları tekrar çekme
                BransCek();
            }
            else
            {
                MessageBox.Show("Lütfen eklemek istediğiniz branşı giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
            if (TxtBransAd.Text!="" && TxtBransid.Text!="")
            {
                SqlCommand BransGuncelle = new SqlCommand("Update Tbl_Branslar Set BransAd=@b1 Where Bransid=@b2", bgl.baglanti());
                BransGuncelle.Parameters.AddWithValue("@b1", TxtBransAd.Text);
                BransGuncelle.Parameters.AddWithValue("@b2", TxtBransid.Text);
                BransGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //branşları tekrar çekme
                BransCek();
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz branşı seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtBransAd.Text != "" && TxtBransid.Text != "")
            {
                SqlCommand BransSil = new SqlCommand("Delete From Tbl_Branslar Where Bransid=@b1", bgl.baglanti());
                BransSil.Parameters.AddWithValue("@b1", TxtBransid.Text);
                BransSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //bransları tekrar gridview çek
                BransCek();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz branşı seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtBransAd.Text = "";
            TxtBransid.Text = "";
        }
    }
}
