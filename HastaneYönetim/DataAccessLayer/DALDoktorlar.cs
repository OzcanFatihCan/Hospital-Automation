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

    }
}
