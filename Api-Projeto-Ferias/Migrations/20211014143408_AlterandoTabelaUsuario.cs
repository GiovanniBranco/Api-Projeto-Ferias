using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Projeto_Ferias.Migrations
{
    public partial class AlterandoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ultima_alteracao",
                table: "usuario",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "ultima_alteracao",
                table: "usuario");
        }
    }
}
