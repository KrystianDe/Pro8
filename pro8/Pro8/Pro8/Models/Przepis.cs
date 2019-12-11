using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Przepis
    {
        public int IdPrzepis { get; set; }
        public int Ilosc { get; set; }
        public int IdSkladnik { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
    }
}
