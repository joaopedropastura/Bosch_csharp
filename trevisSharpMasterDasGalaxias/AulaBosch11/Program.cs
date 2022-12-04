using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var covidCases = read()
    .Where(c => c.IsCovid);

Console.WriteLine(
    $"Média de idade dos pacientes {covidCases.Average(c => c.Idade)}");

// var letalGroup = covidCases
//     .GroupBy(c => c.Doses)
//     .Select(g => new {
//         qtdDoses = g.Key,
//         letalidade = g.Average(c => c.IsDead ? 1.0 : 0.0)
//     });

var vacinados = covidCases
    .Where(c => c.Doses > 0);

var gruposVacinais = vacinados
    .Select(x =>
    {
        if (x.Vacina.Contains("BUT") || x.Vacina.Contains("NAVAC"))
            return new {
                vacina = "CORONAVAC",
                caso = x
            };

        if (x.Vacina.Contains("AST"))
            return new {
                vacina = "ASTRAZENECA",
                caso = x
            };

        if (x.Vacina.Contains("PH") || x.Vacina.Contains("IZER"))
            return new {
                vacina = "PFIZER",
                caso = x
            };

        if (x.Vacina.Contains("JAN") || x.Vacina.Contains("JEN"))
            return new {
                vacina = "JANSSEN",
                caso = x
            };
        
        return new {
                vacina = "DESCONHECIDO",
                caso = x
            };;
    })
    .GroupBy(x => x.vacina)
    .Select(g => new {
        Vacina = g.Key,
        Letalidade = g.Average(c => c.caso.IsDead ? 1.0 : 0.0)
    });

var faixasEtarias = vacinados
    .Select(c =>
    {
        if (c.Idade < 12)
            return new {
                FaixaEtaria = "Criança",
                Caso = c
            };
        
        if (c.Idade < 20)
            return new {
                FaixaEtaria = "Criança Mais velha",
                Caso = c
            };
        
        if (c.Idade < 30)
            return new {
                FaixaEtaria = "Adulto Responsável",
                Caso = c
            };
        
        if (c.Idade < 50)
            return new {
                FaixaEtaria = "Adulto de meia-idade",
                Caso = c
            };
        
        return new {
            FaixaEtaria = "Veio",
            Caso = c
        };
    })
    .GroupBy(c => c.FaixaEtaria)
    .Select(g => new {
        FaixasEtaria = g.Key,
        Letalidade = g.Average(
            x => x.Caso.IsDead ? 1.0 : 0.0)
    });

foreach (var x in faixasEtarias)
{
    Console.WriteLine($"Faixa Etaria: {x.FaixasEtaria}");
    Console.WriteLine($"Letalidade: {x.Letalidade}");
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
    StreamReader reader = new StreamReader("SRAG2021.csv");

    var firstLine = reader.ReadLine();
    var header = firstLine.Split(';').ToList();
    
    int classfin = header.IndexOf("\"CLASSI_FIN\"");
    int evolucao = header.IndexOf("\"EVOLUCAO\"");

    int dose1 = header.IndexOf("\"DOSE_1_COV\"");
    int dose2 = header.IndexOf("\"DOSE_2_COV\"");

    int lab = header.IndexOf("\"LAB_PR_COV\"");

    int idade = header.IndexOf("\"NU_IDADE_N\"");

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

        if (int.TryParse(data[idade], out int i))
        {
            if (i < 0)
                i = -i;
            caso.Idade = i;
        }
        else continue;

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
    public int Idade { get; set; }

    public override string ToString()
        => $"{IsCovid} {IsDead} {Doses}";
}