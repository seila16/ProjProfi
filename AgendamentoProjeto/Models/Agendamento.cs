using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Agendamento")]
    public class Agendamento
    {
        [Key]
        public int AgendamentoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data de Agendamento")]
        public DateTime DataAgendamento { get; set; }
        public int LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public int UsuarioId { get; set; }
        [Display(Name = "Usuário solicitante")]
        public Usuario Usuario { get; set; }
        public int? StatusId { get; set; }      
        public Status Status { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<Aviso> Avisos { get; set; }
    }
}