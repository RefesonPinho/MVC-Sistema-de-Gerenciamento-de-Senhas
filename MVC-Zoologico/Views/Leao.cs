using System;
using Controllers;
using Models;

namespace Views
{
    public class LeaoViews
    {
        public static void ProgramaInicial()
        {

            int Opcao = 0;
            do
            {
                Console.WriteLine("1 - Inserir, 2 - Alterar, 3 - Excluir, 4 - Listar");
                Opcao = Convert.ToInt32(Console.ReadLine());
                switch(Opcao)
                {
                    case 1:
                        Console.WriteLine("Inserir Leões\n");
                        Console.Write("Id: ");
                        int Id = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Nome: ");
                        string Nome = Console.ReadLine();

                        Console.Write("Refeições diárias: ");
                        int Alimentacao = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Visitantes diários: ");
                        int Visitantes = Convert.ToInt16(Console.ReadLine());

                        LeaoControllers.InserirLeao(Id, Nome, Alimentacao, Visitantes);
                        break;

                    case 2:
                        Console.WriteLine("Alterar Leões");
                        Console.Write("Id: ");
                        Id = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Nome: ");
                        Nome = Console.ReadLine();

                        Console.Write("Refeições diárias: ");
                        Alimentacao = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Visitantes diários: ");
                        Visitantes = Convert.ToInt16(Console.ReadLine());
                        
                        LeaoControllers.AlterarLeao(Id, Nome, Alimentacao, Visitantes);
                        break;

                    case 3:
                        Console.WriteLine("Excluir Leões");
                        Console.Write("Id de exclusão: ");
                        Id = Convert.ToInt16(Console.ReadLine());

                        LeaoControllers.ExcluirLeao(Id);
                        break;

                    case 4:
                        Console.WriteLine("Mostrar Leões");

                        foreach(Leao leao in LeaoControllers.ListarLeao())
                        {
                            Console.WriteLine(leao);
                        }
                        break;    
                    
                    default:
                        break;
                }
            } while (Opcao != 0);  
        }
    }
}