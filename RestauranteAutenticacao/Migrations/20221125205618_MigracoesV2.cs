using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAutenticacao.Migrations
{
    public partial class MigracoesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marmita_Bebida_idbebidaid",
                table: "Marmita");

            migrationBuilder.DropIndex(
                name: "IX_Marmita_idbebidaid",
                table: "Marmita");

            migrationBuilder.DropColumn(
                name: "idbebidaid",
                table: "Marmita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idbebidaid",
                table: "Marmita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marmita_idbebidaid",
                table: "Marmita",
                column: "idbebidaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Marmita_Bebida_idbebidaid",
                table: "Marmita",
                column: "idbebidaid",
                principalTable: "Bebida",
                principalColumn: "id");
        }
    }
}
