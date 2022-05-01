using ListaDeTarefas.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class SessaoController : Controller
    {
        private readonly ISessaoBusiness _sessaoBusiness;

        public SessaoController(ISessaoBusiness sessaoBusiness)
        {
            _sessaoBusiness = sessaoBusiness;
        }

        [HttpPost]
        public IActionResult ValidarSessao(string id)
        {
            var sessao = _sessaoBusiness.ValidarSessao(id);
            if (sessao != null)
            {
                return Json(new { valido = true, Usuario = sessao.UsuarioId});
            }

            return Json(new { valido = false, Usuario = 0 });
        }
    }
}
