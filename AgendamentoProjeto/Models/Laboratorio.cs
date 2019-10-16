using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Models
{
    [Table("AGV_Laboratorio")]
    public class Laboratorio
    {
        [Key]
        public int LaboratorioId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Nome do Laboratório")]
        public string NomeLaboratorio { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(150, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Descrição de hardware")]
        public string Hardware { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(150, ErrorMessage = "Limite de caracteres atingido")]
        [Display(Name = "Descrição de software")]
        public string Software { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Quantidade de computadores")]
        public int QuantidadePcs { get; set; }
        [Display(Name = "Tem projetor?")]
        public bool Projetor { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
