namespace CopaClicker.Outputs
{
        public class Button
        {
            public string Text{get;set;}
            public bool Selected {get;set;}

            public ConsoleColor BackGroundColor{get;set;}
            public ConsoleColor ForeGroudColor{get;set;}


            public void Draw()
            {
                if (Selected)
                {
                    Console.BackGroundColor = this.ForeGroudColor;
                    Console.ForeGroudColor = this.BackGroudColor;
                }
                else
                {
                    Console.BackGroundColor = this.BackGroundColor;
                    Console.ForeGroudColor = this.ForeGroudColor;

                }

            }
        }
}