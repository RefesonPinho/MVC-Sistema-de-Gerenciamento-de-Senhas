using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class LeaoControllers
    {
        public static Leao InserirLeao(
            int id, 
            string nome, 
            int alimentacao, 
            int visitantes
        )
        {
            return new Leao(id, nome, alimentacao, visitantes);
        }

        public static void AlterarLeao(
            int id, 
            string nome, 
            int alimentacao, 
            int visitantes
        )
        { 
            Leao lyonUpdate;

            lyonUpdate = Leao.AlterarLeao(id, nome, alimentacao, visitantes);
        }

        public static Leao ExcluirLeao(int id)
        {
            Leao lyonDelete;
            
            lyonDelete = Leao.ExcluirLeao(id);

            if (lyonDelete == null)
            {
                throw new Exception($"Leão não encontrado");
            }

            return lyonDelete;
        }

        public static List<Leao> ListarLeao()
        {
            return Leao.ListarLeoes();
        }
    }
}