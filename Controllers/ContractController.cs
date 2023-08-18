using Microsoft.AspNetCore.Mvc;
using ServicePremise.models;
using ServicePremise.repositories.ports;

namespace ServicePremise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : Controller
    {
        private readonly IPremiseRepository premiseRepository;
        private readonly ITypeEquipmentRepository equipmentRepository;
        private IContractRepository contractRepository;

        public ContractController(IPremiseRepository premiseRepository, ITypeEquipmentRepository equipmentRepository, IContractRepository contractRepository)
        {
            this.premiseRepository = premiseRepository;
            this.equipmentRepository = equipmentRepository;
            this.contractRepository = contractRepository;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await contractRepository.GetAllAsync();

            var contractsDTO = contracts.Select(x => new ContractGetDTO()
            {
                ContractId = x.Id,
                PremiseName = x.Premise.Name,
                TypeEquipmentName = x.TypeEquipment.Name,
                EquipmentUnitsCount = x.EquipmentUnitsCount,
            }).ToList();

            return Ok(contractsDTO);
        }


        [HttpGet("searchById")]
        public async Task<IActionResult> GetContractsByPremise(Guid PremiseId)
        {
            var contracts = await contractRepository.FindContractsByPremise(PremiseId);


            if (contracts.Count == 0)
                return NotFound("Empty or check id");


            var contractDTO = contracts.Select(x => new ContractGetDTO()
            {
                ContractId = x.Id,
                PremiseName = x.Premise.Name,
                TypeEquipmentName = x.TypeEquipment.Name,
                EquipmentUnitsCount = x.EquipmentUnitsCount,
            }).ToList();

            return Ok(contractDTO);
        }


        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractPostDTO contractDTO)
        {
            var premise = await premiseRepository.GetByIdAsync(contractDTO.PremiseId);
            var typeEquipment = await equipmentRepository.GetByIdAsync(contractDTO.TypeEquipmentId);


            if (premise == null || typeEquipment == null || contractDTO.EquipmentUnitsCount <= 0) // де повинна бути перевірка на ноль та мінусове число? 
                return NotFound("The entered data is not valid");

            if (! await contractRepository.ValidateArea(premise, typeEquipment))
                return BadRequest("The contract cannot be created because there is not enough space");


            var contract = contractRepository.CreateContract(premise, typeEquipment, contractDTO.EquipmentUnitsCount);

            return CreatedAtAction("GetContractsByPremise", new { contract.Id }, contract);
        }
    }
}
