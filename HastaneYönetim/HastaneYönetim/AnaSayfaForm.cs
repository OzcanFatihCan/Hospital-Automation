using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneYönetim
{
    public partial class AnaSayfaForm : Form
    {
        public AnaSayfaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaGirisForm HastaGiris= new HastaGirisForm();
            HastaGiris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorGirisForm DoktorGiris = new DoktorGirisForm();
            DoktorGiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterGirisForm SekreterGiris=new SekreterGirisForm();
            SekreterGiris.Show();
            this.Hide();
        }
    }
}
