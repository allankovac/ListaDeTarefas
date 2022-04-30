using ListaDeTarefas.Context;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CriarTarefaNoBd(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public List<Tarefa> RetornarTodasAsTarefas()
        {
            return _context.Tarefas.ToList();
        }
    }
}
