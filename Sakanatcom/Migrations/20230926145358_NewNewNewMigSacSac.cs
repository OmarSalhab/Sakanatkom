using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewNewNewMigSacSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "MasterItemMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "MasterItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
