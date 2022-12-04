using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    static List<Enemy> list = new List<Enemy>();

    public static void Run()
    {
        ApplicationConfiguration.Initialize();

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

        int velocity = 0;
        int player = 200;
        int jump = 0;
        int hig = 0;
        int jumpc = 0;

        Random rand = new Random();

        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Fill;
        form.Controls.Add(pb);

        Bitmap bmp = null;
        Graphics g = null;

        Timer tm = new Timer();
        tm.Interval = 25;

        form.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Left)
            {
                velocity -= 2;
                if (velocity < -10)
                    velocity = -10;
            }
            if (e.KeyCode == Keys.Right)
            {
                velocity += 2;
                if (velocity > 10)
                    velocity = 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (hig == 0 || jumpc < 2)
                {
                    jump += 20;
                    jumpc++;
                }
            }
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            tm.Start();
        };

        List<Enemy> OnScreen = new List<Enemy>();

        tm.Tick += delegate
        {
            player += velocity;
            if (player > bmp.Width)
                player = 0;
            else if (player < 0)
                player = bmp.Width;
            hig += jump;
            jump--;
            if (hig < 0)
            {
                hig = 0;
                jumpc = 0;
                jump = 0;
            }
            if (hig == 0)
            {
                velocity = 9 * velocity / 10;
            }

            if (rand.NextSingle() < 0.05f && list.Count > 0)
            {
                int i = rand.Next() % list.Count;
                if (!OnScreen.Contains(list[i]))
                {
                    OnScreen.Add(list[i]);
                    list[i].Reset();
                    list[i].Build();
                }
            }

            g.Clear(Color.White);

            Rectangle playerRect = new Rectangle(player, bmp.Height - 100 - hig, 40, 100);

            foreach (var x in OnScreen)
            {
                x.Move();
                foreach (var rec in x.Rectangles)
                {
                    Rectangle real = new Rectangle(rec.X + x.Column,
                        rec.Y + x.Line, rec.Width, rec.Height);
                    g.FillRectangle(Brushes.Orange, real);

                    if (real.IntersectsWith(playerRect))
                    {
                        tm.Stop();
                        MessageBox.Show("VOCÊ MORREU :(");
                        Application.Exit();
                    }
                }
            }

            for (int i = 0; i < OnScreen.Count; i++)
            {
                if (OnScreen[i].Line > bmp.Height)
                {
                    OnScreen.RemoveAt(i);
                    i--;
                }
                    
            }

            g.FillRectangle(Brushes.Blue, playerRect);

            pb.Refresh();
        };

        Application.Run(form);
    }

    public static void Add(Enemy enemy)
    {
        list.Add(enemy);
    }
}

public abstract class Entity
{
    static Random rand = new Random();
    public List<Rectangle> Rectangles = new List<Rectangle>();

    protected void build(int x, int y, int wid, int hei)
    {
        this.Rectangles.Add(new Rectangle(x, y, wid, hei));
    }

    public void Reset()
    {
        Rectangles.Clear();
    }

    protected int random(int max)
    {
        return rand.Next(max);
    }
}