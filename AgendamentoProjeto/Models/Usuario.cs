using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome Usuário")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(400, ErrorMessage = "Limite de caracteres atingido")]
        public string Senha { get; set; }
        public int? CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public int? CursoId { get; set; }
        public Curso Curso { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }


    }
}
