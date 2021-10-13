using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Projeto_Ferias.Migrations
{
    public partial class CriandoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_usuario_Usuario_Id",
                table: "Ferias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ferias",
                table: "Ferias");

            migrationBuilder.RenameTable(
                name: "Ferias",
                newName: "ferias");

            migrationBuilder.RenameColumn(
                name: "Usuario_Id",
                table: "ferias",
                newName: "usuario_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ferias_Usuario_Id",
                table: "ferias",
                newName: "IX_ferias_usuario_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ferias",
                table: "ferias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ferias_usuario_usuario_Id",
                table: "ferias",
                column: "usuario_Id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ferias_usuario_usuario_Id",
                table: "ferias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ferias",
                table: "ferias");

            migrationBuilder.RenameTable(
                name: "ferias",
                newName: "Ferias");

            migrationBuilder.RenameColumn(
                name: "usuario_Id",
                table: "Ferias",
                newName: "Usuario_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ferias_usuario_Id",
                table: "Ferias",
                newName: "IX_Ferias_Usuario_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ferias",
                table: "Ferias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_usuario_Usuario_Id",
                table: "Ferias",
                column: "Usuario_Id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
