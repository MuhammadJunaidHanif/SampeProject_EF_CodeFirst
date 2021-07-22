using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProjectDatabase.Migrations
{
    public partial class DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Box",
                        column: x => x.CEO,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Email", "FName", "LName", "Password", "Phone" },
                values: new object[] { 1, "Lahore", "syedjunaidhanif@gmail.com", "Muhammad ", "Junaid", "tylqZKJAuUrW94/8GfoItxs282CnvA/URdTkrVXAMl4=", null });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CEO",
                table: "Company",
                column: "CEO");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
