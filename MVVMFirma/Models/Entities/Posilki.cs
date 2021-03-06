//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posilki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posilki()
        {
            this.Uslugi = new HashSet<Uslugi>();
        }
    
        public int IdPosilku { get; set; }
        public Nullable<int> IdPotrawy { get; set; }
        public Nullable<int> IdNapoju { get; set; }
        public Nullable<int> IloscPotrawy { get; set; }
        public Nullable<int> IloscNapoju { get; set; }
        public string Opis { get; set; }
        public string Nazwa { get; set; }
        public Nullable<System.DateTime> DataZamowienia { get; set; }
        public Nullable<decimal> Netto { get; set; }
        public Nullable<double> Rabat { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<decimal> Brutto { get; set; }
    
        public virtual Napoje Napoje { get; set; }
        public virtual Potrawy Potrawy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi> Uslugi { get; set; }
    }
}
