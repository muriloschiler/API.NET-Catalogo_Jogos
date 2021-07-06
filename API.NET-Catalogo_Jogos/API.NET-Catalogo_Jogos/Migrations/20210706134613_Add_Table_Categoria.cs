using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.NET_Catalogo_Jogos.Migrations
{
    public partial class Add_Table_Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria",
                table: "jogos");

            migrationBuilder.AddColumn<Guid>(
                name: "id_categoria",
                table: "jogos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jogos_id_categoria",
                table: "jogos",
                column: "id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_jogos_categorias_id_categoria",
                table: "jogos",
                column: "id_categoria",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jogos_categorias_id_categoria",
                table: "jogos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropIndex(
                name: "IX_jogos_id_categoria",
                table: "jogos");

            migrationBuilder.DropColumn(
                name: "id_categoria",
                table: "jogos");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "jogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
