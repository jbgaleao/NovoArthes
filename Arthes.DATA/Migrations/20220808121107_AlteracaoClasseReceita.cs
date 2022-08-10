using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arthes.DATA.Migrations
{
    public partial class AlteracaoClasseReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
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
                    _ = table.PrimaryKey("PK_Revista", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "TipoLinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_TipoLinha", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
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
                    _ = table.PrimaryKey("PK_Receita", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Receita_Revista",
                        column: x => x.IdRevista,
                        principalTable: "Revista",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
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
                    _ = table.PrimaryKey("PK_Linha", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Linha_Fabricante",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id");
                    _ = table.ForeignKey(
                        name: "FK_Linha_TipoLinha",
                        column: x => x.TipoLinhaId,
                        principalTable: "TipoLinha",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
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
                    _ = table.PrimaryKey("PK_LinhaReceita", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_LinhaReceita_Linha",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id");
                    _ = table.ForeignKey(
                        name: "FK_LinhaReceita_Receita",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Linha_FabricanteId",
                table: "Linha",
                column: "FabricanteId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Linha_TipoLinhaId",
                table: "Linha",
                column: "TipoLinhaId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_LinhaReceita_LinhaId",
                table: "LinhaReceita",
                column: "LinhaId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_LinhaReceita_ReceitaId",
                table: "LinhaReceita",
                column: "ReceitaId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Receita_IdRevista",
                table: "Receita",
                column: "IdRevista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "LinhaReceita");

            _ = migrationBuilder.DropTable(
                name: "Linha");

            _ = migrationBuilder.DropTable(
                name: "Receita");

            _ = migrationBuilder.DropTable(
                name: "Fabricante");

            _ = migrationBuilder.DropTable(
                name: "TipoLinha");

            _ = migrationBuilder.DropTable(
                name: "Revista");
        }
    }
}
