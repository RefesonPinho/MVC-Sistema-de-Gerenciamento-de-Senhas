using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Views;

namespace Controllers
{
    public class CategoriaController 
    {
        public static Categoria InserirCategoria(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Descrição inválida");
            }

             if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }
           
            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria Categoria = GetCategoria(Id);
            
            string altNome = !String.IsNullOrEmpty(Nome) ? Nome : Categoria.Nome ;
            string altDescricao = !String.IsNullOrEmpty(Descricao) ? Descricao : Categoria.Descricao ;

            Categoria.AlterarCategoria(Id, altNome, altDescricao);

            return Categoria;
        }

        public static Categoria ExcluirCategoria(
            int Id
        )
        {
            Categoria Categoria = GetCategoria(Id);
            Categoria.RemoverCategoria(Categoria);
            return Categoria;
        }

        public static IEnumerable<Categoria> GetCategorias()
        {
            return Categoria.GetCategorias();
        }

        public static Categoria GetCategoria(int Id)
        {
            Categoria categoria = (
                from Categoria in Categoria.GetCategorias()
                    where Categoria.Id == Id
                    select Categoria
            ).First();

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return categoria;
        }
    }
}