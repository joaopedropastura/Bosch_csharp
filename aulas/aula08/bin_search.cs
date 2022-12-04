using System;



public class Tree
{
    public int Index{get;set;}
    public Tree Left{get;set;}
    public Tree Right{get;set;}

    public Tree()
    {
        Right = null;
        Left = null;
    }
    public void Add (int value)
    {
        if (value > this.Index)
        {
            if (Right == null)
            {
                Right = new Tree(); 
                Right.Index = value;
            }
            else
                Right.Add(value);
        }
        else
        {
            if (Left == null)
            {
                Left = new Tree();
                Left.Index = value;
            }
            else
                Left.Add(value);
        }    
            
    }

    public bool Contains(int search)
    {
        if (search == Index)
            return true;
        
        if (search <= Index)
        {
            Left.Contains(Index);
        }
    }

}


