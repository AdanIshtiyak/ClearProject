using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnalyzesWebApplication.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analyzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Norms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ManMin = table.Column<double>(type: "float", nullable: false),
                    ManMax = table.Column<double>(type: "float", nullable: false),
                    WManMin = table.Column<double>(type: "float", nullable: false),
                    WManMax = table.Column<double>(type: "float", nullable: false),
                    AnalyzId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Norms_Analyzes_AnalyzId",
                        column: x => x.AnalyzId,
                        principalTable: "Analyzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Analyzes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "OAK" });

            migrationBuilder.InsertData(
                table: "Analyzes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "OAM" });

            migrationBuilder.InsertData(
                table: "Analyzes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Сахар" });

            migrationBuilder.InsertData(
                table: "Norms",
                columns: new[] { "Id", "AnalyzId", "ManMax", "ManMin", "Name", "WManMax", "WManMin" },
                values: new object[] { 1, 1, 1.8600000000000001, 1.45, "Лейкоциты", 1.8700000000000001, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "Norms",
                columns: new[] { "Id", "AnalyzId", "ManMax", "ManMin", "Name", "WManMax", "WManMin" },
                values: new object[] { 2, 2, 2.5600000000000001, 1.76, "Соль", 2.6000000000000001, 1.8 });

            migrationBuilder.InsertData(
                table: "Norms",
                columns: new[] { "Id", "AnalyzId", "ManMax", "ManMin", "Name", "WManMax", "WManMin" },
                values: new object[] { 3, 3, 95.0, 60.0, "Уровень сахара", 98.0, 63.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Norms_AnalyzId",
                table: "Norms",
                column: "AnalyzId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Norms");

            migrationBuilder.DropTable(
                name: "Analyzes");
        }
    }
}
