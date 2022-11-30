using System;

Vetor v = (1, 2);
Vetor u = (4, 3);
Vetor r = (5, 5);

Console.WriteLine($"{v} + {u} = {r}?");

if (v + u == r)
    Console.WriteLine("Sim!");
else Console.WriteLine("Não! (mas devia)");


public class Vetor
{
    public int x {get;set;} 
    public int y{get;set;}
    public Vetor(int[] dados)
    {
        this.x = dados[0];
        this.y = dados[1];
    }

    public bool EIgual(Vetor vetor) => this.x == vetor.x && this.y == vetor.y ? true : false;

    public Vetor Soma(Vetor vetor) => (this.x += vetor.x, this.y += vetor.y);

    public override string ToString()
    {
        return $"({this.x}, {this.y})";
    }

    public static implicit operator Vetor((int, int) tupla)
        => new Vetor(new int[] {
            tupla.Item1, 
            tupla.Item2
        });

    public static implicit operator Vetor((int, int, int) tupla)
        => new Vetor(new int[] {
            tupla.Item1, 
            tupla.Item2,
            tupla.Item3
        });

    public static Vetor operator +(Vetor v, Vetor u)
        => v.Soma(u);

        //como eu comparo o valor v com o u?

    public static bool operator ==(Vetor v, Vetor u)
        => v.EIgual(u);

    public static bool operator !=(Vetor v, Vetor u)
        => !v.EIgual(u);
}
