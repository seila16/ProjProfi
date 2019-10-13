using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Cargo")]
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome do cargo")]
        public string NomeCargo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
