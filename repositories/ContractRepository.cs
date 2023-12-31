﻿using Microsoft.EntityFrameworkCore;
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


        public async Task<List<Contract>> GetAllAsync()
        {
            var contrats = await dbContext.Contracts
                .Include(x => x.Premise)
                .Include(x => x.TypeEquipment)
                .ToListAsync();

            return contrats;
        }

        public async Task<List<Contract>> FindContractsByPremise(Guid id) 
        {
            return await dbContext.Contracts
                .Include(x => x.Premise)
                .Include(x => x.TypeEquipment)
                .Where(x => x.Premise.Id == id).ToListAsync();
        }

        public Contract CreateContract(Premise premise, TypeEquipment typeEquipment, int EquipmentUnitsCount)
        {
            Contract contract = new Contract()
            {
                Id = Guid.NewGuid(),
                Premise = premise,
                TypeEquipment = typeEquipment,
                EquipmentUnitsCount = EquipmentUnitsCount,
            };

            dbContext.Contracts.AddAsync(contract);
            dbContext.SaveChangesAsync();

            return contract;
        }

        public async Task<bool> ValidateArea(Premise premise, TypeEquipment typeEquipment, int equipmentUnitsCount)
        {
            var actuallyContracts = await FindContractsByPremise(premise.Id);
            decimal occupiedArea = actuallyContracts.Sum(x => x.TypeEquipment.Area * x.EquipmentUnitsCount);

            decimal freeAreaPremise = premise.EquipmentArea - occupiedArea;

            decimal inputSumArea = typeEquipment.Area * equipmentUnitsCount;

            return freeAreaPremise >= inputSumArea;
        }
    }
}
