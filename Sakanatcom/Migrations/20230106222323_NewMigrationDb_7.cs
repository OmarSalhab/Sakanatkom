using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewMigrationDb_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterServiceImageUrl",
                table: "MasterService");

            migrationBuilder.AddColumn<string>(
                name: "MasterServiceIcon",
                table: "MasterService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterServiceIcon",
                table: "MasterService");

            migrationBuilder.AddColumn<string>(
                name: "MasterServiceImageUrl",
                table: "MasterService",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
