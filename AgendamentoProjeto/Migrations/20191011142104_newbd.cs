using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendamentoProjeto.Migrations
{
    public partial class newbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGV_Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCargo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Curso", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeDisciplina = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Disciplina", x => x.DisciplinaId);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProfessor = table.Column<string>(maxLength: 60, nullable: false),
                    EmailProfessor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeStatus = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Laboratorio",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(nullable: false),
                    NomeLaboratorio = table.Column<string>(maxLength: 30, nullable: false),
                    Hardware = table.Column<string>(maxLength: 150, nullable: false),
                    Software = table.Column<string>(maxLength: 150, nullable: false),
                    QuantidadePcs = table.Column<int>(nullable: false),
                    Projetor = table.Column<bool>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Laboratorio", x => x.LaboratorioId);
                    table.ForeignKey(
                        name: "FK_AGV_Laboratorio_AGV_Status_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "AGV_Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(maxLength: 60, nullable: false),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Senha = table.Column<string>(maxLength: 400, nullable: false),
                    CargoId = table.Column<int>(nullable: true),
                    CursoId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_AGV_Usuario_AGV_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "AGV_Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGV_Usuario_AGV_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "AGV_Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGV_Usuario_AGV_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AGV_Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Agendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAgendamento = table.Column<DateTime>(nullable: false),
                    LaboratorioId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_AGV_Agendamento_AGV_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "AGV_Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGV_Agendamento_AGV_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "AGV_Laboratorio",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGV_Agendamento_AGV_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "AGV_Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGV_Agendamento_AGV_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AGV_Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGV_Agendamento_AGV_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AGV_Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGV_Aviso",
                columns: table => new
                {
                    AvisosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgendamentoId = table.Column<int>(nullable: true),
                    Mensagem = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGV_Aviso", x => x.AvisosId);
                    table.ForeignKey(
                        name: "FK_AGV_Aviso_AGV_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "AGV_Agendamento",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AGV_Cargo",
                columns: new[] { "CargoId", "NomeCargo" },
                values: new object[,]
                {
                    { 1, "Coordenador" },
                    { 2, "T.I" }
                });

            migrationBuilder.InsertData(
                table: "AGV_Curso",
                columns: new[] { "CursoId", "Nome" },
                values: new object[] { 1, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "AGV_Disciplina",
                columns: new[] { "DisciplinaId", "NomeDisciplina" },
                values: new object[] { 1, "Disciplina padrão" });

            migrationBuilder.InsertData(
                table: "AGV_Professor",
                columns: new[] { "ProfessorId", "EmailProfessor", "NomeProfessor" },
                values: new object[] { 1, "prof@admin.com", "Professor admin" });

            migrationBuilder.InsertData(
                table: "AGV_Status",
                columns: new[] { "StatusId", "NomeStatus" },
                values: new object[,]
                {
                    { 1, "Disponível" },
                    { 2, "Pendente" },
                    { 3, "Cancelado" },
                    { 4, "Bloqueado" }
                });

            migrationBuilder.InsertData(
                table: "AGV_Laboratorio",
                columns: new[] { "LaboratorioId", "Hardware", "NomeLaboratorio", "Projetor", "QuantidadePcs", "Software", "StatusId" },
                values: new object[] { 1, "I7, GTX 1090, 8GB RAM", "Laboratório padrão", true, 10, "VS2019 e photoshop", 1 });

            migrationBuilder.InsertData(
                table: "AGV_Usuario",
                columns: new[] { "UsuarioId", "CargoId", "CursoId", "Email", "Login", "NomeUsuario", "Senha", "StatusId" },
                values: new object[] { 1, 2, null, "TI@gmail.com", "ti", "TI", "ti", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_DisciplinaId",
                table: "AGV_Agendamento",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_LaboratorioId",
                table: "AGV_Agendamento",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_ProfessorId",
                table: "AGV_Agendamento",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_StatusId",
                table: "AGV_Agendamento",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Agendamento_UsuarioId",
                table: "AGV_Agendamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Aviso_AgendamentoId",
                table: "AGV_Aviso",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Usuario_CargoId",
                table: "AGV_Usuario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Usuario_CursoId",
                table: "AGV_Usuario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AGV_Usuario_StatusId",
                table: "AGV_Usuario",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGV_Aviso");

            migrationBuilder.DropTable(
                name: "AGV_Agendamento");

            migrationBuilder.DropTable(
                name: "AGV_Disciplina");

            migrationBuilder.DropTable(
                name: "AGV_Laboratorio");

            migrationBuilder.DropTable(
                name: "AGV_Professor");

            migrationBuilder.DropTable(
                name: "AGV_Usuario");

            migrationBuilder.DropTable(
                name: "AGV_Cargo");

            migrationBuilder.DropTable(
                name: "AGV_Curso");

            migrationBuilder.DropTable(
                name: "AGV_Status");
        }
    }
}
