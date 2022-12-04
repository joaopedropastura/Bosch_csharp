using System;
using System.Collections;
using System.Collections.Generic;

List<int> list = new List<int>();
list.Add(10);
list.Add(11);
list.Add(12);
list.Add(13);
list.Add(14);
list.Add(15);

list
    .Skip(2)
    .Take(3)
    .ToStringList()
    .Concat()
    .Print();

public class List<T> : IEnumerable<T>
{
    private T[] values = new T[10];
    private int count = 0;

    public T this[int index]
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

    public void Add(T num)
    {
        if (count == values.Length)
        {
            T[] newArr = new T[2 * values.Length];
            for (int i = 0; i < values.Length; i++)
                newArr[i] = values[i];
            this.values = newArr;
        }

        values[count] = num;
        count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return values[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}

public class LinkedList<T>
{
    private LinkedListNode<T> first = null;
    private int count = 0;

    public int Count => count;

    public T this[int index]
    {
        get
        {
            if (first == null)
                throw new IndexOutOfRangeException();
            
            var crr = first;
            for (int i = 0; i < index; i++)
            {
                if (crr.Next == null)
                    throw new IndexOutOfRangeException();
                
                crr = crr.Next;
            }

            return crr.Value;
        }
        set
        {
            if (first == null)
                throw new IndexOutOfRangeException();
            
            var crr = first;
            for (int i = 0; i < index; i++)
            {
                if (crr.Next == null)
                    throw new IndexOutOfRangeException();
                
                crr = crr.Next;
            }

            crr.Value = value;
        }
    }

    public void Add(T value)
    {
        if (first == null)
        {
            first = new LinkedListNode<T>();
            first.Value = value;
            count++;
            return;
        }

        var crr = first;
        while (crr.Next != null)
            crr = crr.Next;
        
        crr.Next = new LinkedListNode<T>();
        crr.Next.Value = value;
        count++;
    }
}

public class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }
}

public class ListIterator<T> : IEnumerator<T>
{
   private List<T> list;
    int index = -1;
    public ListIterator(List<T> list)
    {
        this.list = list;
    }

    public T Current => list[index];

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        index++;
        return index < list.Count;
    }

    public void Reset() => index = -1;
}

public static class MyExtensionMethods
{
    public static double Sqrt(this double x)
    {
        return Math.Sqrt(x);
    }

    public static void Print<T>(this T obj)
    {
        Console.WriteLine(obj);
    }

    public static List<T> Take<T>(this List<T> list, int N)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < N && i < list.Count; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static List<T> Skip<T>(this List<T> list, int N)
    {
        List<T> result = new List<T>();
        for (int i = N; i < list.Count; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static List<string> ToStringList<T>(this List<T> list)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(list[i]?.ToString() ?? "");
        }
        return result;
    }

    public static string Concat(this List<string> list)
    {
        string result = "";
        for (int i = 0; i < list.Count; i++)
        {
            result += list[i];
        }
        return result;
    }
}