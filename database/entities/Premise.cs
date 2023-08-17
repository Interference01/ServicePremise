using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicePremise.database.entities
{
    public class Premise
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal EquipmentArea { get; set; }

    }
}
