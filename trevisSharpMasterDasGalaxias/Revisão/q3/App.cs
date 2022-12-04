using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;

public static class App
{
    public static void Run()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        BluerControl blur = new BluerControl();

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

        form.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };

        PictureBox pb = new PictureBox();
        pb.SizeMode = PictureBoxSizeMode.Zoom;
        pb.Dock = DockStyle.Fill;
        form.Controls.Add(pb);

        form.Load += delegate
        {
            process();
        };

        Application.Run(form);

        void process()
        {
            var back = Image.FromFile("Bosch.jpg") as Bitmap;

            var data = back.LockBits(
                new Rectangle(0, 0, back.Width, back.Height),
                ImageLockMode.ReadWrite, 
                PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* p = (byte*)data.Scan0.ToPointer();

                byte[] tempB = new byte[data.Stride];
                byte[] tempG = new byte[data.Stride];
                byte[] tempR = new byte[data.Stride];

                for (int j = 0; j < data.Height; j++)
                {
                    byte* l = p + j * data.Stride;
                    for (int i = 0; i < 3 * data.Width; i += 3, l += 3)
                    {
                        tempB[i] = l[0];
                        tempG[i] = l[1];
                        tempR[i] = l[2];
                    }

                    blur.ApplyBlur(tempB);
                    blur.ApplyBlur(tempG);
                    blur.ApplyBlur(tempR);

                    l = p + j * data.Stride;
                    for (int i = 0; i < 3 * data.Width; i += 3, l += 3)
                    {
                        l[0] = tempB[i];
                        l[1] = tempG[i];
                        l[2] = tempR[i];
                    }
                }
            }

            back.UnlockBits(data);
            pb.Image = back;
        }
    }
}