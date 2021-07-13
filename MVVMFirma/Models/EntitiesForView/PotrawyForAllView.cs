using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PotrawyForAllView
    {
        public int IdPotrawy { get; set; }
        public String Nazwa { get; set; }
        public String RodzajPotrawyNazwa { get; set; }
        public decimal? Cena { get; set; }
        public String Sklad { get; set; }
        public String Opis { get; set; }
    }
}
