using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class MudancaNoContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Aviso_AgendamentoId",
                table: "AGV_Aviso",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento",
                column: "AvisosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AGV_Aviso_AGV_Agendamento_AgendamentoId",
                table: "AGV_Aviso",
                column: "AgendamentoId",
                principalTable: "AGV_Agendamento",
                principalColumn: "AgendamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGV_Aviso_AGV_Agendamento_AgendamentoId",
                table: "AGV_Aviso");

            migrationBuilder.DropIndex(
                name: "IX_AGV_Aviso_AgendamentoId",
                table: "AGV_Aviso");

            migrationBuilder.DropIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento",
                column: "AvisosId",
                unique: true,
                filter: "[AvisosId] IS NOT NULL");
        }
    }
}
