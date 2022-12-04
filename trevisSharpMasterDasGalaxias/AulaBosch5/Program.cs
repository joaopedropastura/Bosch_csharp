using System.Collections;

IntList list = new IntList();
list.Add(4);
list.Add(2);
list.Add(1);
foreach (var n in list)
{
    Console.WriteLine(n);
}

public class BigNatural : IComparable, IDisposable
{
    private ulong a;
    private ulong b;

    public int CompareTo(object? obj)
    {
        if (obj == null)
            throw new InvalidOperationException();
        
        if (obj is BigNatural bn)
        {
            if (this.b > bn.b)
                return 1;
            else if (this.b < bn.b)
                return -1;
            else
                return (int)(this.a - bn.a);  
        }
        throw new InvalidOperationException();
    }

    public override string ToString() => 
        b.ToString("00000000000000000000") +
        a.ToString("0000000000000000000");
    
    public static BigNatural Parse(string str)
    {
        int splitCharacter = str.Length - 19;
        if (splitCharacter < 0)
            splitCharacter = 0;
        var parta = str.Substring(splitCharacter, 
            str.Length - splitCharacter);
        var partb = str.Substring(0, splitCharacter);
        
        BigNatural bg = new BigNatural();
        bg.a = ulong.Parse(parta);
        if (partb.Length > 0)
            bg.b = ulong.Parse(partb);
        
        return bg;
    }

    public void Dispose() { }

    public static BigNatural operator +(BigNatural n1, BigNatural n2)
    {
        BigNatural result = new BigNatural();

        result.b = n1.b + n2.b;
        result.a = n1.a + n2.a;

        return result;
    }

    public static implicit operator BigNatural(int i)
    {
        BigNatural n = new BigNatural();
        n.a = (ulong)i;
        return n;
    }

    public static bool operator ==(BigNatural n1, BigNatural n2)
    {
        Console.WriteLine("ENTROU");
        return n1.CompareTo(n2) == 0;
    }

    public static bool operator !=(BigNatural n1, BigNatural n2)
    {
        return n1.CompareTo(n2) != 0;
    }
}

public class IntList : IEnumerable
{
    private int[] values = new int[10];
    private int count = 0;

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return values[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            values[index] = value;
        }
    }

    public int Count => count;

    public void Add(int num)
    {
        if (count == values.Length)
        {
            int[] newArr = new int[2 * values.Length];
            for (int i = 0; i < values.Length; i++)
                newArr[i] = values[i];
            this.values = newArr;
        }

        values[count] = num;
        count++;
    }

    public IEnumerator GetEnumerator()
    {
        IntListIterator it = new IntListIterator(this);
        return it;
    }
}

public class IntListIterator : IEnumerator
{
    private IntList list;
    int index = -1;
    public IntListIterator(IntList list)
    {
        this.list = list;
    }

    public object Current => list[index];

    public bool MoveNext()
    {
        index++;
        return index < list.Count;
    }

    public void Reset() => index = -1;
}