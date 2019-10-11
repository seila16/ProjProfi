using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class correcaoDeModelAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGV_Agendamento_AGV_Aviso_AvisoId",
                table: "AGV_Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_AGV_Agendamento_AvisoId",
                table: "AGV_Agendamento");

            migrationBuilder.DropColumn(
                name: "AvisoId",
                table: "AGV_Agendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento",
                column: "AvisosId",
                unique: true,
                filter: "[AvisosId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AGV_Agendamento_AGV_Aviso_AvisosId",
                table: "AGV_Agendamento",
                column: "AvisosId",
                principalTable: "AGV_Aviso",
                principalColumn: "AvisosId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGV_Agendamento_AGV_Aviso_AvisosId",
                table: "AGV_Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_AGV_Agendamento_AvisosId",
                table: "AGV_Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "AvisoId",
                table: "AGV_Agendamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_AvisoId",
                table: "AGV_Agendamento",
                column: "AvisoId",
                unique: true,
                filter: "[AvisoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AGV_Agendamento_AGV_Aviso_AvisoId",
                table: "AGV_Agendamento",
                column: "AvisoId",
                principalTable: "AGV_Aviso",
                principalColumn: "AvisosId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
