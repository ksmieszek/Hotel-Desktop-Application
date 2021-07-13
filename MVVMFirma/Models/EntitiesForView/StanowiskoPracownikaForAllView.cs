using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class StanowiskoPracownikaForAllView
    {
        public string PracownikNazwa { get; set; }
        public string PracownikImie { get; set; }
        public string PracownikNazwisko { get; set; }
        public string PracownikLogin { get; set; }
        public string PracownikPESEL { get; set; }
        public string PracownikMiasto { get; set; }
        public string PracownikKodPocztowy { get; set; }
        public string PracownikUlica { get; set; }
        public string PracownikNumerBudynku { get; set; }
        public string PracownikNumerLokalu { get; set; }
        public DateTime? DataOd { get; set; }
        public DateTime? DataDo { get; set; }
        public string StanowiskoNazwa { get; set; }
        public string PracownikTelefon { get; set; }
    }
}
