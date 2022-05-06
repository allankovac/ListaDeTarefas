using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        private readonly ITarefaBusiness _tarefaBusiness;
        public TarefaController(ITarefaBusiness tarefaBusiness)
        {
            _tarefaBusiness = tarefaBusiness;
        }
        [HttpGet]
        public IActionResult ListarTarefas()
        {
            if (User.Identity.IsAuthenticated)
            {
                var tarefas = _tarefaBusiness.ListaTarefasDoUsuario(User.Identity.Name);

                return View(new TarefaViewModel{
                    Tarefas = tarefas
                });
            }
            

            return RedirectToAction("Index", "Login");
        }

        
        [HttpGet]
        public IActionResult ListarTarefasDashBoard()
        {
            if (User.Identity.IsAuthenticated)
            {
                var tarefas = _tarefaBusiness.ListaTarefasDashBoardDoUsuario(User.Identity.Name);

                return View(tarefas);
            }


            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult CriarTarefa(TarefaViewModel TarefaVM)
        {
            try
            {
                var tarefa = TarefaVM.Tarefa;
                tarefa.DtTarefaFim = _tarefaBusiness.TryParseDateStringToDateTime(TarefaVM.Data);
                _tarefaBusiness.CriarTarefa(TarefaVM.Tarefa, User.Identity.Name);
                return Json(new { status = "sucesso", mensagem = "Tarefa cadastrada com sucesso!" });
            } 
            catch (Exception ex)
            {
                return Json(new { status = "erro", mensagem = ex.Message });
            }
            
            
        }

        [HttpPost]
        public IActionResult FinalizarTarefa(int id)
        {

            _tarefaBusiness.FinalizarTarefa(id);
            return Json(new { status = "sucesso", mensagem = "Tarefa finalizada com sucesso!" });
        }

        [HttpPost]
        public IActionResult FinalizarTarefaEmMassa(List<int> listaId)
        {

            _tarefaBusiness.FinalizarTarefaEmMassa(listaId);
            return Json(new { status = "sucesso", mensagem = "Tarefa finalizada com sucesso!" });
        }

    }
}
