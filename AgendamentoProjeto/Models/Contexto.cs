using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoProjeto.Models;

namespace AgendamentoProjeto.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Status> Status { get; set; }


        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasOne(e => e.Cargo).WithMany(e => e.Usuarios).HasForeignKey(e => e.CargoId);
            modelBuilder.Entity<Usuario>().HasOne(e => e.Curso).WithMany(e => e.Usuarios).HasForeignKey(e => e.CursoId);
            modelBuilder.Entity<Usuario>().HasOne(e => e.Status).WithMany(e => e.Usuarios).HasForeignKey(e => e.StatusId);
            modelBuilder.Entity<Agendamento>().HasOne(a => a.Laboratorio).WithMany(a => a.Agendamentos).HasForeignKey(a => a.LaboratorioId);
            modelBuilder.Entity<Agendamento>().HasOne(a => a.Disciplina).WithMany(a => a.Agendamentos).HasForeignKey(a => a.DisciplinaId);
            modelBuilder.Entity<Agendamento>().HasOne(a => a.Usuario).WithMany(a => a.Agendamentos).HasForeignKey(a => a.UsuarioId);
            modelBuilder.Entity<Agendamento>().HasOne(a => a.Status).WithMany(a => a.Agendamentos).HasForeignKey(a => a.StatusId);

            modelBuilder.Entity<Agendamento>().HasOne(a => a.Professor).WithMany(a => a.Agendamentos).HasForeignKey(a => a.ProfessorId);
            modelBuilder.Entity<Laboratorio>().HasOne(l => l.Status).WithMany(l => l.Laboratorios).HasForeignKey(l => l.StatusId);

            modelBuilder.Entity<Status>().HasData(
                new Status()
                {
                    StatusId = 1,
                    NomeStatus = "Disponível"
                },
                new Status()
                {
                    StatusId = 2,
                    NomeStatus = "Pendente"
                },
                new Status()
                {
                    StatusId = 3,
                    NomeStatus = "Cancelado"
                },
                new Status()
                {
                    StatusId = 4,
                    NomeStatus = "Bloqueado"
                },
                 new Status()
                 {
                     StatusId = 5,
                     NomeStatus = "Manutenção"
                 }
            );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo
                {
                    CargoId = 1,
                    NomeCargo = "Coordenador"
                },
                new Cargo
                {
                    CargoId = 2,
                    NomeCargo = "T.I"
                }
            );

            modelBuilder.Entity<Laboratorio>().HasData(
                new Laboratorio
                {
                    LaboratorioId = 1,
                    NomeLaboratorio = "Laboratório padrão",
                    Hardware = "I7, GTX 1090, 8GB RAM",
                    Projetor = true,
                    QuantidadePcs = 10,
                    Software = "VS2019 e photoshop",
                    StatusId = 1,


                }
                );

            modelBuilder.Entity<Disciplina>().HasData(
                new Disciplina
                {
                    NomeDisciplina = "Disciplina padrão",
                    DisciplinaId = 1
                }
                );

            modelBuilder.Entity<Professor>().HasData(
                new Professor
                {
                    ProfessorId = 1,
                    NomeProfessor = "Professor admin",
                    EmailProfessor = "prof@admin.com"
                }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId = 1,
                    CargoId = 2,
                    Email = "TI@gmail.com",
                    Login = "ti",
                    NomeUsuario = "TI",
                    Senha = "ti",
                    StatusId = 1,
                }
            );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 1,
                    Nome = "Sistemas de Informação",

                }
            );
        }

        public DbSet<AgendamentoProjeto.Models.Agendamento> Agendamento { get; set; }

        public DbSet<AgendamentoProjeto.Models.Aviso> Aviso { get; set; }

        public DbSet<AgendamentoProjeto.Models.Disciplina> Disciplina { get; set; }

        public DbSet<AgendamentoProjeto.Models.Laboratorio> Laboratorio { get; set; }

        public DbSet<AgendamentoProjeto.Models.Professor> Professor { get; set; }
    }
}
