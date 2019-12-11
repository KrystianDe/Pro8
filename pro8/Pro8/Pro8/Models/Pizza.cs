using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Przepis = new HashSet<Przepis>();
            SzczegolyZamowienia = new HashSet<SzczegolyZamowienia>();
        }

        public int IdPizza { get; set; }
        public string NazwaPizzy { get; set; }

        public virtual ICollection<Przepis> Przepis { get; set; }
        public virtual ICollection<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
    }
}
