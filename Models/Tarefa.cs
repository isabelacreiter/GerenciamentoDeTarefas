using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataVencimento { get; set; }

        public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public bool Atrasado =>
            Status?.Nome == "Pendente" &&
            DataVencimento.HasValue &&
            DataVencimento.Value < DateTime.Today;
    }
}