using System;
using System.Threading.Tasks;
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

public class OParas : Enemy
{
    public override void Build()
    {
        Column = 500;
        Line = 500;
        build(0, 0, 30, 30); 
    }

    public override void Move()
    {
        Line = Line;
        Column = Column;
    }
}

public class ElPalito : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        build(-80, 0, 40, 300);
    }

    public override void Move()
    {
        Line += 3;
        Column++;
    }
}

public class Plat : Enemy
{
    public override void Build()
    {
        Column = 0;
        Line = 0;

        int tam = random(1000);

        build(0,0,tam,40);
        build(tam+90,0,10000,40);
    }

    public override void Move()
    {
        Line += 1;
    }
}

public class Ran : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;

        build(0,0,20,20);
    }

    public override void Move()
    {
        int x_move = (int)(random(3) - random(3));
        int y_move = (int)(random(3) - random(3));
        
        Column += y_move;
        Line += x_move;
    }
}

public class Cais : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;

        build(0,0,10,10);
    }

    public override void Move()
    {
        Line += 30;
    }
}

public class Horizontas : Enemy
{
    public override void Build()
    {
        Column = 0;
        Line = random(1000);

        build(0,0,30,50);
    }

    public int moves = 5;
    public override void Move()
    {

        if (Column >= 2000 && Column < 2005)
        {
            moves = -5;  
            Column = 1999;
        }
        else if (Column >= 0 && Column < 5)
        {
            moves = 5; 
            Column = 6;
        }

        Column += moves;
    }
}

public class Teleportas : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = random(1000);

        build(0,0,30,20);
    }

    public override void Move()
    {
        // F ;_;

        var t = Task.Run(async delegate
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            
            Column = random(1000);
            Line = random(1000);
        });
    }
}