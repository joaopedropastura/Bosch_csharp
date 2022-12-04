using System;
public class Pessoa
{
    public Pessoa(string nome, string senha)
    {
        this.Nome = nome;
        this.Senha = senha;
    }
    public DateTime dataNascimento {get;set;}
    public string Nome {get;set;}
    public string Senha {get;set;}
    public long Cpf {get;set;}
    public decimal Saldo{get;set;} //maneira simplificada e mais utilizada para instanciar uma variavel da classe e utilizar o get/set 
}
//     public DateTime getDataNascimento()
//     {
//         return dataNascimento;
//     }

//     public void setDataNascimento(DateTime value)
//     {
//         dataNascimento = value;
//     }
//     public string getCPF()
//     {
//     return cpf.ToString("000.000.000-00");
//     }

//     public void setCPF(string value)
//     {
//         cpf = long.Parse(value.Replace(".","").Replace("-", ""));
//     }
//     private string criptografar(string s)
//     {
//         return s + "oi kkkk";
//     }
//     public string getSenha()
//     {
//         return senha;
//     }

//     public void setSenha(string value)
//     {

//     }
// }
