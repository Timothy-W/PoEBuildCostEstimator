using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class ChangedNameOfFieldsInItemSetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemSetName",
                table: "ItemSets");

            migrationBuilder.RenameColumn(
                name: "PobItemSetId",
                table: "ItemSets",
                newName: "ItemSetTitle");

            migrationBuilder.AddColumn<int>(
                name: "ItemSetXmlId",
                table: "ItemSets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemSetXmlId",
                table: "ItemSets");

            migrationBuilder.RenameColumn(
                name: "ItemSetTitle",
                table: "ItemSets",
                newName: "PobItemSetId");

            migrationBuilder.AddColumn<string>(
                name: "ItemSetName",
                table: "ItemSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
