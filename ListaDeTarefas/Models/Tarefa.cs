using System.Diagnostics.CodeAnalysis;

namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtTarefaFim { get; set; }
        public DateTime DtEncerramento { get; set; }
        public bool Finalizado { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
}
}
