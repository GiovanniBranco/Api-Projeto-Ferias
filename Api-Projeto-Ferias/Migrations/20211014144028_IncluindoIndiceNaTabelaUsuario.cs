using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Projeto_Ferias.Migrations
{
    public partial class IncluindoIndiceNaTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "usuario",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_UserName",
                table: "usuario",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuario_UserName",
                table: "usuario");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
