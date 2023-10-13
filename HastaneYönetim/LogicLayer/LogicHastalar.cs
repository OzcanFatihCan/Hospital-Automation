using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicHastalar
    {
        public static int LLHastaEkle(EntityHastalar ent)
        {
            if (ent.HastaAd!="" &&
                ent.HastaSoyad!=""&&
                ent.HastaTC!="" &&
                ent.HastaTelefon!=""&&
                ent.HastaSifre!=""&&
                ent.HastaCinsiyet!="")
            {
                return DALHastalar.HastaEkle(ent);
            }
            else
            {
                return -1;
            }
        }
    }
}
