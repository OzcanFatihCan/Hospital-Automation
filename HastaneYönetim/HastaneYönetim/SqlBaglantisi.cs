using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneYönetim
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=HastaneYonetim;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
