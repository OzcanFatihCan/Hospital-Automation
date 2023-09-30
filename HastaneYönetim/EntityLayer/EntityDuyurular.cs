using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDuyurular
    {
        private short duyuruid;
        private string duyuru;

        public short Duyuruid { get => duyuruid; set => duyuruid = value; }
        public string Duyuru { get => duyuru; set => duyuru = value; }
    }
}
