    
namespace Desafio3
{

    public static class Menu
    {
        public static void MostrarOpcao(Machine maquina)
        {
            System.Console.WriteLine($"Machine: {maquina.Name}  |  Price:  {maquina.Price}  | Power/Click: {(int)(maquina.Power)}");
        }

        public static void CheckCoins(Player player, List<Machines> list)
        {
            Console.WriteLine("Digite o Id da maquina: ");
            var maq = Console.Read();
            if (list[maq].Price <= player.Coins)
            {
                
            }

        }
    }
}