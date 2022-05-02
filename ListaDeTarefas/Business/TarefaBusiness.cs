using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Business
{
    public class TarefaBusiness : ITarefaBusiness
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        
        public TarefaBusiness(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void CriarTarefa(Tarefa tarefa, string email)
        {
            var usuario = _usuarioRepository.RetornarUsuarioPorEmail(email);
            tarefa.UsuarioId = usuario.Id;
            _tarefaRepository.CriarTarefaNoBd(tarefa);
        }


        public List<Tarefa> ListaTarefa()
        {
            return _tarefaRepository.RetornarTodasAsTarefas();
        }
        public List<Tarefa> ListaTarefasDoUsuario(string email)
        {

            return _usuarioRepository.RetornarUsuarioPorEmail(email).Tarefas;
        }
    }
}
