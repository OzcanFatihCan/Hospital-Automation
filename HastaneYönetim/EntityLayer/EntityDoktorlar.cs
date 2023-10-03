using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDoktorlar
    {
        private byte doktorid;
        private string doktorAd;
        private string doktorSoyad;
        private string doktorBrans;
        private string doktorTC;
        private string doktorSifre;

        public byte Doktorid { get => doktorid; set => doktorid = value; }
        public string DoktorAd { get => doktorAd; set => doktorAd = value; }
        public string DoktorSoyad { get => doktorSoyad; set => doktorSoyad = value; }
        public string DoktorBrans { get => doktorBrans; set => doktorBrans = value; }
        public string DoktorTC { get => doktorTC; set => doktorTC = value; }
        public string DoktorSifre { get => doktorSifre; set => doktorSifre = value; }

    }
}
