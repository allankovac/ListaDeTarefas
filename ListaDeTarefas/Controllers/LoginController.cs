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
            return RedirectToAction("index", "Login");
        }

        public IActionResult RegistrarUsuario()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListarTarefas", "Tarefa");
            }
            return View(new LoginViewModel
            {
                Usuario = new Usuario()
            });
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(LoginViewModel registroVM)
        {
            var user = new IdentityUser {UserName = registroVM.Usuario.Email, Email = registroVM.Usuario.Email };
            var result = await _userManager.CreateAsync(user, registroVM.Password);

            if (result.Succeeded)
            {
                var usuarioCriado = _usuarioBusiness.CriarUsuario(registroVM.Usuario);

                return RedirectToAction("Index", "Login");
            }
            return View(registroVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            //HttpContext.Session.Clear();
            HttpContext.User = null;

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
