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
        
        public static List<EntityDoktorlar> LLBransliDoktor(string brans)
        {
            if (brans!="")
            {
                return DALDoktorlar.BransliDoktorCek(brans);
            }
            else
            {
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

        public static int LLDoktorEkle(EntityDoktorlar ent)
        {
            if (ent.DoktorAd != "" && ent.DoktorSoyad != "" && ent.DoktorTC != "" && ent.DoktorBrans != "" && ent.DoktorSifre != "")
            {
                return DALDoktorlar.DoktorEkle(ent);
            }
            else
            { return -1; }
        }

        public static List<EntityDoktorlar> LLDoktorGetir()
        {
            return DALDoktorlar.DoktorCekTam();
        }

        public static bool LLDoktorSil(EntityDoktorlar p)
        {
            if (p.DoktorTC != "")
            {
                try
                {
                    return DALDoktorlar.DoktorSil(p);
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
