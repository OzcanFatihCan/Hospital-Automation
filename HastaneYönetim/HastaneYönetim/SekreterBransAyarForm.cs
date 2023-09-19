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
    public partial class SekreterBransAyarForm : Form
    {
        public SekreterBransAyarForm()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void SekreterBransAyarForm_Load(object sender, EventArgs e)
        {
            //bransları datagride çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand BransEkle=new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)",bgl.baglanti());
            BransEkle.Parameters.AddWithValue("@b1",TxtBransAd.Text);
            BransEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //branşları tekrar çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;//seçilen hücrelerin içerisindeki sıfırıncı indexe göre satır indexi al
            TxtBransid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();   
            TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand BransGuncelle = new SqlCommand("Update Tbl_Branslar Set BransAd=@b1 Where Bransid=@b2", bgl.baglanti());
            BransGuncelle.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            BransGuncelle.Parameters.AddWithValue("@b2", TxtBransid.Text);
            BransGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //branşları tekrar çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand BransSil = new SqlCommand("Delete From Tbl_Branslar Where Bransid=@b1", bgl.baglanti());
            BransSil.Parameters.AddWithValue("@b1", TxtBransid.Text);
            BransSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //doktorları tekrar gridview çek
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
