using ListaDeTarefas.Models;

namespace ListaDeTarefas.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario usuario);
        Usuario RetornarUsuarioPorEmail(string email);
    }
}
