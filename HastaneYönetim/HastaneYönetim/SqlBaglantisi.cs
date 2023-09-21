using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace HastaneYönetim
{
    internal class SqlBaglantisi
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\DB\HastaneYonetimDBAdres.txt");
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection(Adres);
            baglan.Open();
            return baglan;
        }
    }
}
