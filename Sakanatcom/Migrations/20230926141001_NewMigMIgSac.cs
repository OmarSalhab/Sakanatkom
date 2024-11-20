using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakanatcom.Migrations
{
    public partial class NewMigMIgSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu");

            migrationBuilder.AlterColumn<decimal>(
                name: "MasterItemMenuPrice",
                table: "MasterItemMenu",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuPhone",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuName",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuImageUrl2",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuImageUrl",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuEmail",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterItemMenuDate",
                table: "MasterItemMenu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuAddress",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "MasterItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenu",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "MasterItemMenu");

            migrationBuilder.AlterColumn<decimal>(
                name: "MasterItemMenuPrice",
                table: "MasterItemMenu",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuPhone",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuName",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuImageUrl2",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuImageUrl",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuEmail",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterItemMenuDate",
                table: "MasterItemMenu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "MasterItemMenuAddress",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenu",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
