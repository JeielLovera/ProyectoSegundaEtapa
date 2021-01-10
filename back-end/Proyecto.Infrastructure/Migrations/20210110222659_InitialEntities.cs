using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Infrastructure.Migrations
{
    public partial class InitialEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoGraduados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anyo = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoGraduados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoGraduados_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Education" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Applied Arts" });

            migrationBuilder.InsertData(
                table: "GrupoGraduados",
                columns: new[] { "Id", "Anyo", "Cantidad", "CursoId", "Sexo" },
                values: new object[] { 1, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, 1, "Males" });

            migrationBuilder.InsertData(
                table: "GrupoGraduados",
                columns: new[] { "Id", "Anyo", "Cantidad", "CursoId", "Sexo" },
                values: new object[] { 2, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500, 2, "Females" });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoGraduados_CursoId",
                table: "GrupoGraduados",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoGraduados");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
