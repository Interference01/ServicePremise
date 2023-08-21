using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServicePremise.Migrations
{
    /// <inheritdoc />
    public partial class AddTestingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Premises",
                columns: new[] { "Id", "Code", "EquipmentArea", "Name" },
                values: new object[,]
                {
                    { new Guid("931dc822-0092-4fa0-a44e-4794c58520f6"), "#4124", 6.00m, "Київ. Курортна 25" },
                    { new Guid("a7ca34a9-bb28-454e-939f-bdddbec3d059"), "#4126", 20.00m, "Житомир. Жашківська 33/2" },
                    { new Guid("cfe56f40-cf77-43af-ae04-53f8e4405ca5"), "#4125", 10.00m, "Львів. Юнкерова 86г" }
                });

            migrationBuilder.InsertData(
                table: "TypesEquipment",
                columns: new[] { "Id", "Area", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("0136730c-5aa4-4ca3-919d-31ad6b433bf0"), 15.00m, "#1422", "Токарне обладнання" },
                    { new Guid("2722fde6-3112-48cc-8521-fa71df04cc94"), 8.00m, "#1423", "Швейні станки" },
                    { new Guid("3a5087b1-a418-4895-aefe-945802b1e3d6"), 2.50m, "#1424", "Столярне обладнання" },
                    { new Guid("5ce3db4b-070a-49a6-aeaa-6188f77fa8f7"), 4.50m, "#1421", "Шиномонтажне обладнання" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Premises",
                keyColumn: "Id",
                keyValue: new Guid("931dc822-0092-4fa0-a44e-4794c58520f6"));

            migrationBuilder.DeleteData(
                table: "Premises",
                keyColumn: "Id",
                keyValue: new Guid("a7ca34a9-bb28-454e-939f-bdddbec3d059"));

            migrationBuilder.DeleteData(
                table: "Premises",
                keyColumn: "Id",
                keyValue: new Guid("cfe56f40-cf77-43af-ae04-53f8e4405ca5"));

            migrationBuilder.DeleteData(
                table: "TypesEquipment",
                keyColumn: "Id",
                keyValue: new Guid("0136730c-5aa4-4ca3-919d-31ad6b433bf0"));

            migrationBuilder.DeleteData(
                table: "TypesEquipment",
                keyColumn: "Id",
                keyValue: new Guid("2722fde6-3112-48cc-8521-fa71df04cc94"));

            migrationBuilder.DeleteData(
                table: "TypesEquipment",
                keyColumn: "Id",
                keyValue: new Guid("3a5087b1-a418-4895-aefe-945802b1e3d6"));

            migrationBuilder.DeleteData(
                table: "TypesEquipment",
                keyColumn: "Id",
                keyValue: new Guid("5ce3db4b-070a-49a6-aeaa-6188f77fa8f7"));
        }
    }
}
