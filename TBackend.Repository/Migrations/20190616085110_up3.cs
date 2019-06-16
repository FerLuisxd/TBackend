using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBackend.Repository.Migrations
{
    public partial class up3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Tournaments",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
