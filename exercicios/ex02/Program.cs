// See https://aka.ms/new-console-template for more information



Retangulo ret = new Retangulo();

ret.CalculaArea(3,3);
ret.ExibirDados();

public class Retangulo
{

    public int Lado1{get;set;}
    public int Lado2{get;set;}

    public int Area{get;set;}
    public virtual void CalculaArea(int l1, int l2)
    {
        this.Lado1 = l1;
        this.Lado2 = l2;

        this.Area = this.Lado1 * this.Lado2;
    }

    public virtual void ExibirDados()
    {
        Console.WriteLine($"Lado 1: {this.Lado1}\nLado 2: {this.Lado2}\nArea:   {this.Area}");
    }
}