using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class AddCostInChaosToItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Itemlevel",
                table: "Items",
                newName: "ItemLevel");

            migrationBuilder.AddColumn<int>(
                name: "CostInChaos",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostInChaos",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemLevel",
                table: "Items",
                newName: "Itemlevel");
        }
    }
}
