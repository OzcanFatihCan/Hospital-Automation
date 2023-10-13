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
    }
}
