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
    
    public partial class tblPersonel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPersonel()
        {
            this.tblFaturaBilgi = new HashSet<tblFaturaBilgi>();
            this.tblUrunHareket = new HashSet<tblUrunHareket>();
            this.tblUrunKabul = new HashSet<tblUrunKabul>();
        }
    
        public short Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<byte> Departman { get; set; }
        public string Fotoğraf { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
    
        public virtual tblDepartman tblDepartman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFaturaBilgi> tblFaturaBilgi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUrunHareket> tblUrunHareket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUrunKabul> tblUrunKabul { get; set; }
    }
}
