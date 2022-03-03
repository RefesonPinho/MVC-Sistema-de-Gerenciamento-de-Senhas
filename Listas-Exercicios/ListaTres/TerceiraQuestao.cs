using System;

public class TerceiraQuestao
{
    public static void Main()
    {
        // Crie um programa que leia 10 valores double e salve em um array, depois imprima esses valores

        int Contador;
        double[] Vetor;
        Vetor = new double[10];

        Console.WriteLine("Informe 10 valores");

        for (Contador = 0; Contador < 10; Contador++)
        {
            Console.WriteLine("Informe o " + (Contador + 1) + "º valor: ");
            Vetor[Contador] = Convert.ToDouble(Console.ReadLine());
        }
        Console.WriteLine("Números informados: ");
        foreach (double valores in Vetor)
        {
            Console.WriteLine(valores);
        }
    }
}