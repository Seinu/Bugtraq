using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bugtraq.API.Migrations
{
    public partial class AddedDeveloperEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevId",
                table: "BugLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Devs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    CurrentTask = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devs");

            migrationBuilder.DropColumn(
                name: "DevId",
                table: "BugLists");
        }
    }
}
