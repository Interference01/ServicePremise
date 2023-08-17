using ServicePremise.database.entities;

namespace ServicePremise.repositories.ports
{
    public interface IContractRepository
    {
        public Task<List<Contract>> GetAllAsync();

        public Task<Contract> FindContract(Guid Id);

        public void CreateContract(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount);
    }
}
