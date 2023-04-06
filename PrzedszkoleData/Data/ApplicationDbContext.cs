using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleData.Data.Account;
using PrzedszkoleData.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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

    }
}