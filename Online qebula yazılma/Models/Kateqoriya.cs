//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_qebula_yazılma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kateqoriya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kateqoriya()
        {
            this.Qebuls = new HashSet<Qebul>();
        }
    
        public int kateqoriya_id { get; set; }
        public string kateqoriya_adi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qebul> Qebuls { get; set; }
    }
}
