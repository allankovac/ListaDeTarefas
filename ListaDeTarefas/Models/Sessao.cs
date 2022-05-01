namespace ListaDeTarefas.Models
{
    public class Sessao
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
