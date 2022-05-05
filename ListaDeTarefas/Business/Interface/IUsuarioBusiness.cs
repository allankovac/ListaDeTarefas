using ListaDeTarefas.Models;
using ListaDeTarefas.ViewModel;

namespace ListaDeTarefas.Business.Interface
{
    public interface IUsuarioBusiness
    {
        bool CriarUsuario(Usuario usuario);

        void validarDadosRegistro(LoginViewModel registroVM);
    }
}
