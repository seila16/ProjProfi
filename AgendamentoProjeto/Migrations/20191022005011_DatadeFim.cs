using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class DatadeFim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimAgendamento",
                table: "AGV_Agendamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFimAgendamento",
                table: "AGV_Agendamento");
        }
    }
}
