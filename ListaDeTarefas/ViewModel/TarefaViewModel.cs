using ListaDeTarefas.Models;

namespace ListaDeTarefas.ViewModel
{
    public class TarefaViewModel
    {
        public Tarefa Tarefa { get; set; }

        public List<Tarefa> Tarefas { get; set; }

        public string Data { get; set; }
    }
}
