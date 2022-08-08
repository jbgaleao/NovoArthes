using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arthes.DATA.Migrations
{
    public partial class AlteracaoClasseReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumEdicao = table.Column<int>(type: "int", nullable: false),
                    MesEdicao = table.Column<int>(type: "int", nullable: false),
                    AnoEdicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLinha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    NivelDificuldade = table.Column<int>(type: "int", nullable: false),
                    IdRevista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Revista",
                        column: x => x.IdRevista,
                        principalTable: "Revista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Linha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodLinha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoLinhaId = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linha_Fabricante",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Linha_TipoLinha",
                        column: x => x.TipoLinhaId,
                        principalTable: "TipoLinha",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LinhaReceita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    LinhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhaReceita_Linha",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinhaReceita_Receita",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linha_FabricanteId",
                table: "Linha",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Linha_TipoLinhaId",
                table: "Linha",
                column: "TipoLinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaReceita_LinhaId",
                table: "LinhaReceita",
                column: "LinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaReceita_ReceitaId",
                table: "LinhaReceita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_IdRevista",
                table: "Receita",
                column: "IdRevista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinhaReceita");

            migrationBuilder.DropTable(
                name: "Linha");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "TipoLinha");

            migrationBuilder.DropTable(
                name: "Revista");
        }
    }
}
