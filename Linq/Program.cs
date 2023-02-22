
using System.Collections.Generic;
using System;
var estoque = new List<Produto>()
{
    new Produto("Arroz", 10.0, new DateTime(2023, 12, 31)),
    new Produto("Feijão", 8.0, new DateTime(2023, 6, 30)),
    new Produto("Azeite", 20.0, new DateTime(2025, 2, 28)),
    new Produto("Sal", 2.0, new DateTime(2024, 10, 31)),
    new Produto("Açúcar", 5.0, new DateTime(2023, 8, 31)),
    new Produto("Café", 7.5, new DateTime(2022, 12, 31)),
    new Produto("Leite", 3.5, new DateTime(2023, 4, 30)),
    new Produto("Pão", 4.0, new DateTime(2022, 11, 30)),
    new Produto("Queijo", 15.0, new DateTime(2022, 10, 31)),
    new Produto("Presunto", 12.0, new DateTime(2022, 11, 30)),
    new Produto("Manteiga", 8.5, new DateTime(2023, 1, 31)),
    new Produto("Achocolatado", 6.0, new DateTime(2024, 5, 31)),
    new Produto("Refrigerante", 4.5, new DateTime(2023, 7, 31)),
    new Produto("Suco", 3.5, new DateTime(2023, 3, 31)),
    new Produto("Água", 2.0, new DateTime(2024, 2, 29)),
    new Produto("Carne", 25.0, new DateTime(2023, 2, 28)),
    new Produto("Frango", 15.0, new DateTime(2023, 1, 31)),
    new Produto("Peixe", 20.0, new DateTime(2022, 12, 31)),
    new Produto("Batata", 2.5, new DateTime(2022, 10, 31)),
    new Produto("Cebola", 3.0, new DateTime(2023, 3, 31)),
    new Produto("Alho", 2.0, new DateTime(2022, 11, 30)),
    new Produto("Tomate", 3.5, new DateTime(2023, 1, 28)),
    new Produto("Cenoura", 2.5, new DateTime(2023, 1, 31)),
    new Produto("Abóbora", 4.0, new DateTime(2024, 4, 30)),
    new Produto("Beterraba", 2.5, new DateTime(2023, 2, 19))
};


// 1 -Liste todos os produtos do estoque, do mais barato ao mais caro.


// 2 - Liste os produtos por ordem alfabética.


// 3 - Encontre a média de preço dos produtos, mostre a média, e todos os produtos com o preço acima dela


// 4 - Liste os produtos vencidos


// 5 - Implemente uma função que receba a lista de estoque e uma data utilizando o tipo DateTime, 
// esta função deve retornar uma lista que contendo todos os produtos que irão expirar até esta data
// Ex: WillExpirate(List<estoque> estoque, DateTime dataDesejada) { }


// 6 - Implemente uma função chamada valorMínimo, que tenha como parâmetro a lista de estoque e o valor mínimo
// que a lista deve filtrar, utilize o LINQ para retornar todos os valores acima do valorMínimo
// Ex: getByMinValue(List<estoque> estoque, double minValue)


// 7 - Assim como no exercício 6, implemente agora uma função que pegue todos os valores menores que o valor máximo
// Ex: getByMaxValue(List<estoque> estoque, double maxValue)

var result = estoque
    .Where(p => p.Valor >= 10)
    .Select( p => {
        if (p.Nome.Any(l => l == 'a'))
            return new {Nome = p.Nome, Data = p.DataValidade};
        return new { Nome = "Sla", Data = new DateTime()};
    });


foreach (var item in result)
{
    System.Console.WriteLine(result);
}

public class Produto
{
    public string Nome { get; set; }
    public double Valor { get; set; }

    public DateTime DataValidade { get; set; }

    public Produto(string nome, double valor, DateTime validade)
    {
        Nome = nome;
        Valor = valor;
        this.DataValidade = validade;
    }

    public override string ToString()
    {
        return Nome + " - R$ " + Valor;
    }
}

