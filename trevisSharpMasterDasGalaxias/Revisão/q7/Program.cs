using System;

Random rand = new Random(DateTime.Now.Millisecond);

Ponto sortearPonto()
{
    throw new NotImplementedException();
}

public struct Ponto
{
    
}

public abstract class Figura
{
    public abstract bool EstaDentro(Ponto p);
}