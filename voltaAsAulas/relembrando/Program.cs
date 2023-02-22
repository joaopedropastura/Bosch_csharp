using System;
using System.Collections.Generic;

Stack<int> novaStack = new Stack<int>();
Stack2<int> novaStack2 = new Stack2<int>();
novaStack2.Push(1);
novaStack2.Push(3);
novaStack2.Push(1);
novaStack2.Push(4);
novaStack2.Push(1);
novaStack2.Push(6);


novaStack.Push(1);
novaStack.Push(3);
novaStack.Push(1);
novaStack.Push(4);
novaStack.Push(1);
novaStack.Push(6);

System.Console.WriteLine(novaStack.Size());

System.Console.WriteLine(novaStack2);
public class Stack<T>
{
    public List<T> list = new List<T>();

    public void Push(T i)
    {
        list.Add(i);   
    }
    public void Pop(T i)
    {
        list.RemoveAt(list.Count - 1);
    }
    public bool IsEmpty() => list.Count > 0 ? false : true;
    public double Size() => list.Count;
    public void Clear()
    {
        list.Clear();
    }

    public override string ToString()
    {
        var str = "";
        for (int i = list.Count - 1; i > 0 ; i--)
        {  
           str += $"{i} - [{list[i]}]\n"; 
        }
        return str;
    }
}




// correcao 


public class Stack2<T>
{
    private T[] stack = new T[10];
    private int top = -1;

    public void Push(T i)
    {
        top++;
        stack[top] = i;
    }
    public void Pop(T i)
    {
        if (top > 0)
            return;
        stack[top] = default(T);
        top--;
    }
    public bool IsEmpty() 
    {
        return top < 0;
    }
    public double Size()
    {
        return top++;
    }
    public void Clear()
    {
        for (int i = 0; i < stack.Count(); i++)
        {
            stack[i] = default(T);

        }
        top = -1;
    }

    public override string ToString()
    {
        var str = "";
        for (int i = top - 1; i >= 0 ; i--)
        {  
           str += $"{i} - [{stack[i]}]\n";
        }
        return str;
    }
}