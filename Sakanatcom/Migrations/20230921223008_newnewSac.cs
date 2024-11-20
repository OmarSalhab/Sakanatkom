using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class newnewSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuImageUrl1",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuImageUrl2",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuImageUrl3",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuImageUrl1",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuImageUrl2",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuImageUrl3",
                table: "MasterItemMenu");
        }
    }
}
