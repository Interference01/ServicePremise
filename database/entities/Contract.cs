using System.ComponentModel.DataAnnotations;

namespace ServicePremise.database.entities
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Premise Premise { get; set; }

        [Required]
        public TypeEquipment TypeEquipment { get; set; }
        
        [Required]
        public int EquipmentUnitsCount { get; set; }
    }
}
