using ListaDeTarefas.Models;

namespace ListaDeTarefas.Business.Interface
{
    public interface ITarefaBusiness
    {
        void CriarTarefa(Tarefa tarefa, string email);
        List<Tarefa> ListaTarefa();

        List<Tarefa> ListaTarefasDoUsuario(string id);

        void FinalizarTarefa(int id);
    }
}
