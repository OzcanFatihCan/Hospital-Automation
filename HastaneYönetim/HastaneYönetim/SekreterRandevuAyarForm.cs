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
    public partial class SekreterRandevuAyarForm : Form
    {
        public SekreterRandevuAyarForm()
        {
            InitializeComponent();
        }
       
        private void SekreterRandevuAyarForm_Load(object sender, EventArgs e)
        {          
            List<EntityRandevular> Randevular = LogicRandevular.LLRandevuGetir();
            dataGridView1.DataSource = Randevular;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
