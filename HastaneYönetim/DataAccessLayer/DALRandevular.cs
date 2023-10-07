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
    public class DALRandevular
    {
        public static List<EntityRandevular> RandevuGetir()
        {
            List<EntityRandevular> Randevular = new List<EntityRandevular>();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Randevular", Baglanti.conn);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                EntityRandevular ent= new EntityRandevular();
                ent.Randevuid = int.Parse(dr1["Randevuid"].ToString());
                ent.RandevuTarih = dr1["RandevuTarih"].ToString();
                ent.RandevuSaat = dr1["RandevuSaat"].ToString();
                ent.RandevuBrans = dr1["RandevuBrans"].ToString();
                ent.RandevuDoktor = dr1["RandevuDoktor"].ToString();
                ent.RandevuDurum = bool.Parse(dr1["RandevuDurum"].ToString());
                ent.HastaTC = dr1["HastaTC"].ToString() ;
                ent.HastaSikayet = dr1["HastaSikayet"].ToString();
                Randevular.Add(ent);
            }
            dr1.Close();
            return Randevular;
        }

        public static int RandevuOlustur(EntityRandevular e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@a1,@a2,@a3,@a4)",Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@a1",e.RandevuTarih);
            komut2.Parameters.AddWithValue("@a2", e.RandevuSaat);
            komut2.Parameters.AddWithValue("@a3", e.RandevuBrans);
            komut2.Parameters.AddWithValue("@a4", e.RandevuDoktor);

            return komut2.ExecuteNonQuery();
        }


        public static List<EntityRandevular> DoktorRandevu(string DoktorAdSoyad)
        {
            List<EntityRandevular> DoktorRandevuları = new List<EntityRandevular>();
            SqlCommand komut3 = new SqlCommand("Select * From Tbl_Randevular Where RandevuDoktor=@p1", Baglanti.conn);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", DoktorAdSoyad);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                EntityRandevular ent=new EntityRandevular();
                ent.Randevuid = int.Parse(dr2["Randevuid"].ToString());
                ent.RandevuTarih = dr2["RandevuTarih"].ToString();
                ent.RandevuSaat = dr2["RandevuSaat"].ToString();
                ent.RandevuBrans = dr2["RandevuBrans"].ToString();
                ent.RandevuDoktor = dr2["RandevuDoktor"].ToString();
                ent.RandevuDurum = bool.Parse(dr2["RandevuDurum"].ToString());
                ent.HastaTC = dr2["HastaTC"].ToString();
                ent.HastaSikayet = dr2["HastaSikayet"].ToString();
                DoktorRandevuları.Add(ent);
            }
            dr2.Close();
            return DoktorRandevuları;
        }

        public static List<EntityRandevular> HastaRandevu(string hastatc)
        {
            List<EntityRandevular> HastaRandevuları = new List<EntityRandevular>();
            SqlCommand komut4 = new SqlCommand("Select * From Tbl_Randevular Where HastaTC=@p1", Baglanti.conn);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", hastatc);
            SqlDataReader dr3 = komut4.ExecuteReader();
            while (dr3.Read())
            {
                EntityRandevular ent = new EntityRandevular();
                ent.Randevuid = int.Parse(dr3["Randevuid"].ToString());
                ent.RandevuTarih = dr3["RandevuTarih"].ToString();
                ent.RandevuSaat = dr3["RandevuSaat"].ToString();
                ent.RandevuBrans = dr3["RandevuBrans"].ToString();
                ent.RandevuDoktor = dr3["RandevuDoktor"].ToString();
                ent.RandevuDurum = bool.Parse(dr3["RandevuDurum"].ToString());
                ent.HastaTC = dr3["HastaTC"].ToString();
                ent.HastaSikayet = dr3["HastaSikayet"].ToString();
                HastaRandevuları.Add(ent);
            }
            dr3.Close();
            return HastaRandevuları;
        }

        public static List<EntityRandevular> RandevuM(string brans,string doktor)
        {
            List<EntityRandevular> RandevuM = new List<EntityRandevular>();
            SqlCommand komut5 = new SqlCommand("Select * From Tbl_Randevular Where RandevuBrans=@p1 and RandevuDoktor=@p2 and RandevuDurum=0", Baglanti.conn);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@p1", brans);
            komut5.Parameters.AddWithValue("@p2", doktor);
            SqlDataReader dr4 = komut5.ExecuteReader();
            while (dr4.Read())
            {
                EntityRandevular ent = new EntityRandevular();
                ent.Randevuid = int.Parse(dr4["Randevuid"].ToString());
                ent.RandevuTarih = dr4["RandevuTarih"].ToString();
                ent.RandevuSaat = dr4["RandevuSaat"].ToString();
                ent.RandevuBrans = dr4["RandevuBrans"].ToString();
                ent.RandevuDoktor = dr4["RandevuDoktor"].ToString();
                ent.RandevuDurum = bool.Parse(dr4["RandevuDurum"].ToString());
                ent.HastaTC = dr4["HastaTC"].ToString();
                ent.HastaSikayet = dr4["HastaSikayet"].ToString();
                RandevuM.Add(ent);
            }
            dr4.Close();
            return RandevuM;
        }

        public static bool RandevuAl(EntityRandevular ent)
        {
            SqlCommand komut6 = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", Baglanti.conn);
            if (komut6.Connection.State != ConnectionState.Open)
            {
                komut6.Connection.Open();
            }
            komut6.Parameters.AddWithValue("@p1", ent.HastaTC);
            komut6.Parameters.AddWithValue("@p2", ent.HastaSikayet);
            komut6.Parameters.AddWithValue("@p3", ent.Randevuid);      
            return komut6.ExecuteNonQuery() > 0;
        }

    }
}
