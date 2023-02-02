using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueroComer.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoEndereco3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Users_UsuarioId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Users_UserId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UserId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Enderecos");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Restaurantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Enderecos",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoId",
                table: "Pedidos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Users_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId",
                table: "Pedidos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Users_IdUsuario",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Enderecos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UserId",
                table: "Pedidos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Users_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Users_UserId",
                table: "Pedidos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
