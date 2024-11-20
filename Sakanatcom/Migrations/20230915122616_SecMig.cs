using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class SecMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuEmail",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuName",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuPhone",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuEmail",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuName",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuPhone",
                table: "MasterItemMenu");
        }
    }
}
