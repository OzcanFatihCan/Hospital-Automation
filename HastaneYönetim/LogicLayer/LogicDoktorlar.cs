using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicDoktorlar
    {
        public static List<EntityDoktorlar> LLDoktorListesi(string tc)
        {
            if (tc != "") { 
            return DALDoktorlar.DoktorCek(tc);
            }
            else{
                return null;
            }
        }

    }
}
