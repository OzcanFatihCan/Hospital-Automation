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
    }
}
