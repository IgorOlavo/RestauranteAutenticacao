using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAutenticacao.Migrations
{
    public partial class ContextoV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    preco = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Marmita",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    tamanho = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<float>(type: "real", nullable: false),
                    idbebidaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmita", x => x.id);
                    table.ForeignKey(
                        name: "FK_Marmita_Bebida_idbebidaid",
                        column: x => x.idbebidaid,
                        principalTable: "Bebida",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bebidaid = table.Column<int>(type: "int", nullable: false),
                    marmitaid = table.Column<int>(type: "int", nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    tempoPedido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Bebida_bebidaid",
                        column: x => x.bebidaid,
                        principalTable: "Bebida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Marmita_marmitaid",
                        column: x => x.marmitaid,
                        principalTable: "Marmita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marmita_idbebidaid",
                table: "Marmita",
                column: "idbebidaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_bebidaid",
                table: "Pedido",
                column: "bebidaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_clienteid",
                table: "Pedido",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_marmitaid",
                table: "Pedido",
                column: "marmitaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Marmita");

            migrationBuilder.DropTable(
                name: "Bebida");
        }
    }
}
