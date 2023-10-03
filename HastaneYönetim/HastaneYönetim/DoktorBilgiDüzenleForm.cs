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
using LogicLayer;
using EntityLayer;

namespace HastaneYönetim
{
    public partial class DoktorBilgiDüzenleForm : Form
    {
        public DoktorBilgiDüzenleForm()
        {
            InitializeComponent();
        }
        //SqlBaglantisi bgl=new SqlBaglantisi();
        public string TC;

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            /*
             if (TxtDoktorAd.Text!=""&&TxtDoktorSoyad.Text!=""&&CmbDoktorBrans.Text!=""&&TxtDoktorSifre.Text!=""&&MskDoktorTc.Text!="")
             {
                 SqlCommand DoktorGuncelle = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 Where DoktorTC=@p5", bgl.baglanti());
                 DoktorGuncelle.Parameters.AddWithValue("@p1", TxtDoktorAd.Text);
                 DoktorGuncelle.Parameters.AddWithValue("@p2", TxtDoktorSoyad.Text);
                 DoktorGuncelle.Parameters.AddWithValue("@p3", CmbDoktorBrans.Text);
                 DoktorGuncelle.Parameters.AddWithValue("@p4", TxtDoktorSifre.Text);
                 DoktorGuncelle.Parameters.AddWithValue("@p5", MskDoktorTc.Text);
                 DoktorGuncelle.ExecuteNonQuery();
                 bgl.baglanti().Close();
                 MessageBox.Show("Başarıyla güncelleme yapıldı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 MessageBox.Show("Lütfen boş hücre bırakmayınız", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }*/
            EntityDoktorlar ent = new EntityDoktorlar();
            ent.DoktorTC = MskDoktorTc.Text;
            ent.DoktorAd = TxtDoktorAd.Text;
            ent.DoktorSoyad = TxtDoktorSoyad.Text;
            ent.DoktorBrans = CmbDoktorBrans.Text;
            ent.DoktorSifre = TxtDoktorSifre.Text;
            bool result= LogicDoktorlar.LLDoktorGuncelle(ent);
            if(result == true)
            {
                MessageBox.Show("Başarıyla güncelleme yapıldı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen boş hücre bırakmayınız", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DoktorBilgiDüzenleForm_Load(object sender, EventArgs e)
        {

            //tcsi ana formdan gelen doktorun bilgilerini düzenleme
            //MskDoktorTc.Text = TC;
            /*
            SqlCommand DoktorVeriCek=new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC=@p1",bgl.baglanti());
            DoktorVeriCek.Parameters.AddWithValue("@p1",MskDoktorTc.Text);
            SqlDataReader dr=DoktorVeriCek.ExecuteReader();
            while(dr.Read())
            {
                TxtDoktorAd.Text = dr[1].ToString();
                TxtDoktorSoyad.Text = dr[2].ToString();
                CmbDoktorBrans.Text = dr[3].ToString();
                TxtDoktorSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
            */
           List<EntityDoktorlar> Doktorgetir = LogicDoktorlar.LLDoktorListesi(TC);
          
                foreach (var item in Doktorgetir)
                {
                MskDoktorTc.Text = TC;
                TxtDoktorAd.Text = item.DoktorAd;
                TxtDoktorSoyad.Text = item.DoktorSoyad;
                TxtDoktorSifre.Text = item.DoktorSifre;
                CmbDoktorBrans.SelectedValue = item.DoktorBrans;
                }
              
            //Hazır Branş getir
            List<string> bransAdListesi = LogicBranslar.BransAdListesi();
            CmbDoktorBrans.DataSource = bransAdListesi;
        }
    }
}
