using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Views;

namespace Controllers
{
    public class SenhaTagController 
    {
        public static SenhaTag InserirSenhaTag(
            int SenhaId,
            int TagId
        )
        {
           
            return new SenhaTag(SenhaId, TagId);
        }


        public static SenhaTag RemoverSenhaTag(
            int Id
        )
        {
            SenhaTag SenhaTag = GetSenhaTag(Id);
            SenhaTag.RemoverSenhaTag(SenhaTag);
            return SenhaTag;
        }

        public static IEnumerable<SenhaTag> GetSenhaTags()
        {
            return SenhaTag.GetSenhaTags();
        }

        public static SenhaTag GetSenhaTag(int Id)
        {
            try 
            {
                SenhaTag senhaTag = (
                    from SenhaTag in SenhaTag.GetSenhaTags()
                        where SenhaTag.Id == Id
                        select SenhaTag
                ).First();

                if (senhaTag == null)
                {
                    throw new Exception("SenhaTag não encontrada");
                }

                return senhaTag;
            }
            catch
            {
                throw new Exception("SenhaTag não encontrada");
            }
        }
    }
}