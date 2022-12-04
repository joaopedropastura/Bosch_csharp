namespace CopaClicker.Model.Players;

public class Neymar : Futebolista
{
    public override double Custo => 100.0;

    public override double Eficiencia => 10.0;

    public override string Nome => "Menino Ney";

    private bool liberado = false;
    public override bool EstaLiberado(Game game)
    {
        if (game.Gols > 50.0)
            liberado = true;
        return liberado;
    }
}