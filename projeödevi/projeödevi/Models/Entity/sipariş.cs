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
    
    public partial class sipariş
    {
        public int id { get; set; }
        public string siparisno { get; set; }
        public string toplamtutar { get; set; }
        public string sipariştarihi { get; set; }
        public string kullaniciadi { get; set; }
        public string adres { get; set; }
        public string sehir { get; set; }
        public string semt { get; set; }
        public string mahalle { get; set; }
        public string postakodu { get; set; }
        public object Siparişlerims { get; internal set; }
    }
}
