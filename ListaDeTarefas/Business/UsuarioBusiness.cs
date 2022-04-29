using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;

namespace ListaDeTarefas.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public bool CriarUsuario(Usuario usuario)
        {
            bool criadoComSucesso = false;
            try
            {
                var emailCadastrado = _usuarioRepository.RetornarUsuarioPorEmail(usuario.Email);
                if (emailCadastrado == null)
                {
                    _usuarioRepository.CadastrarUsuario(usuario);
                    criadoComSucesso = true;
                }

                return criadoComSucesso;
            }
            catch (Exception e)
            {
                return criadoComSucesso;
            }
        }

        public bool UsuarioCadastrado(Usuario usuario)
        {
            var usuarioDb = _usuarioRepository.RetornarUsuarioPorEmail(usuario.Email);

            if (usuarioDb.Senha == usuario.Senha)
                return true;

            return false;
        }
    }
}
