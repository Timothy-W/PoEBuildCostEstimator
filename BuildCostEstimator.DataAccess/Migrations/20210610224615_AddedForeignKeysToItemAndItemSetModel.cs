using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildCostEstimator.DataAccess.Migrations
{
    public partial class AddedForeignKeysToItemAndItemSetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BuildId",
                table: "ItemSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemSetId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSets_BuildId",
                table: "ItemSets",
                column: "BuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items",
                column: "ItemSetId",
                principalTable: "ItemSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSets_Builds_BuildId",
                table: "ItemSets",
                column: "BuildId",
                principalTable: "Builds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSets_Builds_BuildId",
                table: "ItemSets");

            migrationBuilder.DropIndex(
                name: "IX_ItemSets_BuildId",
                table: "ItemSets");

            migrationBuilder.DropColumn(
                name: "BuildId",
                table: "ItemSets");

            migrationBuilder.AlterColumn<int>(
                name: "ItemSetId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemSets_ItemSetId",
                table: "Items",
                column: "ItemSetId",
                principalTable: "ItemSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
