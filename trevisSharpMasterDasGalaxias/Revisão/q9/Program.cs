using System.Linq;
using System.Collections.Generic;

App.Run();

public class Pesquisador
{
    public IEnumerable<Colaborador> Search(
        IEnumerable<Colaborador> collab,
        string parametro)
    {
        if (parametro.Length == 0)
            return collab;
        
        var parameters = parametro.Split(" ");
        var yesParams = parameters
            .Where(p => p.Length > 0 && p[0] != '-');
        var noParams = parameters
            .Where(p => p.Length > 0 && p[0] == '-')
            .Select(p => p.Remove(0, 1));
        
        return collab
            .Where(c => yesParams.Count() == 0 ||
                yesParams.Any(p => c.Nome.Contains(p)) ||
                yesParams.Any(p => c.Cargo.Contains(p)) ||
                yesParams.Any(p => c.Edv.Contains(p)) ||
                yesParams.Any(p => c.Setor.Contains(p)))
            .Where(c => 
                !(noParams.Any(p => c.Nome.Contains(p)) ||
                noParams.Any(p => c.Cargo.Contains(p)) ||
                noParams.Any(p => c.Edv.Contains(p)) ||
                noParams.Any(p => c.Setor.Contains(p))));
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