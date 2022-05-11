using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Views;

namespace Controllers
{
    public class SenhaController 
    {
        public static Senha InserirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            if (String.IsNullOrEmpty(Url))
            {
                throw new Exception("Url inválida");
            }
            if (String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("Usuario inválida");
            }

            if (String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("Senha inválida");
            }
            if (String.IsNullOrEmpty(Procedimento))
            {
                throw new Exception("Procedimento inválida");
            }

            string CryptSenha = BCrypt.Net.BCrypt.HashPassword(SenhaEncrypt);
           
            return new Senha(Nome, CategoriaId, Url, Usuario, CryptSenha, Procedimento);
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha Senha = GetSenha(Id);
            
            string altNome = !String.IsNullOrEmpty(Nome) ? Nome : Senha.Nome ;
            string altUrl = !String.IsNullOrEmpty(Url) ? Url : Senha.Url ;
            string altUsuario = !String.IsNullOrEmpty(Usuario) ? Usuario : Senha.Usuario ;
            string altSenha = !String.IsNullOrEmpty(SenhaEncrypt) ? SenhaEncrypt : Senha.SenhaEncrypt ;
            string altProcedimento = !String.IsNullOrEmpty(Procedimento) ? Procedimento : Senha.Procedimento ;
            string CryptSenha = BCrypt.Net.BCrypt.HashPassword(altSenha);

            Senha.AlterarSenha(Id, altNome, CategoriaId, altUrl, altUsuario, CryptSenha, altProcedimento);

            return Senha;
        }

        public static Senha ExcluirSenha(
            int Id
        )
        {
            Senha Senha = GetSenha(Id);
            Senha.RemoverSenha(Senha);
            return Senha;
        }

        public static IEnumerable<Senha> GetSenhas()
        {
            return Senha.GetSenhas();
        }

        public static Senha GetSenha(int Id)
        {
            try 
            {
                Senha senha = (
                    from Senha in Senha.GetSenhas()
                        where Senha.Id == Id
                        select Senha
                ).First();

                if (senha == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                return senha;
            }
            catch
            {
                throw new Exception("Senha não encontrado");
            }
        }
    }
}