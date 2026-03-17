using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.Models
{
    public class Categoria
    {
        [Key]
        public string CategoriaId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}