using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Business
{
    public class TarefaBusiness : ITarefaBusiness
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaBusiness(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public void CriarTarefa(Tarefa tarefa)
        {
            _tarefaRepository.CriarTarefaNoBd(tarefa);
        }


        public List<Tarefa> ListaTarefa()
        {
            return _tarefaRepository.RetornarTodasAsTarefas();
        }
        public List<Tarefa> ListaTarefasDoUsuario(int id)
        {
            return _tarefaRepository.RetornarTodasAsTarefasDoUsuario(id);
        }
    }
}
