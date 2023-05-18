using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleData.Data.Account;
using PrzedszkoleData.Data.CMS;
using PrzedszkoleData.Data.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace PrzedszkoleData.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DzieckoZajeciaDodatkowe>()
            .HasKey(dz => new { dz.DzieckoId, dz.ZajeciaDodatkoweId });

            modelBuilder.Entity<DzieckoZajeciaDodatkowe>()
                .HasOne(dz => dz.Dziecko)
                .WithMany(d => d.ZajeciaDodatkowe)
                .HasForeignKey(dz => dz.DzieckoId);

            modelBuilder.Entity<DzieckoZajeciaDodatkowe>()
                .HasOne(dz => dz.ZajeciaDodatkowe)
                .WithMany()
                .HasForeignKey(dz => dz.ZajeciaDodatkoweId);

        }

        public DbSet<Kontakt>? Kontakt { get; set; }
        public DbSet<GodzinyOtwarcia>? GodzinyOtwarcia { get; set; }
        public DbSet<Informacje>? Informacje { get; set; }
        public DbSet<Adres>? Adres { get; set; }
        public DbSet<HarmonogramDzienny>? HarmonogramDzienny { get; set; }
        public DbSet<Menu>? Menu { get; set; }
        public DbSet<ZajeciaDodatkowe>? ZajeciaDodatkowe { get; set; }
        public DbSet<ZajeciaPodstawowe>? ZajeciaPodstawowe { get; set; }
        public DbSet<Cennik>? Cennik { get; set; }
        public DbSet<Personel>? Personel { get; set; }
        public DbSet<ONas>? ONas { get; set; }
        public DbSet<Grupa>? Grupa { get; set; }
        public DbSet<Dziecko>? Dziecko { get; set; }
        public DbSet<Nazwa>? Nazwa { get; set; }
        public DbSet<Stopka>? Stopka { get; set; }
        public DbSet<Opis>? Opis { get; set; }
        public DbSet<Obecnosc>? Obecnosc { get; set; }
        public DbSet<Parametr>? Parametr { get; set; }
        public DbSet<DzieckoZajeciaDodatkowe> DzieckoZajeciaDodatkowe { get; set; }
        public DbSet<Naleznosci> Naleznosci { get; set; }

    }
}