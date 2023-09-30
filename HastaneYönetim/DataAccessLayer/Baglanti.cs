using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection conn = new SqlConnection(System.IO.File.ReadAllText(@"C:\DB\HastaneYonetimDBAdres.txt"));                
    }
}
