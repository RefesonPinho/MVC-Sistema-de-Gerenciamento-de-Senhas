using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Views;

namespace Controllers
{
    public class UsuarioController 
    {
        public static Usuario InserirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Descrição inválida");
            }

             if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Descrição inválida");
            }
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Descrição inválida");
            }

            string CryptSenha = BCrypt.Net.BCrypt.HashPassword(Senha);
           
            return new Usuario(Nome,Email, CryptSenha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
             string Email,
            string Senha
        )
        {
            Usuario Usuario = GetUsuario(Id);
            
            string altNome = !String.IsNullOrEmpty(Nome) ? Nome : Usuario.Nome ;
            string altEmail = !String.IsNullOrEmpty(Email) ? Email : Usuario.Email ;
            string altSenha = !String.IsNullOrEmpty(Senha) ? Senha : Usuario.Senha ;

            Usuario.AlterarUsuario(Id, altNome, altEmail, altSenha);

            return Usuario;
        }

        public static Usuario ExcluirUsuario(
            int Id
        )
        {
            Usuario Usuario = GetUsuario(Id);
            Usuario.RemoverUsuario(Usuario);
            return Usuario;
        }

        public static IEnumerable<Usuario> GetUsuarios()
        {
            return Usuario.GetUsuarios();
        }

        public static Usuario GetUsuario(int Id)
        {
            try 
            {
                Usuario usuario = (
                    from Usuario in Usuario.GetUsuarios()
                        where Usuario.Id == Id
                        select Usuario
                ).First();

                if (usuario == null)
                {
                    throw new Exception("Categoria não encontrada");
                }

                return usuario;
            }
            catch
            {
                throw new Exception("Categoria não encontrada");
            }
        }
    }
}