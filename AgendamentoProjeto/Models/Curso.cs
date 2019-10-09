using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Curso")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome do curso")]
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
