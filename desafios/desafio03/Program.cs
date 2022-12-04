using System;


namespace Desafio3
{
    public class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione <0> para adicionar moedas     -----     Pressione <1> para abrir o menu");

            Foice foice = new Foice();
            Player player = new Player();
            Impressora impressora = new Impressora();
            List<Machine> machines = new List<Machine>();
            machines.Add(foice);
            machines.Add(impressora);

            

            while(true)
            {
                var tecla = Console.ReadKey().Key;

                if(tecla == ConsoleKey.Escape)
                    break;
                else if(tecla == ConsoleKey.D0)
                {   
                    Console.Clear();
                    Console.WriteLine("Pressione <0> para adicionar moedas     -----     Pressione <1> para abrir o menu");
                    Console.WriteLine($"moedas: {player.Coins * player.Power}");
                }
                else if(tecla == ConsoleKey.D1)
                {
                    Console.Clear();
                    for (int i = 0; i < machines.Count; i++)
                    {
                        Console.Write($"{i+1} - ");
                        Menu.MostrarOpcao(machines[i]);
                    }
                    Console.WriteLine($"moedas: {player.Moedas++}");
                    Menu.CheckCoins(player, List<Machines>);
                }
            }
        }
    }
}

//metodos iteradores
//metodos de extensao
//genericos
//enumerable