using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Adres
    {
        public Adres()
        {
            Lokal = new HashSet<Lokal>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdAdres { get; set; }
        public string Miasto { get; set; }
        public int NrDomu { get; set; }
        public string Ulica { get; set; }
        public int NrMieszkania { get; set; }

        public virtual ICollection<Lokal> Lokal { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
