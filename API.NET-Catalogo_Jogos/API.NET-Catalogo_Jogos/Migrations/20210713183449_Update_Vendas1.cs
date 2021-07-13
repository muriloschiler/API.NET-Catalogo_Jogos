using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.NET_Catalogo_Jogos.Migrations
{
    public partial class Update_Vendas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendas_jogos_id_jogo",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "idJogo",
                table: "vendas");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_jogo",
                table: "vendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vendas_jogos_id_jogo",
                table: "vendas",
                column: "id_jogo",
                principalTable: "jogos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendas_jogos_id_jogo",
                table: "vendas");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_jogo",
                table: "vendas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "idJogo",
                table: "vendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_vendas_jogos_id_jogo",
                table: "vendas",
                column: "id_jogo",
                principalTable: "jogos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
