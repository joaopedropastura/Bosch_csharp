using System;
using System.Collections.Generic;

public static class MyExtensionMethods
{
    public static double Sqrt(this double x)
    {
        return Math.Sqrt(x);
    }
    public static List<Type> Take<Type>(this List<Type> list, int N)
    {
        List<Type> result = new List<Type>();
        for(int i = 0; i < N && i < list.Count; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static List<Type> Skip<Type>(this List<Type> list, int N)
    {
        List<Type> result = new List<Type>();
        for(int i = N; i < list.Count; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static List<string> ToStringList<Type>(this List<Type> list)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(list[i] ?.ToString() ?? "");
        }
        return result;
    }
    public static string Concat(this List<string> list)
    {
        string result = "";
        for (int i = 0; i < list.Count; i++)
            result += list[i];
        return result;
    }
    public static void Print<Type>(this Type obj)
    {
        Console.WriteLine(obj);
    }
}




