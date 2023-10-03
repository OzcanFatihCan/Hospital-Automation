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
                ent.Doktorid = byte.Parse(dr["Doktorid"].ToString());
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

    }
}
