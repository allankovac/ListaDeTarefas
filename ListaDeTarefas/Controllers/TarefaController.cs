using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
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
            
            return View(new List<Tarefa>());
        }

        public IActionResult CriarTarefa()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _tarefaBusiness.CriarTarefa(tarefa);
            return View();
        }
    }
}
