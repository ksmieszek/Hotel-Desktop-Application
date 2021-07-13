using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        public int IdFaktury { get; set; }
        public String Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string KlientNazwa { get; set; }
        public string KlientTelefon { get; set; }
        public string KlientFirma{ get; set; }
        public string KlientRodzaj { get; set; }
        public string KlientMiasto { get; set; }
        public string KlientNIP { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        public string SposobPlatnosciNazwa { get; set; }
        public decimal? DoZaplaty { get; set; }
        public decimal? Zaplacono { get; set; }
        public DateTime? DataSprzedazy { get; set; }

    }
}
