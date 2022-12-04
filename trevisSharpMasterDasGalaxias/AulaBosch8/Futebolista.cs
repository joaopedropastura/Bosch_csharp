namespace CopaClicker.Model;

public abstract class Futebolista
{
    public int Quantidade { get; private set; }

    public abstract string Nome { get; }
    public abstract double Custo { get; }
    public abstract double Eficiencia { get; }

    public abstract bool EstaLiberado(Game game);

    public void Comprar(Game game)
    {
        if (game.Gols > this.Custo)
        {
            game.Pagar(this.Custo);
            this.Quantidade++;
        }
    }

    public double Chutar()
        => Quantidade * Eficiencia;
}