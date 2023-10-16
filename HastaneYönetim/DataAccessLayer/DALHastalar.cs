using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALHastalar
    {
        public static int HastaEkle(EntityHastalar ent)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", Baglanti.conn);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1",ent.HastaAd);
            komut.Parameters.AddWithValue("@p2", ent.HastaSoyad);
            komut.Parameters.AddWithValue("@p3", ent.HastaTC);
            komut.Parameters.AddWithValue("@p4", ent.HastaTelefon);
            komut.Parameters.AddWithValue("@p5", ent.HastaSifre);
            komut.Parameters.AddWithValue("@p6", ent.HastaCinsiyet);
            return komut.ExecuteNonQuery();
        }

        public static List<EntityHastalar> HastaGiris(string Tc, string Pasw)
        {
            List<EntityHastalar> HastaLog= new List<EntityHastalar>();
            SqlCommand komut2 = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1",Tc);
            komut2.Parameters.AddWithValue("@p2",Pasw);
            SqlDataReader dr=komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityHastalar e=new EntityHastalar();
                e.HastaTC = dr["HastaTC"].ToString();
                e.HastaSifre = dr["HastaSifre"].ToString();
                HastaLog.Add(e);
            }
            dr.Close();
           
            return HastaLog;
        }

        public static List<EntityHastalar> Hastalar(string tc)
        {
            List<EntityHastalar> Hasta = new List<EntityHastalar>();
            SqlCommand komut1 = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@p1", Baglanti.conn);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                EntityHastalar ent = new EntityHastalar();
                ent.HastaAd = dr1["HastaAd"].ToString();
                ent.HastaSoyad = dr1["HastaSoyad"].ToString();
                Hasta.Add(ent);
            }
            dr1.Close();
            return Hasta;
        }
    }
}
