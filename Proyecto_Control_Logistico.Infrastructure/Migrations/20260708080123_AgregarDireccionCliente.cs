using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Control_Logistico.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDireccionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionEntrega",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionEntrega",
                table: "AspNetUsers");
        }
    }
}
