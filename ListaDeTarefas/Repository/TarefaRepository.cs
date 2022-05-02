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
        public void AtualizarTarefaNoBd(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }
        public List<Tarefa> RetornarTodasAsTarefas()
        {
            return _context.Tarefas.ToList();
        }
        public List<Tarefa> RetornarTodasAsTarefasDoUsuario(int id)
        {
            return _context.Tarefas.Where(t => t.UsuarioId == id).ToList();
        }

        public Tarefa PesquisarTarefaPeloId(int id)
        {
            return _context.Tarefas.FirstOrDefault(t => t.Id == id);
        }

    }
}
