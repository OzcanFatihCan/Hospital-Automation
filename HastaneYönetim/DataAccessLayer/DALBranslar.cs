using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALBranslar
    {
        public static List<EntityBranslar> BransListesi()
        {
            List<EntityBranslar> BransGetir = new List<EntityBranslar>();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Branslar", Baglanti.conn);
            if (komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityBranslar ent=new EntityBranslar();
                ent.Bransid = byte.Parse(dr["Bransid"].ToString());
                ent.BransAd = dr["BransAd"].ToString();
                BransGetir.Add(ent);
            }
            dr.Close();
            return BransGetir;
        }

        public static int BransEkle(EntityBranslar e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)", Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@b1",e.BransAd);
            return komut2.ExecuteNonQuery();         
        }
        
        public static bool BransSil(byte p)
        {
            SqlCommand komut3 = new SqlCommand("Delete From Tbl_Branslar Where Bransid=@b1",Baglanti.conn);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@b1",p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static bool BransGuncelle(EntityBranslar ent)
        {
            SqlCommand komut4 = new SqlCommand("Update Tbl_Branslar Set BransAd=@b1 Where Bransid=@b2", Baglanti.conn);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@b1",ent.BransAd);
            komut4.Parameters.AddWithValue("@b2", ent.Bransid);
            return komut4.ExecuteNonQuery() > 0;
        }
    }
}
