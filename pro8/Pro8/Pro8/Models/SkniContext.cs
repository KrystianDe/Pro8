using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pro8.Models
{
    public partial class SkniContext : DbContext
    {
        public SkniContext()
        {
        }

        public SkniContext(DbContextOptions<SkniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Lokal> Lokal { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Promcja> Promcja { get; set; }
        public virtual DbSet<Przepis> Przepis { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieDostawca> ZamowienieDostawca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H9ITIFG\\SQLEXPRESS;Initial Catalog=Skni;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("id_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Passoword)
                    .IsRequired()
                    .HasColumnName("passoword")
                    .HasMaxLength(34)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.IdAdres)
                    .HasName("Adres_pk");

                entity.Property(e => e.IdAdres)
                    .HasColumnName("id_Adres")
                    .ValueGeneratedNever();

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu).HasColumnName("Nr_Domu");

                entity.Property(e => e.NrMieszkania).HasColumnName("Nr_mieszkania");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawca)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.IdDostawca)
                    .HasColumnName("id_Dostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("data_zatrudnienia")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdDostawcaNavigation)
                    .WithOne(p => p.Dostawca)
                    .HasForeignKey<Dostawca>(d => d.IdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dostawca_Osoba");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient)
                    .HasColumnName("id_Klient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .IsRequired()
                    .HasColumnName("numer_telefonu")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithOne(p => p.Klient)
                    .HasForeignKey<Klient>(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Klient_Osoba");
            });

            modelBuilder.Entity<Lokal>(entity =>
            {
                entity.HasKey(e => e.IdLokal)
                    .HasName("Lokal_pk");

                entity.Property(e => e.IdLokal)
                    .HasColumnName("Id_Lokal")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAdres).HasColumnName("id_Adres");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .IsRequired()
                    .HasColumnName("numer_telefonu")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdresNavigation)
                    .WithMany(p => p.Lokal)
                    .HasForeignKey(d => d.IdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lokal_Adres");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Osoba_pk");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("id_Pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaPizzy)
                    .IsRequired()
                    .HasColumnName("nazwa_Pizzy")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Promcja>(entity =>
            {
                entity.HasKey(e => e.IdPromcja)
                    .HasName("Promcja_pk");

                entity.Property(e => e.IdPromcja)
                    .HasColumnName("id_Promcja")
                    .ValueGeneratedNever();

                entity.Property(e => e.KodPromocji)
                    .IsRequired()
                    .HasColumnName("kod_Promocji")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Przepis>(entity =>
            {
                entity.HasKey(e => e.IdPrzepis)
                    .HasName("Przepis_pk");

                entity.Property(e => e.IdPrzepis)
                    .HasColumnName("idPrzepis")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPizza).HasColumnName("id_Pizza");

                entity.Property(e => e.IdSkladnik).HasColumnName("idSkladnik");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Przepis)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przepis_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.Przepis)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przepis_Skladnik");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SzczegolyZamowienia>(entity =>
            {
                entity.HasKey(e => e.IdZamownie)
                    .HasName("Szczegoly_zamowienia_pk");

                entity.ToTable("Szczegoly_zamowienia");

                entity.Property(e => e.IdZamownie)
                    .HasColumnName("id_Zamownie")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPizza).HasColumnName("id_Pizza");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.SzczegolyZamowienia)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Szczegoly_zamowienia_Pizza");

                entity.HasOne(d => d.IdZamownieNavigation)
                    .WithOne(p => p.SzczegolyZamowienia)
                    .HasForeignKey<SzczegolyZamowienia>(d => d.IdZamownie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Szczegoly_zamowienia_Zamowienie");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamownie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamownie)
                    .HasColumnName("id_Zamownie")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaZamowienia)
                    .HasColumnName("cena_zamowienia")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("data_zamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAdres).HasColumnName("id_Adres");

                entity.Property(e => e.IdKlient).HasColumnName("id_Klient");

                entity.Property(e => e.IdLokal).HasColumnName("Id_Lokal");

                entity.Property(e => e.IdPromcja).HasColumnName("id_Promcja");

                entity.Property(e => e.Platnosc)
                    .IsRequired()
                    .HasColumnName("platnosc")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdresNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Adres");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.IdLokalNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdLokal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Lokal");

                entity.HasOne(d => d.IdPromcjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromcja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promcja");
            });

            modelBuilder.Entity<ZamowienieDostawca>(entity =>
            {
                entity.HasKey(e => new { e.DostawcaIdDostawca, e.ZamowienieIdZamownie })
                    .HasName("Zamowienie_dostawca_pk");

                entity.ToTable("Zamowienie_dostawca");

                entity.Property(e => e.DostawcaIdDostawca).HasColumnName("Dostawca_id_Dostawca");

                entity.Property(e => e.ZamowienieIdZamownie).HasColumnName("Zamowienie_id_Zamownie");

                entity.HasOne(d => d.DostawcaIdDostawcaNavigation)
                    .WithMany(p => p.ZamowienieDostawca)
                    .HasForeignKey(d => d.DostawcaIdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_15_Dostawca");

                entity.HasOne(d => d.ZamowienieIdZamownieNavigation)
                    .WithMany(p => p.ZamowienieDostawca)
                    .HasForeignKey(d => d.ZamowienieIdZamownie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_15_Zamowienie");
            });
        }
    }
}
