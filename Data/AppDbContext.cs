using GerenciamentoDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = "trabalho", Nome = "Trabalho" },
                new Categoria { CategoriaId = "casa", Nome = "Casa" },
                new Categoria { CategoriaId = "faculdade", Nome = "Faculdade" },
                new Categoria { CategoriaId = "estudos", Nome = "Estudos" },
                new Categoria { CategoriaId = "compras", Nome = "Compras" },
                new Categoria { CategoriaId = "academia", Nome = "Academia" },
                new Categoria { CategoriaId = "livros", Nome = "Livros" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Nome = "Pendente" },
                new Status { StatusId = 2, Nome = "Concluído" }
            );

            modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.Categoria)
            .WithMany()
            .HasForeignKey(t => t.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}