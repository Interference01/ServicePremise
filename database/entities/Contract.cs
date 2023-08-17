using System.ComponentModel.DataAnnotations;

namespace ServicePremise.database.entities
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PremiseId { get; set; }
        public Premise Premise { get; set; }

        [Required]
        public Guid TypeEquipmentId { get; set; }
        public TypeEquipment TypeEquipment { get; set; }
        
        [Required]
        public int EquipmentUnitsCount { get; set; }
    }
}
