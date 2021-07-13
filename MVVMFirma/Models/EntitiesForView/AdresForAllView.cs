using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class AdresForAllView
    {
        public int IdAdresu { get; set; }
        public String Kraj { get; set; }
        public String Wojewodztwo { get; set; }
        public String Miasto { get; set; }
        public String KodPocztowy { get; set; }
        public String Ulica { get; set; }
        public String NumerBudynku { get; set; }
        public String NumerLokalu { get; set; }
        public String Fax { get; set; }
    }
}
