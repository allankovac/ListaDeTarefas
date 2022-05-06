using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;

namespace ListaDeTarefas.Business.Interface
{
    public interface ITarefaBusiness
    {
        void CriarTarefa(Tarefa tarefa, string email);
        List<Tarefa> ListaTarefa();

        List<Tarefa> ListaTarefasDoUsuario(string id);
        TarefaViewModel ListaTarefasDashBoardDoUsuario(string id);

        void FinalizarTarefa(int id);

        void FinalizarTarefaEmMassa(List<int> listaId);
        DateTime TryParseDateStringToDateTime(string dataMesAno);
    }
}
