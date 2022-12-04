class Program
{
    static void Main(string[] args)
    {
        Livros livroFavorito = new Livros();
        Livros novoLivro = new Livros();


        Console.Write("Digite o nome do livro: ");
        novoLivro.Titulo = Console.ReadLine();
        Console.Write("Digite a quantidade de paginas total do livro: ");
        novoLivro.QtPages = Int32.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade de páginas ja lidas: ");
        novoLivro.PaginasLidas = Int32.Parse(Console.ReadLine());


        Console.WriteLine($"Ainda faltam {novoLivro.QtPages - novoLivro.PaginasLidas} paginas.\nProgresso: % {novoLivro.VerificaProgresso()}");
    }
}