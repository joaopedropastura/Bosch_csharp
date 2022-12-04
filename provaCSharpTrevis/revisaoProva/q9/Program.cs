using System.Linq;
using System.Collections.Generic;

App.Run();

public class Pesquisador
{
    public IEnumerable<Colaborador> Search(
        IEnumerable<Colaborador> collab,
        string parametro)
    {
        return collab;
    }
}

public class Colaborador
{
    public Colaborador(string nome, string cargo, string setor, string edv)
    {
        this.Nome = nome;
        this.Cargo = cargo;
        this.Setor = setor;
        this.Edv = edv;
    }

    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Setor { get; set; }
    public string Edv { get; set; }
}