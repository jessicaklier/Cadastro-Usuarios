using System.Collections.Generic;
using System.Linq;

namespace Views.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();

        public static IQueryable<Usuario> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }
        static Usuario()
        {
            Usuario.listagem.Add(new Usuario { IdUsuario = 1, Nome = "Jessica", Email = "jhessica@gmail.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 2, Nome = "Terezinha", Email = "terezinha@gmail.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 3, Nome = "Jeferson", Email = "jeferson@gmail.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 4, Nome = "Juliano", Email = "juliano@gmail.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 5, Nome = "Jean", Email = "jean@gmail.com" });

        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if(usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }
        public static void Excluir(int idusuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == idusuario);
            if(usuarioExistente != null)
            {
                Usuario.listagem.Remove(usuarioExistente);
            }
        }
    }
}

