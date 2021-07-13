using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class UslugaForAllView
    {
        public int IdUslugi { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public decimal? StawkaVat { get; set; }
        public decimal? CenaNetto { get; set; }
        public decimal? CenaBrutto { get; set; }
        public int? NumerPokoju { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public DateTime? DataZamowienia { get; set; }
        public string Potrawa { get; set; }
        public string Napoj { get; set; }
    }
}
