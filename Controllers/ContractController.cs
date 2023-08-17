using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetContractList()
        {
            var contracts = await contractRepository.GetAllAsync();

            var contractsDTO = contracts.Select(x => new ContractGetDTO()
            {
                PremiseName = x.Premise.Name,
                TypeEquipmentName = x.TypeEquipment.Name,
                EquipmentUnitsCount = x.EquipmentUnitsCount,
            }).ToList();

            return Ok(contractsDTO);
        }


        [HttpGet("searchById")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await contractRepository.FindContract(id);

            var contractDTO = new ContractGetDTO()
            {
                PremiseName = contract.Premise.Name,
                TypeEquipmentName = contract.TypeEquipment.Name,
                EquipmentUnitsCount = contract.EquipmentUnitsCount,
            };

            return Ok(contractDTO);
        }


        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractPostDTO contractDTO)
        {
            var premise = await premiseRepository.GetByIdAsync(contractDTO.PremiseId);
            var typeEquipment = await equipmentRepository.GetByIdAsync(contractDTO.TypeEquipmentId);


            if (premise == null || typeEquipment == null)
                return NotFound("Premise or equipment not found, please check ID");


            contractRepository.CreateContract(premise, typeEquipment, contractDTO.EquipmentUnitsCount);

            return Ok();
        }
    }
}
