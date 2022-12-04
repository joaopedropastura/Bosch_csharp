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
        Queue<bool> secs = new Queue<bool>();
        float t = 0f;
        int c = 0;
        bool controllerOn = true;

        // Noises
        var seed = DateTime.Now.Millisecond;
        Random rand = new Random(seed);

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
            
            int k = 0;
            foreach (var sec in secs)
            {
                if (sec)
                    g.DrawLine(Pens.Blue, 50 + k * 10f, 50f, 50 + k * 10f, 1050f);
                k++;
            }

            g.DrawRectangle(Pens.Black, 
                50, 50, 1000, 1000);
            for (int i = 0; i < 21; i++)
                g.DrawString((50 * i -500).ToString(),
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
            c++;
            secs.Enqueue(c % 40 == 0);
            
            float x1 = 50 * (float)Math.Cos(40f * Math.PI * t);
            float x2 = 75 * (float)Math.Cos(20f * Math.PI * t);
            float x3 = 100 * (float)Math.Cos(1f * Math.PI * t);
            float x4 = 125 * (float)Math.Cos(0.1f * Math.PI * t);
            float x5 = 150 * (float)Math.Cos(0.05f * Math.PI * t);

            float output = x1 + x2 + x3 + x4 + x5;

            if (controllerOn)
                output = controller.Control(output);
            ins.Enqueue(output + 500);

            if (ins.Count > 100)
                ins.Dequeue();
            if (secs.Count > 100)
                secs.Dequeue();
        }

        Application.Run(form);
    }
}