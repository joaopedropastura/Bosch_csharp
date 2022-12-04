namespace CopaClicker.Model.Players;

public class AlefManga : Futebolista
{
    public override double Custo => 10.0;

    public override double Eficiencia => 1.0;

    public override string Nome => "Alef Manga";

    public override bool EstaLiberado(Game game)
        => true;
}