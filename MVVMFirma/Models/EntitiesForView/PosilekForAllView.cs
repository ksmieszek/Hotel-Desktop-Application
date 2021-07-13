using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PosilekForAllView
    {
        public int IdPosilku { get; set; }
        public string PotrawaNazwa { get; set; }
        public string NapojNazwa { get; set; }
        public int? IloscPotrawy { get; set; }
        public int? IloscNapoju { get; set; }
        public DateTime? DataZamowienia { get; set; }
        public decimal? Netto { get; set; }
        public double? VAT { get; set; }
        public double? Rabat { get; set; }
        public decimal? Brutto { get; set; }

    }
}
