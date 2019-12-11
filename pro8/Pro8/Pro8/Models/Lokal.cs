using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Lokal
    {
        public Lokal()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdLokal { get; set; }
        public string NumerTelefonu { get; set; }
        public string Nazwa { get; set; }
        public int IdAdres { get; set; }

        public virtual Adres IdAdresNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
