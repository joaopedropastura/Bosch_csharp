using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    public static void Run()
    {
        Controller controller = new Controller();
        Queue<float> ins = new Queue<float>();
        float t = 0f;
        bool controllerOn = true;

        // Noises
        var seed = DateTime.Now.Millisecond;
        Random rand = new Random(seed);
        float noise = 0f;
        int noisePause = 120;

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
            if (e.KeyCode == Keys.Space)
                controllerOn = !controllerOn;
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            tm.Start();
        };

        tm.Tick += delegate
        {
            tick();
            
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 
                50, 50, 1000, 1000);
            for (int i = 0; i < 21; i++)
                g.DrawString((50 * i).ToString(),
                    SystemFonts.CaptionFont,
                    Brushes.Black,
                    new PointF(1050, 1050 - 50 * i));
            
            if (ins.Count < 2)
                return;
            Pen pen = new Pen(Color.Red, 3f);
            g.DrawLines(pen, 
                ins.Select((o, i) => new PointF(
                    50f + 10f * i, 50f + 1000f - o
                )).ToArray());
            
            pb.Refresh();
        };

        void tick()
        {
            t += 0.025f;
            noisePause--;
            noise *= .9f;
            float x = 100 * (float)Math.Cos(Math.PI * t) + 500;
            if (rand.Next() % noisePause < 3)
            {
                noisePause = 120;
                noise += 100 * rand.NextSingle() - 50;
            }

            float minNoise = 20 * rand.NextSingle() - 10;
            float output = x + noise + minNoise;

            if (controllerOn)
                output = controller.Control(output);
            ins.Enqueue(output);

            if (ins.Count > 100)
                ins.Dequeue();
        }

        Application.Run(form);
    }
}