using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace producto_api_rest_01.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sescripcion",
                table: "Productos",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Productos",
                newName: "Sescripcion");
        }
    }
}
