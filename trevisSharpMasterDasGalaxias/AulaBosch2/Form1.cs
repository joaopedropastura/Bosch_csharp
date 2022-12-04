using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AulaBosch2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        KeyDown += delegate
        {
            Application.Exit();
        };

        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Left;
        pb.SizeMode = PictureBoxSizeMode.CenterImage;
        this.Controls.Add(pb);

        PictureBox pbresult = new PictureBox();
        pbresult.Dock = DockStyle.Right;
        pbresult.SizeMode = PictureBoxSizeMode.CenterImage;
        this.Controls.Add(pbresult);

        Bitmap bmp = Image.FromFile("bg.png") as Bitmap;
        Bitmap bmp2 = (Bitmap)bmp.Clone();
        process();
        pbresult.Image = bmp2;

        pb.Image = bmp;

        Load += delegate
        {
            pbresult.Width = Width / 2;
            pb.Width = Width / 2;
        };

        
        void process()
        {
            var data = bmp2.LockBits(
                new Rectangle(0, 0, bmp2.Width, bmp2.Height),
                ImageLockMode.ReadWrite, 
                PixelFormat.Format24bppRgb);
            
            byte[] bytes = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            
            bytes = compressAndDecompress(bytes);

            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);

            bmp2.UnlockBits(data);
        }

        byte[] compressAndDecompress(byte[] bytes)
        {
            var start = DateTime.Now;
            var compressed = compress(bytes);
            bytes = decompress(compressed);
            var end = DateTime.Now;
            MessageBox.Show((end - start).TotalMilliseconds.ToString() + " ms");
            return bytes;
        }

        byte[] compress(byte[] arr)
        {
            byte[] result = new byte[arr.Length / 2];
            for (int i = 0, j = 0; i < result.Length; i++, j += 2)
            {
                result[i] = (byte)((arr[j] & 240) + (arr[j + 1] >> 4));
            }
            return result;
        }

        byte[] decompress(byte[] arr)
        {
            byte[] result = new byte[arr.Length * 2];
            for (int i = 0, j = 0; i < arr.Length; i++, j += 2)
            {
                result[j] = (byte)(arr[i] & 240);
                result[j + 1] = (byte)(arr[i] << 4);
            }
            return result;
        }
    }
}


