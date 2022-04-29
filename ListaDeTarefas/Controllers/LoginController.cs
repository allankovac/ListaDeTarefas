using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public LoginController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Index()
        {
            return View(new Usuario());
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
