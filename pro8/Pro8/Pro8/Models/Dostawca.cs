using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            ZamowienieDostawca = new HashSet<ZamowienieDostawca>();
        }

        public int IdDostawca { get; set; }
        public DateTime DataZatrudnienia { get; set; }

        public virtual Osoba IdDostawcaNavigation { get; set; }
        public virtual ICollection<ZamowienieDostawca> ZamowienieDostawca { get; set; }
    }
}
