using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicDuyurular
    {
        public static int LLDuyuruEkle(EntityDuyurular ent)
        {
            if (ent.Duyuru!="")
            {
                return DALDuyurular.DuyuruEkle(ent);
            }
            else
            {
                return -1;
            }
        }

        public static List<EntityDuyurular> LLDuyuruListesi()
        {
            return DALDuyurular.DuyuruListesi();
        }
       

    }
}
