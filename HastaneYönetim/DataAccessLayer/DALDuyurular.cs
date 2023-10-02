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
    public class DALDuyurular
    {
        public static int DuyuruEkle(EntityDuyurular ent)
        {
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", Baglanti.conn);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@d1", ent.Duyuru);
            return komut1.ExecuteNonQuery();
        }
        public static List<EntityDuyurular> DuyuruListesi()
        {
            List<EntityDuyurular> DuyuruGetir= new List<EntityDuyurular>();
            SqlCommand komut2 = new SqlCommand("Select * From Tbl_Duyurular", Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr=komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityDuyurular ent=new EntityDuyurular();
                ent.Duyuruid = short.Parse(dr["Duyuruid"].ToString());
                ent.Duyuru = dr["Duyuru"].ToString();
                DuyuruGetir.Add(ent);
            }
            dr.Close();
            return DuyuruGetir;
        }
    }
}
