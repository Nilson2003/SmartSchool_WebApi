using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class listagem_Profe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaProfessor");

            migrationBuilder.RenameColumn(
                name: "professorId",
                table: "Disciplinas",
                newName: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Disciplinas",
                newName: "professorId");

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessor",
                columns: table => new
                {
                    Disciplinaid = table.Column<int>(type: "INTEGER", nullable: false),
                    Professorid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessor", x => new { x.Disciplinaid, x.Professorid });
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Disciplinas_Disciplinaid",
                        column: x => x.Disciplinaid,
                        principalTable: "Disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Professores_Professorid",
                        column: x => x.Professorid,
                        principalTable: "Professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessor_Professorid",
                table: "DisciplinaProfessor",
                column: "Professorid");
        }
    }
}
