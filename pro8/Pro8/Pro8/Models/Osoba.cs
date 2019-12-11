using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Osoba
    {
        public int IdOsoba { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual Dostawca Dostawca { get; set; }
        public virtual Klient Klient { get; set; }
    }
}
