using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginController(IUsuarioBusiness usuarioBusiness, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _usuarioBusiness = usuarioBusiness;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListarTarefas", "Tarefa");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListarTarefas", "Tarefa");
                }
            }
            return View(loginVM);
        }

        public IActionResult RegistrarUsuario()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListarTarefas", "Tarefa");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(LoginViewModel usuario)
        {
            var user = new IdentityUser {UserName = usuario.Usuario.Email, Email = usuario.Usuario.Email };
            var result = await _userManager.CreateAsync(user, usuario.Password);

            if (result.Succeeded)
            {
                var usuarioCriado = _usuarioBusiness.CriarUsuario(usuario.Usuario);

                return RedirectToAction("Index", "Login");
            }
            return View(usuario);
        }
    }
}
