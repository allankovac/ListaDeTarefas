using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;
using System.Globalization;

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
            var tarefa = _usuarioRepository
                .RetornarUsuarioPorEmail(email)?
                .Tarefa;

            if(tarefa != null) 
            {
                return tarefa
                       .Where(t => t.Finalizado == false)
                       .OrderBy(t => t.DtTarefaFim)
                       .ToList();
            }
            

            return new List<Tarefa>();
        }

        public void FinalizarTarefa(int id)
        {
            var tarefa = _tarefaRepository.PesquisarTarefaPeloId(id);
            tarefa.DtEncerramento = DateTime.Now;
            tarefa.Finalizado = true;
           
            _tarefaRepository.AtualizarTarefaNoBd(tarefa);
        }

        public void FinalizarTarefaEmMassa(List<int> listaId)
        {
            foreach (var id in listaId)
            {
                FinalizarTarefa(id);
            }
        }

        public DateTime TryParseDateStringToDateTime(string dataMesAno)
        {
            if (DateTime.TryParseExact(dataMesAno, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;

            return DateTime.Today;
        }
    }
}
