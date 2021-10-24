using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.NET_Catalogo_Jogos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtoras",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    produtora = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    dataNasc = table.Column<string>(type: "TEXT", nullable: false),
                    sexo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jogos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    titulo = table.Column<string>(type: "TEXT", nullable: false),
                    id_produtora = table.Column<Guid>(type: "TEXT", nullable: false),
                    id_categoria = table.Column<Guid>(type: "TEXT", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    anoLancamento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogos", x => x.id);
                    table.ForeignKey(
                        name: "FK_jogos_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jogos_produtoras_id_produtora",
                        column: x => x.id_produtora,
                        principalTable: "produtoras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    id_usuario = table.Column<Guid>(type: "TEXT", nullable: false),
                    id_jogo = table.Column<Guid>(type: "TEXT", nullable: false),
                    dataVenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valorTotal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_vendas_jogos_id_jogo",
                        column: x => x.id_jogo,
                        principalTable: "jogos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendas_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jogos_id_categoria",
                table: "jogos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_jogos_id_produtora",
                table: "jogos",
                column: "id_produtora");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_id_jogo",
                table: "vendas",
                column: "id_jogo");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_id_usuario",
                table: "vendas",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vendas");

            migrationBuilder.DropTable(
                name: "jogos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "produtoras");
        }
    }
}
