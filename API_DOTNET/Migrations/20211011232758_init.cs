using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DOTNET.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Nascimento = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Vilma" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Malu" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Rafael" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Nascimento", "Nome", "Sobrenome", "TeacherId" },
                values: new object[] { 1, "22/10/1987", "Eliu", "Moraes", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Nascimento", "Nome", "Sobrenome", "TeacherId" },
                values: new object[] { 2, "12/11/1990", "Rodrigo", "Nasdaq", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Nascimento", "Nome", "Sobrenome", "TeacherId" },
                values: new object[] { 3, "10/01/1988", "Letícia", "Suarez", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Nascimento", "Nome", "Sobrenome", "TeacherId" },
                values: new object[] { 4, "09/04/1992", "Douglas", "Sauro", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
