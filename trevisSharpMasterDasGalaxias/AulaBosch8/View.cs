using CopaClicker.Outputs;
using CopaClicker.Model;

public class View
{
    public void Run()
    {
        Game game = Game.Current;
        int selected = 0;
        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Copa Clicker");
            Console.WriteLine($"Gols: {game.Gols}");

            int j = 0;
            foreach (var futebolista in game.Futebolistas)
            {
                if (futebolista.EstaLiberado(game))
                {
                    Button bt = new Button();
                    bt.Text = $"{futebolista.Nome} - {futebolista.Custo}";
                    bt.Selected = j == selected;
                    bt.Draw();
                }
                j++;
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    game.Chutar();
                break;

                case ConsoleKey.UpArrow:
                    selected--;
                    if (selected < 0)
                        selected = j - 1;
                break;
                
                case ConsoleKey.DownArrow:
                    selected++;
                    if (selected >= j)
                        selected = 0;
                break;

                case ConsoleKey.C:
                    game.Comprar(selected);
                break;
            }
        }
    }
}