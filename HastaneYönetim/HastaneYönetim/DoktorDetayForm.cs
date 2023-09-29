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

namespace HastaneYönetim
{
    public partial class DoktorDetayForm : Form
    {
        public DoktorDetayForm()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();
        public string TC;
        private void DoktorDetayForm_Load(object sender, EventArgs e)
        {
            LblDoktorTc.Text = TC;

            //tc gelen doktorun ad soyad ve branş çek
            SqlCommand DoktorCek=new SqlCommand("Select DoktorAd,DoktorSoyad,DoktorBrans From Tbl_Doktorlar Where DoktorTC=@p1",bgl.baglanti());
            DoktorCek.Parameters.AddWithValue("@p1", LblDoktorTc.Text);
            SqlDataReader dr1= DoktorCek.ExecuteReader();
            while (dr1.Read())
            {
                LblDoktorAdSoyad.Text = dr1[0]+" " + dr1[1];
                LblDoktorBrans.Text = dr1[2].ToString();
            }
            bgl.baglanti().Close();

            //Doktora ait randevuları çekme
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuDoktor='"+LblDoktorAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;


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
