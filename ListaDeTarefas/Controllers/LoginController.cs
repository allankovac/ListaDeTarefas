using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly ISessaoBusiness _sessaoBusiness;

        public LoginController(IUsuarioBusiness usuarioBusiness, ISessaoBusiness sessaoBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
            _sessaoBusiness = sessaoBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var usuarioCadastrado = _usuarioBusiness.UsuarioCadastrado(usuario);
            string idSessao = string.Empty;
            if (usuarioCadastrado != null)
            {
                idSessao =_sessaoBusiness.CriarSessao(usuarioCadastrado);


                return Json(new { sessao = idSessao, usuario = usuarioCadastrado.Id });
            }

            return Json(new { sessao = idSessao, usuario = 0 });
        }
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuario usuario)
        {
            var usuarioCriado = _usuarioBusiness.CriarUsuario(usuario);
            if (usuarioCriado)
            {
                return Redirect("/");
            }

            return View();
        }
    }
}
