using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Aviso")]
    public class Aviso
    {
        [Key]
        public int AvisosId { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(150, ErrorMessage = "Limite de caracteres atingido")]
        public string Mensagem { get; set; }
    }
}
