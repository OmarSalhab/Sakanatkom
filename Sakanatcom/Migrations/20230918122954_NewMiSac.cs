using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewMiSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuImageUrl2",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuImageUrl3",
                table: "MasterItemMenu");

            migrationBuilder.RenameColumn(
                name: "MasterItemMenuImageUrl4",
                table: "MasterItemMenu",
                newName: "MasterItemMenuAddress");

            migrationBuilder.AddColumn<decimal>(
                name: "MasterItemMenuCapicity",
                table: "MasterItemMenu",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuCapicity",
                table: "MasterItemMenu");

            migrationBuilder.RenameColumn(
                name: "MasterItemMenuAddress",
                table: "MasterItemMenu",
                newName: "MasterItemMenuImageUrl4");

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
    }
}
