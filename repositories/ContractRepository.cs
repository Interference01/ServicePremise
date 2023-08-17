using Microsoft.EntityFrameworkCore;
using ServicePremise.database;
using ServicePremise.database.entities;
using ServicePremise.models;
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


        public async Task<List<Contract>> GetAllAsync()
        {
            var contrats = await dbContext.Contracts
                .Include(x => x.Premise)
                .Include(x => x.TypeEquipment)
                .ToListAsync();

            return contrats;
        }

        public async Task<Contract> FindContract(Guid id)
        {
            return await dbContext.Contracts
                .Include(x => x.Premise)
                .Include(x => x.TypeEquipment)
                .FirstAsync(x => x.Id == id);
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
