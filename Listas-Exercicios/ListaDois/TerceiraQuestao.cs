using System;

public class TerceiraQuestao
{
    public static void Main()
    {
        // Crie um programa que receba a altera e o peso e calcule o IMC

        double Altura = 0.0, Peso = 0.0, Imc = 0.0;
        string ResultImc = "";

        Console.WriteLine("Informe sua Altura (em metros): ");
        Altura = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Informe seu Peso (em quilos): ");
        Peso = Convert.ToDouble(Console.ReadLine());

        Imc = Peso / (Altura * Altura);

        if(Imc <= 18.5)
        {
            ResultImc = "abaixo do Peso";
        }
        else if(Imc <= 24.9)
        {
            ResultImc = "no Peso ideal";
        }
        else if(Imc <= 29.9)
        {
            ResultImc = "levemente acima do Peso";
        }
        else if(Imc <= 34.9)
        {
            ResultImc = "na obesidade Grau I";
        }
        else if(Imc <= 39.9)
        {
            ResultImc = "na obesidade Grau II";
        }
        else
        {
            ResultImc = "na obesidade Grau III (mórbida)";
        }

        Console.WriteLine("Seu Imc é: " + Imc + " e você está " + ResultImc);
    }
}