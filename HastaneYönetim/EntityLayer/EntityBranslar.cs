using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    internal class EntityBranslar
    {
        private byte bransid;
        private string bransAd;

        public byte Bransid { get => bransid; set => bransid = value; }
        public string BransAd { get => bransAd; set => bransAd = value; }
    }
}
