namespace ServicePremise.models
{
    public class ContractGetDTO
    {
        public Guid ContractId { get; set; }

        public string PremiseName { get; set; }

        public string TypeEquipmentName { get; set; }

        public int EquipmentUnitsCount { get; set; }

    }
}
