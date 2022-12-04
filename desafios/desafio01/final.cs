using System;

Entrada a = new Entrada();
Entrada b = new Entrada();
Entrada c = new Entrada();

EPorta e = new EPorta();
OuPorta ou = new OuPorta();
NotPorta nao = new NotPorta();
 

a.Connect(e);
b.Connect(e);
e.Connect(ou);
c.Connect(ou);
ou.Connect(nao);

a.isOn = true;

b.isOn = false;

c.isOn = false;

Console.WriteLine(nao.Saida);

public abstract class Component
{
    public abstract bool Saida { get; }
    public abstract void Update();

    protected Component Next {get; private set;}

    public void Connect (Component component)
    {
        this.Next = component;
        this.Next.ConnectInput(this);
    }

    public virtual void ConnectInput(Component component) { }
}


public class Entrada : Component
{
    private bool ison = false;
    public bool isOn
    {
        get
        {
            return ison;
        }

        set
        {
            this.ison = value;
            Update();
        }
    }

    public override bool Saida
    {
        get
        {
            return ison;
        }
    }

    public override void Update()
    {
        this.Next.Update();
    }
}

public class EPorta : Component
{
    private Component inputA = null;
    private Component inputB = null;
    private bool value = false;

    public override bool Saida
    {
        get
        {
            return value;
        }
    }

    public override void Update()
    {
        bool newValue = (inputA?.Saida ?? false) && (inputB?.Saida ?? false);
        if (newValue == value)
            return;
        
        value = newValue;
        this.Next?.Update();
    }

    public override void ConnectInput(Component component)
    {
        if (inputA == null)
            inputA = component;
        else if (inputB == null)
            inputB = component;
    }
}

public class OuPorta : Component
{
    private Component inputA = null;
    private Component inputB = null;
    private bool value = false;

    public override bool Saida
    {
        get
        {
            return value;
        }
    }

    public override void Update()
    {
        bool newValue = (inputA?.Saida ?? false) || (inputB?.Saida ?? false);
        if (newValue == value)
            return;
        
        value = newValue;
        this.Next?.Update();
    }

    public override void ConnectInput(Component component)
    {
        if (inputA == null)
            inputA = component;
        else if (inputB == null)
            inputB = component;
    }
}


public class NotPorta : Component
{
    private Component inputA = null;
    private bool value = true;

    public override bool Saida
    {
        get
        {
            return value;
        }
    }

    public override void Update()
    {
        bool newValue = !(inputA?.Saida ?? false);
        if (newValue == value)
            return;
        
        value = newValue;
        this.Next?.Update();
    }

    public override void ConnectInput(Component component)
    {
        if (inputA == null)
            inputA = component;
    }
}



