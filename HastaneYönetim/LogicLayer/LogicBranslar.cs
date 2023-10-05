using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;


namespace LogicLayer 
{
    public class LogicBranslar 
    {
        public static List<EntityBranslar> LLBransListesi()
        {
            return DALBranslar.BransListesi();
        }

        public static List<string> BransAdListesi()
        {
            List<EntityBranslar> branslar = LLBransListesi();
            List<string> bransAdListesi = new List<string>();

            foreach (EntityBranslar brans in branslar)
            {
                bransAdListesi.Add(brans.BransAd);
            }
            return bransAdListesi;
        }

        public static int LLBransEkle(EntityBranslar p)
        {
            if (p.BransAd != "")
            {
                return DALBranslar.BransEkle(p);
            }
            else
            {
                return -1;//aksi durumda bir şey eklenmesin.
            }
        }
        
        public static bool LLBransGuncelle(EntityBranslar p)
        {
            if (p.Bransid!=0 && p.BransAd!="")
            {
                try
                {
                    return DALBranslar.BransGuncelle(p);
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
        public static bool LLBransSil(EntityBranslar p)
        {
            if (p.Bransid!=0)
            {
                try
                {
                    return DALBranslar.BransSil(p);
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
