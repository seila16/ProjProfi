using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Professor")]
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome professor")]
        public string NomeProfessor { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string EmailProfessor { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
