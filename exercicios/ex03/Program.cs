namespace ex03
{
    class Program
    {
        static void Main(string[] args)
        {

            int cat = 0;
            int dog = 0;
            int fish = 0;
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Digite o nome do animal: ");
                var nome = Console.ReadLine();
                Console.Write("Digite o seu tipo: ");
                var tipo = Console.ReadLine();
                Animal animal = new Animal(nome,tipo);  
                Console.WriteLine(animal);
                if (tipo == "cachorro")
                    dog++;
                else if (tipo == "gato")
                    cat++;
                else
                    fish++;
            }
            Console.WriteLine($"\n\n\nGatos: {cat}\nCachorros: {dog}\nPeixes: {fish}");        
        }

    }
}