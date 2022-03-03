using System;
					
public class PrimeiraQuestao
{
	public static void Main()
	{   

        // Crie um programa que calcule a média ((nota1 + nota2 + nota3 / 3))
		double NotaUm, NotaDois, NotaTres, Media;

        NotaUm = 8.0;
        NotaDois = 6.5;
        NotaTres = 7.2;

        Media = (NotaUm + NotaDois + NotaTres) / 3;

        Console.WriteLine("A média das notas é: " + Media);

	}
}