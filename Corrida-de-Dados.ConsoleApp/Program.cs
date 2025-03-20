namespace Corrida_de_Dados.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        const int Tabuleiro = 30;

        while (true)
        {
            int posicaoUsuario = 0;
            int posicaoComputador = 0;

            bool jogo = true;

            while (jogo)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("        Jogo dos Dados");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Rodada do Usuário");
                Console.WriteLine("----------------------------------");
                Console.Write("Pressione ENTER para rolar o dado...");
                Console.ReadKey();

                int valordadoDado = SortearDado();

                Console.WriteLine("----------------------------------");
                Console.WriteLine($"O dado foi jogado e caiu no número: {valordadoDado}!");
                Console.WriteLine("----------------------------------");

                posicaoUsuario += valordadoDado;

                Console.WriteLine($"Você está na posição: {posicaoUsuario} de {Tabuleiro}!");

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");

                    posicaoUsuario += 3;

                    Console.WriteLine($"Você avançou para a posição: {posicaoUsuario}!");
                    Console.WriteLine("----------------------------------");
                }

                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Recuo de 2 casas!");

                    posicaoUsuario -= 2;

                    Console.WriteLine($"Você recuou para a posição: {posicaoUsuario}!");
                    Console.WriteLine("----------------------------------");
                }

                else if (posicaoUsuario == 17)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Recuou até o início do jogo!");

                    posicaoUsuario = 0;

                    Console.WriteLine($"Você recuou para o início: {posicaoUsuario}!");
                    Console.WriteLine("----------------------------------");
                }

                else if (posicaoUsuario == 29)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Caiu na casa mistério! Irá para uma casa aleatória");

                    Random geraCasa = new Random();

                    posicaoUsuario = geraCasa.Next(1, 30);

                    Console.WriteLine($"Você caiu na casa: {posicaoUsuario}!");
                    Console.WriteLine("----------------------------------");
                }
                    
                if (posicaoUsuario >= Tabuleiro)
                {
                    Console.WriteLine("Parabéns! Você Venceu!");

                    jogo = false;
                    continue;
                }

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Rodada do Computador");
                Console.WriteLine("----------------------------------");
                Console.Write("Pressione ENTER para visualizar a rodada do computador...");
                Console.ReadKey();

                int resultadoComputador = SortearDado();

                Console.WriteLine("----------------------------------");
                Console.WriteLine($"O dado foi jogado e caiu no número: {resultadoComputador}!");
                Console.WriteLine("----------------------------------");

                posicaoComputador += resultadoComputador;

                Console.WriteLine($"O computador está na posição: {posicaoComputador} de {Tabuleiro}!");

                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");

                    posicaoComputador += 3;

                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"O computador avançou para a posição: {posicaoComputador}!");
                    Console.WriteLine("----------------------------------");
                }

                else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Recuo de 2 casas!");

                    posicaoComputador -= 2;

                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"O computador recuou para a posição: {posicaoComputador}!");
                    Console.WriteLine("----------------------------------");
                }
                else if (posicaoComputador == 17)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Recuou até o início do jogo!");

                    posicaoComputador = 0;

                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"O computador recuou para o início: {posicaoComputador}!");
                    Console.WriteLine("----------------------------------");
                }

                else if (posicaoComputador == 29)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Caiu na casa mistério! Irá para uma casa aleatória");

                    Random geraCasa = new Random();

                    posicaoComputador = geraCasa.Next(1, 30);

                    Console.WriteLine($"Computador caiu na casa: {posicaoComputador}!");
                    Console.WriteLine("----------------------------------");
                }

                if (posicaoComputador >= Tabuleiro)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("O computador venceu, tente novamente!");
                    Console.WriteLine("----------------------------------");

                    jogo = false;
                    continue;
                }
                Console.ReadLine();
            }

            if (Continuar() == "N")
                break;
        }
    }

    static int SortearDado()
    {
        Random geradorDeNumeros = new Random();

        int resultado = geradorDeNumeros.Next(1, 7);

        return resultado;
    }
    static string Continuar() 
    {
        Console.Write("Deseja continuar? (S/N) ");
        string opcaoContinuar = Console.ReadLine()!.ToUpper();
        while (string.IsNullOrWhiteSpace(opcaoContinuar) || opcaoContinuar.ToUpper() != "S" && opcaoContinuar.ToUpper() != "N")
        {
            Console.Write(" -> (X) Opção inválida! Digite novamente: ");
            opcaoContinuar = Console.ReadLine()!;
        }
        return opcaoContinuar.ToUpper();
    }
}

