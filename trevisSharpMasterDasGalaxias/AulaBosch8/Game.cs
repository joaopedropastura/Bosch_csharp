namespace CopaClicker.Model;

using Players;

public class Game
{
    private static Game current = new Game();
    public static Game Current => current;

    public static void Reset()
        => current = new Game();

    private Game()
    {
        futebolistas.Add(new AlefManga());
        futebolistas.Add(new Neymar());
    }

    private List<Futebolista> futebolistas = new List<Futebolista>();
    public IEnumerable<Futebolista> Futebolistas => futebolistas;

    public double Gols { get; private set; } = 0;

    public void Chutar()
    {
        this.Gols++;
        foreach (var futebolista in this.futebolistas)
            this.Gols += futebolista.Chutar();
    }

    public void Comprar(int index)
        => futebolistas[index].Comprar(this);

    public void Pagar(double value)
    {
        if (this.Gols < value)
            throw new InvalidOperationException();

        this.Gols -= value;
    }
}