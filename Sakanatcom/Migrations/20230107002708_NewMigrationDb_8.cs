using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewMigrationDb_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterContactUsInformationImageUrl",
                table: "MasterContactUsInformation");

            migrationBuilder.AddColumn<string>(
                name: "MasterContactUsInformationIcon",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterContactUsInformationIcon",
                table: "MasterContactUsInformation");

            migrationBuilder.AddColumn<string>(
                name: "MasterContactUsInformationImageUrl",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
