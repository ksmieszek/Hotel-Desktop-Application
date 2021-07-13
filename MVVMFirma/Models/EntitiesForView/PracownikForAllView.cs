using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PracownikForAllView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        public string Login { get; set; }
        public string PESEL { get; set; }
        public string Telefon { get; set; }
        public string AdresPracownikaMiasto { get; set; }
        public string AdresPracownikaKodPocztowy { get; set; }
        public string AdresPracownikaUlica { get; set; }
        public string AdresPracownikaNumerBudynku { get; set; }
        public string AdresPracownikaNumerLokalu { get; set; }
        public string StanowiskoPracownika { get; set; }
    }
}
