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

        public ContractController(IPremiseRepository premiseRepository, ITypeEquipmentRepository typeEquipment, IContractRepository contractRepository)
        {
            this.premiseRepository = premiseRepository;
            this.equipmentRepository = typeEquipment;
            this.contractRepository = contractRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractDTO contractDTO)
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
