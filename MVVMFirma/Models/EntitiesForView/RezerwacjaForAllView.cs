using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RezerwacjaForAllView
    {
        public int IdRezerwacji { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public decimal? Netto { get; set; }
        public decimal? Brutto { get; set; }
        public double? VAT { get; set; }
        public double? Rabat { get; set; }
        public int? NumerPokoju { get; set; }
        public int? Pietro { get; set; }
        public string Wyposazenie { get; set; }
        public string AdresPokoju { get; set; }
        public string TypPokoju { get; set; }
    }
}
