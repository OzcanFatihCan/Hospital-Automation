using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    internal class EntityHastalar
    {
        private short hastaid;
        private string hastaAd;
        private string hastaSoyad;
        private char hastaTC;
        private string hastaTelefon;
        private string hastaSifre;
        private string hastaCinsiyet;

        public short Hastaid { get => hastaid; set => hastaid = value; }
        public string HastaAd { get => hastaAd; set => hastaAd = value; }
        public string HastaSoyad { get => hastaSoyad; set => hastaSoyad = value; }
        public char HastaTC { get => hastaTC; set => hastaTC = value; }
        public string HastaTelefon { get => hastaTelefon; set => hastaTelefon = value; }
        public string HastaSifre { get => hastaSifre; set => hastaSifre = value; }
        public string HastaCinsiyet { get => hastaCinsiyet; set => hastaCinsiyet = value; }

    }
}
