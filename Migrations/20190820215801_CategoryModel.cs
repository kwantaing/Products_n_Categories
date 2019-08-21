using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdnCategories.Migrations
{
    public partial class CategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Categories",
                nullable: true);
        }
    }
}
