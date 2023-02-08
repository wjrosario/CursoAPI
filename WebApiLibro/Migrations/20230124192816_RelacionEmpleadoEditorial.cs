using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class RelacionEmpleadoEditorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Empleado_EditorialId",
                table: "Empleado",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Editorial_EditorialId",
                table: "Empleado",
                column: "EditorialId",
                principalTable: "Editorial",
                principalColumn: "IdEditorial",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Editorial_EditorialId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_EditorialId",
                table: "Empleado");
        }
    }
}
