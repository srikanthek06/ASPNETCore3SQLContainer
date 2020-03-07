using HealthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Data
{
    public class HealthContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ailment>().Property(p => p.Name).HasMaxLength(40);
            modelBuilder.Entity<Medication>().Property(p => p.Name).HasMaxLength(40);
            modelBuilder.Entity<Patient>().Property(p => p.Name).HasMaxLength(40);

            modelBuilder.Entity<Ailment>().ToTable("Ailment");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<Patient>().ToTable("Patient");
        }

        public HealthContext(DbContextOptions options) : base(options) { }
        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}