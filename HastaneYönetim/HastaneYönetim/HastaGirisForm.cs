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
    public partial class HastaGirisForm : Form
    {
        public HastaGirisForm()
        {
            InitializeComponent();
        }
     
        private void LinkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıtForm HastaKayitGiris = new HastaKayıtForm();
            HastaKayitGiris.Show();
        }

        private void BtnGirisYapHasta_Click(object sender, EventArgs e)
        {
            List<EntityHastalar> HastaGetir = LogicHastalar.LLHastaGiris(maskedTextBox1.Text,textBox1.Text);
            if (HastaGetir!=null && HastaGetir.Count > 0)
            {
                HastaDetayForm HastaDetay = new HastaDetayForm();//geçiş sırasında tc ve ad soyad taşınacak
                HastaDetay.tc = maskedTextBox1.Text;
                HastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void HastaGirisForm_Load(object sender, EventArgs e)
        {

        }
    }
}
