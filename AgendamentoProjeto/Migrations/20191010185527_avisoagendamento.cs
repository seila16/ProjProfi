using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class avisoagendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGV_Aviso_AGV_Agendamento_AgendamentoId",
                table: "AGV_Aviso");

            migrationBuilder.DropIndex(
                name: "IX_AGV_Aviso_AgendamentoId",
                table: "AGV_Aviso");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "AGV_Aviso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendamentoId",
                table: "AGV_Aviso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Aviso_AgendamentoId",
                table: "AGV_Aviso",
                column: "AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AGV_Aviso_AGV_Agendamento_AgendamentoId",
                table: "AGV_Aviso",
                column: "AgendamentoId",
                principalTable: "AGV_Agendamento",
                principalColumn: "AgendamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
