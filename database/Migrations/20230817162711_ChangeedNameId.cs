using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePremise.Migrations
{
    /// <inheritdoc />
    public partial class ChangeedNameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Premises_PremiseGuid",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_TypesEquipment_TypeEquipmentGuid",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "TypesEquipment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Premises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TypeEquipmentGuid",
                table: "Contracts",
                newName: "TypeEquipmentId");

            migrationBuilder.RenameColumn(
                name: "PremiseGuid",
                table: "Contracts",
                newName: "PremiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_TypeEquipmentGuid",
                table: "Contracts",
                newName: "IX_Contracts_TypeEquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_PremiseGuid",
                table: "Contracts",
                newName: "IX_Contracts_PremiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Premises_PremiseId",
                table: "Contracts",
                column: "PremiseId",
                principalTable: "Premises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_TypesEquipment_TypeEquipmentId",
                table: "Contracts",
                column: "TypeEquipmentId",
                principalTable: "TypesEquipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Premises_PremiseId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_TypesEquipment_TypeEquipmentId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypesEquipment",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Premises",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "TypeEquipmentId",
                table: "Contracts",
                newName: "TypeEquipmentGuid");

            migrationBuilder.RenameColumn(
                name: "PremiseId",
                table: "Contracts",
                newName: "PremiseGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_TypeEquipmentId",
                table: "Contracts",
                newName: "IX_Contracts_TypeEquipmentGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_PremiseId",
                table: "Contracts",
                newName: "IX_Contracts_PremiseGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Premises_PremiseGuid",
                table: "Contracts",
                column: "PremiseGuid",
                principalTable: "Premises",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_TypesEquipment_TypeEquipmentGuid",
                table: "Contracts",
                column: "TypeEquipmentGuid",
                principalTable: "TypesEquipment",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
