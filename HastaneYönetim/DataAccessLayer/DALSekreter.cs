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
    public class DALSekreter
    {
        public static List<EntitySekreter> SekreterGetir(string tc)
        {
            List<EntitySekreter> Sekreterler=new List<EntitySekreter>();
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", Baglanti.conn);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                EntitySekreter ent=new EntitySekreter();
                ent.SekreterAdSoyad = dr1["SekreterAdSoyad"].ToString();
                Sekreterler.Add(ent);
            }
            dr1.Close();
            return Sekreterler;
        }
    }
}
