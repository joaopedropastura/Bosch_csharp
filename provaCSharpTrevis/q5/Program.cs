using System;
using System.IO;

string nome = string.Empty;
bool premiun = false;
int dia = -1;
int mes = -1;
int ano = -1;
int quant = -1;
float preco;
int menu = 1;


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
            Console.Write("O Cliente é premium?(y/n):");
            premiun = Console.ReadLine() == "y" ? true : false;
            Console.Write("Digite o dia de nascimento: ");
            dia = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o mes de nascimento: ");
            mes = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o ano de nascimento: ");
            ano = Int32.Parse(Console.ReadLine());
            Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
            cliente.Save();
            break;
        
        case 2:
            Console.Write("Digite o nome do cliente: ");
            nome = Console.ReadLine();
            var dadosCliente = Cliente.Load(nome);
            Console.Write($"Nome: {dadosCliente.Nome}\nPremium? {dadosCliente.Premium}\nDia nasciemento: {dadosCliente.DiaNascimento}\nMes nascimento: {dadosCliente.MesNascimento}\nAno nascimento: {dadosCliente.AnoNascimento}");
            while(menu != 0)
                Console.Write("Para voltar digite 0: ");
                menu = int.Parse(Console.ReadLine());
            menu++;
            break;
            
        case 3:
            Console.Write("Digite o nome do produto: ");
            nome = Console.ReadLine();
            Console.Write("Digite o preco unitario de cada produto: ");
            preco = float.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade: ");
            quant = Int32.Parse(Console.ReadLine());
            Produto novoProduto = new Produto(nome, preco, quant);
            novoProduto.Save();
            break;


        case 4:
            Console.Write("Digite o nome do produto: ");
            var dadosProd = Produto.Load(nome);
            nome = Console.ReadLine();
            Console.Write($"Nome: {dadosProd.Nome}\nPreco:  {dadosProd.Preco}\nQuantidade: {dadosProd.Quantidade}");
            while(menu != 0)
                Console.Write("Para voltar digite 0: ");
                menu = int.Parse(Console.ReadLine());
            menu++;
            break;
        // TODO
        case 5:
            Console.Write("Saindo...");
            break;
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
        int dia = int.Parse(reader.ReadLine());
        int mes = int.Parse(reader.ReadLine());
        int ano = int.Parse(reader.ReadLine());

        // TODO
        
        Cliente cliente = new Cliente(nome, premiun,dia,mes, ano);
        return cliente;
        
        
    }
}
public class Produto
{
    public Produto(string nome, float preco, int quant)
    {
        this.Nome = nome;
        this.Preco = preco;
        this.Quantidade = quant;
    }
    public string Nome { get; set; }
    public float Preco { get; set; }
    public int Quantidade { get; set; }
    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Preco);
        writer.WriteLine(this.Quantidade);
        writer.Close();
    }
    public static Produto Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");
        nome = reader.ReadLine();
        float preco = float.Parse(reader.ReadLine());
        int quant = int.Parse(reader.ReadLine());

        // TODO
        
        Produto produto = new Produto(nome, preco, quant);
        return produto;
        
        
    }
}