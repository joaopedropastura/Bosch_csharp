using System;
using System.Drawing;
using System.Windows.Forms;

Mundo mundo1 = new Mundo();
Mundo mundo2 = new Mundo();
Mundo mundo3 = new Mundo();
Mundo mundo4 = new Mundo();
Mundo mundo5 = new Mundo();
Mundo mundo6 = new Mundo();

for (int i = 0; i < 1000; i++)
    mundo1.AdicionarJogador(new Coolaborador());

for (int i = 0; i < 500; i++)
{
    mundo2.AdicionarJogador(new Coolaborador());
    mundo2.AdicionarJogador(new Trapaceiro());
}

for (int i = 0; i < 750; i++)
    mundo3.AdicionarJogador(new Coolaborador());
for (int i = 0; i < 250; i++)
    mundo3.AdicionarJogador(new Trapaceiro());

for (int i = 0; i < 950; i++)
    mundo4.AdicionarJogador(new Vingativo());
for (int i = 0; i < 50; i++)
    mundo4.AdicionarJogador(new Trapaceiro());

for (int i = 0; i < 250; i++)
{
    mundo5.AdicionarJogador(new Vingativo());
    mundo5.AdicionarJogador(new Trapaceiro());
    mundo5.AdicionarJogador(new Coolaborador());
    mundo5.AdicionarJogador(new Medroso());
}

for (int i = 0; i < 1000; i++)
    mundo6.AdicionarJogador(new Matematico());

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;
form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Timer tm = new Timer();
tm.Interval = 20;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

Bitmap bmp = null;
Graphics g = null;

form.Load += delegate
{
    bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    pb.Image = bmp;
    tm.Start();
};

tm.Tick += delegate
{
    g.Clear(Color.White);

    computarMundo(mundo1, 0);
    computarMundo(mundo2, 300);
    computarMundo(mundo3, 600);
    computarMundo(mundo4, 900);
    computarMundo(mundo5, 1200);
    computarMundo(mundo6, 1500);

    pb.Refresh();
};

void computarMundo(Mundo mundo, int b)
{
    for (int i = 0; i < 100; i++)
        mundo.Jogar();
    g.FillPie(Brushes.LightGreen,
        b + 5, 5, 300, 300, 
        0, mundo.Confianca * 360f);
    g.FillPie(Brushes.Red,
        b + 5, 5, 300, 300, 
        mundo.Confianca * 360f, 
        mundo.Desconfianca * 360f);
    StringFormat sf = new StringFormat();
    sf.Alignment = StringAlignment.Center;
    sf.LineAlignment = StringAlignment.Center;
    g.DrawString(mundo.Total.ToString(),
        SystemFonts.MenuFont,
        Brushes.Black, 
        new RectangleF(b + 5, 305, 300, 50),
        sf);
    int size = bmp.Height - 370;
    float prop = size / 1000000f;

    if (mundo.Total > 1000000)
        g.FillRectangle(Brushes.Yellow, 
            b + 105, 
            360 + size - 1000000 * prop, 100, 
            mundo.Total * prop);
    else
        g.FillRectangle(Brushes.Blue, 
            b + 105, 
            360 + size - mundo.Total * prop, 100, 
            mundo.Total * prop);
}

Application.Run(form);

public abstract class Jogador
{
    public int Moedas { get; set; } = 1;
    public abstract bool Decide();
    public abstract void Recebe(int moedas);
}

public class Mundo
{
    public Mundo()
    {
        for (int i = 0; i < 1000; i++)
            lastResults[i] = 1;
        confianca = 1000;
    }

    int crr = 0;
    Jogador[] jogadores = new Jogador[1000];

    int total = 1000;
    int falidos = 0;

    int lr = 0;
    int[] lastResults = new int[1000];
    int confianca = 0;

    Random rand = new Random();

    public int Total => total;
    public int Falidos => falidos;
    public float Confianca => confianca / 1000f;
    public float Desconfianca => 1f - Confianca;

    public void AdicionarJogador(Jogador jogador)
    {
        jogadores[crr] = jogador;
        crr++;
    }

    public void Jogar()
    {
        if (crr - falidos < 2)
            return;

        (Jogador j1, Jogador j2) t = obterJogadoresAleatorios();

        bool b1 = t.j1.Decide(),
             b2 = t.j2.Decide();
        
        confianca -= lastResults[lr + 1 < 1000 ? lr + 1 : 0];
        if (b1) 
        {
            lastResults[lr] = 1;
            confianca++;
        }
        else lastResults[lr] = 0;
        lr++;
        lr = lr < 1000 ? lr : 0;
            
        confianca -= lastResults[lr + 1 < 1000 ? lr + 1 : 0];
        if (b2)
        {
            lastResults[lr] = 1;
            confianca++;
        }
        else lastResults[lr] = 0;
        lr++;
        lr = lr < 1000 ? lr : 0;

        if (b1 && b2)
        {
            t.j1.Moedas++;
            t.j2.Moedas++;

            t.j1.Recebe(2);
            t.j2.Recebe(2);

            total += 2;
            return;
        }

        if (!b1 && !b2)
        {
            t.j1.Recebe(0);
            t.j2.Recebe(0);
            return;
        }

        // Todo dia um otário e um malandro saem de casa...
        Jogador otario = b1 ? t.j1 : t.j2;
        Jogador malandro = b1 ? t.j2 : t.j1;
        
        otario.Moedas--;
        malandro.Moedas += 4;
        otario.Recebe(0);
        malandro.Recebe(4);

        if (otario.Moedas == 0)
            falidos++;
        total += 3;
    }

    private (Jogador j1, Jogador j2) obterJogadoresAleatorios()
    {
        Jogador j1 = null,
                j2 = null;
        int i1 = 0,
            i2 = 0;
        int len = jogadores.Length;
        do
        {
            i1 = rand.Next(len);
            j1 = jogadores[i1];
        } while ((j1?.Moedas ?? 0) == 0);

        do
        {
            i2 = rand.Next(1, len - 1);
            j2 = jogadores[(i1 + i2) % len];
        } while ((j2?.Moedas ?? 0) == 0);

        return (j1, j2);
    }
}

public class Coolaborador : Jogador
{
    public override bool Decide() => true;

    public override void Recebe(int moedas) { }
}

public class Trapaceiro : Jogador
{
    public override bool Decide() => false;

    public override void Recebe(int moedas) { }
}

public class Medroso : Jogador
{
    bool confiando = true;

    public override bool Decide() => confiando;

    public override void Recebe(int moedas)
    {
        if (moedas == 0)
            confiando = false;
    }
}

public class Vingativo : Jogador
{
    int vingancas = 0;

    public override bool Decide()
    {
        if (vingancas > 0)
        {
            vingancas--;
            return false;
        }
        return true;
    }

    public override void Recebe(int moedas)
    {
        if (moedas == 0)
            vingancas += 3;
    }
}

public class Matematico : Jogador
{
    public override bool Decide()
        => Random.Shared.Next(4) > 0;

    public override void Recebe(int moedas) { }
}