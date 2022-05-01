using ListaDeTarefas.Context;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Repository
{
    public class SessaoRepository : ISessaoRepository
    {
        private AppDbContext _context;

        public SessaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CriarSessao(Sessao session)
        {
            _context.Sessoes.Add(session);
            _context.SaveChanges();
        }

        public Sessao PesquisaSessaoPeloId(string id)
        {
            return _context.Sessoes.FirstOrDefault(s => s.Id == id);
        }
    }
}
