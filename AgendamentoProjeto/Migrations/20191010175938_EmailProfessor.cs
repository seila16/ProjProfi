using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class EmailProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailProfessor",
                table: "AGV_Professor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AvisosId",
                table: "AGV_Agendamento",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AGV_Professor",
                keyColumn: "ProfessorId",
                keyValue: 1,
                column: "EmailProfessor",
                value: "prof@admin.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailProfessor",
                table: "AGV_Professor");

            migrationBuilder.AlterColumn<int>(
                name: "AvisosId",
                table: "AGV_Agendamento",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
