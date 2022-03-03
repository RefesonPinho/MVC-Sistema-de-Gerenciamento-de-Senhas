using System;

public class PrimeiraQuestao
{
    public static void Main()
    {
        // Crie um programa que imprima a tabuada de 0 a 10
        Console.WriteLine("Insira o número a ser calculado a tabuada: ");
        int Tabuadanum = Convert.ToInt32(Console.ReadLine());

        for(int Contador = 0; Contador <= 10; Contador++)
        {
            Console.WriteLine(Tabuadanum + " x " + Contador + " = " + (Tabuadanum * Contador));
        }

    }
}