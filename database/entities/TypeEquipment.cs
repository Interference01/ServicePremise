using System.ComponentModel.DataAnnotations;

namespace ServicePremise.database.entities
{
    public class TypeEquipment
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Area { get; set; }
    }
}
