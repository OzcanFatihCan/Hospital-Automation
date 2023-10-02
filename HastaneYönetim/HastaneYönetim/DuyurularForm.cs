﻿using System;
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
            /*
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Duyurular", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;*/
            List<EntityDuyurular> DuyuruListesi = LogicDuyurular.LLDuyuruListesi();
            dataGridView1.DataSource = DuyuruListesi;
        }
    }
}
