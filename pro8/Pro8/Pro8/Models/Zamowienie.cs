using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ZamowienieDostawca = new HashSet<ZamowienieDostawca>();
        }

        public int IdZamownie { get; set; }
        public DateTime DataZamowienia { get; set; }
        public int IdAdres { get; set; }
        public string Platnosc { get; set; }
        public decimal CenaZamowienia { get; set; }
        public int IdPromcja { get; set; }
        public int IdKlient { get; set; }
        public int IdLokal { get; set; }

        public virtual Adres IdAdresNavigation { get; set; }
        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Lokal IdLokalNavigation { get; set; }
        public virtual Promcja IdPromcjaNavigation { get; set; }
        public virtual SzczegolyZamowienia SzczegolyZamowienia { get; set; }
        public virtual ICollection<ZamowienieDostawca> ZamowienieDostawca { get; set; }
    }
}
