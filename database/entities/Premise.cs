namespace ServicePremise.database.entities
{
    public class Premise
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal EquipmentArea { get; set; }

    }
}
