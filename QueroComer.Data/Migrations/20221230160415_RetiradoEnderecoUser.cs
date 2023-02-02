using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueroComer.Migrations
{
    /// <inheritdoc />
    public partial class RetiradoEnderecoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecosUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecosUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecosUsers_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecosUsers_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosUsers_EnderecoId",
                table: "EnderecosUsers",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosUsers_UsuarioId",
                table: "EnderecosUsers",
                column: "UsuarioId");
        }
    }
}
