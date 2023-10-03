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
        public static bool LLDoktorGuncelle(EntityDoktorlar ent)
        {
            if (ent.DoktorAd!="" && ent.DoktorSoyad!="" && ent.DoktorTC!="" && ent.DoktorBrans!="" && ent.DoktorSifre!="")
            {
                return DALDoktorlar.DoktorGuncelle(ent);
            }
            else
            {
                return false;
            }
        }

    }
}
