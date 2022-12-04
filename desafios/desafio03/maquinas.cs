public abstract class Machine
{
    public string Name {get; set;}
    public int Price{get; set;}
    public int Level{get; set;} = 1;
    public double Power {get;set;}

}

public class Foice : Machine
{
    public Foice()
    {
        this.Name = "Foice";
        this.Price = 20 * Level;
        this.Power = Level * 4.329;
    }
}

public class Impressora : Machine
{
    public Impressora()
    {
        this.Name = "Foice";
        this.Price = 3 * Level;
        this.Power = Level * 1.1845;
    }
}


//cirar um jogo clicker onde apertando 0 ele incrementa moedas ao jogo e 1 abre o menu de upgrade de maquinas

//readkey (funcao para ler diretamente a tecla)
//  nome     preco  coins./click   level
//maquina1   $300       +3          #20