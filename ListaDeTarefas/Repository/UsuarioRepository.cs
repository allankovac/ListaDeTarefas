using ListaDeTarefas.Context;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Usuario RetornarUsuarioPorEmail(string email)
        {
            try
            {
                return _context.Usuarios.Include(u => u.Tarefa).FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
