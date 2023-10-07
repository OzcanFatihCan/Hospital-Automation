using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicRandevular
    {

        public static List<EntityRandevular> LLRandevuGetir()
        {
            return DALRandevular.RandevuGetir();
        }

        public static int LLRandevuEkle(EntityRandevular ent)
        {
            if (ent.RandevuTarih!="" && ent.RandevuSaat!="" && ent.RandevuBrans!="" && ent.RandevuDoktor!="")
            {
                return DALRandevular.RandevuOlustur(ent);
            }
            else
            {
                return -1;
            }
        }

        public static List<EntityRandevular>LLDoktorRandevu (string DoktorAdSoyad)
        {
            if (DoktorAdSoyad!="")
            {
                return DALRandevular.DoktorRandevu(DoktorAdSoyad);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityRandevular> LLHastaRandevu(string HastaTC)
        {
            if (HastaTC!= "")
            {
                return DALRandevular.HastaRandevu(HastaTC);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityRandevular> LLRandevuM(string brans,string doktor)
        {
            if (doktor != "" && brans!="")
            {
                return DALRandevular.RandevuM(brans, doktor);
            }
            else
            {
                return null;
            }
        }

        public static bool LLRandevuAl(EntityRandevular ent)
        {
            
            if (ent.HastaTC!="" && ent.HastaSikayet!="")
            {
                return DALRandevular.RandevuAl(ent);
            }
            else
            {
                return false;
            }
        }
    }
}
