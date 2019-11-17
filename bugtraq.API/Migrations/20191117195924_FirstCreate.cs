using Microsoft.EntityFrameworkCore.Migrations;

namespace bugtraq.API.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BugLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReportedBy = table.Column<string>(nullable: true),
                    SubmitDate = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    BugName = table.Column<string>(nullable: true),
                    BugSummary = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugLists");
        }
    }
}
