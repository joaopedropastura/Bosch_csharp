using System;
using System.IO;

string nome = string.Empty;
bool premiun = false;
int dia = -1;
// TODO

//Vou completar esta bela obra semana que vem,
//se não for demitido né vai que kkkk
//caracteres úteis: ─│┌┐└┘├┤┬┴┼
Console.WriteLine("┌───┐ ┌───┐");
Console.WriteLine("│┌─┐│ │┌─┐│");
Console.WriteLine("│└─┘│ ││ ││");
Console.WriteLine("│ ┌─┘ ││ ││");
Console.WriteLine("│ └─┐ ││ ││");
Console.WriteLine("│┌─┐│ ││ ││");
Console.WriteLine("│└─┘│ │└─┘│");
Console.WriteLine("└───┘ └───┘");
Console.WriteLine("\t\tTecnologia para a vida");
Console.WriteLine("");
Console.WriteLine("Pressione qualquer tecla para começar...");
Console.ReadKey(true);

while (true)
{
    Console.Clear();
    Console.WriteLine("O que você quer fazer?");
    Console.WriteLine("1 - Cadastrar Novo cliente");
    Console.WriteLine("2 - Ler dados do cliente");
    Console.WriteLine("3 - Cadastrar Novo produto");
    Console.WriteLine("4 - Ler dados do produto");
    Console.WriteLine("5 - Sair");
    int id = int.Parse(Console.ReadLine());
    switch(id)
    {
        case 1:
            Console.Write("Digite o nome do Cliente:");
            nome = Console.ReadLine();

            // TODO

            Cliente cliente = new Cliente(nome, premiun, dia, -1, -1);
            cliente.Save();
            break;
        
        // TODO
    }
}

public class Cliente
{
    public Cliente(string nome, bool premium, int dia, int mes, int ano)
    {
        this.Nome = nome;
        this.Premium = premium;
        this.DiaNascimento = dia;
        this.MesNascimento = mes;
        this.AnoNascimento = ano;
    }

    public string Nome { get; set; }
    public bool Premium { get; set; }
    public int DiaNascimento { get; set; }
    public int MesNascimento { get; set; }
    public int AnoNascimento { get; set; }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Premium);
        writer.WriteLine(this.DiaNascimento);
        writer.WriteLine(this.MesNascimento);
        writer.WriteLine(this.AnoNascimento);

        writer.Close();
    }

    public static Cliente Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();
        bool premiun = bool.Parse(reader.ReadLine());

        // TODO
        
        Cliente cliente = new Cliente(nome, premiun, -1, -1, -1);
        return cliente;
    }
}

public class Produto
{
    // TODO
}