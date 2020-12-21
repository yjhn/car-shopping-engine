using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class DatePropertyRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Uploaded",
                table: "Vehicles",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Vehicles",
                newName: "Uploaded");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "getdate()");
        }
    }
}
