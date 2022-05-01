using ListaDeTarefas.Models;

namespace ListaDeTarefas.Repository.Interfaces
{
    public interface ISessaoRepository
    {
        public void CriarSessao(Sessao session);
        public Sessao PesquisaSessaoPeloId(string id);
    }
}
