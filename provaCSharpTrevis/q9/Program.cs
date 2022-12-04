using System.Linq;
using System.Collections.Generic;
using System;
App.Run();

public class Pesquisador
{
    public IEnumerable<Colaborador> Search(
        IEnumerable<Colaborador> collab,
        string parametro)
    {
        var temp = parametro.Split(' ');

        var df = collab
            .Where(x => x.Nome.Contains(temp[0]));
            





       return df;
        // var it = collab.GetEnumerator();
        // while(it.MoveNext())
        //     if(parametro.Contains(it.Current.Nome))
        //        yield return it.Current;
        //     return it;
        

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