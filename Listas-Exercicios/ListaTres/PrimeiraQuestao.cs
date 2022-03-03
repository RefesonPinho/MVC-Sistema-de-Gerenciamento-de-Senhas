using System;

public class PrimeiraQuestao
{
    public static void Main()
    {
        // Crie um programa que questione a quantidade de notas a ser informada, receba as notas e calcule a média

        int QuantNotas;
        double Valor, Soma;

        Console.WriteLine("Quantas notas deseja informar?");
        QuantNotas = Convert.ToInt32(Console.ReadLine());

        for(int Contador = 1; Contador <= QuantNotas; Contador++)
        {
            Console.WriteLine("Digite a " + Contador + " ª nota: ");
            Valor = Convert.ToDouble(Console.ReadLine());

            Soma += Valor;
        }
        Console.WriteLine("A média das notas é: " + (Soma/QuantNotas));
    }
}