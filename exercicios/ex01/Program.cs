Pessoa pessoa = new Pessoa();
Pessoa pessoa2 = new Pessoa();


pessoa.CadPessoa("Joao Pedro", 22);
pessoa2.CadPessoa();

pessoa.ExibirDados();

public class Pessoa
{
    public string Name{get;set;}
    public int Idade {get;set;}

    public virtual void CadPessoa(string name, int idade)
    {
        this.Name = name;
        this.Idade = idade;
    }

    public virtual void CadPessoa()
    {
        Console.WriteLine("Por favor, ensira os parametros de Nome e Idade respectivamente.");
    }
    public virtual void ExibirDados()
    {
        Console.WriteLine($"Nome: {this.Name}\nIdade: {this.Idade}");
    }
}