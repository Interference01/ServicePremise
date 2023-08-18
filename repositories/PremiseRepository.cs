using ServicePremise.database;
using ServicePremise.database.entities;
using ServicePremise.repositories.ports;

namespace ServicePremise.repositories
{
    public class PremiseRepository : IPremiseRepository
    {
        private readonly ServiceDbContext dbContext;

        public PremiseRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Premise> GetByIdAsync(Guid id)
        {
            return await dbContext.Premises.FindAsync(id);
        }
    }
}
