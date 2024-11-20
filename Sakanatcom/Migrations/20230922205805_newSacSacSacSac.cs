using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class newSacSacSacSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenu_AspNetUsers_CreatedById",
                table: "MasterItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_MasterItemMenu_CreatedById",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MasterItemMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MasterItemMenu",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemMenu_CreatedById",
                table: "MasterItemMenu",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenu_AspNetUsers_CreatedById",
                table: "MasterItemMenu",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
