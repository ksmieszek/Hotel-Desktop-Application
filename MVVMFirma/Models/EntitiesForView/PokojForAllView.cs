using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PokojForAllView
    {
        public int IdPokoju { get; set; }
        public int? NumerPokoju { get; set; }
        public int? Pietro { get; set; }
        public string Nazwa { get; set; }
        public string Wysposazenie { get; set; }
        public string Rodzaj { get; set; }
        public string StatusPokoju { get; set; }
        public string AdresPokoju { get; set; }
        public double? Cena { get; set; }
    }
}
