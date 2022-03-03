using System;
					
public class TerceiraQuestao
{
	public static void Main()
	{
		
        // Crie um programa que teste se um número é primo
        int VerificaNumero = 14, ContPrimo = 0;

        for(int Contador = 2; Contador < VerificaNumero; Contador++)
        {
            if (VerificaNumero % Contador == 0)
            {
                ContPrimo++;
            }
        }

        if(ContPrimo > 0)
        {
            Console.WriteLine("Não é primo");
        }
        else
        {
            Console.WriteLine("É primo");
        }

	}
}