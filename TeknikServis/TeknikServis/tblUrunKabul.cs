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
    
    public partial class tblUrunKabul
    {
        public int IslemId { get; set; }
        public Nullable<int> Cari { get; set; }
        public Nullable<short> Personel { get; set; }
        public Nullable<System.DateTime> GelisTarihi { get; set; }
        public Nullable<System.DateTime> CikisTarihi { get; set; }
        public string ÜrünSeriNo { get; set; }
        public Nullable<bool> ÜrünDurum { get; set; }
        public string ÜrünDurumDetay { get; set; }
    
        public virtual tblCari tblCari { get; set; }
        public virtual tblPersonel tblPersonel { get; set; }
    }
}
