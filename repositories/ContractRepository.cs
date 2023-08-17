using ServicePremise.database;
using ServicePremise.database.entities;
using ServicePremise.repositories.ports;

namespace ServicePremise.repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ServiceDbContext dbContext;

        public ContractRepository(ServiceDbContext dbContext)
        {
                this.dbContext = dbContext;
        }


        public void CreateContract(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount)
        {
            Contract contract = new Contract()
            {
                Id = Guid.NewGuid(),
                Premise = premise,
                TypeEquipment = typeEquipment,
                EquipmentUnitsCount = EquipmentUnitsCount, // додати перевірку на нуль та мінус.
            };

            dbContext.Contracts.AddAsync(contract);
            dbContext.SaveChangesAsync();
        }
    }
}
