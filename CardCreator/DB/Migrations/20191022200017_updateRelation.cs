using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCreator.Migrations
{
    public partial class updateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cards",
                newName: "CardId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
