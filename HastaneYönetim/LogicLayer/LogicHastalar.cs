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

        public static List<EntityHastalar> LLHastaGiris(string Tc,string Pasw) 
        {
            if (Tc!="" &&
                Pasw!="")
            {
                return DALHastalar.HastaGiris(Tc,Pasw);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityHastalar> LLHastalar(string tc)
        {
            if (tc!="")
            {
                return DALHastalar.Hastalar(tc);
            }
            else
            {
                return null;
            }
        }
        public static List<EntityHastalar> LLHastaGuncelle(string tc)
        {
            if (tc != "")
            {
                return DALHastalar.HastaGuncelle(tc);
            }
            else
            {
                return null;
            }
        }

        public static bool LLHastaIslem(EntityHastalar ent)
        {
            if (ent.HastaAd!="" && 
                ent.HastaSoyad!=""&&
                ent.HastaTelefon != "" &&
                ent.HastaSifre!=""&&
                ent.HastaCinsiyet!=""&&
                ent.HastaTC!=""            
                )
            {
                return DALHastalar.HastalarIslem(ent);
            }
            else
            {
                return false;
            }
        }

    }
}
