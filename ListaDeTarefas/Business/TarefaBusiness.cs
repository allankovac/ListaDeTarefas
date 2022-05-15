using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;
using ListaDeTarefas.ViewModel;
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
            if (tarefa.Titulo == null || tarefa.DtTarefaFim == null)
            {
                throw new Exception("Campo obrigatório não preenchido");
            }
            if (email == null)
            {
                throw new Exception("Erro inesperado.");
            }
            var usuario = _usuarioRepository.RetornarUsuarioPorEmail(email);
            if (usuario != null)
            {
                tarefa.UsuarioId = usuario.Id;
                _tarefaRepository.CriarTarefaNoBd(tarefa);
            }
            else
            {
                throw new Exception("Erro inesperado.");
            }

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

            if (tarefa != null)
            {
                return tarefa
                       .Where(t => t.Finalizado == false)
                       .OrderBy(t => t.DtTarefaFim)
                       .ToList();
            }


            return new List<Tarefa>();
        }

        public TarefaViewModel ListaTarefasDashBoardDoUsuario(string email)
        {
            var tarefa = _usuarioRepository
                .RetornarUsuarioPorEmail(email)?
                .Tarefa;

            var tarefaVM = new TarefaViewModel
            {
                TarefasFinalizadas = tarefa
                                    .Where(t => t.Finalizado == true)
                                   .OrderBy(t => t.DtTarefaFim)
                                   .ToList(),
                TarefasNaoFinalizadas = tarefa
                                    .Where(t => t.Finalizado == false)
                                   .OrderBy(t => t.DtTarefaFim)
                                   .ToList()
            };
            CountFinalizados(tarefaVM);
            CountEmAberto(tarefaVM);

            return tarefaVM;

        }

        private void CountFinalizados(TarefaViewModel tarefa)
        {
            tarefa.TotalFinalizadoTotal = tarefa.TarefasFinalizadas.Count();
            tarefa.TotalFinalizadoAntes = tarefa.TarefasFinalizadas.Count(t => t.DtEncerramento.Date <= t.DtTarefaFim.Date);
            tarefa.TotalFinalizadoDepois = tarefa.TarefasFinalizadas.Count(t => t.DtEncerramento.Date > t.DtTarefaFim.Date);
        }

        private void CountEmAberto(TarefaViewModel tarefa)
        {
            var data = DateTime.Now.Date;
            tarefa.TotalEmAbertoTotal = tarefa.TarefasNaoFinalizadas.Count();
            tarefa.TotalEmAbertoAntes = tarefa.TarefasNaoFinalizadas.Count(t => data <= t.DtTarefaFim);
            tarefa.TotalEmAbertoDepois = tarefa.TarefasNaoFinalizadas.Count(t => data > t.DtTarefaFim);
        }

        public void FinalizarTarefa(int id)
        {
            var tarefa = _tarefaRepository.PesquisarTarefaPeloId(id);
            tarefa.DtEncerramento = DateTime.Now;
            tarefa.Finalizado = true;

            _tarefaRepository.AtualizarTarefaNoBd(tarefa);
        }

        public void RestaurarTarefa(int id)
        {
            var tarefa = _tarefaRepository.PesquisarTarefaPeloId(id);
            tarefa.Finalizado = false;

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
