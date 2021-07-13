using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class NapojForAllView
    {
        public int IdNapoju { get; set; }
        public String Nazwa { get; set; }
        public String RodzajNapojuNazwa { get; set; }
        public decimal? Cena { get; set; }
        public String Sklad { get; set; }
        public String Opis { get; set; }
    }
}
