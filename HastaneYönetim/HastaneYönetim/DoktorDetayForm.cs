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
    public partial class DoktorDetayForm : Form
    {
        public DoktorDetayForm()
        {
            InitializeComponent();
        }

       
        public string TC;
        private void DoktorDetayForm_Load(object sender, EventArgs e)
        {
           
            List<EntityDoktorlar> Doktorgetir = LogicDoktorlar.LLDoktorListesi(TC);
            foreach (var item in Doktorgetir)
            {
                string ad = item.DoktorAd;
                string soyad=item.DoktorSoyad;
                LblDoktorAdSoyad.Text = ad +" "+ soyad;
                LblDoktorBrans.Text = item.DoktorBrans;
                LblDoktorTc.Text = TC;
            }

            //Doktora ait randevuları çekme
            List<EntityRandevular> DoktorRandevu = LogicRandevular.LLDoktorRandevu(LblDoktorAdSoyad.Text);
            dataGridView1.DataSource = DoktorRandevu;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DoktorBilgiDüzenleForm BilgiDüzenle=new DoktorBilgiDüzenleForm();
            BilgiDüzenle.TC = LblDoktorTc.Text;
            BilgiDüzenle.Show();
            
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            DuyurularForm Duyurular =new DuyurularForm();
            Duyurular.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
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
