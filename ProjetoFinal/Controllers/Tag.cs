using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Views;

namespace Controllers
{
    public class TagController 
    {
        public static Tag InserirTag(
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Nome inválido");
            }
           
            return new Tag(Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag Tag = GetTag(Id);
            
            string altDescricao = !String.IsNullOrEmpty(Descricao) ? Descricao : Tag.Descricao ;

            Tag.AlterarTag(Id, altDescricao);

            return Tag;
        }

        public static Tag ExcluirTag(
            int Id
        )
        {
            Tag Tag = GetTag(Id);
            Tag.RemoverTag(Tag);
            return Tag;
        }

        public static IEnumerable<Tag> GetTags()
        {
            return Tag.GetTags();
        }

        public static Tag GetTag(int Id)
        {
            Tag tag = (
                from Tag in Tag.GetTags()
                    where Tag.Id == Id
                    select Tag
            ).First();

            if (tag == null)
            {
                throw new Exception("Tag não encontrado");
            }

            return tag;
        }

        internal static void InserirTag(TagInsert textDescricao)
        {
            throw new NotImplementedException();
        }
    }
}