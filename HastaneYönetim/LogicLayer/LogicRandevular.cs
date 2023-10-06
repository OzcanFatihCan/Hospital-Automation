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
    }
}
