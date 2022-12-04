namespace pais
{
    class Program
    {
        static void Main(string[] args)
        {
            Pais Joaolandia = new Pais("JPL", "JOAO", 123432, 42343);
            Pais Brasil = new Pais("BRA", "Brasil", 12033, 12343);
            
            Brasil.AddVizinho(Joaolandia);



            Console.WriteLine(Brasil.CheckVizinho(Joaolandia));
        }
    }
}