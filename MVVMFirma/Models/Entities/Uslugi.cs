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
    
    public partial class Uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uslugi()
        {
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
        }
    
        public int IdUslugi { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public Nullable<int> IdPosilku { get; set; }
        public Nullable<int> IdRezerwacji { get; set; }
    
        public virtual Posilki Posilki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
        public virtual Rezerwacje Rezerwacje { get; set; }
    }
}