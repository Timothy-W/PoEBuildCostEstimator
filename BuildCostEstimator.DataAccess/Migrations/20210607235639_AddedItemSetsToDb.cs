using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class AddedItemSetsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemSetId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemSets",
                columns: table => new
                {
                    ItemSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSets", x => x.ItemSetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSetId",
                table: "Items",
                column: "ItemSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items",
                column: "ItemSetId",
                principalTable: "ItemSets",
                principalColumn: "ItemSetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemSets");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemSetId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemSetId",
                table: "Items");
        }
    }
}
