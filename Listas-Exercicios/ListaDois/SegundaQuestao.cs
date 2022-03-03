using System;

public class SegundaQuestao
{
    public static void Main()
    {
        /* Crie um programa que tenha como entrada as notas de um aluno. Somente se encerrará
        quando for inserida uma nota negativa. Ao final deverá informar a média das notas */

        double Nota = 0.0, Soma = 0.0;
        int QuantNotas = 0;

        do {
            Console.WriteLine("Informe a " + (QuantNotas + 1) + " ª nota do aluno: ");
            Nota = Convert.ToInt32(Console.ReadLine());
            Soma += nota;
            QuantNotas++;
        } while(Nota >= 0);

        Console.WriteLine("A média das notas informadas é: " + ((Soma - Nota)/(QuantNotas-1)));

    }
}