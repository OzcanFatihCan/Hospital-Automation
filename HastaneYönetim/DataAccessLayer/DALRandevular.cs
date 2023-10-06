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


    }
}
