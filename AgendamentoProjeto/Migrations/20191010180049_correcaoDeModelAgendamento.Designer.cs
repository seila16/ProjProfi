﻿// <auto-generated />
using System;
using AgendamentoProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgendamentoProjeto.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20191010180049_correcaoDeModelAgendamento")]
    partial class correcaoDeModelAgendamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgendamentoProjeto.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvisosId");

                    b.Property<DateTime>("DataAgendamento");

                    b.Property<int>("DisciplinaId");

                    b.Property<int>("LaboratorioId");

                    b.Property<int>("ProfessorId");

                    b.Property<int?>("StatusId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("AvisosId")
                        .IsUnique()
                        .HasFilter("[AvisosId] IS NOT NULL");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("LaboratorioId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AGV_Agendamento");
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Aviso", b =>
                {
                    b.Property<int>("AvisosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendamentoId");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("AvisosId");

                    b.ToTable("AGV_Aviso");
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("CargoId");

                    b.ToTable("AGV_Cargo");

                    b.HasData(
                        new
                        {
                            CargoId = 1,
                            NomeCargo = "Coordenador"
                        },
                        new
                        {
                            CargoId = 2,
                            NomeCargo = "T.I"
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("CursoId");

                    b.ToTable("AGV_Curso");

                    b.HasData(
                        new
                        {
                            CursoId = 1,
                            Nome = "Sistemas de Informação"
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeDisciplina")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("DisciplinaId");

                    b.ToTable("AGV_Disciplina");

                    b.HasData(
                        new
                        {
                            DisciplinaId = 1,
                            NomeDisciplina = "Disciplina padrão"
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Laboratorio", b =>
                {
                    b.Property<int>("LaboratorioId");

                    b.Property<string>("Hardware")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("NomeLaboratorio")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("Projetor");

                    b.Property<int>("QuantidadePcs");

                    b.Property<string>("Software")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("StatusId");

                    b.HasKey("LaboratorioId");

                    b.ToTable("AGV_Laboratorio");

                    b.HasData(
                        new
                        {
                            LaboratorioId = 1,
                            Hardware = "I7, GTX 1090, 8GB RAM",
                            NomeLaboratorio = "Laboratório padrão",
                            Projetor = true,
                            QuantidadePcs = 10,
                            Software = "VS2019 e photoshop",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailProfessor")
                        .IsRequired();

                    b.Property<string>("NomeProfessor")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ProfessorId");

                    b.ToTable("AGV_Professor");

                    b.HasData(
                        new
                        {
                            ProfessorId = 1,
                            EmailProfessor = "prof@admin.com",
                            NomeProfessor = "Professor admin"
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeStatus")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("StatusId");

                    b.ToTable("AGV_Status");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            NomeStatus = "Disponível"
                        },
                        new
                        {
                            StatusId = 2,
                            NomeStatus = "Pendente"
                        },
                        new
                        {
                            StatusId = 3,
                            NomeStatus = "Cancelado"
                        },
                        new
                        {
                            StatusId = 4,
                            NomeStatus = "Bloqueado"
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargoId");

                    b.Property<int?>("CursoId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int?>("StatusId");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CargoId");

                    b.HasIndex("CursoId");

                    b.HasIndex("StatusId");

                    b.ToTable("AGV_Usuario");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            CargoId = 2,
                            Email = "TI@gmail.com",
                            Login = "ti",
                            NomeUsuario = "TI",
                            Senha = "ti",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Agendamento", b =>
                {
                    b.HasOne("AgendamentoProjeto.Models.Aviso", "Avisos")
                        .WithOne("Agendamento")
                        .HasForeignKey("AgendamentoProjeto.Models.Agendamento", "AvisosId");

                    b.HasOne("AgendamentoProjeto.Models.Disciplina", "Disciplina")
                        .WithMany("Agendamentos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendamentoProjeto.Models.Laboratorio", "Laboratorio")
                        .WithMany("Agendamentos")
                        .HasForeignKey("LaboratorioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendamentoProjeto.Models.Professor", "Professor")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendamentoProjeto.Models.Status", "Status")
                        .WithMany("Agendamentos")
                        .HasForeignKey("StatusId");

                    b.HasOne("AgendamentoProjeto.Models.Usuario", "Usuario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Laboratorio", b =>
                {
                    b.HasOne("AgendamentoProjeto.Models.Status", "Status")
                        .WithMany("Laboratorios")
                        .HasForeignKey("LaboratorioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgendamentoProjeto.Models.Usuario", b =>
                {
                    b.HasOne("AgendamentoProjeto.Models.Cargo", "Cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargoId");

                    b.HasOne("AgendamentoProjeto.Models.Curso", "Curso")
                        .WithMany("Usuarios")
                        .HasForeignKey("CursoId");

                    b.HasOne("AgendamentoProjeto.Models.Status", "Status")
                        .WithMany("Usuarios")
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
