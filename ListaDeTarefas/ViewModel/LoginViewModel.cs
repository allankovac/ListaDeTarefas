using ListaDeTarefas.Models;

namespace ListaDeTarefas.ViewModel
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public Usuario Usuario { get; set; }

        public string statusRetorno { get; set; }
        public string mensagemRetorno { get; set; }
    }
}
