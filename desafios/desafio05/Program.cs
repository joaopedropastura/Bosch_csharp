using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var covidCases = read()
    .Where(c => c.IsCovid);

var letalGroup = covidCases
    .GroupBy(c => c.Doses)
    .Select(g => new {
        qtdDoses = g.Key,
        letalidade = g.Average(c => c.IsDead ? 1.0 : 0.0)
    });

var vacinados = covidCases
    .Where(c => c.Doses > 0);

var gruposVacinais = vacinados
    .Select(x =>
    {
        if (x.Vacina.Contains("BUT"))
            return new {
                vacina = "CORONAVAC",
                caso = x
            };
        

        if (x.Vacina.Contains("ASTRA") || x.Vacina.Contains("OX") || x.Vacina.Contains("FIO" ) )
            return new {
                vacina = "ATRAZENECA",
                caso = x
            };
        
        if (x.Vacina.Contains("ZER"))
            return new {
                vacina = "PFIZER",
                caso = x
            };

        if (x.Vacina.Contains("JAN"))
            return new {
                vacina = "JANSSEN",
                caso = x
            };
        
        return new {
                vacina = "DESCONHECIDO",
                caso = x
            };
    })
    .GroupBy(x => x.vacina)
    .Select(v => new {
        vacina = v.Key,
        vacinados = v.Count(),
        letalidade = v.Where(x => x.caso.IsDead).Count() / v.Count()
    });

// foreach (var lg in letalGroup)
// {
//     Console.WriteLine($"Doses: {lg.qtdDoses}, " + 
//         $"Letalidade: {lg.letalidade}");
// }

foreach (var x in gruposVacinais)
{
    Console.WriteLine(x.vacina);
    Console.WriteLine(x.vacinados);
    Console.WriteLine(x.letalidade);
    Console.WriteLine();
}
// Console.WriteLine(query
//     .Average(c => c.IsDead ? 1.0 : 0.0));

// foreach (var x in query)
// {
//     Console.WriteLine(x);
// }

IEnumerable<CasoCovid> read()
{
    StreamReader reader = new StreamReader("INFLUD21-24-10-2022.csv");

    var firstLine = reader.ReadLine();
    var header = firstLine.Split(';').ToList();
    
    int classfin = header.IndexOf("\"CLASSI_FIN\"");
    int evolucao = header.IndexOf("\"EVOLUCAO\"");

    int dose1 = header.IndexOf("\"DOSE_1_COV\"");
    int dose2 = header.IndexOf("\"DOSE_2_COV\"");

    int lab = header.IndexOf("\"LAB_PR_COV\"");

    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var data = line.Split(';');

        var caso = new CasoCovid();
        caso.IsCovid = data[classfin] == "5";
        caso.IsDead = data[evolucao] == "2";

        int doses = 0;
        if (data[dose1] != "\"\"")
            doses++;
        if (data[dose2] != "\"\"")
            doses++;
        caso.Doses = doses;

        caso.Vacina = data[lab];

        yield return caso;
    }

    reader.Close();
}

public class CasoCovid
{
    public bool IsCovid { get; set; }
    public bool IsDead { get; set; }
    public int Doses { get; set; }
    public string Vacina { get; set; }

    public override string ToString()
        => $"{IsCovid} {IsDead} {Doses}";
}