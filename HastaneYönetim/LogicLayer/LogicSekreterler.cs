using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicSekreterler
    {
        public static List<EntitySekreter> LLSekreterGetir(string tc)
        {
            if (tc!="")
            {
                return DALSekreter.SekreterGetir(tc);
            }
            else
            {
                return null;
            }
        }
    }
}
