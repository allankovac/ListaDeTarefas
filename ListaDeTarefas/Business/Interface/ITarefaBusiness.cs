using ListaDeTarefas.Models;

namespace ListaDeTarefas.Business.Interface
{
    public interface ITarefaBusiness
    {
        void CriarTarefa(Tarefa tarefa);
        List<Tarefa> ListaTarefa();

        List<Tarefa> ListaTarefasDoUsuario(int id);
    }
}
