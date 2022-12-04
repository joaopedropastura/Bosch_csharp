using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    static int N = 8;
    static int tx = Random.Shared.Next(0, N);
    static int ty = Random.Shared.Next(0, N);

    public static void Run()
    {
        Controller controller = new Controller();

        long current = 1 << 24;

        ApplicationConfiguration.Initialize();

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

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
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            tm.Start();
        };

        int tick = 0;
        tm.Tick += delegate
        {
            g.Clear(Color.White);
            tick++;

            if (tick % 5 == 0)
            {
                int move = findBest(current);
                if (move == 0)
                {
                    tx = Random.Shared.Next(0, N);
                    ty = Random.Shared.Next(0, N);
                }
                else current = controller.GetNext(current, move);
            }

            int x = 0;
            int y = 0;
            long crr = current;
            int index = 0;
            while (crr % 2 == 0)
            {
                crr >>= 1;
                index++;
            }
            x = index % N;
            y = index / N;

            int size = 600;
            int startw = pb.Width / 2 - size / 2;
            int starth = pb.Height / 2 - size / 2;
            int quadsize = size / N - 10;

            g.FillRectangle(Brushes.Brown, 
                startw, starth, size, size);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    g.FillRectangle(Brushes.Coral, 
                        startw + i * (quadsize + 10) + 5,
                        starth + j * (quadsize + 10) + 5,
                        quadsize,
                        quadsize);
                    
                    if (x == tx && y == ty && i == x && j == y)
                    {
                        g.FillEllipse(Brushes.Yellow, 
                            startw + i * (quadsize + 10) + 10,
                            starth + j * (quadsize + 10) + 10,
                            quadsize - 10,
                            quadsize - 10);
                    }
                    else if (i == x && j == y)
                    {
                        g.FillEllipse(Brushes.Blue, 
                            startw + i * (quadsize + 10) + 10,
                            starth + j * (quadsize + 10) + 10,
                            quadsize - 10,
                            quadsize - 10);
                    }
                    else if (i == tx && j == ty)
                    {
                        g.FillEllipse(Brushes.Red, 
                            startw + i * (quadsize + 10) + 10,
                            starth + j * (quadsize + 10) + 10,
                            quadsize - 10,
                            quadsize - 10);
                    }
                }
            }
            
            pb.Refresh();
        };

        Application.Run(form);
    }

    private static int findBest(long current)
    {
        int x = 0;
        int y = 0;
        long crr = current;
        int index = 0;
        while (crr % 2 == 0)
        {
            crr >>= 1;
            index++;
        }
        x = index % N;
        y = index / N;

        if (x > tx)
            return 1;
        else if (x < tx)
            return 3;
        else if (y > ty)
            return 2;
        else if (y < ty)
            return 4;
        
        return 0;
    }
}