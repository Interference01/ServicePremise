using ServicePremise.database.entities;

namespace ServicePremise.repositories.ports
{
    public interface IPremiseRepository
    {
        public Task<Premise> GetByIdAsync(Guid id);
    }
}
