using ListaDeTarefas.Models;

namespace ListaDeTarefas.Business.Interface
{
    public interface IUsuarioBusiness
    {
        bool CriarUsuario(Usuario usuario);
        Usuario UsuarioCadastrado(Usuario usuario);
    }
}
