using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace Biblioteca.Models

{
    public class UsuarioService

    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuario.Add(u);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuario.Find(u.Id);
                usuario.Nome = u.Nome;
                usuario.Email = u.Email;
                usuario.Senha = u.Senha;
                bc.SaveChanges();
            }
        }

        public void DeletePost(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuario.Find(id);
                bc.Usuario.Remove(usuario);
                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                query = bc.Usuario;
                return query.OrderBy(u => u.Nome).ToList();
            }
        }

        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.Find(id);
            }
        }
    }
}