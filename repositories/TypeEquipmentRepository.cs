using ServicePremise.database;
using ServicePremise.database.entities;
using ServicePremise.repositories.ports;

namespace ServicePremise.repositories
{
    public class TypeEquipmentRepository : ITypeEquipmentRepository
    {
        private readonly ServiceDbContext dbContext;

        public TypeEquipmentRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TypeEquipment> GetByIdAsync(Guid id)
        {
            return await dbContext.TypesEquipment.FindAsync(id);
        }
    }
}
