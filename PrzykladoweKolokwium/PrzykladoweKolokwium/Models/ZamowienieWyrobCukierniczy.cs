using System;
using System.Collections.Generic;

namespace PrzykladoweKolokwium.Model
{
    public partial class ZamowienieWyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public string Uwagi { get; set; }
        public int Ilosc { get; set; }

        public virtual WyrobCokierniczy IdWyrobuCukierniczegoNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}
