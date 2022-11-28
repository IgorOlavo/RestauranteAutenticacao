using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAutenticacao.Migrations
{
    public partial class Anotacoesv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidadebebida",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidadebebida",
                table: "Pedido");
        }
    }
}
