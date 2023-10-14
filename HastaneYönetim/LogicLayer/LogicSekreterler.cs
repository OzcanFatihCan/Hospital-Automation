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
        public static List<EntitySekreter> LLSekreterGiris(string Tc, string Pasw)
        {
            if (Tc != "" &&
                Pasw != "")
            {
                return DALSekreter.SekreterGiris(Tc, Pasw);
            }
            else
            {
                return null;
            }
        }

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
