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
    public partial class DuyurularForm : Form
    {
        public DuyurularForm()
        {
            InitializeComponent();
        }
        private void DuyurularForm_Load(object sender, EventArgs e)
        {        
            List<EntityDuyurular> DuyuruListesi = LogicDuyurular.LLDuyuruListesi();
            dataGridView1.DataSource = DuyuruListesi;
        }
    }
}
