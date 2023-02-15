using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACoreBackend.Migrations
{
    public partial class sttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstMidName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstMidName", "LastName" },
                values: new object[,]
                {
                    { 1, "Albert1", "Nosteen1" },
                    { 2, "Albert2", "Nosteen2" },
                    { 3, "Albert3", "Nosteen3" },
                    { 4, "Albert4", "Nosteen4" },
                    { 5, "Albert5", "Nosteen5" },
                    { 6, "Albert6", "Nosteen6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
