using System;

public class QuartaQuestao
{
    public static void Main()
    {
        /* Crie um program aque questione 5 perguntas:
        Telefonou a vítima?/Esteve no local do crime?/Mora perto da vítima?
        Devia para a vítima?/Já trabalhou com a vítima?
        Conforme as Resp sim, deve imprimir a classificação da pessoa que respondeu:

        0-1 - Inocente
        2 - Suspeita
        3-4 - Cumplice
        5 - Assassino */

        Console.WriteLine("Estamos investigando um crime! Responde apenas com 0 - Não ou 1 - Sim");

        int Resp, SomaResp = 0;

        string[] Perguntas =
        {
            "Telefonou a vítima?",
            "Esteve no local do crime?",
            "Mora perto da vítima?",
            "Devia para a vítima?",
            "Já trabalhou com a vítima?"
        };

        foreach (string ValorResp in Perguntas)
        {
            Console.WriteLine(ValorResp);
            Resp = Convert.ToInt32(Console.ReadLine());
            SomaResp += Resp;
        }

        if (SomaResp < 2)
        {
            Console.WriteLine("Inocente");
        }
        else if (SomaResp < 3)
        {
            Console.WriteLine("Suspeito(a)");
        }
        else if (SomaResp < 5)
        {
            Console.WriteLine("Cumplice");
        }
        else
        {
            Console.WriteLine("Assassino(a)");
        }
    }
}