using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    internal class EntitySekreter
    {
        private byte sekreterid;
        private string sekreterAdSoyad;
        private char sekreterTC;
        private string sekreterSifre;

        public byte Sekreterid { get => sekreterid; set => sekreterid = value; }
        public string SekreterAdSoyad { get => sekreterAdSoyad; set => sekreterAdSoyad = value; }
        public char SekreterTC { get => sekreterTC; set => sekreterTC = value; }
        public string SekreterSifre { get => sekreterSifre; set => sekreterSifre = value; }
    }
}
