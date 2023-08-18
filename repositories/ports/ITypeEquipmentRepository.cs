using ServicePremise.database.entities;

namespace ServicePremise.repositories.ports
{
    public interface ITypeEquipmentRepository
    {
        public Task<TypeEquipment> GetByIdAsync(Guid id);
    }
}
