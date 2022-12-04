using System;
public class LinkedList<Type>
{
    private LinkedListNode<Type> first = null;
    private int count = 0;
    public int Count => count;
    public Type this[int index]
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
    }
    public void Add(Type value)
    {
        if (first == null)
        {
            first = new LinkedListNode<Type>();
            first.Value = value;
            count++;
            return;
        }
        var crr = first;
        while(crr.Next != null)
            crr = crr.Next;
        crr.Next = new LinkedListNode<Type>();
        crr.Next.Value = value;
        count++;
    }

}

public class LinkedListNode<Type>
{
    public Type Value{get;set;}
    public LinkedListNode<Type> Next {get;set;}
}



