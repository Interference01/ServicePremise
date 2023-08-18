namespace ServicePremise.models
{
    public class ContractPostDTO
    {
        public Guid PremiseId { get; set; }

        public Guid TypeEquipmentId { get; set; }

        public int EquipmentUnitsCount { get; set; }
    }
}
