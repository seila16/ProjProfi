using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Disciplina")]
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome da disciplina")]
        public string NomeDisciplina { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
