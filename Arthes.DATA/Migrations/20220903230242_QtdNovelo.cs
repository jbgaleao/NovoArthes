using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arthes.DATA.Migrations
{
    public partial class QtdNovelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtdNovelo",
                table: "LinhaReceita",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdNovelo",
                table: "LinhaReceita");
        }
    }
}
