using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCreator.Migrations
{
    public partial class addedCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Max_Cost",
                table: "Types",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min_Cost",
                table: "Types",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max_Cost",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "Min_Cost",
                table: "Types");
        }
    }
}
