using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KlientForAllView
    {
        public int IdKlienta { get; set; }
        public String Imie { get; set; }
        public String DrugieImie { get; set; }
        public String Nazwisko { get; set; }
        public String Nazwa { get; set; }
        public String Telefon { get; set; }
        public String E_mail { get; set; }
        public String PESEL { get; set; }
        public String Plec { get; set; }
        public String Firma { get; set; }
        public String NIP { get; set; }
        public String REGON { get; set; }
        public String RodzajKlientaNazwa { get; set; }
        public string AdresMiasto { get; set; }
        public string AdresUlica { get; set; }
        public string AdresNrDomu { get; set; }
        public string AdresNrLokalu { get; set; }
        public string AdresKodPocztowy { get; set; }
    }
}
