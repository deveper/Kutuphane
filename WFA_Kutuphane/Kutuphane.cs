using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_Kutuphane
{
    class Kutuphane
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string YayinEvi { get; set; }
        public string BaskiSayi { get; set; } 
        public string SayfaSayi { get; set; }
        public DateTime BasimYili { get; set; }
        public int IsbnNo { get; set; }
    }
}
