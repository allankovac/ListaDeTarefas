using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;
using ListaDeTarefas.ViewModel;

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
        public void validarDadosRegistro(LoginViewModel registroVM)
        {
            if (registroVM.Usuario != null)
            {
                if (registroVM.Usuario.Email != null)
                {
                    if (EmailValido(registroVM.Usuario.Email))
                    {
                        var usuario = _usuarioRepository.RetornarUsuarioPorEmail(registroVM.Usuario.Email);
                        if (usuario == null)
                        {
                            if (registroVM.Password != null && registroVM.Usuario.Nome != null && registroVM.Usuario.SobreNome != null)
                            {
                                registroVM.statusRetorno = "sucesso";
                            }
                            else
                            {
                                registroVM.statusRetorno = "erro";
                                registroVM.mensagemRetorno = "Campo Obrigatório não preenchido";
                            }
                        } 
                        else
                        {
                            registroVM.statusRetorno = "erro";
                            registroVM.mensagemRetorno = "Email já está em uso";
                        }
                    } else
                    {
                        registroVM.statusRetorno = "erro";
                        registroVM.mensagemRetorno = "Email fora do padrão aceitavel.";
                    }
                }
                else
                {
                    registroVM.statusRetorno = "erro";
                    registroVM.mensagemRetorno = "Campo Obrigatório não preenchido";
                }
            }
            else
            {
                registroVM.statusRetorno = "erro";
                registroVM.mensagemRetorno = "Erro na criação do usuário. Tente novamente mais tarde!";
            }
        }

        static bool EmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
