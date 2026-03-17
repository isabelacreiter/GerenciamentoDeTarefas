using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirFKCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
