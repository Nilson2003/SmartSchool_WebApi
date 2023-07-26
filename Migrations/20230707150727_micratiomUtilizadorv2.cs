using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class micratiomUtilizadorv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    funcao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
