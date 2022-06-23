using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterRazor.Migrations
{
    public partial class Migracion33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaDeNacimiento",
                table: "Profesor",
                newName: "Fechanac");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fechanac",
                table: "Profesor",
                newName: "FechaDeNacimiento");
        }
    }
}
