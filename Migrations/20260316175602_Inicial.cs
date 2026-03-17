using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId1",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CategoriaId1",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaId",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CategoriaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaId1",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CategoriaId1",
                table: "Tarefas",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId1",
                table: "Tarefas",
                column: "CategoriaId1",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
