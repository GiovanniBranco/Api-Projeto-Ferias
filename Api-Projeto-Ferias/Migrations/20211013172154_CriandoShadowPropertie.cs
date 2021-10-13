using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Projeto_Ferias.Migrations
{
    public partial class CriandoShadowPropertie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtual",
                table: "ferias");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_atual",
                table: "ferias",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_atual",
                table: "ferias");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtual",
                table: "ferias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
