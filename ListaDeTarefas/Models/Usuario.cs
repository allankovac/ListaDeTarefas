using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }

        public virtual List<Tarefa> Tarefa { get; set; }
    }
}
