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
    public partial class DoktorGirisForm : Form
    {
        public DoktorGirisForm()
        {
            InitializeComponent();
        }
      
        private void BtnGirisYapDoktor_Click(object sender, EventArgs e)
        {
            List<EntityDoktorlar> DoktorGetir = LogicDoktorlar.LLDoktorGiris(maskedTextBox1.Text, textBox1.Text);
            if (DoktorGetir != null && DoktorGetir.Count > 0)
            {
                DoktorDetayForm DoktorDetay = new DoktorDetayForm();
                DoktorDetay.TC = maskedTextBox1.Text;
                DoktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }      
        }
    }
}
