using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_backend.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
        }

        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Melding> Meldingen { get; set; }
        public DbSet<Plaats> Plaatsen { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Persoon>().ToTable("Persoon");
            modelBuilder.Entity<Melding>().ToTable("Melding");
            modelBuilder.Entity<Plaats>().ToTable("Plaats");
            modelBuilder.Entity<Type>().ToTable("Type");

        }
    }
}
