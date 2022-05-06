using ListaDeTarefas.Models;

namespace ListaDeTarefas.ViewModel
{
    public class TarefaViewModel
    {
        public Tarefa Tarefa { get; set; }

        public List<Tarefa> Tarefas { get; set; }

        public List<Tarefa> TarefasFinalizadas { get; set; }
        public List<Tarefa> TarefasNaoFinalizadas { get; set; }

        public int TotalFinalizadoAntes { get; set; }
        public int TotalFinalizadoDepois { get; set; }
        public int TotalFinalizadoTotal { get; set; }

        public int TotalEmAbertoAntes { get; set; }
        public int TotalEmAbertoDepois { get; set; }
        public int TotalEmAbertoTotal { get; set; }

        public string Data { get; set; }
    }
}
