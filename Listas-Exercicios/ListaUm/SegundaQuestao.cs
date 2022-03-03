using System;
					
public class SegundaQuestao
{
	public static void Main()
	{
		
        // Crie um programa que calcule a velocidade média de uma viagem (distancia (km) / tempo (h))
        double Distancia, Tempo, VelocidadeMedia;

        Distancia = 100.0;
        Tempo = 2.5;

        VelocidadeMedia = Distancia / Tempo;

        Console.WriteLine("A velocidade média é: " + VelocidadeMedia + " km/h");

	}
}