namespace ServicePremise.models
{
    public class ContractDTO
    {
        public Guid PremiseId { get; set; }

        public Guid TypeEquipmentId { get; set; }

        public int EquipmentUnitsCount { get; set; }
    }
}
