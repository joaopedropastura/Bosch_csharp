using MinhaBiblioteca.MinhaSubblibioteca;
using MinhaOutraBiblioteca;

MinhaClasse x = new MinhaClasse();
MinhaOutraClasse y = new MinhaOutraClasse();

for (int i = 0; i < int.Parse(args[1]); i++)
    Console.WriteLine(args[0]);

Vacinas vacina = Vacinas.Pfizer;

if (vacina == Vacinas.Pfizer)
{
    
}

switch (vacina)
{
    case Vacinas.Pfizer:
        break;
    case Vacinas.Coronavac:
        break;
    default:
        break;
}

Key key = Key.Ctrl | Key.C;

if ((key & Key.C) == Key.C)
{

}

public enum Key
{
    Alt = 1,
    Ctrl = 2,
    A = 4,
    B = 8,
    C = 16,
    D = 32,
    N0 = 64,
    N1 = 128,
}

public enum Vacinas : byte
{
    Coronavac,
    Astazeneca,
    Pfizer,
    Janssen
}

public enum Anchor
{
    Left = 1,
    Right = 2,
    Down = 4,
    Top = 8,
    Fill = 15
}