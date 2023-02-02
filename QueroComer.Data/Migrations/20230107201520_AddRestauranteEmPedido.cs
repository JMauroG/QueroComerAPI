using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueroComer.Migrations
{
    /// <inheritdoc />
    public partial class AddRestauranteEmPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestauranteId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_RestauranteId",
                table: "Pedidos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Restaurantes_RestauranteId",
                table: "Pedidos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Restaurantes_RestauranteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_RestauranteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Pedidos");
        }
    }
}
