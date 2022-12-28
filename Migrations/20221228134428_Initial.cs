using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjetoFinalAVMB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomecompleto = table.Column<string>(name: "nome_completo", type: "text", nullable: false),
                    nomeguerra = table.Column<string>(name: "nome_guerra", type: "text", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    nomeresponsavel = table.Column<string>(name: "nome_responsavel", type: "text", nullable: false),
                    datacadastro = table.Column<DateTime>(name: "data_cadastro", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Uniformes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pecaroupa = table.Column<string>(name: "peca_roupa", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uniformes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoUniformes",
                columns: table => new
                {
                    alunoId = table.Column<int>(type: "integer", nullable: false),
                    uniformeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoUniformes", x => new { x.alunoId, x.uniformeId });
                    table.ForeignKey(
                        name: "FK_AlunoUniformes_Alunos_alunoId",
                        column: x => x.alunoId,
                        principalTable: "Alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoUniformes_Uniformes_uniformeId",
                        column: x => x.uniformeId,
                        principalTable: "Uniformes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoUniformes_uniformeId",
                table: "AlunoUniformes",
                column: "uniformeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoUniformes");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Uniformes");
        }
    }
}
