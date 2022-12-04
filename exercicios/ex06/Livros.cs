public class Livros
{
    private string titulo;

    private int qtPages;
    private int paginasLidas;

    public int VerificaProgresso()
    {
        int porcentagem = this.paginasLidas*100/this.qtPages;
        return porcentagem;
    }
    public string Titulo
    {
        get => titulo;
        set => titulo = value;
    }

    public int QtPages
    {
        get =>qtPages;
        set =>qtPages = value;
    }

    public int PaginasLidas
    {
        get=>paginasLidas;
        set=>paginasLidas = value;
    }


}