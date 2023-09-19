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
    public partial class DoktorGirisForm : Form
    {
        public DoktorGirisForm()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void BtnGirisYapDoktor_Click(object sender, EventArgs e)
        {
            SqlCommand GirisDoktor = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            GirisDoktor.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            GirisDoktor.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = GirisDoktor.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetayForm DoktorDetay = new DoktorDetayForm();
                DoktorDetay.TC = maskedTextBox1.Text;
                DoktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız.");
            }
            bgl.baglanti().Close();
        }
    }
}
