using ServicePremise.database.entities;

namespace ServicePremise.repositories.ports
{
    public interface IContractRepository
    {
        public Task<List<Contract>> GetAllAsync();

        public Task<List<Contract>> FindContractsByPremise(Guid Id);

        public Contract CreateContract(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount);

        public Task<bool> ValidateArea(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount);
    }
}
