using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    public class PieceData
    {
        public Piece Piece { get; set; }
        public int CurrentIndex { get; set; }
        public int EndIndex { get; set; }
        public float Animation { get; set; }

        public void Update()
        {
            if (CurrentIndex == EndIndex)
                return;
            Animation += 0.02f;
            if (Animation >= 1f)
            {
                CurrentIndex = EndIndex;
                Animation = 0f;
            }
        }

        public void GoTo(int index)
            => EndIndex = index;

        public void Draw(Graphics g, Point start)
        {
            Piece.Draw(g, CurrentIndex, 
                EndIndex, Animation, start);
        }
    }

    public static void Run()
    {
        Controller controller = new Controller();
        ApplicationConfiguration.Initialize();

        Point start = Point.Empty;
        
        Random rand = Random.Shared;
        Bitmap img = Image.FromFile("img.jpg") as Bitmap;
        List<PieceData> pieces = new List<PieceData>();
        for (int i = 0; i < 32 * 18; i++)
        {
            var data = new PieceData();
            data.Piece = new Piece(img, i, data);
            data.CurrentIndex = i;
            data.Animation = 0f;
            data.EndIndex = i;
            pieces.Add(data);
        }
        
        for (int i = 0; i < 32 * 18; i++)
        {
            var j = rand.Next(pieces.Count);
            var p1 = pieces[i];
            var p2 = pieces[(i + j) % pieces.Count];

            var temp = p1.CurrentIndex;
            p1.CurrentIndex = p2.CurrentIndex;
            p2.CurrentIndex = temp;

            p1.EndIndex = p1.CurrentIndex;
            p2.EndIndex = p2.CurrentIndex;
        }

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Fill;
        form.Controls.Add(pb);

        Bitmap bmp = null;
        Graphics g = null;

        Timer tm = new Timer();
        tm.Interval = 40;

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
            start = new Point(pb.Width / 2 - 800,
                pb.Height / 2 - 450);

            controller.Solve(pieces
                .Select(p => p.Piece));
        };

        tm.Tick += delegate
        {
            g.Clear(Color.White);

            foreach (var p in pieces)
            {
                p.Update();
                p.Draw(g, start);
            }
            
            pb.Refresh();
        };

        Application.Run(form);
    }
}

public class Piece
{
    private Bitmap bmp;
    private Rectangle rect;
    private int realIndex;
    private App.PieceData data = null;

    public Piece(Bitmap bmp, int index, App.PieceData data)
    {
        this.bmp = bmp;
        this.realIndex = index;
        int x = index % 32;
        int y = index / 32;
        this.rect = new Rectangle(
            50 * x, 50 * y, 50, 50
        );
        this.data = data;
    }

    public bool ConnectLeft(Piece piece)
        => this.realIndex - piece.realIndex == 1;

    public bool ConnectRight(Piece piece)
        => piece.realIndex - this.realIndex == 1;

    public bool ConnectTop(Piece piece)
        => this.realIndex - piece.realIndex == 32;

    public bool ConnectBottom(Piece piece)
        => piece.realIndex - this.realIndex == 32;

    public bool IsLeftTopPiece()
        => this.realIndex == 0;

    public void SetPosition(int i, int j)
        => data.GoTo(i + 32 * j);

    public void Draw(
        Graphics g, int index, int nextIndex, 
        float p, Point start)
    {
        int x = index % 32;
        int y = index / 32;
        int nx = nextIndex % 32;
        int ny = nextIndex / 32;
        var dest = new RectangleF(
            50 * (x * (1f - p) + nx * p) + start.X, 
            50 * (y * (1f - p) + ny * p) + start.Y,
            50, 50
        );
        g.DrawImage(bmp, dest, this.rect, GraphicsUnit.Pixel);
    }
}