using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityRandevular
    {
        private int randevuid;
        private string randevuTarih;
        private string randevuSaat;
        private string randevuBrans;
        private string randevuDoktor;
        private bool randevuDurum;
        private string hastaTC;
        private string hastaSikayet;

        public int Randevuid { get => randevuid; set => randevuid = value; }
        public string RandevuTarih { get => randevuTarih; set => randevuTarih = value; }
        public string RandevuSaat { get => randevuSaat; set => randevuSaat = value; }
        public string RandevuBrans { get => randevuBrans; set => randevuBrans = value; }
        public string RandevuDoktor { get => randevuDoktor; set => randevuDoktor = value; }
        public bool RandevuDurum { get => randevuDurum; set => randevuDurum = value; }
        public string HastaTC { get => hastaTC; set => hastaTC = value; }
        public string HastaSikayet { get => hastaSikayet; set => hastaSikayet = value; }
    }
}
