using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjaFakturyForAllView
    {
        public string FakturaNumer { get; set; }
        public string UslugaKod { get; set; }
        public string UslugaNazwa { get; set; }
        public decimal? UslugaRezerwacjaCena { get; set; }
        public decimal? UslugaPosilekCena { get; set; }
        public int? Ilosc { get; set; }
        public decimal? Rabat { get; set; }
        public decimal? Cena { get; set; }
    }
}
