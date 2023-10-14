using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntitySekreter
    {       
        private string sekreterAdSoyad;
        private string sekreterTC;
        private string sekreterSifre;
       
        public string SekreterAdSoyad { get => sekreterAdSoyad; set => sekreterAdSoyad = value; }
        public string SekreterTC { get => sekreterTC; set => sekreterTC = value; }
        public string SekreterSifre { get => sekreterSifre; set => sekreterSifre = value; }
    }
}
