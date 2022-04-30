using ListaDeTarefas.Models;

namespace ListaDeTarefas.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        void CriarTarefaNoBd(Tarefa tarefa);
        List<Tarefa> RetornarTodasAsTarefas();
    }
}
