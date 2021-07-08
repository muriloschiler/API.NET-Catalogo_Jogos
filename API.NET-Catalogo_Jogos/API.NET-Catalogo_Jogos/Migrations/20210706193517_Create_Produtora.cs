using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.NET_Catalogo_Jogos.Migrations
{
    public partial class Create_Produtora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "produtora",
                table: "jogos");

            migrationBuilder.AddColumn<Guid>(
                name: "id_produtora",
                table: "jogos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "produtoras",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    produtora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoras", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jogos_id_produtora",
                table: "jogos",
                column: "id_produtora");

            migrationBuilder.AddForeignKey(
                name: "FK_jogos_produtoras_id_produtora",
                table: "jogos",
                column: "id_produtora",
                principalTable: "produtoras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jogos_produtoras_id_produtora",
                table: "jogos");

            migrationBuilder.DropTable(
                name: "produtoras");

            migrationBuilder.DropIndex(
                name: "IX_jogos_id_produtora",
                table: "jogos");

            migrationBuilder.DropColumn(
                name: "id_produtora",
                table: "jogos");

            migrationBuilder.AddColumn<string>(
                name: "produtora",
                table: "jogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
