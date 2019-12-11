using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class SzczegolyZamowienia
    {
        public int Ilosc { get; set; }
        public int IdZamownie { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamownieNavigation { get; set; }
    }
}
