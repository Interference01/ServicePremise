using Microsoft.EntityFrameworkCore;
using ServicePremise.database.entities;

namespace ServicePremise.database
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
        : base(options)
        {
        }

        public DbSet<Premise> Premises { get; set; }
        public DbSet<TypeEquipment> TypesEquipment { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
