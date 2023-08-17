using Microsoft.EntityFrameworkCore;
using ServicePremise.database.entities;

namespace ServicePremise.database
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Premise> Premises { get; set; }
        public DbSet<TypeEquipment> TypesEquipment { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-29T6DCB\SQLEXPRESS;Database=ServiceDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
