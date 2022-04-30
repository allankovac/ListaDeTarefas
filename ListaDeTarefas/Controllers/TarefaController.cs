using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaBusiness _tarefaBusiness;

        public TarefaController(ITarefaBusiness tarefaBusiness)
        {
            _tarefaBusiness = tarefaBusiness;
        }

        public IActionResult Index()
        {
            var tarefa = new TarefaViewModel
            {
                Tarefas = _tarefaBusiness.ListaTarefa()
            };
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _tarefaBusiness.CriarTarefa(tarefa);
            return View();
        }
    }
}
