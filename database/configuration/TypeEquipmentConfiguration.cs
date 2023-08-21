using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicePremise.database.entities;

namespace ServicePremise.database.configuration
{
    public class TypeEquipmentConfiguration : IEntityTypeConfiguration<TypeEquipment>
    {
        public void Configure(EntityTypeBuilder<TypeEquipment> builder)
        {
            builder.ToTable("TypesEquipment");

            builder.HasData
                (
                new TypeEquipment
                {
                    Id = Guid.NewGuid(),
                    Code = "#1421",
                    Name = "Шиномонтажне обладнання",
                    Area = 4.50M
                },
                new TypeEquipment
                {
                    Id = Guid.NewGuid(),
                    Code = "#1422",
                    Name = "Токарне обладнання",
                    Area = 15.00M
                },
                new TypeEquipment
                {
                    Id = Guid.NewGuid(),
                    Code = "#1423",
                    Name = "Швейні станки",
                    Area = 8.00M
                },
                new TypeEquipment
                {
                    Id = Guid.NewGuid(),
                    Code = "#1424",
                    Name = "Столярне обладнання",
                    Area = 2.50M
                });
        }
    }
}
