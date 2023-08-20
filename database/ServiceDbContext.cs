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
            optionsBuilder.UseSqlServer(@"Server=tcp:server-valentain.database.windows.net,1433;Initial Catalog=ServiceDB;Persist Security Info=False;User ID=val;Password=7306310s!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
