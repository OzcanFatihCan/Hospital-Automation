using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALDoktorlar
    {
        public static List<EntityDoktorlar> DoktorCek(string tc)
        {
            List<EntityDoktorlar> DoktorGetir=new List<EntityDoktorlar>();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC=@p1",Baglanti.conn);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1",tc);
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityDoktorlar ent=new EntityDoktorlar();
                //ent.Doktorid = byte.Parse(dr["Doktorid"].ToString());
                ent.DoktorAd = dr["DoktorAd"].ToString();
                ent.DoktorSoyad = dr["DoktorSoyad"].ToString();
                ent.DoktorBrans = dr["DoktorBrans"].ToString();
                ent.DoktorTC = dr["DoktorTC"].ToString();
                ent.DoktorSifre = dr["DoktorSifre"].ToString();
                DoktorGetir.Add(ent);
            }
            dr.Close();
            return DoktorGetir;
        }

        public static List<EntityDoktorlar> BransliDoktorCek(string brans)
        {
            List<EntityDoktorlar> DoktorGetir = new List<EntityDoktorlar>();
            //seçilen branşa göre doktor çekme
            SqlCommand komut6 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", Baglanti.conn);
            komut6.Parameters.AddWithValue("@p1", brans);
            SqlDataReader dr3 = komut6.ExecuteReader();
            while(dr3.Read())
            {
                EntityDoktorlar ent= new EntityDoktorlar();
                ent.DoktorAd = dr3["DoktorAd"].ToString();
                ent.DoktorSoyad = dr3["DoktorSoyad"].ToString();
                DoktorGetir.Add(ent);
            }
            dr3.Close();
            return DoktorGetir;
        }


        public static List<EntityDoktorlar> DoktorCekTam() {
            List<EntityDoktorlar> DoktorCagir=new List<EntityDoktorlar>();
            SqlCommand komut5=new SqlCommand("Select * From Tbl_Doktorlar",Baglanti.conn);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            SqlDataReader dr2 = komut5.ExecuteReader();
            while (dr2.Read())
            {
                EntityDoktorlar ent = new EntityDoktorlar();
                //ent.Doktorid = byte.Parse(dr2["Doktorid"].ToString());
                ent.DoktorAd = dr2["DoktorAd"].ToString();
                ent.DoktorSoyad = dr2["DoktorSoyad"].ToString();
                ent.DoktorBrans = dr2["DoktorBrans"].ToString();
                ent.DoktorTC = dr2["DoktorTC"].ToString();
                ent.DoktorSifre = dr2["DoktorSifre"].ToString();
                DoktorCagir.Add(ent);
            }
            dr2.Close();
            return DoktorCagir;
        }
        /*
        public static List<EntityDoktorlar> DoktorCekS()
        {
            List<EntityDoktorlar> DoktorGetir = new List<EntityDoktorlar>();
            SqlCommand komut7 = new SqlCommand("Select (DoktorAd+' '+DoktorSoyad) as 'Doktorlar',DoktorBrans,DoktorTC From Tbl_Doktorlar", Baglanti.conn);
            if (komut7.Connection.State != ConnectionState.Open)
            {
                komut7.Connection.Open();
            }
            SqlDataReader dr4=komut7.ExecuteReader();
            while (dr4.Read())
            {
                EntityDoktorlar ent = new EntityDoktorlar();
                ent.DoktorAd = dr4["DoktorAd"].ToString();
                ent.DoktorSoyad = dr4["DoktorSoyad"].ToString();
                ent.DoktorBrans = dr4["DoktorBrans"].ToString();
                ent.DoktorTC = dr4["DoktorTC"].ToString();
                DoktorGetir.Add(ent);
            }
            dr4.Close();
            return DoktorGetir;
        }
        */

        public static bool DoktorGuncelle(EntityDoktorlar ent)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 Where DoktorTC=@p5", Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1",ent.DoktorAd);
            komut2.Parameters.AddWithValue("@p2", ent.DoktorSoyad);
            komut2.Parameters.AddWithValue("@p3", ent.DoktorBrans);
            komut2.Parameters.AddWithValue("@p4", ent.DoktorSifre);
            komut2.Parameters.AddWithValue("@p5", ent.DoktorTC);
            return komut2.ExecuteNonQuery() > 0;
        }

        public static int DoktorEkle(EntityDoktorlar e)
        {
            SqlCommand komut3 = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", Baglanti.conn);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@d1",e.DoktorAd);
            komut3.Parameters.AddWithValue("@d2", e.DoktorSoyad);
            komut3.Parameters.AddWithValue("@d3", e.DoktorBrans);
            komut3.Parameters.AddWithValue("@d4", e.DoktorTC);
            komut3.Parameters.AddWithValue("@d5", e.DoktorSifre);
                
            return komut3.ExecuteNonQuery();
        }

        public static bool DoktorSil(EntityDoktorlar ent)
        {
            SqlCommand komut4 = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@d1", Baglanti.conn);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@d1", ent.DoktorTC);
            return komut4.ExecuteNonQuery() > 0;
        }



    }
}
