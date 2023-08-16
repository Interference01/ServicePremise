namespace ServicePremise.database.entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Premise Premise { get; set; }
        public TypeEquipment TypeEquipment { get; set; }
        public int QuantityEquipment { get; set; }
    }
}
