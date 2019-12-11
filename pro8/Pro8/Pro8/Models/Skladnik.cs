using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Przepis = new HashSet<Przepis>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<Przepis> Przepis { get; set; }
    }
}
