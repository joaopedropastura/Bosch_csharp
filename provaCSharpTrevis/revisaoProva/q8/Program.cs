using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

var X = new Dice6();
float valor = X;
printDistribuition(X);

void printDistribuition(RandomVariable X, float part = 1f, int N = 100000)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
    for (int i = 0; i < N; i++)
    {
        var x = X;
        int p = (int)(X / part);
        if (!dict.ContainsKey(p))
            dict[p] = 0;
        dict[p]++;
    }

    var min = dict.Keys.Min();
    var max = dict.Keys.Max();
    int[] data = new int[max - min + 1];

    foreach (var key in dict)
        data[key.Key - min] = key.Value;

    StringBuilder sb = new StringBuilder();
    foreach (var x in data)
    {
        for (int i = 0; i < x / 500; i++)
            sb.Append("█");
        sb.AppendLine();
    }
    Console.WriteLine(sb);
}

public abstract class RandomVariable
{
    public abstract float Get();

    public RandomVariable Sum(RandomVariable Y)
    {
        throw new NotImplementedException();
    }

    public RandomVariable Subtract(RandomVariable Y)
    {
        throw new NotImplementedException();
    }

    public RandomVariable Times(RandomVariable Y)
    {
        throw new NotImplementedException();
    }

    public RandomVariable Division(RandomVariable Y)
    {
        throw new NotImplementedException();
    }

    public RandomVariable Sample(int size)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        float value = this;
        return value.ToString();
    }
    
    public static implicit operator float(RandomVariable X)
        => X.Get();
    
    public static RandomVariable operator +(RandomVariable X, RandomVariable Y)
        => X.Sum(Y);
    
    public static RandomVariable operator -(RandomVariable X, RandomVariable Y)
        => X.Subtract(Y);
    
    public static RandomVariable operator *(RandomVariable X, RandomVariable Y)
        => X.Times(Y);
    
    public static RandomVariable operator /(RandomVariable X, RandomVariable Y)
        => X.Division(Y);
}

public class Dice6 : RandomVariable
{
    public override float Get()
        => (Random.Shared.Next() % 6) + 1;
}

public class DeathChance : RandomVariable
{
    public override float Get()
    {
        var r = Random.Shared.Next() % 10;
        if (r < 1)
            return 0;
        else if (r < 3)
            return 1;
        else if (r < 6)
            return 2;
        else return 3;
    }
}