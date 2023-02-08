using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class ModeloEditorealEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaInicioActividades = table.Column<DateTime>(nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Legajo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Editorial");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
