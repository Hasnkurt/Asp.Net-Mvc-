//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projeödevi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class sepet
    {
        public int id { get; set; }
        public Nullable<int> ürünid { get; set; }
        public string adet { get; set; }
        public string fiyat { get; set; }
        public string resim { get; set; }
        public Nullable<int> kullaniciid { get; set; }
    }
}
