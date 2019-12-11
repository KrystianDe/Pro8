using System;
using System.Collections.Generic;

namespace Pro8.Models
{
    public partial class ZamowienieDostawca
    {
        public int DostawcaIdDostawca { get; set; }
        public int ZamowienieIdZamownie { get; set; }

        public virtual Dostawca DostawcaIdDostawcaNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamownieNavigation { get; set; }
    }
}
