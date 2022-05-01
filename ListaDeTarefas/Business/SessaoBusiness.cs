using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;
using ListaDeTarefas.ViewModel;

namespace ListaDeTarefas.Business
{
    public class SessaoBusiness : ISessaoBusiness
    {
        private readonly ISessaoRepository _sessionRepository;


        public SessaoBusiness(ISessaoRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        private string CriaIdUnicoDeSessao()
        {
            return Guid.NewGuid().ToString();
        }

        public string CriarSessao(Usuario usuario)
        {
            var idSessao = CriaIdUnicoDeSessao();

            var sessao = _sessionRepository.PesquisaSessaoPeloId(idSessao);
            if (sessao == null)
            {
                sessao = new Sessao
                {
                    Id = idSessao,
                    UsuarioId = usuario.Id,
                    DataCriacao = DateTime.Now
                };


                _sessionRepository.CriarSessao(sessao);

            }
            return idSessao;
        }

        public Sessao ValidarSessao(string id)
        {
            var sessao = _sessionRepository.PesquisaSessaoPeloId(id);

            if (sessao == null)
            {
                return sessao;
            }

            return sessao;
        }
    }
}
