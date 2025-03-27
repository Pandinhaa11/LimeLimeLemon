using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int tentativas = 0;
        bool acertou = false;

        Console.WriteLine("Bem-vindo ao jogo de adivinhação de números!");
        Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100.");

        while (!acertou)
        {
            Console.Write("Digite seu palpite: ");
            string entrada = Console.ReadLine();
            int palpite;

            if (int.TryParse(entrada, out palpite))
            {
                tentativas++;
                int diferenca = Math.Abs(palpite - numeroSecreto);

                if (palpite == numeroSecreto)
                {
                    acertou = true;
                    Console.WriteLine($"Parabéns! Você acertou o número secreto em {tentativas} tentativas.");
                }
                else
                {
                    if (diferenca <= 5)
                    {
                        Console.WriteLine("Muito perto!");
                    }
                    else if (diferenca <= 10)
                    {
                        Console.WriteLine("Perto!");
                    }
                    else
                    {
                        Console.WriteLine("Longe!");
                    }

                    if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é maior. Tente novamente.");
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é menor. Tente novamente.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }
        }

        Console.WriteLine("O console fechará automaticamente em 10 segundos...");
        await Task.Delay(10000);
    }
}
