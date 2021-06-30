using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class ChangedRelationshipsToToListAndAddItemSetRelationshipModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemSetId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemSetId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemSetRelationships",
                columns: table => new
                {
                    ItemSetId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSetRelationships", x => new { x.ItemId, x.ItemSetId });
                    table.ForeignKey(
                        name: "FK_ItemSetRelationships_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSetRelationships_ItemSets_ItemSetId",
                        column: x => x.ItemSetId,
                        principalTable: "ItemSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSetRelationships_ItemSetId",
                table: "ItemSetRelationships",
                column: "ItemSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSetRelationships");

            migrationBuilder.AddColumn<int>(
                name: "ItemSetId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSetId",
                table: "Items",
                column: "ItemSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items",
                column: "ItemSetId",
                principalTable: "ItemSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
