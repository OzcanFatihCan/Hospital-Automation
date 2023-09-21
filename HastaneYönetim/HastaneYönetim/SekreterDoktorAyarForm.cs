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
    public partial class SekreterDoktorAyarForm : Form
    {
        public SekreterDoktorAyarForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void DoktorCek()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void SekreterDoktorAyarForm_Load(object sender, EventArgs e)
        {
            //doktorları datagridviewe çek

            DoktorCek();


            //branşları comboboxa çekme
            SqlCommand BransCek = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr1 = BransCek.ExecuteReader();//burada sqldeki veriler okunuyor.
            while (dr1.Read())
            {
                CmbBrans.Items.Add(dr1[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {  
            if (MskTc.Text!="" && MskTc.MaskCompleted && TxtAd.Text!="" && TxtSoyad.Text!="" && CmbBrans.Text!="" && TxtSifre.Text!="")
            {
                SqlCommand DoktorEkle = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
                DoktorEkle.Parameters.AddWithValue("@d1", TxtAd.Text);
                DoktorEkle.Parameters.AddWithValue("@d2", TxtSoyad.Text);
                DoktorEkle.Parameters.AddWithValue("@d3", CmbBrans.Text);
                DoktorEkle.Parameters.AddWithValue("@d4", MskTc.Text);
                DoktorEkle.Parameters.AddWithValue("@d5", TxtSifre.Text);
                DoktorEkle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Doktor eklemesi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doktorları tekrar gridview çek
                DoktorCek();
            }
            else
            {
                MessageBox.Show("Doktor eklemek için boş hücre bırakmayınız ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;//seçilen hücrelerin içerisindeki sıfırıncı indexe göre satır indexi al
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (MskTc.Text != "" && MskTc.MaskCompleted && TxtAd.Text != "" && TxtSoyad.Text != "" && CmbBrans.Text != "" && TxtSifre.Text != "") {
                SqlCommand DoktorGuncelle = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d4 Where DoktorTC=@d5", bgl.baglanti());
                DoktorGuncelle.Parameters.AddWithValue("@d1", TxtAd.Text);
                DoktorGuncelle.Parameters.AddWithValue("@d2", TxtSoyad.Text);
                DoktorGuncelle.Parameters.AddWithValue("@d3", CmbBrans.Text);
                DoktorGuncelle.Parameters.AddWithValue("@d4", TxtSifre.Text);
                DoktorGuncelle.Parameters.AddWithValue("@d5", MskTc.Text);
                DoktorGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bilgiler başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doktorları tekrar gridview çek
                DoktorCek();
            }
            else
            {
                MessageBox.Show("Bilgileri güncellemek için boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (MskTc.Text != "" && MskTc.MaskCompleted && TxtAd.Text != "" && TxtSoyad.Text != "" && CmbBrans.Text != "" && TxtSifre.Text != "") {
                SqlCommand DoktorSil = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@d1", bgl.baglanti());
                DoktorSil.Parameters.AddWithValue("@d1", MskTc.Text);
                DoktorSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doktorları tekrar gridview çek
                DoktorCek();
            }
            else
            {
                MessageBox.Show("Kaydı silmek için seçim yapınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
