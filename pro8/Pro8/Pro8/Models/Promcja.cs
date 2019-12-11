using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Promcja
    {
        public Promcja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromcja { get; set; }
        public string KodPromocji { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
