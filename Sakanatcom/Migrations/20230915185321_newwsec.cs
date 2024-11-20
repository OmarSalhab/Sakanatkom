using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class newwsec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuDateRange",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuDateRange",
                table: "MasterItemMenu");
        }
    }
}
