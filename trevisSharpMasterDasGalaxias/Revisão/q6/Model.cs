public abstract class Enemy : Entity
{
    public int Column { get; set; }
    public int Line { get; set; }

    public abstract void Move();
    public abstract void Build();
}

public class Rock : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        build(0, 0, 40, 40); // Corpo não deslocado do centro original com tamanho 40x40
    }

    public override void Move()
    {
        Line++; //Cai
    }
}

public class TwoRock : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        build(-60, 0, 40, 40); // Corpo deslocado do centro
        build(60, 0, 40, 40); // Outro corpo deslocado na outra direção
    }

    public override void Move()
    {
        Line += 3; //Cai mais rápido
        Column++; //Cai em diagonal
    }
}

public class Teleporte : Enemy
{
    int count = 0;
    public override void Build()
    {
        Column = random(1000);
        Line = random(1000);
        build(0, 0, 40, 40);
    }

    public override void Move()
    {
        count++;
        if (count % 40 != 0)
            return;
        Line = random(1000);
        Column = random(1000);
    }
}

public class Parede : Enemy
{
    int count = 0;
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        int r = random(1000);
        build(r - 700, 0, 1200, 40);
        build(r + 700, 0, 1200, 40);
    }

    public override void Move()
    {
        Line++;
    }
}