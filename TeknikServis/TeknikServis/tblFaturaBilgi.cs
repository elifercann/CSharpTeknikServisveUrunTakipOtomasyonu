//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFaturaBilgi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFaturaBilgi()
        {
            this.tblFaturaDetay = new HashSet<tblFaturaDetay>();
        }
    
        public int Id { get; set; }
        public string Seri { get; set; }
        public string SiraNo { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Saat { get; set; }
        public string VergiDaire { get; set; }
        public Nullable<int> Cari { get; set; }
        public Nullable<short> Personel { get; set; }
    
        public virtual tblCari tblCari { get; set; }
        public virtual tblPersonel tblPersonel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFaturaDetay> tblFaturaDetay { get; set; }
    }
}