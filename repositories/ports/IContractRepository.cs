using ServicePremise.database.entities;

namespace ServicePremise.repositories.ports
{
    public interface IContractRepository
    {
        public void CreateContract(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount);
    }
}
