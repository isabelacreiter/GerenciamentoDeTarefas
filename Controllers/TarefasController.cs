using GerenciamentoDeTarefas.Data;
using GerenciamentoDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filtroString)
        {
            IQueryable<Tarefa> consulta = _context.Tarefas
                .Include(t => t.Categoria)
                .Include(t => t.Status);

            var filtros = new Filtros(filtroString, null, 0, null);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Prazo = Filtros.PrazoFiltros;
            ViewBag.Criacao = Filtros.CriacaoFiltros;

            var tarefas = consulta
                .OrderBy(t => t.DataVencimento)
                .ThenByDescending(t => t.DataCriacao)
                .ToList();

            return View(tarefas);
        }

        [HttpPost]
        public IActionResult MarcarCompleto(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa != null)
            {
                tarefa.StatusId = 2; 
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletarCompletos()
        {
            var concluidas = _context.Tarefas
                .Where(t => t.StatusId == 2)
                .ToList();

            _context.Tarefas.RemoveRange(concluidas);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Adicionar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now;
            tarefa.StatusId = 1; 

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Filtrar(string[] filtro)
        {
            string filtroString = string.Join("-", filtro);
            return RedirectToAction("Index", new { filtroString });
        }
    }
}