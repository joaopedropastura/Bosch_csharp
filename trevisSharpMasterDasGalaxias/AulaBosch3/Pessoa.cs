using System;

public class Pessoa
{
    public Pessoa(string nome, string senha)
    {
        this.Nome = nome;
        this.Senha = senha;
    }

    public string Nome { get; set; }
    public decimal Saldo { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Senha { get; set; }
    
    private long cpf; //campo
    public string CPF //propriedade
    {
        get
        {
            return cpf.ToString("000.000.000-00");
        }
        set
        {
            cpf = long.Parse(
                value.Replace(".", "")
                    .Replace("-", ""));
        }
    }
}