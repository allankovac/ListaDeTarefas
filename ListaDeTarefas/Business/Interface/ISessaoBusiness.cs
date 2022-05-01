using ListaDeTarefas.Models;

namespace ListaDeTarefas.Business.Interface
{
    public interface ISessaoBusiness
    {
        string CriarSessao(Usuario usuario);

        Sessao ValidarSessao(string id);
    }
}
