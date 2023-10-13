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
        private char sekreterTC;
       
        public string SekreterAdSoyad { get => sekreterAdSoyad; set => sekreterAdSoyad = value; }
        public char SekreterTC { get => sekreterTC; set => sekreterTC = value; }    
    }
}
