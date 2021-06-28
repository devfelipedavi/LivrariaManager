using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.LM.Data.Migrations
{
    public partial class Primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EditoraId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: true),
                    Lancamento = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    AluguelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    AluguelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LivroId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    DataAluguel = table.Column<DateTime>(nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alugueis_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_LivroId",
                table: "Alugueis",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_UsuarioId",
                table: "Alugueis",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AluguelId",
                table: "Livros",
                column: "AluguelId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraId",
                table: "Livros",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AluguelId",
                table: "Usuarios",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Alugueis_AluguelId",
                table: "Livros",
                column: "AluguelId",
                principalTable: "Alugueis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Alugueis_AluguelId",
                table: "Usuarios",
                column: "AluguelId",
                principalTable: "Alugueis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Livros_LivroId",
                table: "Alugueis");

            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alugueis");
        }
    }
}
