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
    
    public partial class Potrawy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Potrawy()
        {
            this.Posilki = new HashSet<Posilki>();
        }
    
        public int IdPotrawy { get; set; }
        public string Sklad { get; set; }
        public Nullable<decimal> Cena { get; set; }
        public Nullable<int> IdRodzajuPotrawy { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posilki> Posilki { get; set; }
        public virtual RodzajePotraw RodzajePotraw { get; set; }
    }
}