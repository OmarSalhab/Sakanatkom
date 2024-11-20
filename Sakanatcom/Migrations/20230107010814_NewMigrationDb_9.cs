using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewMigrationDb_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterSocialMediaImageUrl",
                table: "MasterSocialMedia");

            migrationBuilder.AddColumn<string>(
                name: "MasterSocialMediaIcon",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterSocialMediaIcon",
                table: "MasterSocialMedia");

            migrationBuilder.AddColumn<string>(
                name: "MasterSocialMediaImageUrl",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
