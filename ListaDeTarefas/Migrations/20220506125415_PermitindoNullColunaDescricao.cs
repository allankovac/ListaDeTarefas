using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeTarefas.Migrations
{
    public partial class PermitindoNullColunaDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Descricao",
            table: "Tarefas",
            defaultValue: null,
            nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "OrderSource",
            table: "Orders");
        }
    }
}
