using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class AddedPobItemIdAndUpdatedItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubName",
                table: "Items",
                newName: "BaseType");

            migrationBuilder.AddColumn<int>(
                name: "PobItemId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PobItemId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "BaseType",
                table: "Items",
                newName: "SubName");
        }
    }
}
