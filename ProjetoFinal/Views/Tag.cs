using System;
using Controllers;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Views
{
    public class TagView
    {
        public static void InserirTag()
        {
            Console.WriteLine("Digita Descrição da Tag:");
            string Descricao = Console.ReadLine();
            
            TagController.InserirTag(
                Descricao
            );
        }

        public static void AlterarTag()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Tag: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Número do C.R.O.: ");
            string Descricao = Console.ReadLine();
            
            TagController.AlterarTag(
                Id,
                Descricao

            );

        }

        public static void ExcluirTag()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Tag: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            TagController.ExcluirTag(
                Id
            );

        }

        internal static void InserirTag(string text)
        {
            throw new NotImplementedException();
        }

        public static void ListarTags()
        {
            foreach (Tag item in TagController.GetTags())
            {
                Console.WriteLine(item);
            }
        }
    }
}