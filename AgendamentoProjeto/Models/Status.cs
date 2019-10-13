using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Status")]
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Status")]
        public string NomeStatus { get; set; }
        public ICollection<Laboratorio> Laboratorios { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

    }
}
