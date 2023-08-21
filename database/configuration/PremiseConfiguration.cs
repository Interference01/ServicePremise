using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicePremise.database.entities;

namespace ServicePremise.database.configuration
{
    public class PremiseConfiguration : IEntityTypeConfiguration<Premise>
    {
        public void Configure(EntityTypeBuilder<Premise> builder)
        {
            builder.ToTable("Premises");

            builder.HasData
                (
                new Premise
                {
                    Id = Guid.NewGuid(),
                    Code = "#4124",
                    Name = "Київ. Курортна 25",
                    EquipmentArea = 6.00M
                },
                new Premise
                {
                    Id = Guid.NewGuid(),
                    Code = "#4125",
                    Name = "Львів. Юнкерова 86г",
                    EquipmentArea = 10.00M
                },
                new Premise
                {
                    Id = Guid.NewGuid(),
                    Code = "#4126",
                    Name = "Житомир. Жашківська 33/2",
                    EquipmentArea = 20.00M
                });
        }
    }
}
