using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeödevi.Models.Entity
{
    public class Cart
    {
        private List<Cartline> _cartLines = new List<Cartline>();
        public List<Cartline> Cartlines
        {
            get { return _cartLines; }
        }
        public void EkleÜrün(ürünler ürünler,int adet)
        {
            var line = _cartLines.FirstOrDefault(i => i.Ürünler.ürünid == ürünler.ürünid);
            if (line==null)
            {
                _cartLines.Add(new Cartline() { Ürünler = ürünler, adet = adet });
            }
            else
            {
                line.adet += adet;

            }
        }
        public void DeleteÜrün(ürünler ürünler)
        {
            _cartLines.RemoveAll(i => i.Ürünler.ürünid == ürünler.ürünid);
        }

        public double Total()
        {
            return (double)_cartLines.Sum(i => i.Ürünler.fiyat * i.adet);
        }
        
        public void temizle()
        {
            _cartLines.Clear();
        }
    }
    public class Cartline

    {
        public ürünler Ürünler { get; set; }
        public int adet { get; set; }
    }
}