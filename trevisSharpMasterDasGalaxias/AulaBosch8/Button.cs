namespace CopaClicker.Outputs;

public class Button
{
    public string Text { get; set; }
    public bool Selected { get; set; } = false;
    public int Width { get; set; } = 50;
    public ConsoleColor BackgroundColor { get; set; }
        = ConsoleColor.Black;
    public ConsoleColor ForegroundColor { get; set; }
        = ConsoleColor.White;

    public void Draw()
    {
        if (Selected)
        {
            Console.BackgroundColor = this.ForegroundColor;
            Console.ForegroundColor = this.BackgroundColor;
        }
        else
        {
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.ForegroundColor;
        }

        string bt = "┌";
        for (int i = 0; i < Width; i++)
            bt += "─";
        bt += "┐\n";

        int k = 0;
        for (k = 0; k + Width < Text.Length; k += Width)
            drawLine(Text.Substring(k, Width));
        drawLine(Text.Substring(k));
        

        bt += "└";
        for (int i = 0; i < Width; i++)
            bt += "─";
        bt += "┘";

        Console.WriteLine(bt);

        void drawLine(string text)
        {        
            int spaces = (Width - text.Length) / 2;
            bt += "│";
            for (int i = 0; i < spaces; i++)
                bt += " ";
            bt += text;
            if ((Width - text.Length) % 2 == 1)
                spaces++;
            for (int i = 0; i < spaces; i++)
                bt += " ";
            bt += "│\n";
        }
    }
}