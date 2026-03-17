using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}